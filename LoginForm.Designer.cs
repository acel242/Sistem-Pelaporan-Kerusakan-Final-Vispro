using System.Drawing;
using System.Windows.Forms;

namespace CampusReportApp
{
    partial class LoginForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new CampusReportApp.UI.ModernButton();
            this.lblOr = new System.Windows.Forms.Label();
            this.btnGuest = new CampusReportApp.UI.ModernButton();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = CampusReportApp.UI.ThemeColor.HeaderFont;
            this.lblTitle.ForeColor = CampusReportApp.UI.ThemeColor.PrimaryColor;
            this.lblTitle.Location = new System.Drawing.Point(50, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Selamat Datang";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.lblUser.Location = new System.Drawing.Point(50, 100);
            this.lblUser.Name = "lblUser";
            this.lblUser.Text = "Username (Admin):";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.txtUsername.Location = new System.Drawing.Point(50, 125);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(280, 27);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.lblPass.Location = new System.Drawing.Point(50, 160);
            this.lblPass.Name = "lblPass";
            this.lblPass.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.txtPassword.Location = new System.Drawing.Point(50, 185);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(280, 27);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(50, 230);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(280, 40);
            this.btnLogin.Text = "Masuk sebagai Admin";
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.ForeColor = System.Drawing.Color.Gray;
            this.lblOr.Location = new System.Drawing.Point(170, 290);
            this.lblOr.Name = "lblOr";
            this.lblOr.Text = "- ATAU -";
            // 
            // btnGuest
            // 
            this.btnGuest.BackColor = System.Drawing.Color.Gray;
            this.btnGuest.Location = new System.Drawing.Point(50, 320);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Size = new System.Drawing.Size(280, 40);
            this.btnGuest.Text = "Lanjut sebagai Tamu";
            this.btnGuest.Click += new System.EventHandler(this.BtnGuest_Click);
            this.btnGuest.MouseEnter += new System.EventHandler(this.BtnGuest_MouseEnter);
            this.btnGuest.MouseLeave += new System.EventHandler(this.BtnGuest_MouseLeave);

            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = CampusReportApp.UI.ThemeColor.BackgroundColor;
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.btnGuest);
            this.Controls.Add(this.lblOr);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lapor Kampus - Masuk";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPassword;
        private CampusReportApp.UI.ModernButton btnLogin;
        private System.Windows.Forms.Label lblOr;
        private CampusReportApp.UI.ModernButton btnGuest;
    }
}
