using System;
using System.Drawing;
using System.Windows.Forms;
using CampusReportApp.UI;

namespace CampusReportApp
{
    public class LoginForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private ModernButton btnLogin;
        private ModernButton btnGuest;
        public bool IsAuthenticated { get; private set; } = false;
        public string UserRole { get; private set; } = "Guest";

        public LoginForm()
        {
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Lapor Kampus - Masuk";
            this.Size = new Size(400, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ThemeColor.BackgroundColor;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            int y = 40;
            int x = 50;
            int width = 280;

            Label lblTitle = new Label { Text = "Selamat Datang", Location = new Point(x, y), AutoSize = true, Font = ThemeColor.HeaderFont, ForeColor = ThemeColor.PrimaryColor };
            this.Controls.Add(lblTitle);

            y += 60;
            Label lblUser = new Label { Text = "Username (Admin):", Location = new Point(x, y), AutoSize = true, Font = ThemeColor.PrimaryFont };
            txtUsername = new TextBox { Location = new Point(x, y + 25), Width = width, Font = ThemeColor.PrimaryFont, BorderStyle = BorderStyle.FixedSingle };
            this.Controls.Add(lblUser);
            this.Controls.Add(txtUsername);

            y += 60;
            Label lblPass = new Label { Text = "Password:", Location = new Point(x, y), AutoSize = true, Font = ThemeColor.PrimaryFont };
            txtPassword = new TextBox { Location = new Point(x, y + 25), Width = width, PasswordChar = '*', Font = ThemeColor.PrimaryFont, BorderStyle = BorderStyle.FixedSingle };
            this.Controls.Add(lblPass);
            this.Controls.Add(txtPassword);

            y += 70;
            btnLogin = new ModernButton { Text = "Masuk sebagai Admin", Location = new Point(x, y), Width = width };
            btnLogin.Click += BtnLogin_Click;
            this.Controls.Add(btnLogin);

            y += 60;
            Label lblOr = new Label { Text = "- ATAU -", Location = new Point(170, y), AutoSize = true, ForeColor = Color.Gray };
            this.Controls.Add(lblOr);

            y += 30;
            btnGuest = new ModernButton { Text = "Lanjut sebagai Tamu", Location = new Point(x, y), Width = width, BackColor = Color.Gray };
            btnGuest.Click += BtnGuest_Click;
            // Hover for Guest
            btnGuest.MouseEnter += (s, e) => { btnGuest.BackColor = Color.DarkGray; };
            btnGuest.MouseLeave += (s, e) => { btnGuest.BackColor = Color.Gray; };
            this.Controls.Add(btnGuest);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin123")
            {
                IsAuthenticated = true;
                UserRole = "Admin";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Username atau Password salah.", "Gagal Masuk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuest_Click(object sender, EventArgs e)
        {
            IsAuthenticated = true;
            UserRole = "Guest";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
