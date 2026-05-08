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
            Preivew = new PictureBox();
            AddMeida = new Button();
            label3 = new Label();
            PagesComboBox = new ComboBox();
            CreatePostButton = new Button();
            Scroll = new FlowLayoutPanel();
            Refresh = new Button();
            ((System.ComponentModel.ISupportInitialize)UserPic).BeginInit();
            CreatePostPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Preivew).BeginInit();
            SuspendLayout();
            // 
            // UserPic
            // 
            UserPic.Location = new Point(13, 3);
            UserPic.Name = "UserPic";
            UserPic.Size = new Size(52, 55);
            UserPic.TabIndex = 3;
            UserPic.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 61);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 4;
            label1.Text = "Create Post";
            // 
            // CreatePostText
            // 
            CreatePostText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CreatePostText.Location = new Point(3, 90);
            CreatePostText.Name = "CreatePostText";
            CreatePostText.Size = new Size(821, 56);
            CreatePostText.TabIndex = 5;
            CreatePostText.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 17);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 7;
            label2.Text = "Hi user ";
            // 
            // CreatePostPanel
            // 
            CreatePostPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CreatePostPanel.BorderStyle = BorderStyle.FixedSingle;
            CreatePostPanel.Controls.Add(Preivew);
            CreatePostPanel.Controls.Add(AddMeida);
            CreatePostPanel.Controls.Add(label3);
            CreatePostPanel.Controls.Add(PagesComboBox);
            CreatePostPanel.Controls.Add(CreatePostButton);
            CreatePostPanel.Controls.Add(label2);
            CreatePostPanel.Controls.Add(CreatePostText);
            CreatePostPanel.Controls.Add(label1);
            CreatePostPanel.Controls.Add(UserPic);
            CreatePostPanel.Location = new Point(40, 26);
            CreatePostPanel.Name = "CreatePostPanel";
            CreatePostPanel.Size = new Size(1173, 190);
            CreatePostPanel.TabIndex = 6;
            // 
            // Preivew
            // 
            Preivew.Location = new Point(1042, 17);
            Preivew.Name = "Preivew";
            Preivew.Size = new Size(105, 93);
            Preivew.TabIndex = 12;
            Preivew.TabStop = false;
            // 
            // AddMeida
            // 
            AddMeida.Location = new Point(1070, 116);
            AddMeida.Name = "AddMeida";
            AddMeida.Size = new Size(89, 30);
            AddMeida.TabIndex = 11;
            AddMeida.Text = "AddMedia";
            AddMeida.UseVisualStyleBackColor = true;
            AddMeida.Click += AddMeida_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(858, 61);
            label3.Name = "label3";
            label3.Size = new Size(94, 20);
            label3.TabIndex = 10;
            label3.Text = "Choose Page";
            // 
            // PagesComboBox
            // 
            PagesComboBox.FormattingEnabled = true;
            PagesComboBox.Location = new Point(858, 106);
            PagesComboBox.Name = "PagesComboBox";
            PagesComboBox.Size = new Size(151, 28);
            PagesComboBox.TabIndex = 9;
            // 
            // CreatePostButton
            // 
            CreatePostButton.Location = new Point(1065, 152);
            CreatePostButton.Name = "CreatePostButton";
            CreatePostButton.Size = new Size(94, 29);
            CreatePostButton.TabIndex = 8;
            CreatePostButton.Text = "CreatePost";
            CreatePostButton.UseVisualStyleBackColor = true;
            CreatePostButton.Click += CreatePostButton_Click;
            // 
            // Scroll
            // 
            Scroll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Scroll.AutoScroll = true;
            Scroll.BorderStyle = BorderStyle.FixedSingle;
            Scroll.FlowDirection = FlowDirection.TopDown;
            Scroll.Location = new Point(40, 271);
            Scroll.Name = "Scroll";
            Scroll.Size = new Size(1181, 450);
            Scroll.TabIndex = 1;
            Scroll.WrapContents = false;
            // 
            // Refresh
            // 
            Refresh.Location = new Point(575, 228);
            Refresh.Name = "Refresh";
            Refresh.Size = new Size(94, 37);
            Refresh.TabIndex = 7;
            Refresh.Text = "Refresh 🔄️";
            Refresh.UseVisualStyleBackColor = true;
            Refresh.Click += Refresh_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 745);
            Controls.Add(Refresh);
            Controls.Add(CreatePostPanel);
            Controls.Add(Scroll);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)UserPic).EndInit();
            CreatePostPanel.ResumeLayout(false);
            CreatePostPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Preivew).EndInit();
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
        private Label label3;
        private ComboBox PagesComboBox;
        private Button AddMeida;
        private PictureBox Preivew;
        private Button Refresh;
    }
}
