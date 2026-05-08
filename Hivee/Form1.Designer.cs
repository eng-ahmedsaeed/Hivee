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
            UserPic = new PictureBox();
            label1 = new Label();
            CreatePostText = new RichTextBox();
            label2 = new Label();
            CreatePostPanel = new Panel();
            Scroll = new FlowLayoutPanel();
            CreatePostButton = new Button();
            ((System.ComponentModel.ISupportInitialize)UserPic).BeginInit();
            CreatePostPanel.SuspendLayout();
            SuspendLayout();
            // 
            // UserPic
            // 
            UserPic.Location = new Point(3, 5);
            UserPic.Name = "UserPic";
            UserPic.Size = new Size(51, 42);
            UserPic.TabIndex = 3;
            UserPic.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 25);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 4;
            label1.Text = "Create Post";
            // 
            // CreatePostText
            // 
            CreatePostText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CreatePostText.Location = new Point(70, 48);
            CreatePostText.Name = "CreatePostText";
            CreatePostText.Size = new Size(996, 56);
            CreatePostText.TabIndex = 5;
            CreatePostText.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 5);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 7;
            label2.Text = "Hi user ";
            // 
            // CreatePostPanel
            // 
            CreatePostPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CreatePostPanel.Controls.Add(CreatePostButton);
            CreatePostPanel.Controls.Add(label2);
            CreatePostPanel.Controls.Add(CreatePostText);
            CreatePostPanel.Controls.Add(label1);
            CreatePostPanel.Controls.Add(UserPic);
            CreatePostPanel.Location = new Point(40, 26);
            CreatePostPanel.Name = "CreatePostPanel";
            CreatePostPanel.Size = new Size(1173, 121);
            CreatePostPanel.TabIndex = 6;
            // 
            // Scroll
            // 
            Scroll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Scroll.AutoScroll = true;
            Scroll.FlowDirection = FlowDirection.TopDown;
            Scroll.Location = new Point(40, 173);
            Scroll.Name = "Scroll";
            Scroll.Size = new Size(1181, 548);
            Scroll.TabIndex = 1;
            Scroll.WrapContents = false;
            // 
            // CreatePostButton
            // 
            CreatePostButton.Location = new Point(1072, 89);
            CreatePostButton.Name = "CreatePostButton";
            CreatePostButton.Size = new Size(94, 29);
            CreatePostButton.TabIndex = 8;
            CreatePostButton.Text = "CreatePost";
            CreatePostButton.UseVisualStyleBackColor = true;
            CreatePostButton.Click += CreatePostButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 745);
            Controls.Add(CreatePostPanel);
            Controls.Add(Scroll);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)UserPic).EndInit();
            CreatePostPanel.ResumeLayout(false);
            CreatePostPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox UserPic;
        private Label label1;
        private RichTextBox CreatePostText;
        private Label label2;
        private Panel CreatePostPanel;
        private FlowLayoutPanel Scroll;
        private Button CreatePostButton;
    }
}
