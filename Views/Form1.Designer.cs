namespace AGRIVA
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblUserHeader = new System.Windows.Forms.Label();
            this.pnlUserBox = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblErrUsername = new System.Windows.Forms.Label();
            this.lblPassHeader = new System.Windows.Forms.Label();
            this.pnlPassBox = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pnlToggleEye = new System.Windows.Forms.Panel();
            this.lblErrPassword = new System.Windows.Forms.Label();
            this.btnMasuk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlCard.SuspendLayout();
            this.pnlUserBox.SuspendLayout();
            this.pnlPassBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(325, 45);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(200, 42);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblSubtitle);
            this.pnlCard.Controls.Add(this.lblUserHeader);
            this.pnlCard.Controls.Add(this.pnlUserBox);
            this.pnlCard.Controls.Add(this.lblErrUsername);
            this.pnlCard.Controls.Add(this.lblPassHeader);
            this.pnlCard.Controls.Add(this.pnlPassBox);
            this.pnlCard.Controls.Add(this.lblErrPassword);
            this.pnlCard.Controls.Add(this.btnMasuk);
            this.pnlCard.Location = new System.Drawing.Point(235, 105);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(380, 460);
            this.pnlCard.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(44)))), ((int)(((byte)(36)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(340, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Selamat Datang";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(110)))), ((int)(((byte)(94)))));
            this.lblSubtitle.Location = new System.Drawing.Point(20, 64);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(340, 24);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Silahkan masuk dengan akun Anda";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserHeader
            // 
            this.lblUserHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(44)))), ((int)(((byte)(36)))));
            this.lblUserHeader.Location = new System.Drawing.Point(28, 104);
            this.lblUserHeader.Name = "lblUserHeader";
            this.lblUserHeader.Size = new System.Drawing.Size(324, 20);
            this.lblUserHeader.TabIndex = 2;
            this.lblUserHeader.Text = "Nama Pengguna";
            // 
            // pnlUserBox
            // 
            this.pnlUserBox.BackColor = System.Drawing.Color.White;
            this.pnlUserBox.Controls.Add(this.txtUsername);
            this.pnlUserBox.Location = new System.Drawing.Point(28, 128);
            this.pnlUserBox.Name = "pnlUserBox";
            this.pnlUserBox.Size = new System.Drawing.Size(324, 42);
            this.pnlUserBox.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(44)))), ((int)(((byte)(36)))));
            this.txtUsername.Location = new System.Drawing.Point(14, 11);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(296, 23);
            this.txtUsername.TabIndex = 0;
            // 
            // lblErrUsername
            // 
            this.lblErrUsername.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblErrUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.lblErrUsername.Location = new System.Drawing.Point(28, 173);
            this.lblErrUsername.Name = "lblErrUsername";
            this.lblErrUsername.Size = new System.Drawing.Size(324, 18);
            this.lblErrUsername.TabIndex = 4;
            this.lblErrUsername.Text = "(!) Mohon isi nama pengguna Anda";
            this.lblErrUsername.Visible = false;
            // 
            // lblPassHeader
            // 
            this.lblPassHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(44)))), ((int)(((byte)(36)))));
            this.lblPassHeader.Location = new System.Drawing.Point(28, 198);
            this.lblPassHeader.Name = "lblPassHeader";
            this.lblPassHeader.Size = new System.Drawing.Size(324, 20);
            this.lblPassHeader.TabIndex = 5;
            this.lblPassHeader.Text = "Kata Sandi";
            // 
            // pnlPassBox
            // 
            this.pnlPassBox.BackColor = System.Drawing.Color.White;
            this.pnlPassBox.Controls.Add(this.txtPassword);
            this.pnlPassBox.Controls.Add(this.pnlToggleEye);
            this.pnlPassBox.Location = new System.Drawing.Point(28, 222);
            this.pnlPassBox.Name = "pnlPassBox";
            this.pnlPassBox.Size = new System.Drawing.Size(324, 42);
            this.pnlPassBox.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(44)))), ((int)(((byte)(36)))));
            this.txtPassword.Location = new System.Drawing.Point(14, 11);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(225, 23);
            this.txtPassword.TabIndex = 0;
            // 
            // pnlToggleEye
            // 
            this.pnlToggleEye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlToggleEye.Location = new System.Drawing.Point(244, 7);
            this.pnlToggleEye.Name = "pnlToggleEye";
            this.pnlToggleEye.Size = new System.Drawing.Size(72, 28);
            this.pnlToggleEye.TabIndex = 1;
            // 
            // lblErrPassword
            // 
            this.lblErrPassword.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblErrPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.lblErrPassword.Location = new System.Drawing.Point(28, 267);
            this.lblErrPassword.Name = "lblErrPassword";
            this.lblErrPassword.Size = new System.Drawing.Size(324, 18);
            this.lblErrPassword.TabIndex = 7;
            this.lblErrPassword.Text = "(!) Mohon isi kata sandi Anda";
            this.lblErrPassword.Visible = false;
            // 
            // btnMasuk
            // 
            this.btnMasuk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMasuk.FlatAppearance.BorderSize = 0;
            this.btnMasuk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasuk.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasuk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(44)))), ((int)(((byte)(36)))));
            this.btnMasuk.Location = new System.Drawing.Point(28, 305);
            this.btnMasuk.Name = "btnMasuk";
            this.btnMasuk.Size = new System.Drawing.Size(324, 46);
            this.btnMasuk.TabIndex = 8;
            this.btnMasuk.Text = "→] Masuk";
            this.btnMasuk.UseVisualStyleBackColor = true;
            this.btnMasuk.Click += new System.EventHandler(this.btnMasuk_Click);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnMasuk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(850, 620);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.pnlCard);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AGRIVA — Masuk Sistem";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlCard.ResumeLayout(false);
            this.pnlUserBox.ResumeLayout(false);
            this.pnlUserBox.PerformLayout();
            this.pnlPassBox.ResumeLayout(false);
            this.pnlPassBox.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUserHeader;
        private System.Windows.Forms.Panel pnlUserBox;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblErrUsername;
        private System.Windows.Forms.Label lblPassHeader;
        private System.Windows.Forms.Panel pnlPassBox;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel pnlToggleEye;
        private System.Windows.Forms.Label lblErrPassword;
        private System.Windows.Forms.Button btnMasuk;
    }
}
