namespace WinFormsApp1
{
    partial class SignupForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            btnSignup = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();

            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(180, 50);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 27);
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(180, 100);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(200, 27);
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(180, 150);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(200, 27);
            // 
            // btnSignup
            // 
            btnSignup.Location = new Point(180, 200);
            btnSignup.Name = "btnSignup";
            btnSignup.Size = new Size(94, 29);
            btnSignup.Text = "Sign Up";
            btnSignup.Click += btnSignup_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(286, 200);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 53);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 103);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 153);
            label3.Name = "label3";
            label3.Size = new Size(127, 20);
            label3.Text = "Confirm Password:";
            // 
            // SignupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 250);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(btnSignup);
            Controls.Add(btnCancel);
            Name = "SignupForm";
            Text = "Sign Up";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Button btnSignup;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
