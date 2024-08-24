namespace Restaurant.Views.Movimientos.POS_controles
{
    partial class controlmesas
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
            this.lblcantidad = new System.Windows.Forms.Label();
            this.labelpersonas = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2ShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.lblcantidad);
            this.guna2ShadowPanel1.Controls.Add(this.labelpersonas);
            this.guna2ShadowPanel1.Controls.Add(this.lblnombre);
            this.guna2ShadowPanel1.Controls.Add(this.guna2Separator1);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(2, 2);
            this.guna2ShadowPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(112, 132);
            this.guna2ShadowPanel1.TabIndex = 0;
            // 
            // lblcantidad
            // 
            this.lblcantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcantidad.Location = new System.Drawing.Point(6, 92);
            this.lblcantidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblcantidad.Name = "lblcantidad";
            this.lblcantidad.Size = new System.Drawing.Size(50, 19);
            this.lblcantidad.TabIndex = 3;
            this.lblcantidad.Text = "Total";
            this.lblcantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelpersonas
            // 
            this.labelpersonas.Location = new System.Drawing.Point(48, 92);
            this.labelpersonas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelpersonas.Name = "labelpersonas";
            this.labelpersonas.Size = new System.Drawing.Size(60, 19);
            this.labelpersonas.TabIndex = 2;
            this.labelpersonas.Text = "Personas";
            this.labelpersonas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblnombre
            // 
            this.lblnombre.BackColor = System.Drawing.Color.Green;
            this.lblnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.ForeColor = System.Drawing.Color.White;
            this.lblnombre.Location = new System.Drawing.Point(6, 6);
            this.lblnombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(103, 75);
            this.lblnombre.TabIndex = 0;
            this.lblnombre.Text = "Mesa Name";
            this.lblnombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(2, 78);
            this.guna2Separator1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(106, 8);
            this.guna2Separator1.TabIndex = 1;
            // 
            // controlmesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "controlmesas";
            this.Size = new System.Drawing.Size(117, 141);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Label lblnombre;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label lblcantidad;
        private System.Windows.Forms.Label labelpersonas;
    }
}
