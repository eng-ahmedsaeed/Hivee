namespace Hivee
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            UserPic = new PictureBox();
            UserNameLabel = new Label();
            HeaderPanel = new Panel();
            SearchButton = new Button();
            DisplayProfileButton = new Button();
            PostsScroll = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)UserPic).BeginInit();
            HeaderPanel.SuspendLayout();
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
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Location = new Point(60, 16);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(59, 20);
            UserNameLabel.TabIndex = 7;
            UserNameLabel.Text = "Hi user";
            // 
            // HeaderPanel
            // 
            HeaderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            HeaderPanel.Controls.Add(SearchButton);
            HeaderPanel.Controls.Add(DisplayProfileButton);
            HeaderPanel.Controls.Add(UserNameLabel);
            HeaderPanel.Controls.Add(UserPic);
            HeaderPanel.Location = new Point(40, 26);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(1173, 76);
            HeaderPanel.TabIndex = 6;
            // 
            // SearchButton
            // 
            SearchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SearchButton.Location = new Point(859, 16);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(140, 29);
            SearchButton.TabIndex = 10;
            SearchButton.Text = "Search Users";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // DisplayProfileButton
            // 
            DisplayProfileButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DisplayProfileButton.Location = new Point(1005, 16);
            DisplayProfileButton.Name = "DisplayProfileButton";
            DisplayProfileButton.Size = new Size(163, 29);
            DisplayProfileButton.TabIndex = 9;
            DisplayProfileButton.Text = "Display Profile";
            DisplayProfileButton.UseVisualStyleBackColor = true;
            DisplayProfileButton.Click += DisplayProfileButton_Click;
            // 
            // PostsScroll
            // 
            PostsScroll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PostsScroll.AutoScroll = true;
            PostsScroll.FlowDirection = FlowDirection.TopDown;
            PostsScroll.Location = new Point(40, 128);
            PostsScroll.Name = "PostsScroll";
            PostsScroll.Size = new Size(1181, 593);
            PostsScroll.TabIndex = 1;
            PostsScroll.WrapContents = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 745);
            Controls.Add(HeaderPanel);
            Controls.Add(PostsScroll);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)UserPic).EndInit();
            HeaderPanel.ResumeLayout(false);
            HeaderPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox UserPic;
        private Label UserNameLabel;
        private Panel HeaderPanel;
        private Button DisplayProfileButton;
        private Button SearchButton;
        private FlowLayoutPanel PostsScroll;
    }
}
