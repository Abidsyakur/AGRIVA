namespace AGRIVA
{
    partial class SetorPanenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetorPanenForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSidebar = new Sunny.UI.UIPanel();
            this.lblKoperasi = new Sunny.UI.UILabel();
            this.btnManajemenUser = new Sunny.UI.UIButton();
            this.btnLaporan = new Sunny.UI.UIButton();
            this.btnMuatanBarang = new Sunny.UI.UIButton();
            this.btnProdukPanen = new Sunny.UI.UIButton();
            this.btnPetani = new Sunny.UI.UIButton();
            this.btnSetorPanen = new Sunny.UI.UIButton();
            this.btnDashboard = new Sunny.UI.UIButton();
            this.lblNamaApp = new Sunny.UI.UILabel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlHeader = new Sunny.UI.UIPanel();
            this.btnKeluar = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.pnlSetorPanen = new Sunny.UI.UIPanel();
            this.lblJudulSetor = new Sunny.UI.UILabel();
            this.lblKetSetor = new Sunny.UI.UILabel();
            this.lblPetani = new Sunny.UI.UILabel();
            this.cmbPetani = new Sunny.UI.UIComboBox();
            this.lblProdukPanen = new Sunny.UI.UILabel();
            this.cmbProduk = new Sunny.UI.UIComboBox();
            this.lblBerat = new Sunny.UI.UILabel();
            this.txtBerat = new ReaLTaiizor.Controls.AloneTextBox();
            this.lblKualitas = new Sunny.UI.UILabel();
            this.cmbKualitas = new Sunny.UI.UIComboBox();
            this.lblTotalUang = new Sunny.UI.UILabel();
            this.txtTotalUang = new ReaLTaiizor.Controls.AloneTextBox();
            this.lblInfoTotal = new Sunny.UI.UILabel();
            this.btnSimpanSetoran = new Sunny.UI.UIButton();
            this.btnKosongkan = new Sunny.UI.UIButton();
            this.pnlTabelSetoran = new Sunny.UI.UIPanel();
            this.lblSetoranHariIni = new Sunny.UI.UILabel();
            this.dgvSetoran = new System.Windows.Forms.DataGridView();
            this.colTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPetani = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBerat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKualitas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPetugas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlSetorPanen.SuspendLayout();
            this.pnlTabelSetoran.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetoran)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.pnlSidebar.Controls.Add(this.lblKoperasi);
            this.pnlSidebar.Controls.Add(this.btnManajemenUser);
            this.pnlSidebar.Controls.Add(this.btnLaporan);
            this.pnlSidebar.Controls.Add(this.btnMuatanBarang);
            this.pnlSidebar.Controls.Add(this.btnProdukPanen);
            this.pnlSidebar.Controls.Add(this.btnPetani);
            this.pnlSidebar.Controls.Add(this.btnSetorPanen);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.lblNamaApp);
            this.pnlSidebar.Controls.Add(this.picLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.pnlSidebar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlSidebar.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Radius = 0;
            this.pnlSidebar.Size = new System.Drawing.Size(220, 744);
            this.pnlSidebar.TabIndex = 2;
            this.pnlSidebar.Text = null;
            this.pnlSidebar.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKoperasi
            // 
            this.lblKoperasi.BackColor = System.Drawing.Color.Transparent;
            this.lblKoperasi.Font = new System.Drawing.Font("Segoe UI", 5F);
            this.lblKoperasi.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblKoperasi.Location = new System.Drawing.Point(57, 45);
            this.lblKoperasi.Name = "lblKoperasi";
            this.lblKoperasi.Size = new System.Drawing.Size(100, 30);
            this.lblKoperasi.TabIndex = 9;
            this.lblKoperasi.Text = "Koperasi Tani Desa";
            // 
            // btnManajemenUser
            // 
            this.btnManajemenUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManajemenUser.FillColor = System.Drawing.Color.Transparent;
            this.btnManajemenUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnManajemenUser.Location = new System.Drawing.Point(12, 462);
            this.btnManajemenUser.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnManajemenUser.Name = "btnManajemenUser";
            this.btnManajemenUser.Radius = 8;
            this.btnManajemenUser.Size = new System.Drawing.Size(150, 38);
            this.btnManajemenUser.TabIndex = 8;
            this.btnManajemenUser.Text = "Manajemen User";
            this.btnManajemenUser.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // btnLaporan
            // 
            this.btnLaporan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLaporan.FillColor = System.Drawing.Color.Transparent;
            this.btnLaporan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLaporan.Location = new System.Drawing.Point(12, 398);
            this.btnLaporan.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Radius = 8;
            this.btnLaporan.Size = new System.Drawing.Size(150, 38);
            this.btnLaporan.TabIndex = 7;
            this.btnLaporan.Text = "Laporan";
            this.btnLaporan.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // btnMuatanBarang
            // 
            this.btnMuatanBarang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMuatanBarang.FillColor = System.Drawing.Color.Transparent;
            this.btnMuatanBarang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMuatanBarang.Location = new System.Drawing.Point(12, 337);
            this.btnMuatanBarang.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnMuatanBarang.Name = "btnMuatanBarang";
            this.btnMuatanBarang.Radius = 8;
            this.btnMuatanBarang.Size = new System.Drawing.Size(150, 38);
            this.btnMuatanBarang.TabIndex = 6;
            this.btnMuatanBarang.Text = "Muatan Barang";
            this.btnMuatanBarang.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // btnProdukPanen
            // 
            this.btnProdukPanen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProdukPanen.FillColor = System.Drawing.Color.Transparent;
            this.btnProdukPanen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProdukPanen.Location = new System.Drawing.Point(12, 220);
            this.btnProdukPanen.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnProdukPanen.Name = "btnProdukPanen";
            this.btnProdukPanen.Radius = 8;
            this.btnProdukPanen.Size = new System.Drawing.Size(150, 38);
            this.btnProdukPanen.TabIndex = 5;
            this.btnProdukPanen.Text = "Produk Panen";
            this.btnProdukPanen.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // btnPetani
            // 
            this.btnPetani.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPetani.FillColor = System.Drawing.Color.Transparent;
            this.btnPetani.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPetani.Location = new System.Drawing.Point(12, 158);
            this.btnPetani.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnPetani.Name = "btnPetani";
            this.btnPetani.Radius = 8;
            this.btnPetani.Size = new System.Drawing.Size(150, 38);
            this.btnPetani.TabIndex = 4;
            this.btnPetani.Text = "Petani";
            this.btnPetani.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // btnSetorPanen
            // 
            this.btnSetorPanen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetorPanen.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(172)))), ((int)(((byte)(120)))));
            this.btnSetorPanen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSetorPanen.Location = new System.Drawing.Point(12, 275);
            this.btnSetorPanen.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSetorPanen.Name = "btnSetorPanen";
            this.btnSetorPanen.Radius = 8;
            this.btnSetorPanen.Size = new System.Drawing.Size(150, 38);
            this.btnSetorPanen.TabIndex = 3;
            this.btnSetorPanen.Text = "Setor Panen";
            this.btnSetorPanen.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FillColor = System.Drawing.Color.Transparent;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDashboard.Location = new System.Drawing.Point(12, 99);
            this.btnDashboard.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Radius = 8;
            this.btnDashboard.Size = new System.Drawing.Size(150, 38);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // lblNamaApp
            // 
            this.lblNamaApp.BackColor = System.Drawing.Color.Transparent;
            this.lblNamaApp.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblNamaApp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(240)))), ((int)(((byte)(218)))));
            this.lblNamaApp.Location = new System.Drawing.Point(52, 0);
            this.lblNamaApp.Name = "lblNamaApp";
            this.lblNamaApp.Size = new System.Drawing.Size(129, 45);
            this.lblNamaApp.TabIndex = 1;
            this.lblNamaApp.Text = "AGRIVA";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(-9, 10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(65, 55);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.Controls.Add(this.btnKeluar);
            this.pnlHeader.Controls.Add(this.uiLabel1);
            this.pnlHeader.Controls.Add(this.uiButton2);
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pnlHeader.Location = new System.Drawing.Point(228, 3);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Radius = 0;
            this.pnlHeader.Size = new System.Drawing.Size(750, 60);
            this.pnlHeader.TabIndex = 3;
            this.pnlHeader.Text = null;
            this.pnlHeader.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnKeluar
            // 
            this.btnKeluar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKeluar.FillColor = System.Drawing.Color.Transparent;
            this.btnKeluar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.btnKeluar.Location = new System.Drawing.Point(626, 18);
            this.btnKeluar.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Radius = 10;
            this.btnKeluar.Size = new System.Drawing.Size(92, 32);
            this.btnKeluar.TabIndex = 2;
            this.btnKeluar.Text = "↪ Keluar";
            this.btnKeluar.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.uiLabel1.Location = new System.Drawing.Point(485, 22);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(109, 28);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "Bapak Budi";
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.FillColor = System.Drawing.Color.Goldenrod;
            this.uiButton2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.uiButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.uiButton2.Location = new System.Drawing.Point(379, 15);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Radius = 10;
            this.uiButton2.Size = new System.Drawing.Size(100, 35);
            this.uiButton2.TabIndex = 0;
            this.uiButton2.Text = "Admin";
            this.uiButton2.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // pnlSetorPanen
            // 
            this.pnlSetorPanen.Controls.Add(this.btnKosongkan);
            this.pnlSetorPanen.Controls.Add(this.btnSimpanSetoran);
            this.pnlSetorPanen.Controls.Add(this.lblInfoTotal);
            this.pnlSetorPanen.Controls.Add(this.txtTotalUang);
            this.pnlSetorPanen.Controls.Add(this.lblTotalUang);
            this.pnlSetorPanen.Controls.Add(this.cmbKualitas);
            this.pnlSetorPanen.Controls.Add(this.lblKualitas);
            this.pnlSetorPanen.Controls.Add(this.txtBerat);
            this.pnlSetorPanen.Controls.Add(this.lblBerat);
            this.pnlSetorPanen.Controls.Add(this.cmbProduk);
            this.pnlSetorPanen.Controls.Add(this.lblProdukPanen);
            this.pnlSetorPanen.Controls.Add(this.cmbPetani);
            this.pnlSetorPanen.Controls.Add(this.lblPetani);
            this.pnlSetorPanen.Controls.Add(this.lblKetSetor);
            this.pnlSetorPanen.Controls.Add(this.lblJudulSetor);
            this.pnlSetorPanen.FillColor = System.Drawing.Color.White;
            this.pnlSetorPanen.FillColor2 = System.Drawing.Color.White;
            this.pnlSetorPanen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pnlSetorPanen.Location = new System.Drawing.Point(228, 99);
            this.pnlSetorPanen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlSetorPanen.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlSetorPanen.Name = "pnlSetorPanen";
            this.pnlSetorPanen.Radius = 12;
            this.pnlSetorPanen.Size = new System.Drawing.Size(727, 420);
            this.pnlSetorPanen.Style = Sunny.UI.UIStyle.Custom;
            this.pnlSetorPanen.TabIndex = 4;
            this.pnlSetorPanen.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJudulSetor
            // 
            this.lblJudulSetor.AutoSize = true;
            this.lblJudulSetor.BackColor = System.Drawing.Color.Transparent;
            this.lblJudulSetor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblJudulSetor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.lblJudulSetor.Location = new System.Drawing.Point(3, 22);
            this.lblJudulSetor.Name = "lblJudulSetor";
            this.lblJudulSetor.Size = new System.Drawing.Size(200, 45);
            this.lblJudulSetor.TabIndex = 0;
            this.lblJudulSetor.Text = "Setor Panen";
            // 
            // lblKetSetor
            // 
            this.lblKetSetor.AutoSize = true;
            this.lblKetSetor.BackColor = System.Drawing.Color.Transparent;
            this.lblKetSetor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKetSetor.ForeColor = System.Drawing.Color.Gray;
            this.lblKetSetor.Location = new System.Drawing.Point(6, 67);
            this.lblKetSetor.Name = "lblKetSetor";
            this.lblKetSetor.Size = new System.Drawing.Size(365, 25);
            this.lblKetSetor.TabIndex = 1;
            this.lblKetSetor.Text = "Catat hasil panen yang ditimbang di gudang";
            // 
            // lblPetani
            // 
            this.lblPetani.AutoSize = true;
            this.lblPetani.BackColor = System.Drawing.Color.Transparent;
            this.lblPetani.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPetani.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.lblPetani.Location = new System.Drawing.Point(20, 100);
            this.lblPetani.Name = "lblPetani";
            this.lblPetani.Size = new System.Drawing.Size(59, 25);
            this.lblPetani.TabIndex = 2;
            this.lblPetani.Text = "Petani";
            // 
            // cmbPetani
            // 
            this.cmbPetani.DataSource = null;
            this.cmbPetani.FillColor = System.Drawing.Color.White;
            this.cmbPetani.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPetani.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.cmbPetani.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cmbPetani.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cmbPetani.Location = new System.Drawing.Point(20, 130);
            this.cmbPetani.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPetani.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbPetani.Name = "cmbPetani";
            this.cmbPetani.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbPetani.Radius = 8;
            this.cmbPetani.Size = new System.Drawing.Size(300, 35);
            this.cmbPetani.SymbolSize = 24;
            this.cmbPetani.TabIndex = 3;
            this.cmbPetani.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbPetani.Watermark = "";
            // 
            // lblProdukPanen
            // 
            this.lblProdukPanen.AutoSize = true;
            this.lblProdukPanen.BackColor = System.Drawing.Color.Transparent;
            this.lblProdukPanen.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblProdukPanen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.lblProdukPanen.Location = new System.Drawing.Point(350, 100);
            this.lblProdukPanen.Name = "lblProdukPanen";
            this.lblProdukPanen.Size = new System.Drawing.Size(106, 21);
            this.lblProdukPanen.TabIndex = 4;
            this.lblProdukPanen.Text = "Produk Panen";
            // 
            // cmbProduk
            // 
            this.cmbProduk.DataSource = null;
            this.cmbProduk.FillColor = System.Drawing.Color.White;
            this.cmbProduk.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbProduk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.cmbProduk.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cmbProduk.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cmbProduk.Location = new System.Drawing.Point(350, 130);
            this.cmbProduk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbProduk.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbProduk.Name = "cmbProduk";
            this.cmbProduk.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbProduk.Radius = 8;
            this.cmbProduk.Size = new System.Drawing.Size(300, 35);
            this.cmbProduk.SymbolSize = 24;
            this.cmbProduk.TabIndex = 5;
            this.cmbProduk.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbProduk.Watermark = "";
            // 
            // lblBerat
            // 
            this.lblBerat.AutoSize = true;
            this.lblBerat.BackColor = System.Drawing.Color.Transparent;
            this.lblBerat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBerat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.lblBerat.Location = new System.Drawing.Point(20, 185);
            this.lblBerat.Name = "lblBerat";
            this.lblBerat.Size = new System.Drawing.Size(83, 25);
            this.lblBerat.TabIndex = 6;
            this.lblBerat.Text = "Berat(Kg)";
            // 
            // txtBerat
            // 
            this.txtBerat.BackColor = System.Drawing.Color.Transparent;
            this.txtBerat.EnabledCalc = true;
            this.txtBerat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBerat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.txtBerat.Location = new System.Drawing.Point(20, 210);
            this.txtBerat.MaxLength = 32767;
            this.txtBerat.MultiLine = false;
            this.txtBerat.Name = "txtBerat";
            this.txtBerat.ReadOnly = false;
            this.txtBerat.Size = new System.Drawing.Size(300, 30);
            this.txtBerat.TabIndex = 7;
            this.txtBerat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBerat.UseSystemPasswordChar = false;
            // 
            // lblKualitas
            // 
            this.lblKualitas.AutoSize = true;
            this.lblKualitas.BackColor = System.Drawing.Color.Transparent;
            this.lblKualitas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKualitas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.lblKualitas.Location = new System.Drawing.Point(350, 185);
            this.lblKualitas.Name = "lblKualitas";
            this.lblKualitas.Size = new System.Drawing.Size(72, 25);
            this.lblKualitas.TabIndex = 8;
            this.lblKualitas.Text = "Kualitas";
            // 
            // cmbKualitas
            // 
            this.cmbKualitas.DataSource = null;
            this.cmbKualitas.FillColor = System.Drawing.Color.White;
            this.cmbKualitas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbKualitas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.cmbKualitas.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cmbKualitas.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cmbKualitas.Location = new System.Drawing.Point(350, 210);
            this.cmbKualitas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbKualitas.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbKualitas.Name = "cmbKualitas";
            this.cmbKualitas.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbKualitas.Radius = 8;
            this.cmbKualitas.Size = new System.Drawing.Size(300, 35);
            this.cmbKualitas.SymbolSize = 24;
            this.cmbKualitas.TabIndex = 9;
            this.cmbKualitas.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbKualitas.Watermark = "";
            // 
            // lblTotalUang
            // 
            this.lblTotalUang.AutoSize = true;
            this.lblTotalUang.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalUang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalUang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.lblTotalUang.Location = new System.Drawing.Point(20, 270);
            this.lblTotalUang.Name = "lblTotalUang";
            this.lblTotalUang.Size = new System.Drawing.Size(96, 25);
            this.lblTotalUang.TabIndex = 10;
            this.lblTotalUang.Text = "Total Uang";
            // 
            // txtTotalUang
            // 
            this.txtTotalUang.BackColor = System.Drawing.Color.Transparent;
            this.txtTotalUang.EnabledCalc = true;
            this.txtTotalUang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtTotalUang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.txtTotalUang.Location = new System.Drawing.Point(20, 295);
            this.txtTotalUang.MaxLength = 32767;
            this.txtTotalUang.MultiLine = false;
            this.txtTotalUang.Name = "txtTotalUang";
            this.txtTotalUang.ReadOnly = false;
            this.txtTotalUang.Size = new System.Drawing.Size(680, 45);
            this.txtTotalUang.TabIndex = 11;
            this.txtTotalUang.Text = "Rp";
            this.txtTotalUang.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTotalUang.UseSystemPasswordChar = false;
            // 
            // lblInfoTotal
            // 
            this.lblInfoTotal.AutoSize = true;
            this.lblInfoTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoTotal.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblInfoTotal.ForeColor = System.Drawing.Color.Gray;
            this.lblInfoTotal.Location = new System.Drawing.Point(20, 340);
            this.lblInfoTotal.Name = "lblInfoTotal";
            this.lblInfoTotal.Size = new System.Drawing.Size(372, 21);
            this.lblInfoTotal.TabIndex = 12;
            this.lblInfoTotal.Text = "Pilih produk panen dan kualitas untuk melihat harga";
            // 
            // btnSimpanSetoran
            // 
            this.btnSimpanSetoran.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimpanSetoran.FillColor = System.Drawing.Color.Olive;
            this.btnSimpanSetoran.FillColor2 = System.Drawing.Color.Olive;
            this.btnSimpanSetoran.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSimpanSetoran.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.btnSimpanSetoran.Location = new System.Drawing.Point(550, 370);
            this.btnSimpanSetoran.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSimpanSetoran.Name = "btnSimpanSetoran";
            this.btnSimpanSetoran.Radius = 7;
            this.btnSimpanSetoran.Size = new System.Drawing.Size(150, 30);
            this.btnSimpanSetoran.TabIndex = 14;
            this.btnSimpanSetoran.Text = "▣ Simpan Setoran";
            this.btnSimpanSetoran.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // btnKosongkan
            // 
            this.btnKosongkan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKosongkan.FillColor = System.Drawing.Color.White;
            this.btnKosongkan.FillColor2 = System.Drawing.Color.White;
            this.btnKosongkan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnKosongkan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.btnKosongkan.Location = new System.Drawing.Point(430, 370);
            this.btnKosongkan.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnKosongkan.Name = "btnKosongkan";
            this.btnKosongkan.Radius = 7;
            this.btnKosongkan.Size = new System.Drawing.Size(110, 35);
            this.btnKosongkan.TabIndex = 15;
            this.btnKosongkan.Text = "◇ Kosongkan";
            this.btnKosongkan.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnKosongkan.Click += new System.EventHandler(this.btnKosongkan_Click);
            // 
            // pnlTabelSetoran
            // 
            this.pnlTabelSetoran.Controls.Add(this.dgvSetoran);
            this.pnlTabelSetoran.FillColor = System.Drawing.Color.White;
            this.pnlTabelSetoran.FillColor2 = System.Drawing.Color.White;
            this.pnlTabelSetoran.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pnlTabelSetoran.Location = new System.Drawing.Point(228, 590);
            this.pnlTabelSetoran.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTabelSetoran.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTabelSetoran.Name = "pnlTabelSetoran";
            this.pnlTabelSetoran.Radius = 10;
            this.pnlTabelSetoran.Size = new System.Drawing.Size(727, 180);
            this.pnlTabelSetoran.Style = Sunny.UI.UIStyle.Custom;
            this.pnlTabelSetoran.TabIndex = 5;
            this.pnlTabelSetoran.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSetoranHariIni
            // 
            this.lblSetoranHariIni.AutoSize = true;
            this.lblSetoranHariIni.BackColor = System.Drawing.Color.Transparent;
            this.lblSetoranHariIni.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSetoranHariIni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblSetoranHariIni.Location = new System.Drawing.Point(233, 541);
            this.lblSetoranHariIni.Name = "lblSetoranHariIni";
            this.lblSetoranHariIni.Size = new System.Drawing.Size(194, 32);
            this.lblSetoranHariIni.TabIndex = 6;
            this.lblSetoranHariIni.Text = "Setoran Hari Ini";
            // 
            // dgvSetoran
            // 
            this.dgvSetoran.AllowUserToAddRows = false;
            this.dgvSetoran.AllowUserToDeleteRows = false;
            this.dgvSetoran.AllowUserToResizeColumns = false;
            this.dgvSetoran.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSetoran.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSetoran.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkKhaki;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSetoran.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSetoran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSetoran.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTanggal,
            this.colPetani,
            this.colProduk,
            this.colBerat,
            this.colKualitas,
            this.colPetugas});
            this.dgvSetoran.EnableHeadersVisualStyles = false;
            this.dgvSetoran.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvSetoran.Location = new System.Drawing.Point(11, 17);
            this.dgvSetoran.Name = "dgvSetoran";
            this.dgvSetoran.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSetoran.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSetoran.RowHeadersVisible = false;
            this.dgvSetoran.RowHeadersWidth = 62;
            this.dgvSetoran.RowTemplate.Height = 28;
            this.dgvSetoran.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSetoran.Size = new System.Drawing.Size(697, 115);
            this.dgvSetoran.TabIndex = 0;
            // 
            // colTanggal
            // 
            this.colTanggal.HeaderText = "Tanggal";
            this.colTanggal.MinimumWidth = 8;
            this.colTanggal.Name = "colTanggal";
            this.colTanggal.ReadOnly = true;
            // 
            // colPetani
            // 
            this.colPetani.HeaderText = "Petani";
            this.colPetani.MinimumWidth = 8;
            this.colPetani.Name = "colPetani";
            this.colPetani.ReadOnly = true;
            // 
            // colProduk
            // 
            this.colProduk.HeaderText = "Produk Panen";
            this.colProduk.MinimumWidth = 8;
            this.colProduk.Name = "colProduk";
            this.colProduk.ReadOnly = true;
            // 
            // colBerat
            // 
            this.colBerat.HeaderText = "Berat (Kg)";
            this.colBerat.MinimumWidth = 8;
            this.colBerat.Name = "colBerat";
            this.colBerat.ReadOnly = true;
            // 
            // colKualitas
            // 
            this.colKualitas.HeaderText = "Kualitas";
            this.colKualitas.MinimumWidth = 8;
            this.colKualitas.Name = "colKualitas";
            this.colKualitas.ReadOnly = true;
            // 
            // colPetugas
            // 
            this.colPetugas.HeaderText = "Petugas";
            this.colPetugas.MinimumWidth = 8;
            this.colPetugas.Name = "colPetugas";
            this.colPetugas.ReadOnly = true;
            // 
            // SetorPanenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(978, 744);
            this.Controls.Add(this.lblSetoranHariIni);
            this.Controls.Add(this.pnlTabelSetoran);
            this.Controls.Add(this.pnlSetorPanen);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SetorPanenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AGRIVA - Setor Panen";
            this.Load += new System.EventHandler(this.SetorPanenForm_Load);
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSetorPanen.ResumeLayout(false);
            this.pnlSetorPanen.PerformLayout();
            this.pnlTabelSetoran.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetoran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Sunny.UI.UIPanel pnlSidebar;
        private Sunny.UI.UILabel lblKoperasi;
        private Sunny.UI.UIButton btnManajemenUser;
        private Sunny.UI.UIButton btnLaporan;
        private Sunny.UI.UIButton btnMuatanBarang;
        private Sunny.UI.UIButton btnProdukPanen;
        private Sunny.UI.UIButton btnPetani;
        private Sunny.UI.UIButton btnSetorPanen;
        private Sunny.UI.UIButton btnDashboard;
        private Sunny.UI.UILabel lblNamaApp;
        private System.Windows.Forms.PictureBox picLogo;
        private Sunny.UI.UIPanel pnlHeader;
        private Sunny.UI.UIButton btnKeluar;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIPanel pnlSetorPanen;
        private Sunny.UI.UILabel lblKetSetor;
        private Sunny.UI.UILabel lblJudulSetor;
        private Sunny.UI.UILabel lblPetani;
        private Sunny.UI.UIComboBox cmbPetani;
        private Sunny.UI.UIComboBox cmbProduk;
        private Sunny.UI.UILabel lblProdukPanen;
        private Sunny.UI.UILabel lblBerat;
        private Sunny.UI.UILabel lblKualitas;
        private ReaLTaiizor.Controls.AloneTextBox txtBerat;
        private Sunny.UI.UILabel lblTotalUang;
        private Sunny.UI.UIComboBox cmbKualitas;
        private Sunny.UI.UILabel lblInfoTotal;
        private ReaLTaiizor.Controls.AloneTextBox txtTotalUang;
        private Sunny.UI.UIButton btnSimpanSetoran;
        private Sunny.UI.UIButton btnKosongkan;
        private Sunny.UI.UIPanel pnlTabelSetoran;
        private Sunny.UI.UILabel lblSetoranHariIni;
        private System.Windows.Forms.DataGridView dgvSetoran;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPetani;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBerat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKualitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPetugas;
    }
}