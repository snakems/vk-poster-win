using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace vk_poster
{
    public class VkAuth
    {
        protected int appId;
        protected string permissions;
        protected string sessionFile;
        protected string sessionFileSetter
        {
            set { sessionFile = value; }
            get { return sessionFile; }
        }

        public VkAuth(int appId, string permissions)
        {
            this.appId = appId;
            this.permissions = permissions;
            this.sessionFile = ".session";
        }

        public VkAuthParams getSavedSession()
        {
            try
            {
                Serializer serializer = new Serializer();
                VkAuthParams p = serializer.Deserialize<VkAuthParams>(this.sessionFile);

                // check if session expired
                long now = Unixtime.Now();
                if (p.expiresIn <= now)
                {
                    return new VkAuthParams();
                }

                return p;
            }
            catch (FileNotFoundException)
            {
                return new VkAuthParams();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VkAuthParams getAccessParams()
        {
            VkAuthParams p = new VkAuthParams();

            p = this.getSavedSession();

            if (String.IsNullOrEmpty(p.accessToken))
            {
                p = this.authorize();

                if (p.expiresIn > 0)
                {
                    p.expiresIn += Unixtime.Now();
                }

                this.saveSession(p);
            }
         
            return p;
        }

        public VkAuthParams authorize()
        {
            AuthForm authForm = new AuthForm();

            authForm.appId = this.appId;
            authForm.permissions = this.permissions;
            authForm.ShowDialog();

            if (authForm.loginInfoRecieved)
            {
                VkAuthParams p = new VkAuthParams();

                p.accessToken = authForm.si.AccessToken;
                p.userId = authForm.si.UserId;
                p.expiresIn = authForm.si.ExpiresIn;

                return p;
            }
            else
            {
                return new VkAuthParams();
            }
        }

        public void logout()
        {
            this.saveSession(new VkAuthParams());
        }

        protected void saveSession(VkAuthParams p)
        {
            try
            {
                Serializer serializer = new Serializer();
                serializer.Serialize<VkAuthParams>(p, this.sessionFile);
            }
            catch (Exception ex)
            {
                // @todo handle exception
                throw ex;
            }
        }
    }
}
