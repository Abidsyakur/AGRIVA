namespace AGRIVA
{
    partial class EntriProdukForm
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
            this.pnlFormProduk = new Sunny.UI.UIPanel();
            this.btnSimpan = new Sunny.UI.UIButton();
            this.btnBatal = new Sunny.UI.UIButton();
            this.cmbStatus = new Sunny.UI.UIComboBox();
            this.lblStatus = new Sunny.UI.UILabel();
            this.lblKetHarga = new Sunny.UI.UILabel();
            this.txtHarga = new ReaLTaiizor.Controls.AloneTextBox();
            this.lblHarga = new Sunny.UI.UILabel();
            this.txtNamaProduk = new ReaLTaiizor.Controls.AloneTextBox();
            this.lblNamaProduk = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.lblJudulProduk = new Sunny.UI.UILabel();
            this.pnlFormProduk.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFormProduk
            // 
            this.pnlFormProduk.Controls.Add(this.btnSimpan);
            this.pnlFormProduk.Controls.Add(this.btnBatal);
            this.pnlFormProduk.Controls.Add(this.cmbStatus);
            this.pnlFormProduk.Controls.Add(this.lblStatus);
            this.pnlFormProduk.Controls.Add(this.lblKetHarga);
            this.pnlFormProduk.Controls.Add(this.txtHarga);
            this.pnlFormProduk.Controls.Add(this.lblHarga);
            this.pnlFormProduk.Controls.Add(this.txtNamaProduk);
            this.pnlFormProduk.Controls.Add(this.lblNamaProduk);
            this.pnlFormProduk.Controls.Add(this.uiLabel1);
            this.pnlFormProduk.Controls.Add(this.lblJudulProduk);
            this.pnlFormProduk.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlFormProduk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pnlFormProduk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.pnlFormProduk.Location = new System.Drawing.Point(5, 5);
            this.pnlFormProduk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlFormProduk.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlFormProduk.Name = "pnlFormProduk";
            this.pnlFormProduk.Radius = 15;
            this.pnlFormProduk.Size = new System.Drawing.Size(420, 450);
            this.pnlFormProduk.Style = Sunny.UI.UIStyle.Custom;
            this.pnlFormProduk.TabIndex = 0;
            this.pnlFormProduk.Text = null;
            this.pnlFormProduk.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimpan.FillColor = System.Drawing.Color.Olive;
            this.btnSimpan.FillColor2 = System.Drawing.Color.Olive;
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSimpan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.btnSimpan.Location = new System.Drawing.Point(235, 393);
            this.btnSimpan.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Radius = 7;
            this.btnSimpan.Size = new System.Drawing.Size(120, 38);
            this.btnSimpan.TabIndex = 14;
            this.btnSimpan.Text = "▣ Simpan";
            this.btnSimpan.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatal.FillColor = System.Drawing.Color.White;
            this.btnBatal.FillColor2 = System.Drawing.Color.White;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBatal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.btnBatal.Location = new System.Drawing.Point(73, 393);
            this.btnBatal.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Radius = 7;
            this.btnBatal.Size = new System.Drawing.Size(120, 38);
            this.btnBatal.TabIndex = 13;
            this.btnBatal.Text = "Batal";
            this.btnBatal.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DataSource = null;
            this.cmbStatus.FillColor = System.Drawing.Color.White;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbStatus.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cmbStatus.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.cmbStatus.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cmbStatus.Location = new System.Drawing.Point(20, 282);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbStatus.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbStatus.Size = new System.Drawing.Size(350, 30);
            this.cmbStatus.SymbolSize = 24;
            this.cmbStatus.TabIndex = 8;
            this.cmbStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbStatus.Watermark = "";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblStatus.Location = new System.Drawing.Point(20, 260);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 25);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status";
            // 
            // lblKetHarga
            // 
            this.lblKetHarga.AutoSize = true;
            this.lblKetHarga.BackColor = System.Drawing.Color.Transparent;
            this.lblKetHarga.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lblKetHarga.ForeColor = System.Drawing.Color.Gray;
            this.lblKetHarga.Location = new System.Drawing.Point(20, 222);
            this.lblKetHarga.Name = "lblKetHarga";
            this.lblKetHarga.Size = new System.Drawing.Size(231, 19);
            this.lblKetHarga.TabIndex = 6;
            this.lblKetHarga.Text = "Tulis angka tanpa titik.Contoh: 8000";
            // 
            // txtHarga
            // 
            this.txtHarga.BackColor = System.Drawing.Color.Transparent;
            this.txtHarga.EnabledCalc = true;
            this.txtHarga.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHarga.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.txtHarga.Location = new System.Drawing.Point(20, 190);
            this.txtHarga.MaxLength = 32767;
            this.txtHarga.MultiLine = false;
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.ReadOnly = false;
            this.txtHarga.Size = new System.Drawing.Size(350, 30);
            this.txtHarga.TabIndex = 5;
            this.txtHarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtHarga.UseSystemPasswordChar = false;
            // 
            // lblHarga
            // 
            this.lblHarga.AutoSize = true;
            this.lblHarga.BackColor = System.Drawing.Color.Transparent;
            this.lblHarga.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHarga.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.lblHarga.Location = new System.Drawing.Point(20, 165);
            this.lblHarga.Name = "lblHarga";
            this.lblHarga.Size = new System.Drawing.Size(117, 25);
            this.lblHarga.TabIndex = 4;
            this.lblHarga.Text = "Harga per Kg";
            // 
            // txtNamaProduk
            // 
            this.txtNamaProduk.BackColor = System.Drawing.Color.Transparent;
            this.txtNamaProduk.EnabledCalc = true;
            this.txtNamaProduk.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNamaProduk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.txtNamaProduk.Location = new System.Drawing.Point(20, 122);
            this.txtNamaProduk.MaxLength = 32767;
            this.txtNamaProduk.MultiLine = false;
            this.txtNamaProduk.Name = "txtNamaProduk";
            this.txtNamaProduk.ReadOnly = false;
            this.txtNamaProduk.Size = new System.Drawing.Size(350, 30);
            this.txtNamaProduk.TabIndex = 3;
            this.txtNamaProduk.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNamaProduk.UseSystemPasswordChar = false;
            // 
            // lblNamaProduk
            // 
            this.lblNamaProduk.AutoSize = true;
            this.lblNamaProduk.BackColor = System.Drawing.Color.Transparent;
            this.lblNamaProduk.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNamaProduk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblNamaProduk.Location = new System.Drawing.Point(20, 100);
            this.lblNamaProduk.Name = "lblNamaProduk";
            this.lblNamaProduk.Size = new System.Drawing.Size(173, 25);
            this.lblNamaProduk.TabIndex = 2;
            this.lblNamaProduk.Text = "Nama Produk Panen";
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.uiLabel1.ForeColor = System.Drawing.Color.Gray;
            this.uiLabel1.Location = new System.Drawing.Point(20, 58);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(311, 25);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "Isi data dibawah ini, lalu tekan simpan";
            // 
            // lblJudulProduk
            // 
            this.lblJudulProduk.AutoSize = true;
            this.lblJudulProduk.BackColor = System.Drawing.Color.Transparent;
            this.lblJudulProduk.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblJudulProduk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.lblJudulProduk.Location = new System.Drawing.Point(20, 18);
            this.lblJudulProduk.Name = "lblJudulProduk";
            this.lblJudulProduk.Size = new System.Drawing.Size(381, 38);
            this.lblJudulProduk.TabIndex = 0;
            this.lblJudulProduk.Text = "Tambah Produk Panen Baru";
            // 
            // EntriProdukForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 555);
            this.Controls.Add(this.pnlFormProduk);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntriProdukForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AGRIVA - Tambah Produk";
            this.pnlFormProduk.ResumeLayout(false);
            this.pnlFormProduk.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel pnlFormProduk;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel lblJudulProduk;
        private ReaLTaiizor.Controls.AloneTextBox txtNamaProduk;
        private Sunny.UI.UILabel lblNamaProduk;
        private Sunny.UI.UILabel lblHarga;
        private ReaLTaiizor.Controls.AloneTextBox txtHarga;
        private Sunny.UI.UILabel lblStatus;
        private Sunny.UI.UILabel lblKetHarga;
        private Sunny.UI.UIComboBox cmbStatus;
        private Sunny.UI.UIButton btnBatal;
        private Sunny.UI.UIButton btnSimpan;
    }
}