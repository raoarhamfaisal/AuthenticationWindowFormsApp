using System;
using System.Windows.Forms;
// Add ZXing namespaces
using ZXing;
using ZXing.Common;
using System.Drawing;

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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Close this form and return to the login screen
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGenerateQr_Click(object sender, EventArgs e)
        {
            string input = txtQrInput.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please enter text to generate QR code.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generate QR code using ZXing.Net
            var writer = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = pictureBoxQr.Height,
                    Width = pictureBoxQr.Width,
                    Margin = 1
                }
            };

            var pixelData = writer.Write(input);

            // Create a bitmap from the raw pixel data
            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
            {
                var bitmapData = bitmap.LockBits(
                    new Rectangle(0, 0, pixelData.Width, pixelData.Height),
                    System.Drawing.Imaging.ImageLockMode.WriteOnly,
                    System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                try
                {
                    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                }
                finally
                {
                    bitmap.UnlockBits(bitmapData);
                }
                // Display the QR code in the PictureBox
                pictureBoxQr.Image = new Bitmap(bitmap);
            }
        }

        private void btnAddFavourite_Click(object sender, EventArgs e)
        {
            string text = txtQrInput.Text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("No text to add as favourite.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "INSERT INTO Favourites (FavouriteText) VALUES (@text)";
            var parameters = new Dictionary<string, object> { { "text", text } };
            if (DatabaseHelper.ExecuteNonQuery(query, parameters) > 0)
            {
                MessageBox.Show("Added as favourite!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to add favourite.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewFavourites_Click(object sender, EventArgs e)
        {
            // Open FavouritesForm to view/edit/delete favourites
            var favForm = new FavouritesForm();
            favForm.ShowDialog();
        }
    }
}
