namespace LyncTest.UI
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
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            this.lblName = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtOAuthToken = new System.Windows.Forms.TextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSipEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridFriends = new System.Windows.Forms.DataGridView();
            this.txtMessage = new System.Windows.Forms.TextBox();
            Label1 = new System.Windows.Forms.Label();
            Label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridFriends)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new System.Drawing.Point(12, 20);
            Label1.Name = "Label1";
            Label1.Size = new System.Drawing.Size(96, 17);
            Label1.TabIndex = 1;
            Label1.Text = "SIP URI User ID";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new System.Drawing.Point(309, 20);
            Label2.Name = "Label2";
            Label2.Size = new System.Drawing.Size(64, 17);
            Label2.TabIndex = 1;
            Label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(276, 120);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(46, 17);
            label3.TabIndex = 3;
            label3.Text = "Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(25, 51);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(83, 17);
            label4.TabIndex = 1;
            label4.Text = "OAuth Token";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(12, 120);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(23, 17);
            label5.TabIndex = 1;
            label5.Text = "Hi,";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(12, 146);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(53, 17);
            label7.TabIndex = 3;
            label7.Text = "Friends:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(276, 146);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(37, 17);
            label8.TabIndex = 3;
            label8.Text = "Chat:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(33, 120);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(114, 17);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(189, 25);
            this.txtUserID.TabIndex = 0;
            this.txtUserID.Text = "saraj742@gotuc.net";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(12, 77);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 31);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(379, 17);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(189, 25);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.Text = "saraj742@gotuc.net";
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(93, 77);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 31);
            this.btnInit.TabIndex = 2;
            this.btnInit.Text = "Init chat";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(361, 120);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 3;
            // 
            // txtOAuthToken
            // 
            this.txtOAuthToken.Location = new System.Drawing.Point(114, 48);
            this.txtOAuthToken.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOAuthToken.Name = "txtOAuthToken";
            this.txtOAuthToken.Size = new System.Drawing.Size(454, 25);
            this.txtOAuthToken.TabIndex = 0;
            // 
            // txtChat
            // 
            this.txtChat.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtChat.Location = new System.Drawing.Point(279, 166);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.Size = new System.Drawing.Size(289, 199);
            this.txtChat.TabIndex = 5;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colSipEmail
            // 
            this.colSipEmail.HeaderText = "SIP Email";
            this.colSipEmail.Name = "colSipEmail";
            this.colSipEmail.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
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
            this.gridFriends.Location = new System.Drawing.Point(12, 166);
            this.gridFriends.MultiSelect = false;
            this.gridFriends.Name = "gridFriends";
            this.gridFriends.ReadOnly = true;
            this.gridFriends.RowHeadersVisible = false;
            this.gridFriends.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFriends.Size = new System.Drawing.Size(261, 199);
            this.gridFriends.TabIndex = 4;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 371);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(556, 68);
            this.txtMessage.TabIndex = 5;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(580, 451);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.gridFriends);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(label7);
            this.Controls.Add(label8);
            this.Controls.Add(label3);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(Label2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(Label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtOAuthToken);
            this.Controls.Add(this.txtUserID);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "LyncTest";
            ((System.ComponentModel.ISupportInitialize)(this.gridFriends)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.TextBox txtUserID;
        internal System.Windows.Forms.Button btnLogin;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Button btnInit;
        internal System.Windows.Forms.Label lblStatus;
        internal System.Windows.Forms.TextBox txtOAuthToken;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSipEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridView gridFriends;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtMessage;
    }
}

