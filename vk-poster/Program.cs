using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vk_poster
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // @fixme remove hardcode, move to external config
            int appId = 3645275;
            string permissions = "wall,groups";

            VkAuth auth = new VkAuth(appId, permissions);
            PostForm postForm = new PostForm(auth);

            Application.Run(postForm);
        }
    }
}
