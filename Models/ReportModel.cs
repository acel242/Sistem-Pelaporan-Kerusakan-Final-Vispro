using System;

namespace CampusReportApp.Models
{
    public class ReportModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; } // Furniture, Electrical, etc.
        public string Urgency { get; set; } // Low, Medium, High
        public string RoomNumber { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string ReporterName { get; set; }
        public DateTime DateReported { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending";
        public string ImagePath { get; set; } // Pending, In Progress, Resolved
    }
}
