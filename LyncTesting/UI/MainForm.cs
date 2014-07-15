using LyncTest.Contacts;
using LyncTest.Events;
using LyncTest.Helpers;
using LyncTest.JsonResponses;
using LyncTest.Messaging;
using LyncTest.PhoneAudio;
using LyncTest.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LyncTest.UI
{
    public partial class MainForm : Form
    {
        internal static Label nameLabel, statusLabel, callLabel;
        internal static DataGridView gridReference;
        internal static TextBox chatBox;
        internal static TextBox loginActivityIndicator;
        internal static TextBox applicationObject;
        private static ResponseForm responseForm;

        public MainForm()
        {
            InitializeComponent();
            gridReference = gridFriends;
            statusLabel = lblStatus;
            nameLabel = lblName;
            chatBox = txtChat;
            loginActivityIndicator = txtLoginActivities;
            applicationObject = txtApplicationObject;
            callLabel = lblCallStatus;
        }


        private async void btnLogin_Click(object sender, EventArgs e)
        {
            LoginTasks.UserID = txtUserID.Text;
            LoginTasks.Password = txtPassword.Text;
            Settings.Default.OAuthToken = txtOAuthToken.Text;
            try
            {
                await LoginTasks.DoLoginTasks();
                tlpUserStuff.Visible = true;
            }
            catch (Exception ex)
            {
                loginActivityIndicator.AppendText(ex.ToString());
            }
            await MiscellaneousTasks.MakeMeAvailable();
            Program.Contacts = await ContactsTasks.GetContacts();
            await UpdateContacts(Program.Contacts);
            Program.Phones = await NumberTasks.GetPhones(Program.ApplicationInstance._embedded.me._links.phones);
            await UpdatePhoneNumbers(Program.Phones);
            EventListener.StartListening();
        }
        
        private async void btnInit_Click(object sender, EventArgs e)
        {
            await OutgoingMessageTasks.DoSendMessageTasks(this);       
        }

        private async void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                await OutgoingMessageTasks.PostSendMessage(txtMessage.Text);
                txtMessage.Clear();
            }
        }

        private async void btnCall_Click(object sender, EventArgs e)
        {
            if (txtPhoneNumber.TextLength != 0 && IsValidPhoneNumber(txtPhoneNumber.Text))
            {
                await CallTasks.Call(txtPhoneNumber.Text.Trim(), gridFriends.Rows[0].Cells[1].Value.ToString());
            }
        }

        private bool IsValidPhoneNumber(string p)
        {
            //implement this function fully later
            return true;
        }
       
        private void MainForm_Load(object sender, EventArgs e)
        {
            loginActivityIndicator.Text = String.Empty;
            applicationObject.Text = String.Empty;
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            var link = txtLink.Text;
            if (!Uri.IsWellFormedUriString(link, UriKind.RelativeOrAbsolute)) return;

            if (responseForm == null) //Application.OpenForms.OfType<ResponseForm>().Any()
            {
                responseForm = new ResponseForm();
                responseForm.Show();
            }
            responseForm.txtResponseContent.Text = await (new LyncHttpClient()).GetStringAsync(link);
        }

        private async Task UpdateContacts(MyContacts myContactsResource)
        {
            foreach (Contact person in myContactsResource._embedded.contact)
            {
                var presence = await Task.Run<string>(async delegate
                {
                    return
                    (string)JObject.Parse(json: (await (new LyncHttpClient()).
                    GetStringAsync(person._links.contactPresence.href))).
                    SelectToken("availability");
                });
                gridReference.Rows.Add(person.name ?? "(NA)", 
                    person.emailAddresses == null
                    || !person.emailAddresses.Any() ?
                    "(NA)" : person.emailAddresses[0],
                    presence ?? "(NA)");
            }
        }

        private async Task UpdatePhoneNumbers(Phones phoneResource)
        {
            Phone work = null, home = null, mobile = null;
            await Task.Run(delegate
            {
                var phones = phoneResource._embedded.phone;
                if (phones == null) return;
                work = phones.Find(p => p.type.ICEquals("work"));
                home = phones.Find(p => p.type.ICEquals("home"));
                mobile = phones.Find(p => p.type.ICEquals("mobile"));
            });
            if (work != null)
            {
                txtWorkPhone.Text = work.number.IsEmpty() ? "-" : work.number;   
                txtWorkPhone.Tag = work._links.changeNumber.href;
            }
            if (home != null)
            {
                txtHomePhone.Text = home.number.IsEmpty() ? "-" : home.number;
                txtHomePhone.Tag = home._links.changeNumber.href;
            }
            if (mobile != null)
            {
                txtMobilePhone.Text = mobile.number.IsEmpty() ? "-" : mobile.number;
                txtMobilePhone.Tag = mobile._links.changeNumber.href;
            }
        }

        private void phoneNumber_DoubleClick(object sender, EventArgs e)
        {
            var txtBox = (TextBox)sender;
            txtBox.ReadOnly = false;
        }

        private async void phoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            var txtBox = (TextBox)sender;

            if (e.KeyCode == Keys.Escape) { txtBox.ReadOnly = true; return; }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                txtBox.ReadOnly = true;
                if ((await NumberTasks.ChangeNumber(txtBox.Tag.ToString(), txtBox.Text)).IsSuccessStatusCode)
                {
                    MessageBox.Show("Number changed successfully.");
                }
            }
        }
    }
}