namespace Restaurant.Views.Movimientos.POS_Paneles
{
    partial class controlproductos
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblprecio = new System.Windows.Forms.Label();
            this.gunaSeparator1 = new Guna.UI.WinForms.GunaSeparator();
            this.lblnombre = new System.Windows.Forms.Label();
            this.boxfoto = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2ShadowPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxfoto)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.panel1);
            this.guna2ShadowPanel1.Controls.Add(this.boxfoto);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(3, 3);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(150, 179);
            this.guna2ShadowPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblprecio);
            this.panel1.Controls.Add(this.gunaSeparator1);
            this.panel1.Controls.Add(this.lblnombre);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 50);
            this.panel1.TabIndex = 139;
            // 
            // lblprecio
            // 
            this.lblprecio.Location = new System.Drawing.Point(6, 23);
            this.lblprecio.Name = "lblprecio";
            this.lblprecio.Size = new System.Drawing.Size(141, 19);
            this.lblprecio.TabIndex = 2;
            this.lblprecio.Text = "Price";
            this.lblprecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gunaSeparator1
            // 
            this.gunaSeparator1.LineColor = System.Drawing.Color.Silver;
            this.gunaSeparator1.Location = new System.Drawing.Point(4, -4);
            this.gunaSeparator1.Name = "gunaSeparator1";
            this.gunaSeparator1.Size = new System.Drawing.Size(141, 10);
            this.gunaSeparator1.TabIndex = 1;
            // 
            // lblnombre
            // 
            this.lblnombre.Location = new System.Drawing.Point(6, 4);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(141, 19);
            this.lblnombre.TabIndex = 0;
            this.lblnombre.Text = "Name Producto";
            this.lblnombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boxfoto
            // 
            this.boxfoto.Location = new System.Drawing.Point(15, 13);
            this.boxfoto.Name = "boxfoto";
            this.boxfoto.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.boxfoto.ShadowDecoration.Parent = this.boxfoto;
            this.boxfoto.Size = new System.Drawing.Size(120, 110);
            this.boxfoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boxfoto.TabIndex = 138;
            this.boxfoto.TabStop = false;
            // 
            // controlproductos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "controlproductos";
            this.Size = new System.Drawing.Size(156, 185);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.boxfoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblnombre;
        private Guna.UI2.WinForms.Guna2CirclePictureBox boxfoto;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator1;
        private System.Windows.Forms.Label lblprecio;
    }
}
