namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            // Ensure the database is initialized
            DatabaseHelper.InitializeDatabase();
        }

        // Add this method to set the username from the signup form
        public void SetUsername(string username)
        {
            txtUsername.Text = username;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (UserManager.ValidateUser(username, password))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Changed: Open the welcome form instead of just closing
                this.Hide();
                var welcomeForm = new WelcomeForm(username);
                welcomeForm.ShowDialog();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
         {
            this.DialogResult = DialogResult.Cancel;
            this.Close();}
    }
}}