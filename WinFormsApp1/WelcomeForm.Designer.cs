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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.txtQrInput = new System.Windows.Forms.TextBox();
            this.btnGenerateQr = new System.Windows.Forms.Button();
            this.pictureBoxQr = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQr)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.Location = new System.Drawing.Point(83, 68);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(296, 32);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to QR Generator!";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtQrInput
            // 
            this.txtQrInput.Location = new System.Drawing.Point(83, 120);
            this.txtQrInput.Name = "txtQrInput";
            this.txtQrInput.Size = new System.Drawing.Size(296, 27);
            this.txtQrInput.TabIndex = 1;
            // 
            // btnGenerateQr
            // 
            this.btnGenerateQr.Location = new System.Drawing.Point(152, 160);
            this.btnGenerateQr.Name = "btnGenerateQr";
            this.btnGenerateQr.Size = new System.Drawing.Size(150, 40);
            this.btnGenerateQr.TabIndex = 2;
            this.btnGenerateQr.Text = "Generate QR Code";
            this.btnGenerateQr.UseVisualStyleBackColor = true;
            this.btnGenerateQr.Click += new System.EventHandler(this.btnGenerateQr_Click);
            // 
            // pictureBoxQr
            // 
            this.pictureBoxQr.Location = new System.Drawing.Point(152, 210);
            this.pictureBoxQr.Name = "pictureBoxQr";
            this.pictureBoxQr.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxQr.TabIndex = 3;
            this.pictureBoxQr.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(152, 370);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(150, 40);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 430);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.pictureBoxQr);
            this.Controls.Add(this.btnGenerateQr);
            this.Controls.Add(this.txtQrInput);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private TextBox txtQrInput;
        private Button btnGenerateQr;
        private PictureBox pictureBoxQr;
        private Button btnLogout;
    }
}
