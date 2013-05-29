namespace vk_poster
{
    partial class AuthForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            this.AuthBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // AuthBrowser
            // 
            this.AuthBrowser.AllowWebBrowserDrop = false;
            this.AuthBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AuthBrowser.IsWebBrowserContextMenuEnabled = false;
            this.AuthBrowser.Location = new System.Drawing.Point(0, 0);
            this.AuthBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.AuthBrowser.Name = "AuthBrowser";
            this.AuthBrowser.ScrollBarsEnabled = false;
            this.AuthBrowser.Size = new System.Drawing.Size(719, 613);
            this.AuthBrowser.TabIndex = 0;
            this.AuthBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.AuthBrowser_Navigated);
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 613);
            this.Controls.Add(this.AuthBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Shown += new System.EventHandler(this.LoginWnd_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser AuthBrowser;
    }
}