using System;
using System.Data;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using System.Drawing;

namespace WinFormsApp1
{
    public partial class FavouritesForm : Form
    {
        public FavouritesForm()
        {
            InitializeComponent();
            LoadFavourites();
        }

        private void LoadFavourites()
        {
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT Id, FavouriteText FROM Favourites");
            // Add Edit and Delete button columns if not already added
            if (!dgvFavourites.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editCol = new DataGridViewButtonColumn
                {
                    HeaderText = "Edit",
                    Name = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dgvFavourites.Columns.Add(editCol);
            }
            if (!dgvFavourites.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn delCol = new DataGridViewButtonColumn
                {
                    HeaderText = "Delete",
                    Name = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dgvFavourites.Columns.Add(delCol);
            }
            dgvFavourites.DataSource = dt;
        }

        private void dgvFavourites_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            // Check if Edit button clicked
            if (dgvFavourites.Columns[e.ColumnIndex].Name == "Edit")
            {
                int id = Convert.ToInt32(dgvFavourites.Rows[e.RowIndex].Cells["Id"].Value);
                string currentText = dgvFavourites.Rows[e.RowIndex].Cells["FavouriteText"].Value.ToString();
                string newText = Microsoft.VisualBasic.Interaction.InputBox("Edit Favourite Text:", "Edit Favourite", currentText);
                if (!string.IsNullOrEmpty(newText) && newText != currentText)
                {
                    string query = "UPDATE Favourites SET FavouriteText = @text WHERE Id = @id";
                    var parameters = new Dictionary<string, object>
                    {
                        { "text", newText },
                        { "id", id }
                    };
                    if (DatabaseHelper.ExecuteNonQuery(query, parameters) > 0)
                    {
                        MessageBox.Show("Favourite updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFavourites();
                    }
                    else
                    {
                        MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // Check if Delete button clicked
            else if (dgvFavourites.Columns[e.ColumnIndex].Name == "Delete")
            {
                int id = Convert.ToInt32(dgvFavourites.Rows[e.RowIndex].Cells["Id"].Value);
                var confirmResult = MessageBox.Show("Are you sure to delete this favourite?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    string query = "DELETE FROM Favourites WHERE Id = @id";
                    var parameters = new Dictionary<string, object> { { "id", id } };
                    if (DatabaseHelper.ExecuteNonQuery(query, parameters) > 0)
                    {
                        MessageBox.Show("Favourite deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFavourites();
                    }
                    else
                    {
                        MessageBox.Show("Delete failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // On double-click (or single click on non-button cells), show the QR code for the favourite text
        private void dgvFavourites_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string favText = dgvFavourites.Rows[e.RowIndex].Cells["FavouriteText"].Value.ToString();
            ShowQRCode(favText);
        }
        private void ShowQRCode(string text)
        {
            // Generate QR code using ZXing (similar to WelcomeForm)
            var writer = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 300,
                    Width = 300,
                    Margin = 1
                }
            };
            var pixelData = writer.Write(text);
            Bitmap qrBitmap = new Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            var bitmapData = qrBitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height),
                                                 System.Drawing.Imaging.ImageLockMode.WriteOnly,
                                                 System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            try
            {
                System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
            }
            finally
            {
                qrBitmap.UnlockBits(bitmapData);
            }

            // Create a form to show QR code
            Form qrForm = new Form
            {
                Text = "QR Code",
                ClientSize = new Size(320, 340),
                StartPosition = FormStartPosition.CenterParent
            };

            PictureBox pb = new PictureBox
            {
                Image = qrBitmap,
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            qrForm.Controls.Add(pb);
            qrForm.ShowDialog();
        }

    }
}
