namespace Restaurant.Views.Movimientos
{
    partial class FacturaView
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
            this.report = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // report
            // 
            this.report.AutoSize = true;
            this.report.LocalReport.ReportEmbeddedResource = "Restaurant.Views.Movimientos.controlesPOS.FacturaReport.rdlc";
            this.report.Location = new System.Drawing.Point(0, 0);
            this.report.Margin = new System.Windows.Forms.Padding(4);
            this.report.Name = "report";
            this.report.ServerReport.BearerToken = null;
            this.report.Size = new System.Drawing.Size(605, 822);
            this.report.TabIndex = 0;
            // 
            // FacturaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 822);
            this.Controls.Add(this.report);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FacturaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura View";
            this.Load += new System.EventHandler(this.ReportView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer report;
    }
}