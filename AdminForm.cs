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
