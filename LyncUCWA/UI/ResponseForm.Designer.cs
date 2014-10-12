namespace LyncUCWA.UI
{
    partial class ResponseForm
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
            this.txtResponseContent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtResponseContent
            // 
            this.txtResponseContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponseContent.Location = new System.Drawing.Point(0, 0);
            this.txtResponseContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtResponseContent.Multiline = true;
            this.txtResponseContent.Name = "txtResponseContent";
            this.txtResponseContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponseContent.Size = new System.Drawing.Size(644, 492);
            this.txtResponseContent.TabIndex = 0;
            // 
            // ResponseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(644, 492);
            this.Controls.Add(this.txtResponseContent);
            this.Font = new System.Drawing.Font("Nirmala UI", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ResponseForm";
            this.Text = "ResponseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.TextBox txtResponseContent;

    }
}