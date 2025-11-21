using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CampusReportApp.Models;
using CampusReportApp.Services;
using CampusReportApp.UI;

namespace CampusReportApp
{
    public class AdminForm : Form
    {
        private DataGridView dgvReports;
        private DataService _dataService;
        private TextBox txtSearch;
        private ComboBox cmbFilter;

        public AdminForm()
        {
            _dataService = new DataService();
            SetupUI();
            LoadData();
        }

        private void SetupUI()
        {
            this.Text = "Admin - Lihat Laporan";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = ThemeColor.BackgroundColor;

            // Header
            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 80, BackColor = ThemeColor.PrimaryColor };
            Label lblHeader = new Label { Text = "Kelola Laporan", Font = ThemeColor.HeaderFont, ForeColor = Color.White, AutoSize = true, Location = new Point(20, 20) };
            pnlHeader.Controls.Add(lblHeader);
            this.Controls.Add(pnlHeader);

            // Filter/Search Panel
            Panel pnlFilter = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = ThemeColor.BackgroundColor, Padding = new Padding(20) };
            this.Controls.Add(pnlFilter);

            Label lblSearch = new Label { Text = "Cari:", Location = new Point(20, 20), AutoSize = true, Font = ThemeColor.PrimaryFont };
            pnlFilter.Controls.Add(lblSearch);

            txtSearch = new TextBox { Location = new Point(80, 18), Width = 200, Font = ThemeColor.PrimaryFont, BorderStyle = BorderStyle.FixedSingle };
            txtSearch.TextChanged += (s, e) => LoadData();
            pnlFilter.Controls.Add(txtSearch);

            Label lblFilter = new Label { Text = "Status:", Location = new Point(320, 20), AutoSize = true, Font = ThemeColor.PrimaryFont };
            pnlFilter.Controls.Add(lblFilter);

            cmbFilter = new ComboBox { Location = new Point(380, 18), Width = 150, Font = ThemeColor.PrimaryFont, DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat };
            cmbFilter.Items.AddRange(new string[] { "Semua", "Pending", "Resolved" });
            cmbFilter.SelectedIndex = 0;
            cmbFilter.SelectedIndexChanged += (s, e) => LoadData();
            pnlFilter.Controls.Add(cmbFilter);

            // DataGridView
            dgvReports = new DataGridView();
            dgvReports.Dock = DockStyle.Fill;
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReports.ReadOnly = true;
            dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReports.BackgroundColor = Color.White;
            dgvReports.BorderStyle = BorderStyle.None;
            dgvReports.AutoGenerateColumns = false; // Manual columns
            
            // Headers
            dgvReports.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
            dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReports.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvReports.EnableHeadersVisualStyles = false;
            
            // Rows
            dgvReports.DefaultCellStyle.Font = ThemeColor.PrimaryFont;
            dgvReports.DefaultCellStyle.ForeColor = Color.Black;
            dgvReports.DefaultCellStyle.BackColor = Color.White;
            dgvReports.DefaultCellStyle.SelectionBackColor = ThemeColor.ButtonHoverColor;
            dgvReports.DefaultCellStyle.SelectionForeColor = Color.White;
            
            // Alternating Rows
            dgvReports.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvReports.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            // Add Columns
            dgvReports.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Barang", DataPropertyName = "ItemName" });
            dgvReports.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Kategori", DataPropertyName = "Category" });
            dgvReports.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Lokasi", DataPropertyName = "Location" });
            dgvReports.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Pelapor", DataPropertyName = "ReporterName" });
            dgvReports.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status" });
            dgvReports.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tanggal", DataPropertyName = "DateReported" });

            this.Controls.Add(dgvReports);

            // Buttons Panel
            Panel pnlButtons = new Panel { Dock = DockStyle.Bottom, Height = 100, BackColor = ThemeColor.BackgroundColor };
            this.Controls.Add(pnlButtons);

            ModernButton btnResolve = new ModernButton { Text = "✅ Tandai Selesai", Location = new Point(50, 30), Width = 180, BackColor = ThemeColor.SuccessColor };
            btnResolve.Click += BtnResolve_Click;
            btnResolve.MouseEnter += (s, e) => { btnResolve.BackColor = Color.FromArgb(39, 174, 96); };
            btnResolve.MouseLeave += (s, e) => { btnResolve.BackColor = ThemeColor.SuccessColor; };
            pnlButtons.Controls.Add(btnResolve);

            ModernButton btnDelete = new ModernButton { Text = "🗑️ Hapus Laporan", Location = new Point(260, 30), Width = 180, BackColor = ThemeColor.AccentColor };
            btnDelete.Click += BtnDelete_Click;
            btnDelete.MouseEnter += (s, e) => { btnDelete.BackColor = Color.FromArgb(192, 57, 43); };
            btnDelete.MouseLeave += (s, e) => { btnDelete.BackColor = ThemeColor.AccentColor; };
            pnlButtons.Controls.Add(btnDelete);
            
            // Z-Order for Docking (Reverse priority)
            // We want Grid to fill remaining space, so it should be at the TOP of Z-order (Index 0)
            // But wait, Dock=Fill fills *remaining* space.
            // If we add Grid last (Index 0), it fills space left by Header, Filter, Buttons.
            // So we need Header, Filter, Buttons to be docked *before* Grid?
            // No, "The control that is to fill the remaining space should be the first control in the Controls collection (index 0)."
            // So:
            // 1. Add Header, Filter, Buttons (they go to bottom of Z-order as we add more?)
            // Actually Controls.Add puts at Index 0.
            // Add Header -> Index 0.
            // Add Filter -> Index 0 (Header 1).
            // Add Grid -> Index 0 (Filter 1, Header 2).
            // Add Buttons -> Index 0 (Grid 1, Filter 2, Header 3).
            
            // If we leave it like this:
            // Buttons (Dock Bottom) -> Docked first? No, Z-order bottom docked first?
            // WinForms Docking: "Controls are docked in reverse z-order." (Bottom to Top).
            // Index 3 (Header) -> Dock Top.
            // Index 2 (Filter) -> Dock Top.
            // Index 1 (Grid) -> Dock Fill.
            // Index 0 (Buttons) -> Dock Bottom.
            
            // If Grid is docked Fill *before* Buttons is docked Bottom, Grid takes everything. Buttons sits on top or is obscured.
            // We want Buttons to be docked *before* Grid takes the rest.
            // So Buttons needs to be *lower* in Z-order (Higher Index) than Grid.
            // So Grid must be Index 0.
            
            // Current Add Order in my code above:
            // ... Add(dgvReports) -> Index 0
            // ... Add(pnlButtons) -> Index 0 (dgvReports becomes 1)
            
            // So dgvReports is Index 1. pnlButtons is Index 0.
            // Docking order (Reverse Z):
            // ...
            // dgvReports (Index 1) -> Dock Fill.
            // pnlButtons (Index 0) -> Dock Bottom.
            
            // Result: Grid fills everything. Buttons sits on top of Grid at bottom.
            // This is actually fine visually usually, but let's be precise.
            // We want Buttons to take space *allocated* to it.
            // So Buttons must be docked *before* Grid.
            // So Buttons must be *lower* Z-order (Higher Index).
            
            // So we want:
            // Header (Highest Index)
            // Filter
            // Buttons
            // Grid (Lowest Index / 0)
            
            this.Controls.SetChildIndex(pnlHeader, 3);
            this.Controls.SetChildIndex(pnlFilter, 2);
            this.Controls.SetChildIndex(pnlButtons, 1);
            this.Controls.SetChildIndex(dgvReports, 0);
        }

        private void LoadData()
        {
            var reports = _dataService.LoadReports();

            // Filter
            if (cmbFilter.SelectedItem.ToString() != "Semua")
            {
                reports = reports.Where(r => r.Status == cmbFilter.SelectedItem.ToString()).ToList();
            }

            // Search
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string term = txtSearch.Text.ToLower();
                reports = reports.Where(r => 
                    r.ItemName.ToLower().Contains(term) || 
                    r.ReporterName.ToLower().Contains(term) ||
                    r.Location.ToLower().Contains(term)
                ).ToList();
            }

            dgvReports.DataSource = null;
            dgvReports.DataSource = reports;
        }

        private void BtnResolve_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count > 0)
            {
                var report = (ReportModel)dgvReports.SelectedRows[0].DataBoundItem;
                report.Status = "Resolved";
                _dataService.UpdateReport(report);
                LoadData();
                MessageBox.Show("Laporan ditandai selesai.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count > 0)
            {
                var report = (ReportModel)dgvReports.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show($"Apakah Anda yakin ingin menghapus laporan untuk {report.ItemName}?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _dataService.DeleteReport(report.Id);
                    LoadData();
                }
            }
        }
    }
}
