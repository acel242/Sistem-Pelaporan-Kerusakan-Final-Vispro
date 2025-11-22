using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using CampusReportApp.Models;

namespace CampusReportApp.Services
{
    public class DataService
    {
        private readonly DatabaseHelper _db;

        public DataService()
        {
            _db = new DatabaseHelper();
            // Ensure DB exists on startup
            _db.InitializeDatabase();
        }

        public List<ReportModel> LoadReports()
        {
            var reports = new List<ReportModel>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM reports ORDER BY DateReported DESC";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reports.Add(new ReportModel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            ItemName = reader["ItemName"].ToString(),
                            Category = reader["Category"].ToString(),
                            Urgency = reader["Urgency"].ToString(),
                            RoomNumber = reader["RoomNumber"].ToString(),
                            Location = reader["Location"].ToString(),
                            Description = reader["Description"].ToString(),
                            ReporterName = reader["ReporterName"].ToString(),
                            DateReported = Convert.ToDateTime(reader["DateReported"]),
                            Status = reader["Status"].ToString(),
                            ImagePath = reader["ImagePath"]?.ToString()
                        });
                    }
                }
            }
            return reports;
        }

        public void SaveReport(ReportModel report)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO reports (ItemName, Category, Urgency, RoomNumber, Location, Description, ReporterName, DateReported, Status, ImagePath)
                    VALUES (@ItemName, @Category, @Urgency, @RoomNumber, @Location, @Description, @ReporterName, @DateReported, @Status, @ImagePath)";
                
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ItemName", report.ItemName);
                    cmd.Parameters.AddWithValue("@Category", report.Category);
                    cmd.Parameters.AddWithValue("@Urgency", report.Urgency);
                    cmd.Parameters.AddWithValue("@RoomNumber", report.RoomNumber);
                    cmd.Parameters.AddWithValue("@Location", report.Location);
                    cmd.Parameters.AddWithValue("@Description", report.Description);
                    cmd.Parameters.AddWithValue("@ReporterName", report.ReporterName);
                    cmd.Parameters.AddWithValue("@DateReported", report.DateReported);
                    cmd.Parameters.AddWithValue("@Status", report.Status);
                    cmd.Parameters.AddWithValue("@ImagePath", report.ImagePath ?? (object)DBNull.Value);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateReportStatus(int id, string status)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "UPDATE reports SET Status = @Status WHERE Id = @Id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteReport(int id)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM reports WHERE Id = @Id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        // User Authentication
        public bool AuthenticateUser(string username, string password)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                // In production, hash the password before comparing!
                string query = "SELECT Count(*) FROM users WHERE Username = @Username AND PasswordHash = @Password";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}
