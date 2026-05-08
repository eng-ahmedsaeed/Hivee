namespace Hivee.Messages
{
    partial class InboxForm
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
            lstContacts = new ListBox();
            txtReply = new TextBox();
            btnSendReply = new Button();
            btnAttach = new Button();
            lblAttachment = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            flpChatHistory = new FlowLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // lstContacts
            // 
            lstContacts.Dock = DockStyle.Left;
            lstContacts.FormattingEnabled = true;
            lstContacts.Location = new Point(0, 0);
            lstContacts.Name = "lstContacts";
            lstContacts.Size = new Size(200, 450);
            lstContacts.TabIndex = 0;
            lstContacts.SelectedIndexChanged += lstContacts_SelectedIndexChanged;
            // 
            // txtReply
            // 
            txtReply.Dock = DockStyle.Fill;
            txtReply.Location = new Point(3, 29);
            txtReply.Multiline = true;
            txtReply.Name = "txtReply";
            txtReply.Size = new Size(388, 53);
            txtReply.TabIndex = 2;
            // 
            // btnSendReply
            // 
            btnSendReply.Location = new Point(497, 29);
            btnSendReply.Name = "btnSendReply";
            btnSendReply.Size = new Size(94, 48);
            btnSendReply.TabIndex = 3;
            btnSendReply.Text = "Send";
            btnSendReply.UseVisualStyleBackColor = true;
            btnSendReply.Click += btnSendReply_Click;
            // 
            // btnAttach
            // 
            btnAttach.Location = new Point(397, 29);
            btnAttach.Name = "btnAttach";
            btnAttach.Size = new Size(94, 48);
            btnAttach.TabIndex = 4;
            btnAttach.Text = "Attach";
            btnAttach.UseVisualStyleBackColor = true;
            btnAttach.Click += btnAttach_Click;
            // 
            // lblAttachment
            // 
            lblAttachment.AutoSize = true;
            lblAttachment.Location = new Point(3, 0);
            lblAttachment.Name = "lblAttachment";
            lblAttachment.Size = new Size(0, 20);
            lblAttachment.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(txtReply, 0, 1);
            tableLayoutPanel1.Controls.Add(btnAttach, 1, 1);
            tableLayoutPanel1.Controls.Add(btnSendReply, 2, 1);
            tableLayoutPanel1.Controls.Add(lblAttachment, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(3, 364);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 59F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(594, 83);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 0, 1);
            tableLayoutPanel2.Controls.Add(flpChatHistory, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(200, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 80.22222F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 19.7777786F));
            tableLayoutPanel2.Size = new Size(600, 450);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // flpChatHistory
            // 
            flpChatHistory.AutoScroll = true;
            flpChatHistory.Dock = DockStyle.Fill;
            flpChatHistory.FlowDirection = FlowDirection.TopDown;
            flpChatHistory.Location = new Point(3, 3);
            flpChatHistory.Name = "flpChatHistory";
            flpChatHistory.Size = new Size(594, 355);
            flpChatHistory.TabIndex = 7;
            flpChatHistory.WrapContents = false;
            // 
            // InboxForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(lstContacts);
            Name = "InboxForm";
            Text = "InboxForm";
            Load += InboxForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstContacts;
        private TextBox txtReply;
        private Button btnSendReply;
        private Button btnAttach;
        private Label lblAttachment;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flpChatHistory;
    }
}