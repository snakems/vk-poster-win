using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vk_poster
{
    public partial class CaptchaForm : Form
    {
        public string captchaSid { get; set; }
        public string captchaImg { get; set; }
        public string captchaKey { get; set; }

        public CaptchaForm(string captchaSid, string captchaImg)
        {
            this.captchaSid = captchaSid;
            this.captchaImg = captchaImg;

            InitializeComponent();

            this.pictureBox.Load(this.captchaImg);
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.captchaKey = this.userInput.Text.Trim();
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
