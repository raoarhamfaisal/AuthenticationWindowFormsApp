namespace WinFormsApp1
{
    partial class WelcomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblWelcome = new Label();
            btnLogout = new Button();
            txtQrInput = new TextBox();
            btnGenerateQr = new Button();
            pictureBoxQr = new PictureBox();
            btnAddFavourite = new Button();
            btnViewFavourites = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQr).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblWelcome.Location = new Point(12, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(250, 25);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome to QR Generator!";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(133, 278);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(131, 30);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // txtQrInput
            // 
            txtQrInput.Location = new Point(12, 36);
            txtQrInput.Margin = new Padding(3, 2, 3, 2);
            txtQrInput.Name = "txtQrInput";
            txtQrInput.Size = new Size(380, 23);
            txtQrInput.TabIndex = 1;
            // 
            // btnGenerateQr
            // 
            btnGenerateQr.Location = new Point(133, 63);
            btnGenerateQr.Margin = new Padding(3, 2, 3, 2);
            btnGenerateQr.Name = "btnGenerateQr";
            btnGenerateQr.Size = new Size(131, 30);
            btnGenerateQr.TabIndex = 2;
            btnGenerateQr.Text = "Generate QR Code";
            btnGenerateQr.UseVisualStyleBackColor = true;
            btnGenerateQr.Click += btnGenerateQr_Click;
            // 
            // pictureBoxQr
            // 
            pictureBoxQr.Location = new Point(133, 97);
            pictureBoxQr.Margin = new Padding(3, 2, 3, 2);
            pictureBoxQr.Name = "pictureBoxQr";
            pictureBoxQr.Size = new Size(131, 112);
            pictureBoxQr.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxQr.TabIndex = 3;
            pictureBoxQr.TabStop = false;
            // 
            // btnAddFavourite
            // 
            btnAddFavourite.Location = new Point(41, 223);
            btnAddFavourite.Margin = new Padding(3, 2, 3, 2);
            btnAddFavourite.Name = "btnAddFavourite";
            btnAddFavourite.Size = new Size(131, 30);
            btnAddFavourite.TabIndex = 5;
            btnAddFavourite.Text = "Add as Favourite";
            btnAddFavourite.UseVisualStyleBackColor = true;
            btnAddFavourite.Click += btnAddFavourite_Click;
            // 
            // btnViewFavourites
            // 
            btnViewFavourites.Location = new Point(220, 223);
            btnViewFavourites.Margin = new Padding(3, 2, 3, 2);
            btnViewFavourites.Name = "btnViewFavourites";
            btnViewFavourites.Size = new Size(131, 30);
            btnViewFavourites.TabIndex = 6;
            btnViewFavourites.Text = "View Favourites";
            btnViewFavourites.UseVisualStyleBackColor = true;
            btnViewFavourites.Click += btnViewFavourites_Click;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 322);
            Controls.Add(btnViewFavourites);
            Controls.Add(btnAddFavourite);
            Controls.Add(btnLogout);
            Controls.Add(pictureBoxQr);
            Controls.Add(btnGenerateQr);
            Controls.Add(txtQrInput);
            Controls.Add(lblWelcome);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WelcomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Welcome";
            ((System.ComponentModel.ISupportInitialize)pictureBoxQr).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private TextBox txtQrInput;
        private Button btnGenerateQr;
        private PictureBox pictureBoxQr;
        private Button btnLogout;
        private Button btnAddFavourite;
        private Button btnViewFavourites;
    }
}
