namespace Restaurant.Views.Movimientos
{
    partial class ReporteVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteVentas));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbmes = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbano = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbltotal = new System.Windows.Forms.Label();
            this.lblimpuesto = new System.Windows.Forms.Label();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbtiporeporte = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.table = new System.Windows.Forms.DataGridView();
            this.btnimprimir = new Guna.UI2.WinForms.Guna2Button();
            this.btngenerar = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1367, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reportes de Ventas Mensual";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 22);
            this.label2.TabIndex = 139;
            this.label2.Text = "Mes de Reporte:";
            // 
            // cmbmes
            // 
            this.cmbmes.BackColor = System.Drawing.Color.White;
            this.cmbmes.BorderColor = System.Drawing.Color.Black;
            this.cmbmes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbmes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmes.FocusedColor = System.Drawing.Color.Empty;
            this.cmbmes.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.cmbmes.FocusedState.ForeColor = System.Drawing.Color.White;
            this.cmbmes.FocusedState.Parent = this.cmbmes;
            this.cmbmes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbmes.ForeColor = System.Drawing.Color.Black;
            this.cmbmes.FormattingEnabled = true;
            this.cmbmes.HoverState.Parent = this.cmbmes;
            this.cmbmes.ItemHeight = 30;
            this.cmbmes.ItemsAppearance.Parent = this.cmbmes;
            this.cmbmes.Location = new System.Drawing.Point(148, 110);
            this.cmbmes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbmes.Name = "cmbmes";
            this.cmbmes.ShadowDecoration.Parent = this.cmbmes;
            this.cmbmes.Size = new System.Drawing.Size(203, 36);
            this.cmbmes.TabIndex = 138;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(386, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 22);
            this.label3.TabIndex = 141;
            this.label3.Text = "Año de Reporte:";
            // 
            // cmbano
            // 
            this.cmbano.BackColor = System.Drawing.Color.White;
            this.cmbano.BorderColor = System.Drawing.Color.Black;
            this.cmbano.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbano.FocusedColor = System.Drawing.Color.Empty;
            this.cmbano.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.cmbano.FocusedState.ForeColor = System.Drawing.Color.White;
            this.cmbano.FocusedState.Parent = this.cmbano;
            this.cmbano.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbano.ForeColor = System.Drawing.Color.Black;
            this.cmbano.FormattingEnabled = true;
            this.cmbano.HoverState.Parent = this.cmbano;
            this.cmbano.ItemHeight = 30;
            this.cmbano.ItemsAppearance.Parent = this.cmbano;
            this.cmbano.Location = new System.Drawing.Point(388, 110);
            this.cmbano.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbano.Name = "cmbano";
            this.cmbano.ShadowDecoration.Parent = this.cmbano;
            this.cmbano.Size = new System.Drawing.Size(203, 36);
            this.cmbano.TabIndex = 140;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 22);
            this.label4.TabIndex = 142;
            this.label4.Text = "Resultados:";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2Panel1.Controls.Add(this.panel1);
            this.guna2Panel1.Controls.Add(this.label10);
            this.guna2Panel1.Controls.Add(this.label11);
            this.guna2Panel1.Controls.Add(this.label12);
            this.guna2Panel1.Location = new System.Drawing.Point(840, 220);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(477, 100);
            this.guna2Panel1.TabIndex = 149;
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.ForeColor = System.Drawing.Color.White;
            this.lbltotal.Location = new System.Drawing.Point(52, 65);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(44, 20);
            this.lbltotal.TabIndex = 5;
            this.lbltotal.Text = "0.00";
            // 
            // lblimpuesto
            // 
            this.lblimpuesto.AutoSize = true;
            this.lblimpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblimpuesto.ForeColor = System.Drawing.Color.White;
            this.lblimpuesto.Location = new System.Drawing.Point(54, 36);
            this.lblimpuesto.Name = "lblimpuesto";
            this.lblimpuesto.Size = new System.Drawing.Size(40, 20);
            this.lblimpuesto.TabIndex = 4;
            this.lblimpuesto.Text = "0.00";
            // 
            // lblsubtotal
            // 
            this.lblsubtotal.AutoSize = true;
            this.lblsubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubtotal.ForeColor = System.Drawing.Color.White;
            this.lblsubtotal.Location = new System.Drawing.Point(52, 7);
            this.lblsubtotal.Name = "lblsubtotal";
            this.lblsubtotal.Size = new System.Drawing.Size(44, 20);
            this.lblsubtotal.TabIndex = 3;
            this.lblsubtotal.Text = "0.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(11, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Impuesto:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(11, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "Total:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(11, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "Subtotal:";
            // 
            // cmbtiporeporte
            // 
            this.cmbtiporeporte.BackColor = System.Drawing.Color.White;
            this.cmbtiporeporte.BorderColor = System.Drawing.Color.Black;
            this.cmbtiporeporte.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbtiporeporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtiporeporte.FocusedColor = System.Drawing.Color.Empty;
            this.cmbtiporeporte.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.cmbtiporeporte.FocusedState.ForeColor = System.Drawing.Color.White;
            this.cmbtiporeporte.FocusedState.Parent = this.cmbtiporeporte;
            this.cmbtiporeporte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbtiporeporte.ForeColor = System.Drawing.Color.Black;
            this.cmbtiporeporte.FormattingEnabled = true;
            this.cmbtiporeporte.HoverState.Parent = this.cmbtiporeporte;
            this.cmbtiporeporte.ItemHeight = 30;
            this.cmbtiporeporte.Items.AddRange(new object[] {
            "Usuario",
            "Producto",
            "Categoria"});
            this.cmbtiporeporte.ItemsAppearance.Parent = this.cmbtiporeporte;
            this.cmbtiporeporte.Location = new System.Drawing.Point(631, 108);
            this.cmbtiporeporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbtiporeporte.Name = "cmbtiporeporte";
            this.cmbtiporeporte.ShadowDecoration.Parent = this.cmbtiporeporte;
            this.cmbtiporeporte.Size = new System.Drawing.Size(203, 36);
            this.cmbtiporeporte.TabIndex = 152;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(627, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 22);
            this.label5.TabIndex = 153;
            this.label5.Text = "Tipo de Reporte";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(836, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(214, 22);
            this.label6.TabIndex = 155;
            this.label6.Text = "Total General del Mes:";
            // 
            // table
            // 
            this.table.AllowUserToAddRows = false;
            this.table.AllowUserToDeleteRows = false;
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.BackgroundColor = System.Drawing.Color.Silver;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Location = new System.Drawing.Point(57, 220);
            this.table.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.table.Name = "table";
            this.table.ReadOnly = true;
            this.table.RowHeadersVisible = false;
            this.table.RowHeadersWidth = 51;
            this.table.RowTemplate.Height = 24;
            this.table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table.Size = new System.Drawing.Size(734, 542);
            this.table.TabIndex = 157;
            // 
            // btnimprimir
            // 
            this.btnimprimir.BackColor = System.Drawing.Color.Transparent;
            this.btnimprimir.BorderRadius = 18;
            this.btnimprimir.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnimprimir.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnimprimir.CheckedState.Image")));
            this.btnimprimir.CheckedState.Parent = this.btnimprimir;
            this.btnimprimir.CustomImages.Parent = this.btnimprimir;
            this.btnimprimir.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnimprimir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnimprimir.ForeColor = System.Drawing.Color.White;
            this.btnimprimir.HoverState.Parent = this.btnimprimir;
            this.btnimprimir.Image = global::Restaurant.Properties.Resources.btn_imprimir_pink;
            this.btnimprimir.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnimprimir.ImageSize = new System.Drawing.Size(35, 35);
            this.btnimprimir.Location = new System.Drawing.Point(1038, 95);
            this.btnimprimir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnimprimir.Name = "btnimprimir";
            this.btnimprimir.ShadowDecoration.Parent = this.btnimprimir;
            this.btnimprimir.Size = new System.Drawing.Size(177, 50);
            this.btnimprimir.TabIndex = 156;
            this.btnimprimir.Text = "Imprimir";
            this.btnimprimir.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // btngenerar
            // 
            this.btngenerar.BackColor = System.Drawing.Color.Transparent;
            this.btngenerar.BorderRadius = 18;
            this.btngenerar.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btngenerar.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btngenerar.CheckedState.Image")));
            this.btngenerar.CheckedState.Parent = this.btngenerar;
            this.btngenerar.CustomImages.Parent = this.btngenerar;
            this.btngenerar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btngenerar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btngenerar.ForeColor = System.Drawing.Color.White;
            this.btngenerar.HoverState.Parent = this.btngenerar;
            this.btngenerar.Image = global::Restaurant.Properties.Resources.btn_generar_pink;
            this.btngenerar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btngenerar.ImageSize = new System.Drawing.Size(35, 35);
            this.btngenerar.Location = new System.Drawing.Point(855, 96);
            this.btngenerar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btngenerar.Name = "btngenerar";
            this.btngenerar.ShadowDecoration.Parent = this.btngenerar;
            this.btngenerar.Size = new System.Drawing.Size(177, 50);
            this.btngenerar.TabIndex = 151;
            this.btngenerar.Text = "Generar";
            this.btngenerar.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lbltotal);
            this.panel1.Controls.Add(this.lblsubtotal);
            this.panel1.Controls.Add(this.lblimpuesto);
            this.panel1.Location = new System.Drawing.Point(208, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "RD$";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "RD$";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "RD$";
            // 
            // ReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 826);
            this.Controls.Add(this.table);
            this.Controls.Add(this.btnimprimir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbtiporeporte);
            this.Controls.Add(this.btngenerar);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbano);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbmes);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReporteVentas";
            this.Text = "ReporteVentas";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbmes;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cmbano;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label lblimpuesto;
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2Button btngenerar;
        private Guna.UI2.WinForms.Guna2ComboBox cmbtiporeporte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button btnimprimir;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}