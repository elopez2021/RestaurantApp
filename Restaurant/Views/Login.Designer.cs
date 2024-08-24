namespace Restaurant
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtuser = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpass = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnlogin = new Guna.UI2.WinForms.Guna2Button();
            this.btnexit = new Guna.UI2.WinForms.Guna2Button();
            this.showpass = new System.Windows.Forms.PictureBox();
            this.noshowpass = new System.Windows.Forms.PictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showpass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noshowpass)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(395, 158);
            this.guna2Panel1.TabIndex = 4;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::Restaurant.Properties.Resources.Logo_Pizzeria;
            this.guna2PictureBox1.Location = new System.Drawing.Point(128, 12);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(139, 129);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // txtuser
            // 
            this.txtuser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtuser.DefaultText = "";
            this.txtuser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtuser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtuser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtuser.DisabledState.Parent = this.txtuser;
            this.txtuser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtuser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtuser.FocusedState.Parent = this.txtuser;
            this.txtuser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtuser.HoverState.Parent = this.txtuser;
            this.txtuser.Location = new System.Drawing.Point(32, 204);
            this.txtuser.Margin = new System.Windows.Forms.Padding(5);
            this.txtuser.Name = "txtuser";
            this.txtuser.PasswordChar = '\0';
            this.txtuser.PlaceholderText = "";
            this.txtuser.SelectedText = "";
            this.txtuser.ShadowDecoration.Parent = this.txtuser;
            this.txtuser.Size = new System.Drawing.Size(335, 31);
            this.txtuser.TabIndex = 0;
            this.txtuser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtuser_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // txtpass
            // 
            this.txtpass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpass.DefaultText = "";
            this.txtpass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtpass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtpass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpass.DisabledState.Parent = this.txtpass;
            this.txtpass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpass.FocusedState.Parent = this.txtpass;
            this.txtpass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpass.HoverState.Parent = this.txtpass;
            this.txtpass.Location = new System.Drawing.Point(32, 282);
            this.txtpass.Margin = new System.Windows.Forms.Padding(5);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '\0';
            this.txtpass.PlaceholderText = "";
            this.txtpass.SelectedText = "";
            this.txtpass.ShadowDecoration.Parent = this.txtpass;
            this.txtpass.Size = new System.Drawing.Size(335, 31);
            this.txtpass.TabIndex = 1;
            this.txtpass.UseSystemPasswordChar = true;
            this.txtpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpass_KeyPress);
            // 
            // btnlogin
            // 
            this.btnlogin.Animated = true;
            this.btnlogin.BorderRadius = 10;
            this.btnlogin.CheckedState.Parent = this.btnlogin;
            this.btnlogin.CustomImages.Parent = this.btnlogin;
            this.btnlogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnlogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.ForeColor = System.Drawing.Color.White;
            this.btnlogin.HoverState.Parent = this.btnlogin;
            this.btnlogin.Location = new System.Drawing.Point(59, 367);
            this.btnlogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.ShadowDecoration.Parent = this.btnlogin;
            this.btnlogin.Size = new System.Drawing.Size(117, 46);
            this.btnlogin.TabIndex = 2;
            this.btnlogin.Text = "Login";
            // 
            // btnexit
            // 
            this.btnexit.Animated = true;
            this.btnexit.BorderRadius = 10;
            this.btnexit.CheckedState.Parent = this.btnexit;
            this.btnexit.CustomImages.Parent = this.btnexit;
            this.btnexit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnexit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.ForeColor = System.Drawing.Color.White;
            this.btnexit.HoverState.Parent = this.btnexit;
            this.btnexit.Location = new System.Drawing.Point(227, 367);
            this.btnexit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnexit.Name = "btnexit";
            this.btnexit.ShadowDecoration.Parent = this.btnexit;
            this.btnexit.Size = new System.Drawing.Size(117, 46);
            this.btnexit.TabIndex = 3;
            this.btnexit.Text = "Exit";
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // showpass
            // 
            this.showpass.BackColor = System.Drawing.Color.White;
            this.showpass.Image = global::Restaurant.Properties.Resources.showpass;
            this.showpass.Location = new System.Drawing.Point(336, 286);
            this.showpass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showpass.Name = "showpass";
            this.showpass.Size = new System.Drawing.Size(28, 26);
            this.showpass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.showpass.TabIndex = 7;
            this.showpass.TabStop = false;
            this.showpass.Click += new System.EventHandler(this.showpass_Click_1);
            // 
            // noshowpass
            // 
            this.noshowpass.BackColor = System.Drawing.Color.White;
            this.noshowpass.Image = global::Restaurant.Properties.Resources.noshowpass;
            this.noshowpass.Location = new System.Drawing.Point(336, 286);
            this.noshowpass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.noshowpass.Name = "noshowpass";
            this.noshowpass.Size = new System.Drawing.Size(28, 26);
            this.noshowpass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.noshowpass.TabIndex = 8;
            this.noshowpass.TabStop = false;
            this.noshowpass.Click += new System.EventHandler(this.noshowpass_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 450);
            this.Controls.Add(this.noshowpass);
            this.Controls.Add(this.showpass);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showpass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noshowpass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtuser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtpass;
        private Guna.UI2.WinForms.Guna2Button btnlogin;
        private Guna.UI2.WinForms.Guna2Button btnexit;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.PictureBox showpass;
        private System.Windows.Forms.PictureBox noshowpass;
    }
}

