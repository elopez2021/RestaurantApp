namespace Restaurant.Views.Movimientos.POS_controles
{
    partial class controlpendientes
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnentregado = new Guna.UI2.WinForms.Guna2Button();
            this.table = new Zuby.ADGV.AdvancedDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnexitpedidos = new Guna.UI2.WinForms.Guna2ControlBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnentregado);
            this.panel2.Controls.Add(this.table);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(904, 456);
            this.panel2.TabIndex = 3;
            // 
            // btnentregado
            // 
            this.btnentregado.BackColor = System.Drawing.Color.Transparent;
            this.btnentregado.BorderRadius = 18;
            this.btnentregado.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnentregado.CheckedState.Image = global::Restaurant.Properties.Resources.btnguardar_white;
            this.btnentregado.CheckedState.Parent = this.btnentregado;
            this.btnentregado.CustomImages.Parent = this.btnentregado;
            this.btnentregado.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnentregado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnentregado.ForeColor = System.Drawing.Color.White;
            this.btnentregado.HoverState.Parent = this.btnentregado;
            this.btnentregado.Image = global::Restaurant.Properties.Resources.btn_entregado_pink;
            this.btnentregado.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnentregado.ImageSize = new System.Drawing.Size(35, 35);
            this.btnentregado.Location = new System.Drawing.Point(712, 18);
            this.btnentregado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnentregado.Name = "btnentregado";
            this.btnentregado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnentregado.ShadowDecoration.Parent = this.btnentregado;
            this.btnentregado.Size = new System.Drawing.Size(180, 50);
            this.btnentregado.TabIndex = 141;
            this.btnentregado.Text = "Entregado";
            this.btnentregado.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnentregado.TextOffset = new System.Drawing.Point(10, 0);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.guna2PictureBox1);
            this.panel1.Controls.Add(this.btnexitpedidos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 71);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pedidos Pendientes";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::Restaurant.Properties.Resources.btn_pedidos_pink;
            this.guna2PictureBox1.Location = new System.Drawing.Point(8, 7);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(59, 57);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 1;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btnexitpedidos
            // 
            this.btnexitpedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnexitpedidos.BorderRadius = 5;
            this.btnexitpedidos.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnexitpedidos.HoverState.Parent = this.btnexitpedidos;
            this.btnexitpedidos.IconColor = System.Drawing.Color.White;
            this.btnexitpedidos.Location = new System.Drawing.Point(833, 23);
            this.btnexitpedidos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnexitpedidos.Name = "btnexitpedidos";
            this.btnexitpedidos.ShadowDecoration.Parent = this.btnexitpedidos;
            this.btnexitpedidos.Size = new System.Drawing.Size(45, 30);
            this.btnexitpedidos.TabIndex = 0;
            this.btnexitpedidos.Click += new System.EventHandler(this.btnexitpedidos_Click);
            // 
            // controlpendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 527);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "controlpendientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "controlpendientes";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnentregado;
        private Zuby.ADGV.AdvancedDataGridView table;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2ControlBox btnexitpedidos;
    }
}