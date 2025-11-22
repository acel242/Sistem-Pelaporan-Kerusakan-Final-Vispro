using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CampusReportApp.Services
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper()
        {
            // Default XAMPP credentials: user=root, password= (empty), database=campus_report_db
            _connectionString = "Server=localhost;Database=campus_report_db;User ID=root;Password=;";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public void InitializeDatabase()
        {
            // Connect to server without database first to create it if not exists
            string serverConnection = "Server=localhost;User ID=root;Password=;";
            using (var conn = new MySqlConnection(serverConnection))
            {
                try
                {
                    conn.Open();
                    var cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS campus_report_db;", conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Gagal membuat database. Pastikan XAMPP (MySQL) sudah berjalan. Error: " + ex.Message);
                }
            }

            // Now connect to the database and create tables
            using (var conn = GetConnection())
            {
                conn.Open();
                
                // Table: reports
                string createReportsTable = @"
                    CREATE TABLE IF NOT EXISTS reports (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        ItemName VARCHAR(255) NOT NULL,
                        Category VARCHAR(100),
                        Urgency VARCHAR(50),
                        RoomNumber VARCHAR(50),
                        Location VARCHAR(255),
                        Description TEXT,
                        ReporterName VARCHAR(255),
                        DateReported DATETIME,
                        Status VARCHAR(50),
                        ImagePath VARCHAR(500)
                    );";

                // Table: users
                string createUsersTable = @"
                    CREATE TABLE IF NOT EXISTS users (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Username VARCHAR(100) UNIQUE NOT NULL,
                        PasswordHash VARCHAR(255) NOT NULL,
                        Role VARCHAR(50) NOT NULL,
                        Email VARCHAR(255)
                    );";

                // Insert Default Admin if not exists
                string insertAdmin = @"
                    INSERT IGNORE INTO users (Id, Username, PasswordHash, Role) 
                    VALUES (1, 'admin', 'admin123', 'Admin');"; 
                // Note: In production, use real hashing! For now, keeping simple as per previous logic.

                new MySqlCommand(createReportsTable, conn).ExecuteNonQuery();
                new MySqlCommand(createUsersTable, conn).ExecuteNonQuery();
                new MySqlCommand(insertAdmin, conn).ExecuteNonQuery();
            }
        }
    }
}
