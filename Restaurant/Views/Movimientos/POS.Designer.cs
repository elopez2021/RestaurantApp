namespace Restaurant.Views.Movimientos
{
    partial class POS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbcategoria = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbsalas = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtsearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabletotales = new Guna.UI2.WinForms.Guna2Panel();
            this.lbltotal = new System.Windows.Forms.Label();
            this.lblimpuesto = new System.Windows.Forms.Label();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnsolicitar = new Guna.UI2.WinForms.Guna2Button();
            this.btnborrar = new Guna.UI2.WinForms.Guna2Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtcliente = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnfacturas = new Guna.UI2.WinForms.Guna2Button();
            this.btnpendientes = new Guna.UI2.WinForms.Guna2Button();
            this.btnbuscarcliente = new Guna.UI2.WinForms.Guna2Button();
            this.panelproducto = new System.Windows.Forms.FlowLayoutPanel();
            this.panelmesas = new System.Windows.Forms.FlowLayoutPanel();
            this.btnlimpiarcliente = new Guna.UI2.WinForms.Guna2Button();
            this.carttable = new System.Windows.Forms.DataGridView();
            this.IdProductotbl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Totaltbl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impuestotbl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EsProductoFinaltbl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabletotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carttable)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbcategoria
            // 
            this.cmbcategoria.BackColor = System.Drawing.Color.White;
            this.cmbcategoria.BorderColor = System.Drawing.Color.Black;
            this.cmbcategoria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbcategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcategoria.FocusedColor = System.Drawing.Color.Empty;
            this.cmbcategoria.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.cmbcategoria.FocusedState.ForeColor = System.Drawing.Color.White;
            this.cmbcategoria.FocusedState.Parent = this.cmbcategoria;
            this.cmbcategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbcategoria.ForeColor = System.Drawing.Color.Black;
            this.cmbcategoria.FormattingEnabled = true;
            this.cmbcategoria.HoverState.Parent = this.cmbcategoria;
            this.cmbcategoria.ItemHeight = 30;
            this.cmbcategoria.ItemsAppearance.Parent = this.cmbcategoria;
            this.cmbcategoria.Location = new System.Drawing.Point(248, 52);
            this.cmbcategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbcategoria.Name = "cmbcategoria";
            this.cmbcategoria.ShadowDecoration.Parent = this.cmbcategoria;
            this.cmbcategoria.Size = new System.Drawing.Size(316, 36);
            this.cmbcategoria.TabIndex = 133;
            // 
            // cmbsalas
            // 
            this.cmbsalas.BackColor = System.Drawing.Color.White;
            this.cmbsalas.BorderColor = System.Drawing.Color.Black;
            this.cmbsalas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbsalas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsalas.FocusedColor = System.Drawing.Color.Empty;
            this.cmbsalas.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.cmbsalas.FocusedState.ForeColor = System.Drawing.Color.White;
            this.cmbsalas.FocusedState.Parent = this.cmbsalas;
            this.cmbsalas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbsalas.ForeColor = System.Drawing.Color.Black;
            this.cmbsalas.FormattingEnabled = true;
            this.cmbsalas.HoverState.Parent = this.cmbsalas;
            this.cmbsalas.ItemHeight = 30;
            this.cmbsalas.ItemsAppearance.Parent = this.cmbsalas;
            this.cmbsalas.Location = new System.Drawing.Point(27, 172);
            this.cmbsalas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbsalas.Name = "cmbsalas";
            this.cmbsalas.ShadowDecoration.Parent = this.cmbsalas;
            this.cmbsalas.Size = new System.Drawing.Size(185, 36);
            this.cmbsalas.TabIndex = 134;
            // 
            // txtsearch
            // 
            this.txtsearch.BorderColor = System.Drawing.Color.Black;
            this.txtsearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsearch.DefaultText = "";
            this.txtsearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtsearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtsearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsearch.DisabledState.Parent = this.txtsearch;
            this.txtsearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.txtsearch.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtsearch.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.txtsearch.FocusedState.Parent = this.txtsearch;
            this.txtsearch.ForeColor = System.Drawing.Color.Black;
            this.txtsearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtsearch.HoverState.Parent = this.txtsearch;
            this.txtsearch.Location = new System.Drawing.Point(616, 52);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(5);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PasswordChar = '\0';
            this.txtsearch.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtsearch.PlaceholderText = "";
            this.txtsearch.SelectedText = "";
            this.txtsearch.ShadowDecoration.Parent = this.txtsearch;
            this.txtsearch.Size = new System.Drawing.Size(316, 44);
            this.txtsearch.TabIndex = 135;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 22);
            this.label2.TabIndex = 136;
            this.label2.Text = "Sala:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(244, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 22);
            this.label1.TabIndex = 137;
            this.label1.Text = "Categoria:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(612, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 22);
            this.label3.TabIndex = 138;
            this.label3.Text = "Buscar Producto:";
            // 
            // tabletotales
            // 
            this.tabletotales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.tabletotales.Controls.Add(this.lbltotal);
            this.tabletotales.Controls.Add(this.lblimpuesto);
            this.tabletotales.Controls.Add(this.lblsubtotal);
            this.tabletotales.Controls.Add(this.label6);
            this.tabletotales.Controls.Add(this.label5);
            this.tabletotales.Controls.Add(this.label4);
            this.tabletotales.Location = new System.Drawing.Point(964, 618);
            this.tabletotales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabletotales.Name = "tabletotales";
            this.tabletotales.ShadowDecoration.Parent = this.tabletotales;
            this.tabletotales.Size = new System.Drawing.Size(377, 100);
            this.tabletotales.TabIndex = 139;
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.ForeColor = System.Drawing.Color.White;
            this.lbltotal.Location = new System.Drawing.Point(223, 68);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(81, 20);
            this.lbltotal.TabIndex = 5;
            this.lbltotal.Text = "RD$0.00";
            // 
            // lblimpuesto
            // 
            this.lblimpuesto.AutoSize = true;
            this.lblimpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblimpuesto.ForeColor = System.Drawing.Color.White;
            this.lblimpuesto.Location = new System.Drawing.Point(230, 39);
            this.lblimpuesto.Name = "lblimpuesto";
            this.lblimpuesto.Size = new System.Drawing.Size(74, 20);
            this.lblimpuesto.TabIndex = 4;
            this.lblimpuesto.Text = "RD$0.00";
            // 
            // lblsubtotal
            // 
            this.lblsubtotal.AutoSize = true;
            this.lblsubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubtotal.ForeColor = System.Drawing.Color.White;
            this.lblsubtotal.Location = new System.Drawing.Point(223, 10);
            this.lblsubtotal.Name = "lblsubtotal";
            this.lblsubtotal.Size = new System.Drawing.Size(81, 20);
            this.lblsubtotal.TabIndex = 3;
            this.lblsubtotal.Text = "RD$0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(11, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Impuesto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(11, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(11, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Subtotal:";
            // 
            // btnsolicitar
            // 
            this.btnsolicitar.BackColor = System.Drawing.Color.Transparent;
            this.btnsolicitar.BorderRadius = 18;
            this.btnsolicitar.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnsolicitar.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnsolicitar.CheckedState.Image")));
            this.btnsolicitar.CheckedState.Parent = this.btnsolicitar;
            this.btnsolicitar.CustomImages.Parent = this.btnsolicitar;
            this.btnsolicitar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnsolicitar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnsolicitar.ForeColor = System.Drawing.Color.White;
            this.btnsolicitar.HoverState.Parent = this.btnsolicitar;
            this.btnsolicitar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnsolicitar.ImageSize = new System.Drawing.Size(35, 35);
            this.btnsolicitar.Location = new System.Drawing.Point(1177, 750);
            this.btnsolicitar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsolicitar.Name = "btnsolicitar";
            this.btnsolicitar.ShadowDecoration.Parent = this.btnsolicitar;
            this.btnsolicitar.Size = new System.Drawing.Size(164, 50);
            this.btnsolicitar.TabIndex = 141;
            this.btnsolicitar.Text = "Solicitar";
            // 
            // btnborrar
            // 
            this.btnborrar.BackColor = System.Drawing.Color.Transparent;
            this.btnborrar.BorderRadius = 18;
            this.btnborrar.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnborrar.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnborrar.CheckedState.Image")));
            this.btnborrar.CheckedState.Parent = this.btnborrar;
            this.btnborrar.CustomImages.Parent = this.btnborrar;
            this.btnborrar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnborrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnborrar.ForeColor = System.Drawing.Color.White;
            this.btnborrar.HoverState.Parent = this.btnborrar;
            this.btnborrar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnborrar.ImageSize = new System.Drawing.Size(35, 35);
            this.btnborrar.Location = new System.Drawing.Point(964, 750);
            this.btnborrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnborrar.Name = "btnborrar";
            this.btnborrar.ShadowDecoration.Parent = this.btnborrar;
            this.btnborrar.Size = new System.Drawing.Size(164, 50);
            this.btnborrar.TabIndex = 142;
            this.btnborrar.Text = "Borrar";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(960, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 20);
            this.label10.TabIndex = 143;
            this.label10.Text = "Cliente:";
            // 
            // txtcliente
            // 
            this.txtcliente.BorderColor = System.Drawing.Color.Black;
            this.txtcliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcliente.DefaultText = "";
            this.txtcliente.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtcliente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtcliente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcliente.DisabledState.Parent = this.txtcliente;
            this.txtcliente.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcliente.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.txtcliente.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtcliente.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.txtcliente.FocusedState.Parent = this.txtcliente;
            this.txtcliente.ForeColor = System.Drawing.Color.Black;
            this.txtcliente.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtcliente.HoverState.Parent = this.txtcliente;
            this.txtcliente.Location = new System.Drawing.Point(964, 52);
            this.txtcliente.Margin = new System.Windows.Forms.Padding(5);
            this.txtcliente.Name = "txtcliente";
            this.txtcliente.PasswordChar = '\0';
            this.txtcliente.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtcliente.PlaceholderText = "";
            this.txtcliente.SelectedText = "";
            this.txtcliente.ShadowDecoration.Parent = this.txtcliente;
            this.txtcliente.Size = new System.Drawing.Size(257, 44);
            this.txtcliente.TabIndex = 144;
            // 
            // btnfacturas
            // 
            this.btnfacturas.BackColor = System.Drawing.Color.Transparent;
            this.btnfacturas.BorderRadius = 18;
            this.btnfacturas.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnfacturas.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnfacturas.CheckedState.Image")));
            this.btnfacturas.CheckedState.Parent = this.btnfacturas;
            this.btnfacturas.CustomImages.Parent = this.btnfacturas;
            this.btnfacturas.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnfacturas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnfacturas.ForeColor = System.Drawing.Color.White;
            this.btnfacturas.HoverState.Parent = this.btnfacturas;
            this.btnfacturas.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnfacturas.ImageSize = new System.Drawing.Size(35, 35);
            this.btnfacturas.Location = new System.Drawing.Point(27, 28);
            this.btnfacturas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnfacturas.Name = "btnfacturas";
            this.btnfacturas.ShadowDecoration.Parent = this.btnfacturas;
            this.btnfacturas.Size = new System.Drawing.Size(185, 50);
            this.btnfacturas.TabIndex = 146;
            this.btnfacturas.Text = "Registro Facturas";
            // 
            // btnpendientes
            // 
            this.btnpendientes.BackColor = System.Drawing.Color.Transparent;
            this.btnpendientes.BorderRadius = 18;
            this.btnpendientes.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnpendientes.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnpendientes.CheckedState.Image")));
            this.btnpendientes.CheckedState.Parent = this.btnpendientes;
            this.btnpendientes.CustomImages.Parent = this.btnpendientes;
            this.btnpendientes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnpendientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnpendientes.ForeColor = System.Drawing.Color.White;
            this.btnpendientes.HoverState.Parent = this.btnpendientes;
            this.btnpendientes.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnpendientes.ImageSize = new System.Drawing.Size(35, 35);
            this.btnpendientes.Location = new System.Drawing.Point(27, 82);
            this.btnpendientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnpendientes.Name = "btnpendientes";
            this.btnpendientes.ShadowDecoration.Parent = this.btnpendientes;
            this.btnpendientes.Size = new System.Drawing.Size(185, 50);
            this.btnpendientes.TabIndex = 147;
            this.btnpendientes.Text = "Pedidos Pendientes";
            // 
            // btnbuscarcliente
            // 
            this.btnbuscarcliente.BackColor = System.Drawing.Color.Transparent;
            this.btnbuscarcliente.BorderRadius = 18;
            this.btnbuscarcliente.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnbuscarcliente.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnbuscarcliente.CheckedState.Image")));
            this.btnbuscarcliente.CheckedState.Parent = this.btnbuscarcliente;
            this.btnbuscarcliente.CustomImages.Parent = this.btnbuscarcliente;
            this.btnbuscarcliente.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnbuscarcliente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnbuscarcliente.ForeColor = System.Drawing.Color.White;
            this.btnbuscarcliente.HoverState.Parent = this.btnbuscarcliente;
            this.btnbuscarcliente.Image = global::Restaurant.Properties.Resources.btn_buscar_pink;
            this.btnbuscarcliente.ImageSize = new System.Drawing.Size(35, 35);
            this.btnbuscarcliente.Location = new System.Drawing.Point(1229, 50);
            this.btnbuscarcliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnbuscarcliente.Name = "btnbuscarcliente";
            this.btnbuscarcliente.ShadowDecoration.Parent = this.btnbuscarcliente;
            this.btnbuscarcliente.Size = new System.Drawing.Size(53, 46);
            this.btnbuscarcliente.TabIndex = 145;
            // 
            // panelproducto
            // 
            this.panelproducto.AutoScroll = true;
            this.panelproducto.Location = new System.Drawing.Point(252, 103);
            this.panelproducto.Margin = new System.Windows.Forms.Padding(4);
            this.panelproducto.Name = "panelproducto";
            this.panelproducto.Size = new System.Drawing.Size(680, 697);
            this.panelproducto.TabIndex = 148;
            // 
            // panelmesas
            // 
            this.panelmesas.AutoScroll = true;
            this.panelmesas.Location = new System.Drawing.Point(27, 223);
            this.panelmesas.Margin = new System.Windows.Forms.Padding(4);
            this.panelmesas.Name = "panelmesas";
            this.panelmesas.Size = new System.Drawing.Size(185, 577);
            this.panelmesas.TabIndex = 0;
            // 
            // btnlimpiarcliente
            // 
            this.btnlimpiarcliente.BackColor = System.Drawing.Color.Transparent;
            this.btnlimpiarcliente.BorderRadius = 18;
            this.btnlimpiarcliente.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnlimpiarcliente.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnlimpiarcliente.CheckedState.Image")));
            this.btnlimpiarcliente.CheckedState.Parent = this.btnlimpiarcliente;
            this.btnlimpiarcliente.CustomImages.Parent = this.btnlimpiarcliente;
            this.btnlimpiarcliente.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnlimpiarcliente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnlimpiarcliente.ForeColor = System.Drawing.Color.White;
            this.btnlimpiarcliente.HoverState.Parent = this.btnlimpiarcliente;
            this.btnlimpiarcliente.Image = global::Restaurant.Properties.Resources.btnlimpiar_pink;
            this.btnlimpiarcliente.ImageSize = new System.Drawing.Size(35, 35);
            this.btnlimpiarcliente.Location = new System.Drawing.Point(1288, 50);
            this.btnlimpiarcliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnlimpiarcliente.Name = "btnlimpiarcliente";
            this.btnlimpiarcliente.ShadowDecoration.Parent = this.btnlimpiarcliente;
            this.btnlimpiarcliente.Size = new System.Drawing.Size(53, 46);
            this.btnlimpiarcliente.TabIndex = 149;
            // 
            // carttable
            // 
            this.carttable.AllowUserToAddRows = false;
            this.carttable.AllowUserToDeleteRows = false;
            this.carttable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.carttable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.carttable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carttable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProductotbl,
            this.NoProducto,
            this.NombreProducto,
            this.Precio,
            this.Cantidad,
            this.Subtotal,
            this.Totaltbl,
            this.Impuestotbl,
            this.EsProductoFinaltbl});
            this.carttable.Location = new System.Drawing.Point(964, 103);
            this.carttable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.carttable.Name = "carttable";
            this.carttable.ReadOnly = true;
            this.carttable.RowHeadersVisible = false;
            this.carttable.RowHeadersWidth = 51;
            this.carttable.RowTemplate.Height = 24;
            this.carttable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.carttable.Size = new System.Drawing.Size(377, 510);
            this.carttable.TabIndex = 150;
            // 
            // IdProductotbl
            // 
            this.IdProductotbl.HeaderText = "IdProducto";
            this.IdProductotbl.MinimumWidth = 6;
            this.IdProductotbl.Name = "IdProductotbl";
            this.IdProductotbl.ReadOnly = true;
            this.IdProductotbl.Visible = false;
            this.IdProductotbl.Width = 78;
            // 
            // NoProducto
            // 
            this.NoProducto.HeaderText = "Código";
            this.NoProducto.MinimumWidth = 6;
            this.NoProducto.Name = "NoProducto";
            this.NoProducto.ReadOnly = true;
            this.NoProducto.Width = 80;
            // 
            // NombreProducto
            // 
            this.NombreProducto.HeaderText = "Producto";
            this.NombreProducto.MinimumWidth = 6;
            this.NombreProducto.Name = "NombreProducto";
            this.NombreProducto.ReadOnly = true;
            this.NombreProducto.Width = 90;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "P.Unitario";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 94;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 90;
            // 
            // Subtotal
            // 
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Subtotal.DefaultCellStyle = dataGridViewCellStyle1;
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.MinimumWidth = 6;
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            this.Subtotal.Width = 85;
            // 
            // Totaltbl
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Totaltbl.DefaultCellStyle = dataGridViewCellStyle2;
            this.Totaltbl.HeaderText = "Total";
            this.Totaltbl.MinimumWidth = 6;
            this.Totaltbl.Name = "Totaltbl";
            this.Totaltbl.ReadOnly = true;
            this.Totaltbl.Width = 67;
            // 
            // Impuestotbl
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Impuestotbl.DefaultCellStyle = dataGridViewCellStyle3;
            this.Impuestotbl.HeaderText = "Impuesto";
            this.Impuestotbl.MinimumWidth = 6;
            this.Impuestotbl.Name = "Impuestotbl";
            this.Impuestotbl.ReadOnly = true;
            this.Impuestotbl.Visible = false;
            this.Impuestotbl.Width = 91;
            // 
            // EsProductoFinaltbl
            // 
            this.EsProductoFinaltbl.HeaderText = "EsProductoFinal";
            this.EsProductoFinaltbl.MinimumWidth = 6;
            this.EsProductoFinaltbl.Name = "EsProductoFinaltbl";
            this.EsProductoFinaltbl.ReadOnly = true;
            this.EsProductoFinaltbl.Visible = false;
            this.EsProductoFinaltbl.Width = 135;
            // 
            // POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 826);
            this.Controls.Add(this.carttable);
            this.Controls.Add(this.cmbcategoria);
            this.Controls.Add(this.btnlimpiarcliente);
            this.Controls.Add(this.panelmesas);
            this.Controls.Add(this.panelproducto);
            this.Controls.Add(this.btnpendientes);
            this.Controls.Add(this.btnfacturas);
            this.Controls.Add(this.btnbuscarcliente);
            this.Controls.Add(this.txtcliente);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnborrar);
            this.Controls.Add(this.btnsolicitar);
            this.Controls.Add(this.tabletotales);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.cmbsalas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "POS";
            this.Text = "POS";
            this.tabletotales.ResumeLayout(false);
            this.tabletotales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carttable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ComboBox cmbcategoria;
        private Guna.UI2.WinForms.Guna2ComboBox cmbsalas;
        private Guna.UI2.WinForms.Guna2TextBox txtsearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel tabletotales;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label lblimpuesto;
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnsolicitar;
        private Guna.UI2.WinForms.Guna2Button btnborrar;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox txtcliente;
        private Guna.UI2.WinForms.Guna2Button btnbuscarcliente;
        private Guna.UI2.WinForms.Guna2Button btnfacturas;
        private Guna.UI2.WinForms.Guna2Button btnpendientes;
        private System.Windows.Forms.FlowLayoutPanel panelproducto;
        private System.Windows.Forms.FlowLayoutPanel panelmesas;
        private Guna.UI2.WinForms.Guna2Button btnlimpiarcliente;
        private System.Windows.Forms.DataGridView carttable;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProductotbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Totaltbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impuestotbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn EsProductoFinaltbl;
    }
}