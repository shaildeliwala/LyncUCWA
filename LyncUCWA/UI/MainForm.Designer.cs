namespace LyncUCWA.UI
{
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    partial class MainForm : System.Windows.Forms.Form
    {

        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        //Required by the Windows Form Designer

        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.Windows.Forms.Label Label1;
            System.Windows.Forms.Label Label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.GroupBox gbMyPhones;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label8;
            this.txtMobilePhone = new System.Windows.Forms.TextBox();
            this.txtHomePhone = new System.Windows.Forms.TextBox();
            this.txtWorkPhone = new System.Windows.Forms.TextBox();
            this.lblEditPhoneNumber = new System.Windows.Forms.Label();
            this.tlpUserStuff = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtOAuthToken = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpgLogin = new System.Windows.Forms.TabPage();
            this.txtLoginActivities = new System.Windows.Forms.TextBox();
            this.tpgApplicationObject = new System.Windows.Forms.TabPage();
            this.btnGet = new System.Windows.Forms.Button();
            this.txtApplicationObject = new System.Windows.Forms.TextBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.tpgPhoneCall = new System.Windows.Forms.TabPage();
            this.lblCallStatus = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.gridFriends = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSipEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Label1 = new System.Windows.Forms.Label();
            Label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            gbMyPhones = new System.Windows.Forms.GroupBox();
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            gbMyPhones.SuspendLayout();
            this.tlpUserStuff.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpgLogin.SuspendLayout();
            this.tpgApplicationObject.SuspendLayout();
            this.tpgPhoneCall.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFriends)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new System.Drawing.Point(2, 9);
            Label1.Name = "Label1";
            Label1.Size = new System.Drawing.Size(96, 17);
            Label1.TabIndex = 1;
            Label1.Text = "SIP URI User ID";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new System.Drawing.Point(295, 9);
            Label2.Name = "Label2";
            Label2.Size = new System.Drawing.Size(64, 17);
            Label2.TabIndex = 1;
            Label2.Text = "Password";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(80, 6);
            label3.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(46, 17);
            label3.TabIndex = 3;
            label3.Text = "Status:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(16, 42);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(83, 17);
            label4.TabIndex = 1;
            label4.Text = "OAuth Token";
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(4, 6);
            label5.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(23, 17);
            label5.TabIndex = 1;
            label5.Text = "Hi,";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(5, 9);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(30, 17);
            label9.TabIndex = 3;
            label9.Text = "Link";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(8, 11);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(56, 17);
            label6.TabIndex = 3;
            label6.Text = "Number";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(552, 34);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(53, 17);
            label7.TabIndex = 8;
            label7.Text = "Friends:";
            // 
            // gbMyPhones
            // 
            gbMyPhones.Controls.Add(this.txtMobilePhone);
            gbMyPhones.Controls.Add(this.txtHomePhone);
            gbMyPhones.Controls.Add(this.txtWorkPhone);
            gbMyPhones.Controls.Add(label11);
            gbMyPhones.Controls.Add(label10);
            gbMyPhones.Controls.Add(this.lblEditPhoneNumber);
            gbMyPhones.Controls.Add(label8);
            gbMyPhones.Dock = System.Windows.Forms.DockStyle.Bottom;
            gbMyPhones.Location = new System.Drawing.Point(2, 62);
            gbMyPhones.Name = "gbMyPhones";
            gbMyPhones.Size = new System.Drawing.Size(536, 340);
            gbMyPhones.TabIndex = 6;
            gbMyPhones.TabStop = false;
            gbMyPhones.Text = "My Phones";
            // 
            // txtMobilePhone
            // 
            this.txtMobilePhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobilePhone.Location = new System.Drawing.Point(63, 134);
            this.txtMobilePhone.Name = "txtMobilePhone";
            this.txtMobilePhone.ReadOnly = true;
            this.txtMobilePhone.Size = new System.Drawing.Size(189, 25);
            this.txtMobilePhone.TabIndex = 4;
            this.txtMobilePhone.Tag = "";
            this.txtMobilePhone.DoubleClick += new System.EventHandler(this.phoneNumber_DoubleClick);
            this.txtMobilePhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phoneNumber_KeyDown);
            // 
            // txtHomePhone
            // 
            this.txtHomePhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHomePhone.Location = new System.Drawing.Point(63, 96);
            this.txtHomePhone.Name = "txtHomePhone";
            this.txtHomePhone.ReadOnly = true;
            this.txtHomePhone.Size = new System.Drawing.Size(189, 25);
            this.txtHomePhone.TabIndex = 4;
            this.txtHomePhone.Tag = "";
            this.txtHomePhone.DoubleClick += new System.EventHandler(this.phoneNumber_DoubleClick);
            this.txtHomePhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phoneNumber_KeyDown);
            // 
            // txtWorkPhone
            // 
            this.txtWorkPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWorkPhone.Location = new System.Drawing.Point(63, 57);
            this.txtWorkPhone.Name = "txtWorkPhone";
            this.txtWorkPhone.ReadOnly = true;
            this.txtWorkPhone.Size = new System.Drawing.Size(189, 25);
            this.txtWorkPhone.TabIndex = 4;
            this.txtWorkPhone.Tag = "";
            this.txtWorkPhone.DoubleClick += new System.EventHandler(this.phoneNumber_DoubleClick);
            this.txtWorkPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phoneNumber_KeyDown);
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(13, 136);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(49, 17);
            label11.TabIndex = 3;
            label11.Text = "Mobile";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(19, 98);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(43, 17);
            label10.TabIndex = 3;
            label10.Text = "Home";
            // 
            // lblEditPhoneNumber
            // 
            this.lblEditPhoneNumber.AutoSize = true;
            this.lblEditPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic);
            this.lblEditPhoneNumber.Location = new System.Drawing.Point(6, 26);
            this.lblEditPhoneNumber.Name = "lblEditPhoneNumber";
            this.lblEditPhoneNumber.Size = new System.Drawing.Size(232, 17);
            this.lblEditPhoneNumber.TabIndex = 3;
            this.lblEditPhoneNumber.Text = "(Double click a phone number to edit it.)";
            this.lblEditPhoneNumber.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(23, 59);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(39, 17);
            label8.TabIndex = 3;
            label8.Text = "Work";
            // 
            // tlpUserStuff
            // 
            this.tlpUserStuff.ColumnCount = 4;
            this.tlpUserStuff.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpUserStuff.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpUserStuff.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpUserStuff.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpUserStuff.Controls.Add(label5, 0, 0);
            this.tlpUserStuff.Controls.Add(this.lblName, 1, 0);
            this.tlpUserStuff.Controls.Add(label3, 2, 0);
            this.tlpUserStuff.Controls.Add(this.lblStatus, 3, 0);
            this.tlpUserStuff.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpUserStuff.Location = new System.Drawing.Point(0, 0);
            this.tlpUserStuff.Margin = new System.Windows.Forms.Padding(0);
            this.tlpUserStuff.Name = "tlpUserStuff";
            this.tlpUserStuff.Padding = new System.Windows.Forms.Padding(1);
            this.tlpUserStuff.RowCount = 1;
            this.tlpUserStuff.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUserStuff.Size = new System.Drawing.Size(941, 30);
            this.tlpUserStuff.TabIndex = 5;
            this.tlpUserStuff.Visible = false;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(27, 6);
            this.lblName.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(126, 6);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 17);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "           ";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUserID
            // 
            this.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserID.Location = new System.Drawing.Point(105, 6);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(167, 25);
            this.txtUserID.TabIndex = 0;
            this.txtUserID.Text = "amya1344";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(457, 69);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(78, 31);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(365, 6);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(170, 25);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "<NoPassword>";
            // 
            // txtOAuthToken
            // 
            this.txtOAuthToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOAuthToken.Location = new System.Drawing.Point(105, 37);
            this.txtOAuthToken.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOAuthToken.Name = "txtOAuthToken";
            this.txtOAuthToken.Size = new System.Drawing.Size(430, 25);
            this.txtOAuthToken.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Call Phone";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpgLogin);
            this.tabControl1.Controls.Add(this.tpgApplicationObject);
            this.tabControl1.Controls.Add(this.tpgPhoneCall);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(548, 430);
            this.tabControl1.TabIndex = 6;
            // 
            // tpgLogin
            // 
            this.tpgLogin.Controls.Add(this.txtLoginActivities);
            this.tpgLogin.Controls.Add(Label1);
            this.tpgLogin.Controls.Add(this.txtUserID);
            this.tpgLogin.Controls.Add(this.txtOAuthToken);
            this.tpgLogin.Controls.Add(this.txtPassword);
            this.tpgLogin.Controls.Add(label4);
            this.tpgLogin.Controls.Add(Label2);
            this.tpgLogin.Controls.Add(this.btnLogin);
            this.tpgLogin.Location = new System.Drawing.Point(4, 26);
            this.tpgLogin.Margin = new System.Windows.Forms.Padding(0);
            this.tpgLogin.Name = "tpgLogin";
            this.tpgLogin.Padding = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.tpgLogin.Size = new System.Drawing.Size(540, 400);
            this.tpgLogin.TabIndex = 0;
            this.tpgLogin.Text = "Login";
            this.tpgLogin.UseVisualStyleBackColor = true;
            // 
            // txtLoginActivities
            // 
            this.txtLoginActivities.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtLoginActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginActivities.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLoginActivities.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginActivities.ForeColor = System.Drawing.Color.Chartreuse;
            this.txtLoginActivities.Location = new System.Drawing.Point(0, 107);
            this.txtLoginActivities.Margin = new System.Windows.Forms.Padding(0);
            this.txtLoginActivities.Multiline = true;
            this.txtLoginActivities.Name = "txtLoginActivities";
            this.txtLoginActivities.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLoginActivities.Size = new System.Drawing.Size(538, 291);
            this.txtLoginActivities.TabIndex = 6;
            this.txtLoginActivities.Text = "(This area shows statuses of Login activities.)";
            // 
            // tpgApplicationObject
            // 
            this.tpgApplicationObject.Controls.Add(this.btnGet);
            this.tpgApplicationObject.Controls.Add(this.txtApplicationObject);
            this.tpgApplicationObject.Controls.Add(this.txtLink);
            this.tpgApplicationObject.Controls.Add(label9);
            this.tpgApplicationObject.Location = new System.Drawing.Point(4, 22);
            this.tpgApplicationObject.Margin = new System.Windows.Forms.Padding(0);
            this.tpgApplicationObject.Name = "tpgApplicationObject";
            this.tpgApplicationObject.Padding = new System.Windows.Forms.Padding(2);
            this.tpgApplicationObject.Size = new System.Drawing.Size(540, 404);
            this.tpgApplicationObject.TabIndex = 1;
            this.tpgApplicationObject.Text = "Application Object";
            this.tpgApplicationObject.UseVisualStyleBackColor = true;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(477, 6);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(61, 25);
            this.btnGet.TabIndex = 6;
            this.btnGet.Text = "GET";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // txtApplicationObject
            // 
            this.txtApplicationObject.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtApplicationObject.Location = new System.Drawing.Point(2, 43);
            this.txtApplicationObject.Multiline = true;
            this.txtApplicationObject.Name = "txtApplicationObject";
            this.txtApplicationObject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtApplicationObject.Size = new System.Drawing.Size(536, 359);
            this.txtApplicationObject.TabIndex = 5;
            // 
            // txtLink
            // 
            this.txtLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLink.Location = new System.Drawing.Point(36, 6);
            this.txtLink.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(435, 25);
            this.txtLink.TabIndex = 4;
            // 
            // tpgPhoneCall
            // 
            this.tpgPhoneCall.Controls.Add(gbMyPhones);
            this.tpgPhoneCall.Controls.Add(this.lblCallStatus);
            this.tpgPhoneCall.Controls.Add(this.txtPhoneNumber);
            this.tpgPhoneCall.Controls.Add(label6);
            this.tpgPhoneCall.Controls.Add(this.button1);
            this.tpgPhoneCall.Location = new System.Drawing.Point(4, 22);
            this.tpgPhoneCall.Margin = new System.Windows.Forms.Padding(0);
            this.tpgPhoneCall.Name = "tpgPhoneCall";
            this.tpgPhoneCall.Padding = new System.Windows.Forms.Padding(2);
            this.tpgPhoneCall.Size = new System.Drawing.Size(540, 404);
            this.tpgPhoneCall.TabIndex = 2;
            this.tpgPhoneCall.Text = "Phone Call";
            this.tpgPhoneCall.UseVisualStyleBackColor = true;
            // 
            // lblCallStatus
            // 
            this.lblCallStatus.AutoSize = true;
            this.lblCallStatus.BackColor = System.Drawing.Color.Black;
            this.lblCallStatus.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblCallStatus.Location = new System.Drawing.Point(341, 7);
            this.lblCallStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblCallStatus.Name = "lblCallStatus";
            this.lblCallStatus.Padding = new System.Windows.Forms.Padding(6);
            this.lblCallStatus.Size = new System.Drawing.Size(88, 29);
            this.lblCallStatus.TabIndex = 5;
            this.lblCallStatus.Text = "[Call Status]";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhoneNumber.Location = new System.Drawing.Point(65, 9);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(189, 25);
            this.txtPhoneNumber.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMessage);
            this.tabPage1.Controls.Add(this.txtChat);
            this.tabPage1.Controls.Add(this.btnInit);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(540, 404);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Messaging";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtMessage.Location = new System.Drawing.Point(3, 333);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(534, 68);
            this.txtMessage.TabIndex = 8;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // txtChat
            // 
            this.txtChat.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtChat.Location = new System.Drawing.Point(3, 43);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.Size = new System.Drawing.Size(534, 280);
            this.txtChat.TabIndex = 7;
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(459, 6);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(78, 31);
            this.btnInit.TabIndex = 5;
            this.btnInit.Text = "Init chat";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // gridFriends
            // 
            this.gridFriends.AllowUserToAddRows = false;
            this.gridFriends.AllowUserToDeleteRows = false;
            this.gridFriends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFriends.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colSipEmail,
            this.colStatus});
            this.gridFriends.Location = new System.Drawing.Point(552, 54);
            this.gridFriends.MultiSelect = false;
            this.gridFriends.Name = "gridFriends";
            this.gridFriends.ReadOnly = true;
            this.gridFriends.RowHeadersVisible = false;
            this.gridFriends.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFriends.Size = new System.Drawing.Size(389, 403);
            this.gridFriends.TabIndex = 9;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colSipEmail
            // 
            this.colSipEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSipEmail.HeaderText = "SIP Email";
            this.colSipEmail.Name = "colSipEmail";
            this.colSipEmail.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 68;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(941, 461);
            this.Controls.Add(this.tlpUserStuff);
            this.Controls.Add(this.gridFriends);
            this.Controls.Add(label7);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lync UCWA Client";
            this.Load += new System.EventHandler(this.MainForm_Load);
            gbMyPhones.ResumeLayout(false);
            gbMyPhones.PerformLayout();
            this.tlpUserStuff.ResumeLayout(false);
            this.tlpUserStuff.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpgLogin.ResumeLayout(false);
            this.tpgLogin.PerformLayout();
            this.tpgApplicationObject.ResumeLayout(false);
            this.tpgApplicationObject.PerformLayout();
            this.tpgPhoneCall.ResumeLayout(false);
            this.tpgPhoneCall.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFriends)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.TextBox txtUserID;
        internal System.Windows.Forms.Button btnLogin;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label lblStatus;
        internal System.Windows.Forms.TextBox txtOAuthToken;
        private System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgLogin;
        private System.Windows.Forms.TabPage tpgApplicationObject;
        internal System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.TextBox txtApplicationObject;
        private System.Windows.Forms.TabPage tpgPhoneCall;
        internal System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TabPage tabPage1;
        internal System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TextBox txtLoginActivities;
        private System.Windows.Forms.DataGridView gridFriends;
        private System.Windows.Forms.TableLayoutPanel tlpUserStuff;
        internal System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label lblCallStatus;
        private System.Windows.Forms.TextBox txtWorkPhone;
        private System.Windows.Forms.TextBox txtMobilePhone;
        private System.Windows.Forms.TextBox txtHomePhone;
        private System.Windows.Forms.Label lblEditPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSipEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}

