namespace Restaurant.Views.Movimientos.POS_controles
{
    partial class controlclientes
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
            this.table = new Zuby.ADGV.AdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.AllowUserToAddRows = false;
            this.table.AllowUserToDeleteRows = false;
            this.table.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.FilterAndSortEnabled = true;
            this.table.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.table.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.table.MaxFilterButtonImageHeight = 23;
            this.table.Name = "table";
            this.table.ReadOnly = true;
            this.table.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.table.RowHeadersWidth = 51;
            this.table.RowTemplate.Height = 24;
            this.table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table.Size = new System.Drawing.Size(537, 209);
            this.table.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.table.TabIndex = 127;
            // 
            // controlclientes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(537, 209);
            this.Controls.Add(this.table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(837, 202);
            this.Name = "controlclientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "controlclientes";
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView table;
    }
}