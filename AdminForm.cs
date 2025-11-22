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
    public partial class AdminForm : Form
    {
        private DataService _dataService;

        public AdminForm()
        {
            _dataService = new DataService();
            InitializeComponent();
            LoadData();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void CmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var reports = _dataService.LoadReports();

            // Filter by Search
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                reports = reports.Where(r => 
                    r.ItemName.ToLower().Contains(txtSearch.Text.ToLower()) || 
                    r.ReporterName.ToLower().Contains(txtSearch.Text.ToLower())
                ).ToList();
            }

            // Filter by Status
            if (cmbFilter.SelectedIndex > 0)
            {
                string status = cmbFilter.SelectedItem.ToString();
                reports = reports.Where(r => r.Status == status).ToList();
            }

            dgvReports.DataSource = null;
            dgvReports.DataSource = reports;
        }

        private void DgvReports_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count > 0)
            {
                var report = (ReportModel)dgvReports.SelectedRows[0].DataBoundItem;
                if (!string.IsNullOrEmpty(report.ImagePath) && System.IO.File.Exists(report.ImagePath))
                {
                    picEvidence.Image = Image.FromFile(report.ImagePath);
                }
                else
                {
                    picEvidence.Image = null;
                }
            }
            else
            {
                picEvidence.Image = null;
            }
        }

        private void BtnResolve_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count > 0)
            {
                var report = (ReportModel)dgvReports.SelectedRows[0].DataBoundItem;
                _dataService.UpdateReportStatus(report.Id, "Resolved");
                LoadData();
                MessageBox.Show("Laporan ditandai selesai.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count > 0)
            {
                var report = (ReportModel)dgvReports.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show("Hapus laporan ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _dataService.DeleteReport(report.Id);
                    LoadData();
                }
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var reports = (List<ReportModel>)dgvReports.DataSource;
                if (reports == null || reports.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk diexport.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV File|*.csv";
                    sfd.FileName = "Laporan_Kampus_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
                        {
                            // Header
                            sw.WriteLine("ID,Barang,Kategori,Lokasi,Pelapor,Deskripsi,Status,Tanggal,Foto");

                            // Data
                            foreach (var r in reports)
                            {
                                string line = $"{r.Id},{EscapeCsv(r.ItemName)},{EscapeCsv(r.Category)},{EscapeCsv(r.Location)},{EscapeCsv(r.ReporterName)},{EscapeCsv(r.Description)},{r.Status},{r.DateReported},{EscapeCsv(r.ImagePath)}";
                                sw.WriteLine(line);
                            }
                        }
                        MessageBox.Show("Export berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error export: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string EscapeCsv(string field)
        {
            if (string.IsNullOrEmpty(field)) return "";
            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
            {
                return "\"" + field.Replace("\"", "\"\"") + "\"";
            }
            return field;
        }
    }
}
