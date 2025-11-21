using System;
using System.Drawing;
using System.Windows.Forms;
using CampusReportApp.Models;
using CampusReportApp.Services;
using CampusReportApp.UI;

namespace CampusReportApp
{
    public class ReportForm : Form
    {
        private TextBox txtItemName;
        private ComboBox cmbCategory;
        private ComboBox cmbUrgency;
        private TextBox txtRoomNumber;
        private TextBox txtLocation;
        private TextBox txtDescription;
        private TextBox txtReporterName;
        private ModernButton btnSubmit;
        private DataService _dataService;

        public ReportForm()
        {
            _dataService = new DataService();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Lapor Kerusakan";
            this.Size = new Size(600, 750);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = ThemeColor.BackgroundColor;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Main Container with Padding
            Panel mainPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(40) };
            this.Controls.Add(mainPanel);

            // Title
            Label lblTitle = new Label { 
                Text = "Buat Laporan Baru", 
                Dock = DockStyle.Top, 
                Height = 60,
                Font = ThemeColor.HeaderFont, 
                ForeColor = ThemeColor.PrimaryColor 
            };
            mainPanel.Controls.Add(lblTitle);

            // Table Layout for Form Fields
            TableLayoutPanel table = new TableLayoutPanel();
            table.Dock = DockStyle.Top;
            table.AutoSize = true;
            table.ColumnCount = 2;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table.RowCount = 8;
            // Add rows dynamically...
            mainPanel.Controls.Add(table);
            table.BringToFront(); // Ensure it's below title? No, Dock=Top logic. 
            // We want Title Top, then Table Top.
            // Reverse Z-Order: Title (Bottom), Table (Top).
            mainPanel.Controls.SetChildIndex(lblTitle, 1);
            mainPanel.Controls.SetChildIndex(table, 0);

            // Helper to add controls
            void AddField(string label, Control control, int row, int col, int colSpan = 1)
            {
                Panel p = new Panel { Height = 70, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 10, 0) };
                Label l = new Label { Text = label, Dock = DockStyle.Top, Height = 25, Font = ThemeColor.PrimaryFont, ForeColor = ThemeColor.TextColor };
                control.Dock = DockStyle.Top;
                control.Width = p.Width; // Initial width
                p.Controls.Add(control);
                p.Controls.Add(l);
                l.BringToFront(); // Label on top of control visually? No, Dock=Top. 
                // We want Label Top, Control Top (below label).
                // So Label (Bottom Z), Control (Top Z).
                p.Controls.SetChildIndex(l, 1);
                p.Controls.SetChildIndex(control, 0);

                table.Controls.Add(p, col, row);
                if (colSpan > 1) table.SetColumnSpan(p, colSpan);
            }

            // Row 0: Item Name (Full Width)
            txtItemName = CreateTextBox();
            AddField("Nama Barang:", txtItemName, 0, 0, 2);

            // Row 1: Category & Urgency
            cmbCategory = CreateComboBox(new string[] { "Mebel", "Listrik", "Pipa/Air", "Peralatan IT", "Bangunan", "Lainnya" });
            AddField("Kategori:", cmbCategory, 1, 0);

            cmbUrgency = CreateComboBox(new string[] { "Rendah", "Sedang", "Tinggi", "Kritis" });
            AddField("Urgensi:", cmbUrgency, 1, 1);

            // Row 2: Location & Room
            txtLocation = CreateTextBox();
            AddField("Gedung/Lokasi:", txtLocation, 2, 0);

            txtRoomNumber = CreateTextBox();
            AddField("Nomor Ruangan:", txtRoomNumber, 2, 1);

            // Row 3: Description (Full Width, Taller)
            txtDescription = CreateTextBox();
            txtDescription.Height = 100;
            txtDescription.Multiline = true;
            // Custom panel for description to handle height
            Panel pDesc = new Panel { Height = 130, Dock = DockStyle.Fill };
            Label lDesc = new Label { Text = "Deskripsi Kerusakan:", Dock = DockStyle.Top, Height = 25, Font = ThemeColor.PrimaryFont, ForeColor = ThemeColor.TextColor };
            txtDescription.Dock = DockStyle.Fill;
            pDesc.Controls.Add(txtDescription);
            pDesc.Controls.Add(lDesc);
            pDesc.Controls.SetChildIndex(lDesc, 1);
            pDesc.Controls.SetChildIndex(txtDescription, 0);
            table.Controls.Add(pDesc, 0, 3);
            table.SetColumnSpan(pDesc, 2);

            // Row 4: Reporter Name
            txtReporterName = CreateTextBox();
            AddField("Nama Pelapor:", txtReporterName, 4, 0, 2);

            // Submit Button (Bottom Panel)
            Panel pnlBottom = new Panel { Dock = DockStyle.Top, Height = 80, Padding = new Padding(0, 20, 0, 0) };
            btnSubmit = new ModernButton { Text = "Kirim Laporan", Dock = DockStyle.Fill, Height = 50 };
            btnSubmit.Click += BtnSubmit_Click;
            pnlBottom.Controls.Add(btnSubmit);
            mainPanel.Controls.Add(pnlBottom);
            // Order: Title, Table, Bottom
            mainPanel.Controls.SetChildIndex(lblTitle, 2);
            mainPanel.Controls.SetChildIndex(table, 1);
            mainPanel.Controls.SetChildIndex(pnlBottom, 0);
        }

        private TextBox CreateTextBox()
        {
            return new TextBox { Font = ThemeColor.PrimaryFont, BorderStyle = BorderStyle.FixedSingle };
        }

        private ComboBox CreateComboBox(string[] items)
        {
            ComboBox cmb = new ComboBox { Font = ThemeColor.PrimaryFont, DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat };
            cmb.Items.AddRange(items);
            return cmb;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text) || string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Mohon isi Nama Barang dan Lokasi.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var report = new ReportModel
            {
                ItemName = txtItemName.Text,
                Category = cmbCategory.SelectedItem?.ToString() ?? "Lainnya",
                Urgency = cmbUrgency.SelectedItem?.ToString() ?? "Rendah",
                RoomNumber = txtRoomNumber.Text,
                Location = txtLocation.Text,
                Description = txtDescription.Text,
                ReporterName = txtReporterName.Text,
                DateReported = DateTime.Now,
                Status = "Pending"
            };

            _dataService.SaveReport(report);
            MessageBox.Show("Laporan berhasil dikirim!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
