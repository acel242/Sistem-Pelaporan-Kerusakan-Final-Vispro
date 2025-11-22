using System;
using System.Drawing;
using System.Windows.Forms;
using CampusReportApp.Models;
using CampusReportApp.Services;
using CampusReportApp.UI;
using System.IO;

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

        private string _selectedImagePath;

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Pilih Foto Kerusakan";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = openFileDialog.FileName;
                    picPreview.Image = Image.FromFile(_selectedImagePath);
                }
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text) || string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Mohon isi Nama Barang dan Lokasi.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string savedImagePath = null;
            if (!string.IsNullOrEmpty(_selectedImagePath))
            {
                // Create Images directory if not exists
                string imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                if (!Directory.Exists(imagesDir))
                {
                    Directory.CreateDirectory(imagesDir);
                }

                // Copy file to Images directory with unique name
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(_selectedImagePath)}";
                savedImagePath = Path.Combine(imagesDir, fileName);
                File.Copy(_selectedImagePath, savedImagePath);
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
                Status = "Pending",
                ImagePath = savedImagePath
            };

            _dataService.SaveReport(report);
            MessageBox.Show("Laporan berhasil dikirim!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
