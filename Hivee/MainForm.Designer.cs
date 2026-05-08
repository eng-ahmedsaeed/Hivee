namespace Hivee
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTopbar = new Panel();
            btnEvent = new Button();
            btnPage = new Button();
            btnInbox = new Button();
            btnProfile = new Button();
            btnPost = new Button();
            pnlContent = new Panel();
            pnlTopbar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTopbar
            // 
            pnlTopbar.Controls.Add(btnEvent);
            pnlTopbar.Controls.Add(btnPage);
            pnlTopbar.Controls.Add(btnInbox);
            pnlTopbar.Controls.Add(btnProfile);
            pnlTopbar.Controls.Add(btnPost);
            pnlTopbar.Dock = DockStyle.Top;
            pnlTopbar.Location = new Point(0, 0);
            pnlTopbar.Name = "pnlTopbar";
            pnlTopbar.Padding = new Padding(10);
            pnlTopbar.Size = new Size(1182, 59);
            pnlTopbar.TabIndex = 0;
            // 
            // btnEvent
            // 
            btnEvent.Dock = DockStyle.Left;
            btnEvent.Location = new Point(198, 10);
            btnEvent.Name = "btnEvent";
            btnEvent.Size = new Size(94, 39);
            btnEvent.TabIndex = 4;
            btnEvent.Text = "Events";
            btnEvent.UseVisualStyleBackColor = true;
            btnEvent.Click += btnEvent_Click;
            // 
            // btnPage
            // 
            btnPage.Dock = DockStyle.Left;
            btnPage.Location = new Point(104, 10);
            btnPage.Name = "btnPage";
            btnPage.Size = new Size(94, 39);
            btnPage.TabIndex = 2;
            btnPage.Text = "Pages";
            btnPage.UseVisualStyleBackColor = true;
            btnPage.Click += btnPage_Click;
            // 
            // btnInbox
            // 
            btnInbox.Dock = DockStyle.Right;
            btnInbox.Location = new Point(984, 10);
            btnInbox.Name = "btnInbox";
            btnInbox.Size = new Size(94, 39);
            btnInbox.TabIndex = 1;
            btnInbox.Text = "Inbox";
            btnInbox.UseVisualStyleBackColor = true;
            btnInbox.Click += btnInbox_Click;
            // 
            // btnProfile
            // 
            btnProfile.Dock = DockStyle.Right;
            btnProfile.Location = new Point(1078, 10);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(94, 39);
            btnProfile.TabIndex = 0;
            btnProfile.Text = "Profile";
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnPost
            // 
            btnPost.Dock = DockStyle.Left;
            btnPost.Location = new Point(10, 10);
            btnPost.Name = "btnPost";
            btnPost.Size = new Size(94, 39);
            btnPost.TabIndex = 3;
            btnPost.Text = "Posts";
            btnPost.UseVisualStyleBackColor = true;
            btnPost.Click += btnPost_Click;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 59);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1182, 694);
            pnlContent.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(pnlContent);
            Controls.Add(pnlTopbar);
            Name = "MainForm";
            Text = "Form1";
            pnlTopbar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTopbar;
        private Button btnInbox;
        private Button btnProfile;
        private Panel pnlContent;
        private Button btnPage;
        private Button btnPost;
        private Button btnEvent;
    }
}
