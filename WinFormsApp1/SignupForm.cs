namespace WinFormsApp1
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
            // Ensure the database is initialized
            DatabaseHelper.InitializeDatabase();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UserManager.RegisterUser(username, password))
            {
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Changed: Open the login form directly instead of just closing
                this.Hide();
                var loginForm = new LoginForm();
                loginForm.SetUsername(username); // Set the username in the login form if you add this method
                loginForm.ShowDialog();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Username already exists or registration failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
