namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            // Initialize the database at app startup
            bool dbInitialized = DatabaseHelper.InitializeDatabase();
            if (!dbInitialized)
            {
                MessageBox.Show("Failed to initialize database. The application may not function correctly.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            Application.Run(new Form1());
        }
    }
}