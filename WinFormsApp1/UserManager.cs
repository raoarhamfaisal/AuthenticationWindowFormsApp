using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace WinFormsApp1
{
    public static class UserManager
    {
        // Initialize the database when the class is first loaded
        static UserManager()
        {
            bool initialized = DatabaseHelper.InitializeDatabase();
            if (initialized)
            {
                Debug.WriteLine("UserManager initialized database successfully");
            }
            else
            {
                Debug.WriteLine("UserManager failed to initialize database");
            }
        }

        // Register a new user
        public static bool RegisterUser(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return false;

                // Check if the username already exists
                if (UserExists(username))
                    return false;

                // Hash the password before storing it
                string passwordHash = HashPassword(password);
                string createdAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO Users (Username, PasswordHash, CreatedAt) VALUES (@Username, @PasswordHash, @CreatedAt)";
                var parameters = new Dictionary<string, object>
                {
                    { "Username", username },
                    { "PasswordHash", passwordHash },
                    { "CreatedAt", createdAt }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                Debug.WriteLine($"Register user result: {rowsAffected > 0}, Username: {username}");
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error registering user: {ex.Message}");
                return false;
            }
        }

        // Check if a username already exists
        private static bool UserExists(string username)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                var parameters = new Dictionary<string, object>
                {
                    { "Username", username }
                };

                object? result = DatabaseHelper.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result ?? 0) > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error checking if user exists: {ex.Message}");
                return false;
            }
        }

        // Validate a user's credentials
        public static bool ValidateUser(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return false;

                string query = "SELECT PasswordHash FROM Users WHERE Username = @Username";
                var parameters = new Dictionary<string, object>
                {
                    { "Username", username }
                };

                DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

                if (result == null || result.Rows.Count == 0)
                {
                    Debug.WriteLine($"No user found with username: {username}");
                    return false;
                }

                string storedHash = result.Rows[0]["PasswordHash"]?.ToString() ?? "";
                string inputHash = HashPassword(password);

                bool isValid = storedHash == inputHash;
                Debug.WriteLine($"User validation result for {username}: {isValid}");
                return isValid;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error validating user: {ex.Message}");
                return false;
            }
        }

        // Simple password hashing (in production, use a more secure method with salt)
        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // List all users (for debugging)
        public static List<string> GetAllUsers()
        {
            try
            {
                var users = new List<string>();
                string query = "SELECT Username FROM Users";
                DataTable result = DatabaseHelper.ExecuteQuery(query);

                if (result != null)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        string? username = row["Username"]?.ToString();
                        if (!string.IsNullOrEmpty(username))
                        {
                            users.Add(username);
                        }
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error getting users: {ex.Message}");
                return new List<string>();
            }
        }
    }
}
