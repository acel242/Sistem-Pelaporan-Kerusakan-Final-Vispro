using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CampusReportApp.Services;
using CampusReportApp.UI;

namespace CampusReportApp
{
    public partial class MainForm : Form
    {
        private Button btnReport;
        private Button btnAdmin;
        private string _userRole;
        private DataService _dataService;

        public MainForm(string userRole)
        {
            _userRole = userRole;
            _dataService = new DataService();
            InitializeComponent();
            SetupDynamicUI();
        }

        private void SetupDynamicUI()
        {
            // Logo/Title in Menu
            Panel panelLogo = new Panel();
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Height = 100;
            panelLogo.BackColor = Color.FromArgb(39, 39, 58); 
            Label lblLogo = new Label();
            lblLogo.Text = "Campus\nReport";
            lblLogo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Dock = DockStyle.Fill;
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            panelLogo.Controls.Add(lblLogo);
            panelMenu.Controls.Add(panelLogo);

            // Logout Button (Dock Bottom)
            Button btnLogout = CreateMenuButton("🚪  Keluar", 0);
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.BackColor = Color.FromArgb(192, 57, 43); // Red for logout
            btnLogout.Click += (s, e) => { 
                Application.Restart(); 
                Environment.Exit(0); 
            };
            btnLogout.MouseEnter += (s, e) => { btnLogout.BackColor = Color.FromArgb(231, 76, 60); };
            btnLogout.MouseLeave += (s, e) => { btnLogout.BackColor = Color.FromArgb(192, 57, 43); };
            panelMenu.Controls.Add(btnLogout);

            // Menu Buttons
            if (_userRole != "Admin")
            {
                btnReport = CreateMenuButton("📝  Lapor Kerusakan", 100);
                btnReport.Click += (s, e) => { OpenReportForm(); };
                panelMenu.Controls.Add(btnReport);
            }

            if (_userRole == "Admin")
            {
                btnAdmin = CreateMenuButton("🛡️  Kelola Laporan", 160);
                btnAdmin.Click += (s, e) => { OpenAdminForm(); };
                panelMenu.Controls.Add(btnAdmin);
            }

            // Set Title Text
            lblTitle.Text = _userRole == "Admin" ? "DASHBOARD ADMIN" : "DASHBOARD TAMU";

            // Dashboard Stats
            LoadDashboardStats();
        }

        private void LoadDashboardStats()
        {
            panelDesktop.Controls.Clear();
            
            var reports = _dataService.LoadReports();
            int total = reports.Count;
            int pending = reports.Count(r => r.Status == "Pending");
            int resolved = reports.Count(r => r.Status == "Resolved");

            // Use FlowLayoutPanel for responsive card layout
            FlowLayoutPanel flowStats = new FlowLayoutPanel();
            flowStats.Dock = DockStyle.Top;
            flowStats.Height = 180;
            flowStats.Padding = new Padding(10);
            flowStats.AutoSize = false;
            panelDesktop.Controls.Add(flowStats);

            flowStats.Controls.Add(CreateStatCard("Total Laporan", total.ToString(), Color.FromArgb(52, 73, 94)));
            flowStats.Controls.Add(CreateStatCard("Menunggu", pending.ToString(), ThemeColor.AccentColor));
            flowStats.Controls.Add(CreateStatCard("Selesai", resolved.ToString(), ThemeColor.SuccessColor));

            Label lblWelcome = new Label();
            lblWelcome.Text = "Selamat Datang di Sistem Pelaporan Kampus.\n" + (_userRole == "Admin" ? "Kelola laporan dan lihat statistik." : "Laporkan kerusakan fasilitas dengan mudah.");
            lblWelcome.Font = new Font("Segoe UI Light", 16F);
            lblWelcome.ForeColor = ThemeColor.TextColor;
            lblWelcome.AutoSize = true;
            lblWelcome.Padding = new Padding(20);
            lblWelcome.Dock = DockStyle.Fill; 
            
            panelDesktop.Controls.Add(lblWelcome);
            panelDesktop.Controls.SetChildIndex(flowStats, 1); // Push to back
            panelDesktop.Controls.SetChildIndex(lblWelcome, 0); // Pull to front
        }

        private Panel CreateStatCard(string title, string value, Color color)
        {
            Panel card = new Panel();
            card.Size = new Size(280, 150);
            card.BackColor = color;
            card.Margin = new Padding(10); 
            
            Label lblValue = new Label();
            lblValue.Text = value;
            lblValue.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblValue.ForeColor = Color.White;
            lblValue.AutoSize = true;
            lblValue.Location = new Point(20, 40);
            card.Controls.Add(lblValue);

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 14F);
            lblTitle.ForeColor = Color.WhiteSmoke;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 15);
            card.Controls.Add(lblTitle);

            return card;
        }

        private Button CreateMenuButton(string text, int top)
        {
            Button btn = new Button();
            btn.Dock = DockStyle.Top;
            btn.Height = 60;
            btn.Text = text;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 11F);
            btn.ForeColor = Color.Gainsboro;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(15, 0, 0, 0);
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.BackColor = ThemeColor.PrimaryColor;
            
            btn.MouseEnter += (s, e) => { btn.BackColor = ThemeColor.ButtonHoverColor; btn.ForeColor = Color.White; };
            btn.MouseLeave += (s, e) => { btn.BackColor = ThemeColor.PrimaryColor; btn.ForeColor = Color.Gainsboro; };
            
            return btn;
        }

        private void OpenReportForm()
        {
            ReportForm reportForm = new ReportForm();
            reportForm.ShowDialog();
            LoadDashboardStats(); 
        }

        private void OpenAdminForm()
        {
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
            LoadDashboardStats(); 
        }
    }
}
