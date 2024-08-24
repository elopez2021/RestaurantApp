namespace Restaurant.Views.Movimientos.POS_controles
{
    partial class controlesfacturas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnexirfacturas = new Guna.UI2.WinForms.Guna2ControlBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnimprimir = new Guna.UI2.WinForms.Guna2Button();
            this.table = new Zuby.ADGV.AdvancedDataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.guna2PictureBox1);
            this.panel1.Controls.Add(this.btnexirfacturas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 72);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Facturas";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::Restaurant.Properties.Resources.btn_facturas_pink;
            this.guna2PictureBox1.Location = new System.Drawing.Point(8, 8);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(58, 56);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 1;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btnexirfacturas
            // 
            this.btnexirfacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnexirfacturas.BorderRadius = 5;
            this.btnexirfacturas.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnexirfacturas.HoverState.Parent = this.btnexirfacturas;
            this.btnexirfacturas.IconColor = System.Drawing.Color.White;
            this.btnexirfacturas.Location = new System.Drawing.Point(833, 23);
            this.btnexirfacturas.Name = "btnexirfacturas";
            this.btnexirfacturas.ShadowDecoration.Parent = this.btnexirfacturas;
            this.btnexirfacturas.Size = new System.Drawing.Size(45, 29);
            this.btnexirfacturas.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnimprimir);
            this.panel2.Controls.Add(this.table);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(904, 455);
            this.panel2.TabIndex = 1;
            // 
            // btnimprimir
            // 
            this.btnimprimir.BackColor = System.Drawing.Color.Transparent;
            this.btnimprimir.BorderRadius = 18;
            this.btnimprimir.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnimprimir.CheckedState.Image = global::Restaurant.Properties.Resources.btnguardar_white;
            this.btnimprimir.CheckedState.Parent = this.btnimprimir;
            this.btnimprimir.CustomImages.Parent = this.btnimprimir;
            this.btnimprimir.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnimprimir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnimprimir.ForeColor = System.Drawing.Color.White;
            this.btnimprimir.HoverState.Parent = this.btnimprimir;
            this.btnimprimir.Image = global::Restaurant.Properties.Resources.btn_imprimir_pink;
            this.btnimprimir.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnimprimir.ImageSize = new System.Drawing.Size(35, 35);
            this.btnimprimir.Location = new System.Drawing.Point(712, 18);
            this.btnimprimir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnimprimir.Name = "btnimprimir";
            this.btnimprimir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnimprimir.ShadowDecoration.Parent = this.btnimprimir;
            this.btnimprimir.Size = new System.Drawing.Size(180, 50);
            this.btnimprimir.TabIndex = 141;
            this.btnimprimir.Text = "Imprimir";
            this.btnimprimir.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnimprimir.TextOffset = new System.Drawing.Point(10, 0);
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
            this.table.Location = new System.Drawing.Point(12, 82);
            this.table.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.table.MaxFilterButtonImageHeight = 23;
            this.table.Name = "table";
            this.table.ReadOnly = true;
            this.table.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.table.RowHeadersVisible = false;
            this.table.RowHeadersWidth = 51;
            this.table.RowTemplate.Height = 24;
            this.table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table.Size = new System.Drawing.Size(880, 362);
            this.table.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.table.TabIndex = 131;
            // 
            // controlesfacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 527);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "controlesfacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "controlesfacturas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2ControlBox btnexirfacturas;
        private Zuby.ADGV.AdvancedDataGridView table;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnimprimir;
    }
}