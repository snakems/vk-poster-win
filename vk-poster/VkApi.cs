using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

namespace vk_poster
{
    class VkApi
    {
        public int timeout = 15000;
        public int maxTries = 3;
        public int sleepTime = 1000;

        protected string apiUrl = "https://api.vk.com/method/";
        protected string accessToken;

        public VkApi(string accessToken)
        {
            this.accessToken = accessToken;
        }

        // @todo refactor:
        // 1. remove hardcoded GET-request
        // 2. implement factory
        // 3. replace dialogs with events (for example, raise event "onCapthcaRequest" in place of captchaForm.showDialog())
        public T call<T>(string method, NameValueCollection parameters) where T : VkApiResponse
        {
            try
            {
                for (int i = 0; i <= this.maxTries; i++)
                {
                    T apiResponse = this._call<T>(method, parameters);

                    int errorCode = -1;
                    
                    if (apiResponse.error != null)
                    {
                        errorCode = apiResponse.error.error_code;
                    }

                    if (errorCode == 6 && i < this.maxTries)
                    {
                        // 6: Too many requests per second.
                        // need some sleep
                        System.Threading.Thread.Sleep(this.sleepTime);
                    }
                    else if (errorCode == 14 && i < this.maxTries)
                    {
                        // 14: Captcha needed
                        // incoming parameters: captcha_sid, captcha_img
                        // parameters to add to request: captcha_sid=<captcha_sid>&captcha_key=<user_input>

                        CaptchaForm captchaForm = new CaptchaForm(
                            apiResponse.error.captcha_sid,
                            apiResponse.error.captcha_img);

                        captchaForm.ShowDialog();

                        if (
                            !String.IsNullOrWhiteSpace(captchaForm.captchaSid) &&
                            !String.IsNullOrWhiteSpace(captchaForm.captchaKey)
                            )
                        {
                            parameters["captcha_sid"] = captchaForm.captchaSid;
                            parameters["captcha_key"] = captchaForm.captchaKey;
                        }
                    }
                    else
                    {
                        return apiResponse;
                    }
                }

                // just for compiler
                return null;
            }
            catch (Exception ex)
            {
                throw new VkApiException("Неизвестный результат. " + ex.ToString());
            }
        }

        protected T _call<T>(string method, NameValueCollection parameters) where T : VkApiResponse
        {
            string uri = this.apiUrl + method + "?";
            parameters["access_token"] = this.accessToken;
            uri += this.toQueryString(parameters);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.UserAgent = "stpk/0.1a";
            request.Method = "GET";
            request.Timeout = this.timeout;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            if (responseStream == null)
            {
                throw new VkApiException("Сервер \"Вконтакте\" не вернул результат.");
            }
            else
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                T apiResponse = (T)serializer.ReadObject(responseStream);

                return apiResponse;
            }
        }

        protected string toQueryString(NameValueCollection parameters)
        {
            var items = parameters.AllKeys.SelectMany(
                parameters.GetValues,
                (k, v) => k + "=" + Uri.EscapeDataString(v)
                ).ToArray();

            return String.Join("&", items);
        }


        // @todo refactor:
        // 1. replace messageboxes with events
        // 2. split method
        // 3. add flexibility (upload photos to user wall, user album, group wall or group album etc.)
        // 4. improve error handling
        public string uploadAttachments(string [] fileNames, int userId)
        {
            try
            {
                VkApi api = new VkApi(this.accessToken);

                NameValueCollection parameters = new NameValueCollection();
                parameters["aid"] = "174799255"; // @fixme replace with vk-poster service album id
                parameters["save_big"] = "1";

                VkApiResponsePhotosGetUploadServer uploadServerResponse =
                    api.call<VkApiResponsePhotosGetUploadServer>("photos.getUploadServer", parameters);

                // @todo handle error
                if (
                    uploadServerResponse.error != null ||
                    uploadServerResponse.response.upload_url == null)
                {
                    MessageBox.Show("Не удалось получить адрес сервера для загрузки фотографий.");
                    return "";
                }

                string uploadServer = uploadServerResponse.response.upload_url;

                for (int i = 0; i < fileNames.Count(); i++)
                {
                    string fileName = fileNames[i];
                    string fileExt = Path.GetExtension(fileName);

                    try
                    {
                        string contentType = this.GetMimeType(fileExt);
                        Stream resp = this.HttpUploadFile(uploadServer, fileName, "photo", contentType, new NameValueCollection());

                        if (resp == null)
                        {
                            throw new Exception("Сервер вернул пустой ответ.");
                        }

                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(VkApiResponseUploadPhotoAlbum));
                        VkApiResponseUploadPhotoAlbum respUpload = (VkApiResponseUploadPhotoAlbum)serializer.ReadObject(resp);

                        if (
                            respUpload.response.aid == 0 ||
                            respUpload.response.server == null ||
                            respUpload.response.photos_list == null ||
                            respUpload.response.hash == null
                            )
                        {
                            throw new Exception("Недостаточно аргументов в ответе сервера.");
                        }

                        int aid = respUpload.response.aid;
                        string server = respUpload.response.server;
                        string photosList = respUpload.response.photos_list;
                        string hash = respUpload.response.hash;

                        // @todo call photos.save(aid, server, photos_list, hash)
                        
                        // @todo create VkApiResponsePhotosSave:
                        // После успешного выполнения возвращает массив объектов с загруженными фотографиями,
                        // каждый из которых имеет поля id, pid, aid, owner_id, src, src_big, src_small, created.
                        // В случае наличия фотографий в высоком разрешении также будут возвращены адреса с названиями src_xbig и src_xxbig.
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось загрузить файл " + fileName + ". " + ex.ToString());
                    }
                }
            }
            catch (VkApiException ex)
            {
                MessageBox.Show("Ошибка при загрузке файлов: " + ex.ToString());
            }

            return "";
        }

        private IDictionary<string, string> _mimeTypes = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            {".bmp", "image/bmp"},
            {".gif", "image/gif"},
            {".jpeg", "image/jpeg"},
            {".jpg", "image/jpeg"},
            {".png", "image/png"}
        };

        public string GetMimeType(string extension)
        {
            if (extension == null)
            {
                throw new ArgumentNullException("extension");
            }

            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }

            string mime;

            return this._mimeTypes.TryGetValue(extension, out mime) ? mime : "application/octet-stream";
        }

        protected Stream HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();

                return stream2;
            }
            catch (Exception ex)
            {
                // @todo write to log
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }

                throw ex;
            }
            finally
            {
                wr = null;
            }
        }
    }
}
