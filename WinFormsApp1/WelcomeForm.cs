using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class WelcomeForm : Form
    {
        private string _username;

        public WelcomeForm(string username)
        {
            InitializeComponent();
            _username = username;

            // Set the welcome message
            lblWelcome.Text = $"Welcome to QR Generator, {_username}!";
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            // Close this form and continue to the main application
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Close this form and return to the login screen
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
