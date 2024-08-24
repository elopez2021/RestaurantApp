namespace Restaurant.Views
{
    partial class MantImpuestos
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnomb = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtporcen = new Guna.UI2.WinForms.Guna2TextBox();
            this.table = new Zuby.ADGV.AdvancedDataGridView();
            this.btneliminar = new Guna.UI2.WinForms.Guna2Button();
            this.btnlimpiar = new Guna.UI2.WinForms.Guna2Button();
            this.btnguardar = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 22);
            this.label3.TabIndex = 86;
            this.label3.Text = "Nombre de Impuesto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 22);
            this.label1.TabIndex = 81;
            this.label1.Text = "Porcentaje (%):";
            // 
            // txtnomb
            // 
            this.txtnomb.BorderColor = System.Drawing.Color.Black;
            this.txtnomb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtnomb.DefaultText = "";
            this.txtnomb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtnomb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtnomb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtnomb.DisabledState.Parent = this.txtnomb;
            this.txtnomb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtnomb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.txtnomb.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtnomb.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.txtnomb.FocusedState.Parent = this.txtnomb;
            this.txtnomb.ForeColor = System.Drawing.Color.Black;
            this.txtnomb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtnomb.HoverState.Parent = this.txtnomb;
            this.txtnomb.Location = new System.Drawing.Point(51, 110);
            this.txtnomb.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtnomb.Name = "txtnomb";
            this.txtnomb.PasswordChar = '\0';
            this.txtnomb.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtnomb.PlaceholderText = "";
            this.txtnomb.SelectedText = "";
            this.txtnomb.ShadowDecoration.Parent = this.txtnomb;
            this.txtnomb.Size = new System.Drawing.Size(611, 44);
            this.txtnomb.TabIndex = 113;
            this.txtnomb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnomb_KeyPress);
            // 
            // txtporcen
            // 
            this.txtporcen.BorderColor = System.Drawing.Color.Black;
            this.txtporcen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtporcen.DefaultText = "";
            this.txtporcen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtporcen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtporcen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtporcen.DisabledState.Parent = this.txtporcen;
            this.txtporcen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtporcen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.txtporcen.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtporcen.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.txtporcen.FocusedState.Parent = this.txtporcen;
            this.txtporcen.ForeColor = System.Drawing.Color.Black;
            this.txtporcen.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtporcen.HoverState.Parent = this.txtporcen;
            this.txtporcen.Location = new System.Drawing.Point(51, 214);
            this.txtporcen.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtporcen.Name = "txtporcen";
            this.txtporcen.PasswordChar = '\0';
            this.txtporcen.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtporcen.PlaceholderText = "";
            this.txtporcen.SelectedText = "";
            this.txtporcen.ShadowDecoration.Parent = this.txtporcen;
            this.txtporcen.Size = new System.Drawing.Size(611, 44);
            this.txtporcen.TabIndex = 114;
            this.txtporcen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtporcen_KeyPress);
            // 
            // table
            // 
            this.table.AllowUserToAddRows = false;
            this.table.AllowUserToDeleteRows = false;
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.FilterAndSortEnabled = true;
            this.table.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.table.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.table.Location = new System.Drawing.Point(712, 82);
            this.table.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.table.MaxFilterButtonImageHeight = 23;
            this.table.Name = "table";
            this.table.ReadOnly = true;
            this.table.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.table.RowHeadersVisible = false;
            this.table.RowHeadersWidth = 51;
            this.table.RowTemplate.Height = 24;
            this.table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table.Size = new System.Drawing.Size(605, 656);
            this.table.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.table.TabIndex = 135;
            // 
            // btneliminar
            // 
            this.btneliminar.BackColor = System.Drawing.Color.Transparent;
            this.btneliminar.BorderRadius = 18;
            this.btneliminar.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btneliminar.CheckedState.Image = global::Restaurant.Properties.Resources.btncategorias_white;
            this.btneliminar.CheckedState.Parent = this.btneliminar;
            this.btneliminar.CustomImages.Parent = this.btneliminar;
            this.btneliminar.Enabled = false;
            this.btneliminar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btneliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btneliminar.ForeColor = System.Drawing.Color.White;
            this.btneliminar.HoverState.Parent = this.btneliminar;
            this.btneliminar.Image = global::Restaurant.Properties.Resources.btn_eliminar_pink;
            this.btneliminar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btneliminar.ImageSize = new System.Drawing.Size(35, 35);
            this.btneliminar.Location = new System.Drawing.Point(51, 346);
            this.btneliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btneliminar.ShadowDecoration.Parent = this.btneliminar;
            this.btneliminar.Size = new System.Drawing.Size(164, 50);
            this.btneliminar.TabIndex = 134;
            this.btneliminar.Text = "Borrar";
            this.btneliminar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btneliminar.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.Color.Transparent;
            this.btnlimpiar.BorderRadius = 18;
            this.btnlimpiar.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnlimpiar.CheckedState.Image = global::Restaurant.Properties.Resources.btncategorias_white;
            this.btnlimpiar.CheckedState.Parent = this.btnlimpiar;
            this.btnlimpiar.CustomImages.Parent = this.btnlimpiar;
            this.btnlimpiar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnlimpiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnlimpiar.ForeColor = System.Drawing.Color.White;
            this.btnlimpiar.HoverState.Parent = this.btnlimpiar;
            this.btnlimpiar.Image = global::Restaurant.Properties.Resources.btnlimpiar_pink;
            this.btnlimpiar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnlimpiar.ImageSize = new System.Drawing.Size(35, 35);
            this.btnlimpiar.Location = new System.Drawing.Point(271, 346);
            this.btnlimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnlimpiar.ShadowDecoration.Parent = this.btnlimpiar;
            this.btnlimpiar.Size = new System.Drawing.Size(164, 50);
            this.btnlimpiar.TabIndex = 133;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnlimpiar.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.Color.Transparent;
            this.btnguardar.BorderRadius = 18;
            this.btnguardar.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnguardar.CheckedState.Image = global::Restaurant.Properties.Resources.btnguardar_white;
            this.btnguardar.CheckedState.Parent = this.btnguardar;
            this.btnguardar.CustomImages.Parent = this.btnguardar;
            this.btnguardar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnguardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnguardar.ForeColor = System.Drawing.Color.White;
            this.btnguardar.HoverState.Parent = this.btnguardar;
            this.btnguardar.Image = global::Restaurant.Properties.Resources.btnguardar_pink;
            this.btnguardar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnguardar.ImageSize = new System.Drawing.Size(35, 35);
            this.btnguardar.Location = new System.Drawing.Point(496, 346);
            this.btnguardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnguardar.ShadowDecoration.Parent = this.btnguardar;
            this.btnguardar.Size = new System.Drawing.Size(164, 50);
            this.btnguardar.TabIndex = 132;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnguardar.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // MantImpuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 826);
            this.Controls.Add(this.table);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.txtporcen);
            this.Controls.Add(this.txtnomb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MantImpuestos";
            this.Text = "MantImpuestos";
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtnomb;
        private Guna.UI2.WinForms.Guna2TextBox txtporcen;
        private Zuby.ADGV.AdvancedDataGridView table;
        private Guna.UI2.WinForms.Guna2Button btneliminar;
        private Guna.UI2.WinForms.Guna2Button btnlimpiar;
        private Guna.UI2.WinForms.Guna2Button btnguardar;
    }
}