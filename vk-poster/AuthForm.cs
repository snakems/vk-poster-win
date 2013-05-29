using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Web;

namespace vk_poster
{
    public partial class AuthForm : Form
    {
        public int appId;
        public string permissions;

        public SessionInfo si;
        public bool loginInfoRecieved = false;

        public AuthForm()
        {
            InitializeComponent();

            this.AuthBrowser.ScriptErrorsSuppressed = true;
        }
        
        private void LoginWnd_Shown(object sender, EventArgs e)
        {
            this.AuthBrowser.Navigate(
                "https://oauth.vk.com/authorize?client_id=" + this.appId.ToString() +
                "&scope=" + this.permissions +
                "&redirect_uri=http://oauth.vk.com/blank.html" +
                "&display=page" +
                "&response_type=token"
            );
        }

        private void AuthBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            int hashPos = 0;

            try
            {
                hashPos = e.Url.ToString().IndexOf("#");
            }
            catch (NullReferenceException ex)
            {
                // no cookie, proceed
            }

            if (hashPos > 0)
            {
                string urlParams = e.Url.ToString().Substring(hashPos + 1);

                NameValueCollection h = HttpUtility.ParseQueryString(urlParams);

                if (!String.IsNullOrEmpty(h["error"]))
                {
                    MessageBox.Show(
                        "Ошибка авторизации на сервере \"Вконтакте\": " + h["error_description"]
                        );

                    this.Close();
                }

                if (String.IsNullOrWhiteSpace(h["access_token"]))
                {
                    MessageBox.Show(
                        "Ошибка авторизации на сервере \"Вконтакте\": сервер вернул пустой токен."
                        );

                    this.Close();
                }

                this.si = new SessionInfo();
                this.si.AccessToken = (string)h["access_token"];
                this.si.UserId = Convert.ToInt32(h["user_id"]);
                this.si.ExpiresIn = Convert.ToInt32(h["expires_in"]);

                this.loginInfoRecieved = true;

                this.Close();
            }
        }
    }
}

