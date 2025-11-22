using System.Drawing;
using System.Windows.Forms;

namespace CampusReportApp
{
    partial class AdminForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.picEvidence = new System.Windows.Forms.PictureBox();
            this.lblEvidence = new System.Windows.Forms.Label();
            
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnResolve = new CampusReportApp.UI.ModernButton();
            this.btnDelete = new CampusReportApp.UI.ModernButton();
            this.btnExport = new CampusReportApp.UI.ModernButton();

            // Columns
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReporter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEvidence)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = CampusReportApp.UI.ThemeColor.PrimaryColor;
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.pnlHeader.Name = "pnlHeader";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = CampusReportApp.UI.ThemeColor.HeaderFont;
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(20, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Text = "Kelola Laporan";

            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = CampusReportApp.UI.ThemeColor.BackgroundColor;
            this.pnlFilter.Controls.Add(this.lblSearch);
            this.pnlFilter.Controls.Add(this.txtSearch);
            this.pnlFilter.Controls.Add(this.lblFilter);
            this.pnlFilter.Controls.Add(this.cmbFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Height = 60;
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(20);
            this.pnlFilter.Name = "pnlFilter";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.lblSearch.Location = new System.Drawing.Point(20, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "Cari:";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.txtSearch.Location = new System.Drawing.Point(80, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 27);
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.lblFilter.Location = new System.Drawing.Point(320, 20);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Text = "Status:";
            // 
            // cmbFilter
            // 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFilter.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.cmbFilter.Items.AddRange(new object[] { "Semua", "Pending", "Resolved" });
            this.cmbFilter.Location = new System.Drawing.Point(380, 18);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(150, 27);
            this.cmbFilter.SelectedIndex = 0;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.CmbFilter_SelectedIndexChanged);

            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 140); // Below Header + Filter
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgvReports);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pnlDetails);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(20);
            this.splitContainer.Size = new System.Drawing.Size(1000, 460);
            this.splitContainer.SplitterDistance = 650;
            this.splitContainer.TabIndex = 5;

            // 
            // dgvReports
            // 
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReports.BackgroundColor = System.Drawing.Color.White;
            this.dgvReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReports.ColumnHeadersDefaultCellStyle.BackColor = CampusReportApp.UI.ThemeColor.SecondaryColor;
            this.dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReports.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvReports.EnableHeadersVisualStyles = false;
            this.dgvReports.DefaultCellStyle.Font = CampusReportApp.UI.ThemeColor.PrimaryFont;
            this.dgvReports.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvReports.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvReports.DefaultCellStyle.SelectionBackColor = CampusReportApp.UI.ThemeColor.ButtonHoverColor;
            this.dgvReports.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvReports.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReports.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.ReadOnly = true;
            this.dgvReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReports.AutoGenerateColumns = false;
            this.dgvReports.SelectionChanged += new System.EventHandler(this.DgvReports_SelectionChanged);
            
            // Columns
            this.colItemName.HeaderText = "Barang";
            this.colItemName.DataPropertyName = "ItemName";
            this.colCategory.HeaderText = "Kategori";
            this.colCategory.DataPropertyName = "Category";
            this.colLocation.HeaderText = "Lokasi";
            this.colLocation.DataPropertyName = "Location";
            this.colReporter.HeaderText = "Pelapor";
            this.colReporter.DataPropertyName = "ReporterName";
            this.colStatus.HeaderText = "Status";
            this.colStatus.DataPropertyName = "Status";
            this.colDate.HeaderText = "Tanggal";
            this.colDate.DataPropertyName = "DateReported";

            this.dgvReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colItemName, this.colCategory, this.colLocation, this.colReporter, this.colStatus, this.colDate
            });

            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.White;
            this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetails.Controls.Add(this.picEvidence);
            this.pnlDetails.Controls.Add(this.lblEvidence);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Name = "pnlDetails";
            // 
            // lblEvidence
            // 
            this.lblEvidence.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEvidence.Font = CampusReportApp.UI.ThemeColor.HeaderFont;
            this.lblEvidence.ForeColor = CampusReportApp.UI.ThemeColor.PrimaryColor;
            this.lblEvidence.Height = 40;
            this.lblEvidence.Text = "Bukti Foto";
            this.lblEvidence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picEvidence
            // 
            this.picEvidence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picEvidence.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEvidence.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picEvidence.Name = "picEvidence";

            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = CampusReportApp.UI.ThemeColor.BackgroundColor;
            this.pnlButtons.Controls.Add(this.btnResolve);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnExport);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Height = 100;
            this.pnlButtons.Name = "pnlButtons";
            // 
            // btnResolve
            // 
            this.btnResolve.BackColor = CampusReportApp.UI.ThemeColor.SuccessColor;
            this.btnResolve.Location = new System.Drawing.Point(50, 30);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(180, 40);
            this.btnResolve.Text = "✅ Tandai Selesai";
            this.btnResolve.Click += new System.EventHandler(this.BtnResolve_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = CampusReportApp.UI.ThemeColor.AccentColor;
            this.btnDelete.Location = new System.Drawing.Point(260, 30);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(180, 40);
            this.btnDelete.Text = "🗑️ Hapus Laporan";
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = CampusReportApp.UI.ThemeColor.SecondaryColor;
            this.btnExport.Location = new System.Drawing.Point(470, 30);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(180, 40);
            this.btnExport.Text = "📄 Export CSV";
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);

            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = CampusReportApp.UI.ThemeColor.BackgroundColor;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Admin - Lihat Laporan";
            
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEvidence)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Panel pnlButtons;
        private CampusReportApp.UI.ModernButton btnResolve;
        private CampusReportApp.UI.ModernButton btnDelete;
        private CampusReportApp.UI.ModernButton btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReporter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label lblEvidence;
        private System.Windows.Forms.PictureBox picEvidence;
    }
}
