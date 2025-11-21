using System;
using System.Drawing;
using System.Windows.Forms;
using CampusReportApp.UI;

namespace CampusReportApp
{
    public partial class LoginForm : Form
    {

        public bool IsAuthenticated { get; private set; } = false;
        public string UserRole { get; private set; } = "Guest";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnGuest_MouseEnter(object sender, EventArgs e)
        {
            btnGuest.BackColor = Color.DarkGray;
        }

        private void BtnGuest_MouseLeave(object sender, EventArgs e)
        {
            btnGuest.BackColor = Color.Gray;
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
