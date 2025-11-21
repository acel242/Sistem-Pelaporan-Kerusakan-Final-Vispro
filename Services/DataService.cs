using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CampusReportApp.Models;

namespace CampusReportApp.Services
{
    public class DataService
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reports.json");

        public List<ReportModel> LoadReports()
        {
            if (!File.Exists(_filePath))
            {
                return new List<ReportModel>();
            }

            try
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<ReportModel>>(json) ?? new List<ReportModel>();
            }
            catch
            {
                return new List<ReportModel>();
            }
        }

        public void SaveReport(ReportModel report)
        {
            List<ReportModel> reports = LoadReports();
            reports.Add(report);
            SaveAll(reports);
        }

        public void UpdateReport(ReportModel updatedReport)
        {
            List<ReportModel> reports = LoadReports();
            int index = reports.FindIndex(r => r.Id == updatedReport.Id);
            if (index != -1)
            {
                reports[index] = updatedReport;
                SaveAll(reports);
            }
        }

        public void DeleteReport(string reportId)
        {
            List<ReportModel> reports = LoadReports();
            reports.RemoveAll(r => r.Id == reportId);
            SaveAll(reports);
        }

        private void SaveAll(List<ReportModel> reports)
        {
            string json = JsonSerializer.Serialize(reports, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
