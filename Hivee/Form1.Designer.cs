namespace Hivee
{
    partial class Form1
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
            btnInbox = new Button();
            btnProfile = new Button();
            pnlContent = new Panel();
            pnlTopbar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTopbar
            // 
            pnlTopbar.Controls.Add(btnInbox);
            pnlTopbar.Controls.Add(btnProfile);
            pnlTopbar.Dock = DockStyle.Top;
            pnlTopbar.Location = new Point(0, 0);
            pnlTopbar.Name = "pnlTopbar";
            pnlTopbar.Padding = new Padding(10);
            pnlTopbar.Size = new Size(1182, 59);
            pnlTopbar.TabIndex = 0;
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
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 59);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1182, 694);
            pnlContent.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(pnlContent);
            Controls.Add(pnlTopbar);
            Name = "Form1";
            Text = "Form1";
            pnlTopbar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTopbar;
        private Button btnInbox;
        private Button btnProfile;
        private Panel pnlContent;
    }
}
