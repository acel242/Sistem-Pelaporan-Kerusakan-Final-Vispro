using System;
using System.Drawing;
using System.Windows.Forms;
using CampusReportApp.Models;
using CampusReportApp.Services;
using CampusReportApp.UI;

namespace CampusReportApp
{
    public partial class ReportForm : Form
    {
        private DataService _dataService;

        public ReportForm()
        {
            _dataService = new DataService();
            InitializeComponent();
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
