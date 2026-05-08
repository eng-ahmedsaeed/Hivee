namespace Hivee
{
    public class PostEditorForm : Form
    {
        private readonly RichTextBox postTextBox = new();
        private readonly Button saveButton = new();
        private readonly Button cancelButton = new();

        public PostEditorForm(string postText)
        {
            InitializeEditor(postText);
        }

        public string PostText => postTextBox.Text.Trim();

        private void InitializeEditor(string postText)
        {
            Text = "Update Post";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(560, 320);
            MinimumSize = new Size(480, 260);

            postTextBox.Location = new Point(18, 18);
            postTextBox.Size = new Size(500, 180);
            postTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            postTextBox.Text = postText;

            saveButton.Text = "Save";
            saveButton.Location = new Point(328, 220);
            saveButton.Size = new Size(90, 32);
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveButton.Click += SaveButton_Click;

            cancelButton.Text = "Cancel";
            cancelButton.Location = new Point(428, 220);
            cancelButton.Size = new Size(90, 32);
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.Click += (_, _) => Close();

            Controls.Add(postTextBox);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PostText))
            {
                MessageBox.Show("Post text cannot be empty.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
