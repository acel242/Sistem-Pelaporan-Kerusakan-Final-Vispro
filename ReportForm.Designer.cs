using System.Drawing;
using System.Windows.Forms;

namespace CampusReportApp
{
    partial class ReportForm
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSubmit = new CampusReportApp.UI.ModernButton();
            
            // Field Panels
            this.pnlItemName = new System.Windows.Forms.Panel();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();

            this.pnlCategory = new System.Windows.Forms.Panel();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();

            this.pnlUrgency = new System.Windows.Forms.Panel();
            this.lblUrgency = new System.Windows.Forms.Label();
            this.cmbUrgency = new System.Windows.Forms.ComboBox();

            this.pnlLocation = new System.Windows.Forms.Panel();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();

            this.pnlRoom = new System.Windows.Forms.Panel();
            this.lblRoom = new System.Windows.Forms.Label();
            this.txtRoomNumber = new System.Windows.Forms.TextBox();

            this.pnlDescription = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();

            this.pnlReporter = new System.Windows.Forms.Panel();
            this.lblReporter = new System.Windows.Forms.Label();
            this.txtReporterName = new System.Windows.Forms.TextBox();

            this.pnlImage = new System.Windows.Forms.Panel();
            this.lblImage = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnUpload = new CampusReportApp.UI.ModernButton();

            this.mainPanel.SuspendLayout();
            this.table.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlItemName.SuspendLayout();
            this.pnlCategory.SuspendLayout();
            this.pnlUrgency.SuspendLayout();
            this.pnlLocation.SuspendLayout();
            this.pnlRoom.SuspendLayout();
            this.pnlDescription.SuspendLayout();
            this.pnlReporter.SuspendLayout();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();

            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.table);
            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Controls.Add(this.pnlBottom);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(600, 700);
            this.mainPanel.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = CampusReportApp.UI.ThemeColor.HeaderFont;
            this.lblTitle.ForeColor = CampusReportApp.UI.ThemeColor.PrimaryColor;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(560, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Formulir Laporan Kerusakan";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // table
            // 
            this.table.ColumnCount = 2;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.Controls.Add(this.pnlItemName, 0, 0);
            this.table.Controls.Add(this.pnlCategory, 0, 1);
            this.table.Controls.Add(this.pnlUrgency, 1, 1);
            this.table.Controls.Add(this.pnlLocation, 0, 2);
            this.table.Controls.Add(this.pnlRoom, 1, 2);
            this.table.Controls.Add(this.pnlDescription, 0, 3);
            this.table.Controls.Add(this.pnlReporter, 0, 4);
            this.table.Controls.Add(this.pnlImage, 0, 5);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(20, 60);
            this.table.Name = "table";
            this.table.RowCount = 6;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F)); // Item
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F)); // Cat/Urg
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F)); // Loc/Room
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F)); // Desc
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F)); // Reporter
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F)); // Image
            this.table.Size = new System.Drawing.Size(560, 540);
            this.table.TabIndex = 1;

            // Spans
            this.table.SetColumnSpan(this.pnlItemName, 2);
            this.table.SetColumnSpan(this.pnlDescription, 2);
            this.table.SetColumnSpan(this.pnlReporter, 2);
            this.table.SetColumnSpan(this.pnlImage, 2);

            // 
            // pnlItemName
            // 
            this.pnlItemName.Controls.Add(this.txtItemName);
            this.pnlItemName.Controls.Add(this.lblItemName);
            this.pnlItemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItemName.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            // 
            // lblItemName
            // 
            this.lblItemName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblItemName.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.lblItemName.Text = "Nama Barang:";
            this.lblItemName.Height = 25;
            // 
            // txtItemName
            // 
            this.txtItemName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtItemName.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // pnlCategory
            // 
            this.pnlCategory.Controls.Add(this.cmbCategory);
            this.pnlCategory.Controls.Add(this.lblCategory);
            this.pnlCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCategory.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            // 
            // lblCategory
            // 
            this.lblCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCategory.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.lblCategory.Text = "Kategori:";
            this.lblCategory.Height = 25;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbCategory.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Items.AddRange(new object[] { "Fasilitas Kelas", "Kelistrikan", "Air/Pipa", "Internet/Jaringan", "Lainnya" });
            this.cmbCategory.SelectedIndex = 0;

            // 
            // pnlUrgency
            // 
            this.pnlUrgency.Controls.Add(this.cmbUrgency);
            this.pnlUrgency.Controls.Add(this.lblUrgency);
            this.pnlUrgency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUrgency.Margin = new System.Windows.Forms.Padding(10, 0, 0, 10);
            // 
            // lblUrgency
            // 
            this.lblUrgency.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUrgency.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.lblUrgency.Text = "Urgensi:";
            this.lblUrgency.Height = 25;
            // 
            // cmbUrgency
            // 
            this.cmbUrgency.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbUrgency.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.cmbUrgency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUrgency.Items.AddRange(new object[] { "Rendah", "Sedang", "Tinggi", "Darurat" });
            this.cmbUrgency.SelectedIndex = 0;

            // 
            // pnlLocation
            // 
            this.pnlLocation.Controls.Add(this.txtLocation);
            this.pnlLocation.Controls.Add(this.lblLocation);
            this.pnlLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLocation.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            // 
            // lblLocation
            // 
            this.lblLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLocation.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.lblLocation.Text = "Lokasi (Gedung/Lantai):";
            this.lblLocation.Height = 25;
            // 
            // txtLocation
            // 
            this.txtLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLocation.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // 
            // pnlRoom
            // 
            this.pnlRoom.Controls.Add(this.txtRoomNumber);
            this.pnlRoom.Controls.Add(this.lblRoom);
            this.pnlRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoom.Margin = new System.Windows.Forms.Padding(10, 0, 0, 10);
            // 
            // lblRoom
            // 
            this.lblRoom.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRoom.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.lblRoom.Text = "Nomor Ruangan:";
            this.lblRoom.Height = 25;
            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtRoomNumber.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.txtRoomNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // 
            // pnlDescription
            // 
            this.pnlDescription.Controls.Add(this.txtDescription);
            this.pnlDescription.Controls.Add(this.lblDescription);
            this.pnlDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDescription.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescription.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.lblDescription.Text = "Deskripsi Masalah:";
            this.lblDescription.Height = 25;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Multiline = true;

            // 
            // pnlReporter
            // 
            this.pnlReporter.Controls.Add(this.txtReporterName);
            this.pnlReporter.Controls.Add(this.lblReporter);
            this.pnlReporter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReporter.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            // 
            // lblReporter
            // 
            this.lblReporter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReporter.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.lblReporter.Text = "Nama Pelapor (Opsional):";
            this.lblReporter.Height = 25;
            // 
            // txtReporterName
            // 
            this.txtReporterName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtReporterName.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.txtReporterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // 
            // pnlImage
            // 
            this.pnlImage.Controls.Add(this.btnUpload);
            this.pnlImage.Controls.Add(this.picPreview);
            this.pnlImage.Controls.Add(this.lblImage);
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImage.Height = 150;
            this.pnlImage.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            // 
            // lblImage
            // 
            this.lblImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblImage.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.lblImage.ForeColor = CampusReportApp.UI.ThemeColor.TextColor;
            this.lblImage.Height = 25;
            this.lblImage.Text = "Foto Bukti:";
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.picPreview.Width = 120;
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // btnUpload
            // 
            this.btnUpload.Text = "Upload Foto";
            this.btnUpload.Location = new System.Drawing.Point(130, 30);
            this.btnUpload.Width = 120;
            this.btnUpload.Height = 40;
            this.btnUpload.Click += new System.EventHandler(this.BtnUpload_Click);

            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnSubmit);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 80;
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            
            // 
            // btnSubmit
            // 
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubmit.Text = "Kirim Laporan";
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);

            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = CampusReportApp.UI.ThemeColor.BackgroundColor;
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.Add(this.mainPanel);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lapor Kerusakan";
            
            this.mainPanel.ResumeLayout(false);
            this.table.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlItemName.ResumeLayout(false);
            this.pnlItemName.PerformLayout();
            this.pnlCategory.ResumeLayout(false);
            this.pnlUrgency.ResumeLayout(false);
            this.pnlLocation.ResumeLayout(false);
            this.pnlLocation.PerformLayout();
            this.pnlRoom.ResumeLayout(false);
            this.pnlRoom.PerformLayout();
            this.pnlDescription.ResumeLayout(false);
            this.pnlDescription.PerformLayout();
            this.pnlReporter.ResumeLayout(false);
            this.pnlReporter.PerformLayout();
            this.pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Panel pnlBottom;
        private CampusReportApp.UI.ModernButton btnSubmit;
        
        private System.Windows.Forms.Panel pnlItemName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtItemName;

        private System.Windows.Forms.Panel pnlCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;

        private System.Windows.Forms.Panel pnlUrgency;
        private System.Windows.Forms.Label lblUrgency;
        private System.Windows.Forms.ComboBox cmbUrgency;

        private System.Windows.Forms.Panel pnlLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;

        private System.Windows.Forms.Panel pnlRoom;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.TextBox txtRoomNumber;

        private System.Windows.Forms.Panel pnlDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Panel pnlReporter;
        private System.Windows.Forms.Label lblReporter;
        private System.Windows.Forms.TextBox txtReporterName;

        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.PictureBox picPreview;
        private CampusReportApp.UI.ModernButton btnUpload;
    }
}
