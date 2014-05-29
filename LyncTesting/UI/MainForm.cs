using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyncTest.UI
{
    public partial class MainForm : Form
    {
        internal static Label nameLabel;
        internal static DataGridView gridReference;
        internal static Label statusLabel;
        internal static TextBox chatBox;
        public MainForm()
        {
            InitializeComponent();
            gridReference = gridFriends;
            statusLabel = lblStatus;
            nameLabel = lblName;
            chatBox = txtChat; 
        }

        private async void btnLogin_Click(object sender, System.EventArgs e)
        {
            LoginTasks.UserID = txtUserID.Text;
            LoginTasks.Password = txtPassword.Text;
            Properties.Settings.Default.copytoken = txtOAuthToken.Text;
            await LoginTasks.DoLoginTasks();
            await MiscellaneousTasks.MakeMeAvailable();
            await MiscellaneousTasks.GetContacts();
            EventListener.StartListening();
        }
        
        private async void btnInit_Click(object sender, System.EventArgs e)
        {
            await MessagingClasses.OutgoingMessageTasks.DoSendMessageTasks(this);
        }

        private async void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                await MessagingClasses.OutgoingMessageTasks.PostSendMessage(txtMessage.Text);
                txtMessage.Clear();
            }
        }

    }
}
