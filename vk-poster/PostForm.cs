using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace vk_poster
{
    public partial class PostForm : Form
    {
        protected VkAuth Auth;
        protected VkAuthParams AuthParams;
        protected RuntimeSettings RuntimeSettings;
        protected string RuntimeSettingsFile = ".runtime_settings";
        protected bool FirstTimeFileOk = true;
        protected string ServiceAlbum = "_vk_poster";
        protected int MaxRetries = 3;
        protected int PhotosUploadTimeout = 60;

        private const int INTERNET_OPTION_END_BROWSER_SESSION = 42;

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);


        public PostForm(VkAuth Auth)
        {
            Serializer Serializer = new Serializer();

            this.Auth = Auth;

            try
            {
                this.RuntimeSettings = Serializer.Deserialize<RuntimeSettings>(this.RuntimeSettingsFile);
            } catch (Exception Ex) {
                // @todo write to log
                this.RuntimeSettings = new RuntimeSettings();
            }

            InitializeComponent();

            if (!String.IsNullOrWhiteSpace(this.RuntimeSettings.Groups))
            {
                this.Groups.Text = this.RuntimeSettings.Groups;
                this.ActiveControl = this.Message;
            }
        }

        // @todo refactor:
        // 1. implement background jobs
        // 2. show progress
        // 3. move auth to VkApi
        // 4. create event handlers to communicate between api and application; for example "onCaptchaRequest"
        private void button_post_Click(object sender, EventArgs e)
        {
            // @todo implement background workers to get rid of ui freezes
            // @todo add messages indicating task execution status
            try
            {
                this.AuthParams = this.Auth.getAccessParams();

                // check if access token not recieved
                if (String.IsNullOrWhiteSpace(this.AuthParams.accessToken))
                {
                    this.label_status.Text = "ошибка получения токена";
                    return;
                }

                VkApi api = new VkApi(this.AuthParams.accessToken);
                NameValueCollection parameters = new NameValueCollection();

                parameters["from_group"] = "1";
                parameters["message"] = this.Message.Text;

                if (!String.IsNullOrWhiteSpace(this.Attachments.Text)) {
                    parameters["attachments"] = this.Attachments.Text.Replace(" ", "");
                } else {
                    // parameters["attachments"] = api.uploadAttachments(this.openFileDialog.FileNames, this.AuthParams.userId);
                }

                try
                {
                    Serializer Serializer = new Serializer();
                    this.RuntimeSettings.Groups = this.Groups.Text;
                    Serializer.Serialize(this.RuntimeSettings, this.RuntimeSettingsFile);
                }
                catch (Exception Ex)
                {
                    // @todo write to log
                }

                string [] groups = this.Groups.Text.Split(',');

                foreach (string group in groups)
                {
                    if (group.Trim() != "")
                    {
                        parameters["owner_id"] = "-" + group.Trim().Replace("-", "");
                        VkApiResponseWallPost response = api.call<VkApiResponseWallPost>("wall.post", parameters);

                        if (response.error != null)
                        {
                            int errorCode = response.error.error_code;
                            string errorMsg = response.error.error_msg;

                            MessageBox.Show(
                                "Ошибка при размещении сообщения в группу " + group.Trim() + "\n" +
                                "(" + errorCode + ") " + errorMsg
                                );
                        }
                        
                        // @todo return uri of created post
                        // int postId = response.response.post_id;
                    }
                }

                this.label_status.Text = "выполнено";
            }
            catch (VkAuthException ex)
            {
                this.label_status.Text = "ошибка при выполнении запроса";
                MessageBox.Show(ex.ToString());
            }
            catch (VkApiException ex)
            {
                this.label_status.Text = "ошибка при выполнении запроса";
                MessageBox.Show("Ошибка при работе с API: " + ex.ToString());
            }
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            foreach (string file in this.openFileDialog.FileNames)
            {
                Image img = Image.FromFile(file);
                int thumbWidth = this.imageList.ImageSize.Width;
                int thumbHeight = this.imageList.ImageSize.Height;
                this.imageList.Images.Add(img.GetThumbnailImage(thumbWidth, thumbHeight, null, new IntPtr()));
            }

            if (this.FirstTimeFileOk)
            {
                this.Height += 70;
                this.FirstTimeFileOk = false;
            }

            this.listView.Items.Clear();

            for (int i = 0; i < this.imageList.Images.Count; i++)
            {
                this.listView.Items.Add(new ListViewItem() { ImageIndex = i });
            }

            this.listView.Refresh();
        }

        private void button_select_photos_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
        }

        private void button_clear_photos_Click(object sender, EventArgs e)
        {
            this.imageList.Images.Clear();
            this.listView.Refresh();
        }

        private void button_relogin_Click(object sender, EventArgs e)
        {
            // delete session
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_END_BROWSER_SESSION, IntPtr.Zero, 0);

            // delete cookies
            Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2");

            this.Auth.authorize();
        }
    }
}
