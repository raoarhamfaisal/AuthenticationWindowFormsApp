namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            // Add button for checking database status (for debugging)
            Button btnCheckDb = new Button
            {
                Text = "Check Database",
                Location = new Point(100, 150),
                Size = new Size(120, 30)
            };
            btnCheckDb.Click += BtnCheckDb_Click;
            this.Controls.Add(btnCheckDb);
        }

        private void BtnCheckDb_Click(object sender, EventArgs e)
        {
            string dbInfo = DatabaseHelper.GetDatabaseInfo();
            var users = UserManager.GetAllUsers();
            string userList = string.Join(", ", users);
            
            MessageBox.Show($"{dbInfo}\n\nRegistered users: {userList}", 
                "Database Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Update the login button click handler to handle the new flow
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            this.Hide();
            var result = loginForm.ShowDialog();

            // We don't need to show Form1 again if login was successful and user is now in the WelcomeForm
            if (result != DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                // Close Form1 as the user will continue in the WelcomeForm
                this.Close();
            }
        }

        // Update the signup button click handler
        private void btnSignup_Click(object sender, EventArgs e)
        {
            var signupForm = new SignupForm();
            this.Hide();
            signupForm.ShowDialog();

            // Form1 should be shown again regardless of signup result
            // as the user will be directed to LoginForm if successful
            this.Show();
        }
    }
}
