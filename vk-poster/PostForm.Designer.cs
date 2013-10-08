namespace vk_poster
{
    partial class PostForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostForm));
            this.button_post = new System.Windows.Forms.Button();
            this.Message = new System.Windows.Forms.TextBox();
            this.label_message = new System.Windows.Forms.Label();
            this.Groups = new System.Windows.Forms.TextBox();
            this.label_groups = new System.Windows.Forms.Label();
            this.label_attachments = new System.Windows.Forms.Label();
            this.Attachments = new System.Windows.Forms.TextBox();
            this.label_sub_attachments = new System.Windows.Forms.Label();
            this.label_sub_groups = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button_select_photos = new System.Windows.Forms.Button();
            this.button_clear_photos = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_attachments_local = new System.Windows.Forms.Label();
            this.button_relogin = new System.Windows.Forms.Button();
            this.label_delay = new System.Windows.Forms.Label();
            this.Delay = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Delay)).BeginInit();
            this.SuspendLayout();
            // 
            // button_post
            // 
            this.button_post.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_post.Location = new System.Drawing.Point(12, 556);
            this.button_post.Name = "button_post";
            this.button_post.Size = new System.Drawing.Size(75, 23);
            this.button_post.TabIndex = 7;
            this.button_post.Text = "Отправить";
            this.button_post.UseVisualStyleBackColor = true;
            this.button_post.Click += new System.EventHandler(this.button_post_Click);
            // 
            // Message
            // 
            this.Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Message.Location = new System.Drawing.Point(12, 99);
            this.Message.Multiline = true;
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(473, 196);
            this.Message.TabIndex = 2;
            // 
            // label_message
            // 
            this.label_message.AutoSize = true;
            this.label_message.Location = new System.Drawing.Point(9, 83);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(65, 13);
            this.label_message.TabIndex = 0;
            this.label_message.Text = "Сообщение";
            // 
            // Groups
            // 
            this.Groups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Groups.Location = new System.Drawing.Point(12, 25);
            this.Groups.Name = "Groups";
            this.Groups.Size = new System.Drawing.Size(323, 20);
            this.Groups.TabIndex = 1;
            // 
            // label_groups
            // 
            this.label_groups.AutoSize = true;
            this.label_groups.Location = new System.Drawing.Point(9, 9);
            this.label_groups.Name = "label_groups";
            this.label_groups.Size = new System.Drawing.Size(44, 13);
            this.label_groups.TabIndex = 0;
            this.label_groups.Text = "Группы";
            // 
            // label_attachments
            // 
            this.label_attachments.AutoSize = true;
            this.label_attachments.Location = new System.Drawing.Point(6, 30);
            this.label_attachments.Name = "label_attachments";
            this.label_attachments.Size = new System.Drawing.Size(134, 13);
            this.label_attachments.TabIndex = 0;
            this.label_attachments.Text = "Из альбома \"Вконтакте\"";
            // 
            // Attachments
            // 
            this.Attachments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Attachments.Location = new System.Drawing.Point(9, 46);
            this.Attachments.Name = "Attachments";
            this.Attachments.Size = new System.Drawing.Size(458, 20);
            this.Attachments.TabIndex = 3;
            // 
            // label_sub_attachments
            // 
            this.label_sub_attachments.AutoSize = true;
            this.label_sub_attachments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_sub_attachments.ForeColor = System.Drawing.Color.DarkGray;
            this.label_sub_attachments.Location = new System.Drawing.Point(6, 69);
            this.label_sub_attachments.Name = "label_sub_attachments";
            this.label_sub_attachments.Size = new System.Drawing.Size(285, 13);
            this.label_sub_attachments.TabIndex = 0;
            this.label_sub_attachments.Text = "photo21137_30348,photo75075_9783,video432524_8295";
            // 
            // label_sub_groups
            // 
            this.label_sub_groups.AutoSize = true;
            this.label_sub_groups.ForeColor = System.Drawing.Color.DarkGray;
            this.label_sub_groups.Location = new System.Drawing.Point(9, 48);
            this.label_sub_groups.Name = "label_sub_groups";
            this.label_sub_groups.Size = new System.Drawing.Size(106, 13);
            this.label_sub_groups.TabIndex = 8;
            this.label_sub_groups.Text = "53681235,53947907";
            // 
            // label_status
            // 
            this.label_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(102, 561);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(0, 13);
            this.label_status.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "jpg";
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Изображения (jpg, png, gif, bmp)|*.jpg;*.png;*.gif;*.bmp";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // button_select_photos
            // 
            this.button_select_photos.Location = new System.Drawing.Point(9, 130);
            this.button_select_photos.Name = "button_select_photos";
            this.button_select_photos.Size = new System.Drawing.Size(139, 23);
            this.button_select_photos.TabIndex = 4;
            this.button_select_photos.Text = "Выбрать фотографии";
            this.button_select_photos.UseVisualStyleBackColor = true;
            this.button_select_photos.Click += new System.EventHandler(this.button_select_photos_Click);
            // 
            // button_clear_photos
            // 
            this.button_clear_photos.Location = new System.Drawing.Point(154, 130);
            this.button_clear_photos.Name = "button_clear_photos";
            this.button_clear_photos.Size = new System.Drawing.Size(75, 23);
            this.button_clear_photos.TabIndex = 5;
            this.button_clear_photos.Text = "Очистить";
            this.button_clear_photos.UseVisualStyleBackColor = true;
            this.button_clear_photos.Click += new System.EventHandler(this.button_clear_photos_Click);
            // 
            // listView
            // 
            this.listView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView.AllowDrop = true;
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.BackColor = System.Drawing.SystemColors.Control;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(9, 170);
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(458, 0);
            this.listView.TabIndex = 0;
            this.listView.TabStop = false;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(48, 48);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label_attachments_local);
            this.groupBox1.Controls.Add(this.listView);
            this.groupBox1.Controls.Add(this.button_clear_photos);
            this.groupBox1.Controls.Add(this.label_attachments);
            this.groupBox1.Controls.Add(this.button_select_photos);
            this.groupBox1.Controls.Add(this.Attachments);
            this.groupBox1.Controls.Add(this.label_sub_attachments);
            this.groupBox1.Location = new System.Drawing.Point(12, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 174);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Изображения, видео, музыка";
            // 
            // label_attachments_local
            // 
            this.label_attachments_local.AutoSize = true;
            this.label_attachments_local.Location = new System.Drawing.Point(9, 105);
            this.label_attachments_local.Name = "label_attachments_local";
            this.label_attachments_local.Size = new System.Drawing.Size(111, 13);
            this.label_attachments_local.TabIndex = 6;
            this.label_attachments_local.Text = "С этого компьютера";
            // 
            // button_relogin
            // 
            this.button_relogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_relogin.Location = new System.Drawing.Point(341, 22);
            this.button_relogin.Name = "button_relogin";
            this.button_relogin.Size = new System.Drawing.Size(144, 23);
            this.button_relogin.TabIndex = 10;
            this.button_relogin.Text = "Сменить пользователя";
            this.button_relogin.UseVisualStyleBackColor = true;
            this.button_relogin.Click += new System.EventHandler(this.button_relogin_Click);
            // 
            // label_delay
            // 
            this.label_delay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_delay.AutoSize = true;
            this.label_delay.Location = new System.Drawing.Point(9, 518);
            this.label_delay.Name = "label_delay";
            this.label_delay.Size = new System.Drawing.Size(252, 13);
            this.label_delay.TabIndex = 12;
            this.label_delay.Text = "Время ожидания между запросами (в секундах)";
            // 
            // Delay
            // 
            this.Delay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Delay.Location = new System.Drawing.Point(267, 516);
            this.Delay.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.Delay.Name = "Delay";
            this.Delay.Size = new System.Drawing.Size(48, 20);
            this.Delay.TabIndex = 6;
            // 
            // PostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 591);
            this.Controls.Add(this.Delay);
            this.Controls.Add(this.label_delay);
            this.Controls.Add(this.button_relogin);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.label_sub_groups);
            this.Controls.Add(this.label_groups);
            this.Controls.Add(this.Groups);
            this.Controls.Add(this.label_message);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.button_post);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PostForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "vk-poster";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Delay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_post;
        private System.Windows.Forms.TextBox Message;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.TextBox Groups;
        private System.Windows.Forms.Label label_groups;
        private System.Windows.Forms.Label label_attachments;
        private System.Windows.Forms.TextBox Attachments;
        private System.Windows.Forms.Label label_sub_attachments;
        private System.Windows.Forms.Label label_sub_groups;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button_select_photos;
        private System.Windows.Forms.Button button_clear_photos;
        private System.Windows.Forms.ListView listView;
        protected System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_attachments_local;
        private System.Windows.Forms.Button button_relogin;
        private System.Windows.Forms.Label label_delay;
        private System.Windows.Forms.NumericUpDown Delay;
    }
}

