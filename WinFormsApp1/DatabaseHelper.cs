using System;
using System.Data;
using System.Data.SQLite;

// Ensure you have installed the SQLite package via NuGet
// Example: Install-Package System.Data.SQLite
using System.IO;

namespace WinFormsApp1
{
    public class DatabaseHelper
    {
        // Use an absolute path to store the database in the application directory
        private static readonly string DatabasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_QRGenerator.db");
        private static readonly string ConnectionString = $"Data Source={DatabasePath};Version=3;";
        private static bool _databaseInitialized = false;

        // Initialize the database if it doesn't exist
        public static bool InitializeDatabase()
        {
            try
            {
                if (_databaseInitialized) return true;
                bool newDatabase = !File.Exists(DatabasePath);
                if (newDatabase)
                {
                    SQLiteConnection.CreateFile(DatabasePath);
                }
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Create the Users table if it doesn't exist
                    string createUsersQuery = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT UNIQUE NOT NULL,
                            PasswordHash TEXT NOT NULL,
                            CreatedAt TEXT NOT NULL
                        )";
                    using (var command = new SQLiteCommand(createUsersQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Create the Favourites table if it doesn't exist
                    string createFavouritesQuery = @"
                        CREATE TABLE IF NOT EXISTS Favourites (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            FavouriteText TEXT NOT NULL
                        )";
                    using (var command = new SQLiteCommand(createFavouritesQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                _databaseInitialized = true;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize database: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        // Get a new connection to the database
        public static SQLiteConnection GetConnection()
        {
            if (!_databaseInitialized)
            {
                InitializeDatabase();
            }
            return new SQLiteConnection(ConnectionString);
        }

        // ...existing code...

        // Example fix for nullability warning in ExecuteNonQuery:
        public static int ExecuteNonQuery(string commandText, Dictionary<string, object>? parameters = null)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(commandText, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.AddWithValue($"@{param.Key}", param.Value);
                            }
                        }
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        // Fix ExecuteScalar method by adding missing SQLiteCommand declaration
        public static object? ExecuteScalar(string query, Dictionary<string, object>? parameters = null)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.AddWithValue($"@{param.Key}", param.Value);
                            }
                        }
                        return command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        // In ExecuteQuery method - Replace commandText with query
        public static DataTable ExecuteQuery(string query, Dictionary<string, object>? parameters = null)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.AddWithValue($"@{param.Key}", param.Value);
                            }
                        }

                        var dataTable = new DataTable();
                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        // Check database status and return info
        public static string GetDatabaseInfo()
        {
            if (!_databaseInitialized)
            {
                InitializeDatabase();
            }

            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();

                    // Get user count
                    int userCount = 0;
                    using (var command = new SQLiteCommand("SELECT COUNT(*) FROM Users", connection))
                    {
                        userCount = Convert.ToInt32(command.ExecuteScalar());
                    }

                    return $"Database path: {DatabasePath}\nConnection state: {connection.State}\nUsers in database: {userCount}";
                }
            }
            catch (Exception ex)
            {
                return $"Database connection error: {ex.Message}";
            }
        }
    }
}
