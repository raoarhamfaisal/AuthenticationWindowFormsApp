namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Show();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            var signupForm = new SignupForm();
            this.Hide();
            signupForm.ShowDialog();
            this.Show();
        }
    }
}
