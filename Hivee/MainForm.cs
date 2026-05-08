namespace Hivee
{
    public partial class MainForm : Form
    {
        private int currentUserId;
        private Form? activeForm = null;

        public MainForm(int loggedInUserId)
        {
            InitializeComponent();
            currentUserId = loggedInUserId;
        }

        private void LoadFormIntoPanel(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnInbox_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new Messages.InboxForm(currentUserId));
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            
        }
    }
}
