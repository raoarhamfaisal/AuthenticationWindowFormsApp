namespace WinFormsApp1
{
    partial class FavouritesForm
    {
        private System.ComponentModel.IContainer components = null;

        // Clean up code...
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.dgvFavourites = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFavourites)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFavourites
            // 
            this.dgvFavourites.AllowUserToAddRows = false;
            this.dgvFavourites.AllowUserToDeleteRows = false;
            this.dgvFavourites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFavourites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFavourites.Location = new System.Drawing.Point(0, 0);
            this.dgvFavourites.Name = "dgvFavourites";
            this.dgvFavourites.ReadOnly = true;
            this.dgvFavourites.RowHeadersWidth = 51;
            this.dgvFavourites.RowTemplate.Height = 29;
            this.dgvFavourites.Size = new System.Drawing.Size(600, 400);
            this.dgvFavourites.TabIndex = 0;
            this.dgvFavourites.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFavourites_CellContentClick);
            this.dgvFavourites.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFavourites_CellDoubleClick);
            // 
            // FavouritesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.dgvFavourites);
            this.Name = "FavouritesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Favourites";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFavourites)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView dgvFavourites;
    }
}
