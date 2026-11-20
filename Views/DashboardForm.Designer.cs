namespace AGRIVA
{
    partial class DashboardForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvAltRowStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlNavArea = new System.Windows.Forms.Panel();
            this.btnNavManajemenUser = new System.Windows.Forms.Button();
            this.btnNavLaporan = new System.Windows.Forms.Button();
            this.btnNavMuatanBarang = new System.Windows.Forms.Button();
            this.btnNavSetorPanen = new System.Windows.Forms.Button();
            this.btnNavProdukPanen = new System.Windows.Forms.Button();
            this.btnNavPetani = new System.Windows.Forms.Button();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.pnlLogoArea = new System.Windows.Forms.Panel();
            this.lblLogoSub = new System.Windows.Forms.Label();
            this.lblLogoMain = new System.Windows.Forms.Label();

            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlHeaderBorder = new System.Windows.Forms.Panel();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblAdminBadge = new System.Windows.Forms.Label();

            // Toast
            this.pnlToast = new System.Windows.Forms.Panel();
            this.lblToastText = new System.Windows.Forms.Label();
            this.tmrToast = new System.Windows.Forms.Timer(this.components);

            // Dashboard Page
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.lblDashGreeting = new System.Windows.Forms.Label();
            this.lblDashSubtitle = new System.Windows.Forms.Label();
            this.pnlCardsContainer = new System.Windows.Forms.Panel();
            this.pnlStatCard1 = new System.Windows.Forms.Panel();
            this.pnlStatCard2 = new System.Windows.Forms.Panel();
            this.pnlStatCard3 = new System.Windows.Forms.Panel();
            this.pnlBackupCard = new System.Windows.Forms.Panel();
            this.lblBackupTitle = new System.Windows.Forms.Label();
            this.lblBackupSub = new System.Windows.Forms.Label();
            this.btnBackupDatabase = new System.Windows.Forms.Button();

            // Petani Page
            this.pnlPetani = new System.Windows.Forms.Panel();
            this.pnlPetaniHeader = new System.Windows.Forms.Panel();
            this.lblPetaniTitle = new System.Windows.Forms.Label();
            this.lblPetaniSubtitle = new System.Windows.Forms.Label();
            this.btnTambahPetani = new System.Windows.Forms.Button();
            this.pnlPetaniTableOuter = new System.Windows.Forms.Panel();
            this.pnlPetaniTableInner = new System.Windows.Forms.Panel();
            this.pnlPetaniTableHeader = new System.Windows.Forms.Panel();
            this.dgvPetani = new System.Windows.Forms.DataGridView();
            this.lblEmptyState = new System.Windows.Forms.Label();

            // Produk Panen Page
            this.pnlProdukPanen = new System.Windows.Forms.Panel();
            this.pnlProdukPanenHeader = new System.Windows.Forms.Panel();
            this.lblProdukPanenTitle = new System.Windows.Forms.Label();
            this.lblProdukPanenSubtitle = new System.Windows.Forms.Label();
            this.btnTambahProduk = new System.Windows.Forms.Button();
            this.pnlProdukPanenTableOuter = new System.Windows.Forms.Panel();
            this.pnlProdukPanenTableInner = new System.Windows.Forms.Panel();
            this.pnlProdukPanenTableHeader = new System.Windows.Forms.Panel();
            this.dgvProdukPanen = new System.Windows.Forms.DataGridView();
            this.lblEmptyProduk = new System.Windows.Forms.Label();

            // Modal Tambah/Edit Petani
            this.pnlModalOverlay = new System.Windows.Forms.Panel();
            this.pnlModalCard = new System.Windows.Forms.Panel();
            this.lblModalClose = new System.Windows.Forms.Label();
            this.lblModalTitle = new System.Windows.Forms.Label();
            this.lblModalSubtitle = new System.Windows.Forms.Label();

            this.lblFldNama = new System.Windows.Forms.Label();
            this.pnlBoxNama = new System.Windows.Forms.Panel();
            this.txtModalNama = new System.Windows.Forms.TextBox();
            this.lblErrNama = new System.Windows.Forms.Label();

            this.lblFldDesa = new System.Windows.Forms.Label();
            this.pnlBoxDesa = new System.Windows.Forms.Panel();
            this.txtModalDesa = new System.Windows.Forms.TextBox();
            this.lblErrDesa = new System.Windows.Forms.Label();

            this.lblFldNoHp = new System.Windows.Forms.Label();
            this.pnlBoxNoHp = new System.Windows.Forms.Panel();
            this.txtModalNoHp = new System.Windows.Forms.TextBox();
            this.lblErrNoHp = new System.Windows.Forms.Label();

            this.lblFldLuas = new System.Windows.Forms.Label();
            this.pnlBoxLuas = new System.Windows.Forms.Panel();
            this.txtModalLuas = new System.Windows.Forms.TextBox();
            this.lblErrLuas = new System.Windows.Forms.Label();

            this.lblFldStatus = new System.Windows.Forms.Label();
            this.pnlBoxStatus = new System.Windows.Forms.Panel();
            this.cmbModalStatus = new System.Windows.Forms.ComboBox();

            this.btnModalBatal = new System.Windows.Forms.Button();
            this.btnModalSimpan = new System.Windows.Forms.Button();

            // Modal Tambah/Edit Produk Panen
            this.pnlModalProdukCard = new System.Windows.Forms.Panel();
            this.lblModalProdClose = new System.Windows.Forms.Label();
            this.lblModalProdTitle = new System.Windows.Forms.Label();
            this.lblModalProdSubtitle = new System.Windows.Forms.Label();

            this.lblFldProdNama = new System.Windows.Forms.Label();
            this.pnlBoxProdNama = new System.Windows.Forms.Panel();
            this.txtModalProdNama = new System.Windows.Forms.TextBox();
            this.lblErrProdNama = new System.Windows.Forms.Label();

            this.lblFldProdHarga = new System.Windows.Forms.Label();
            this.pnlBoxProdHarga = new System.Windows.Forms.Panel();
            this.txtModalProdHarga = new System.Windows.Forms.TextBox();
            this.lblHelpProdHarga = new System.Windows.Forms.Label();
            this.lblErrProdHarga = new System.Windows.Forms.Label();

            this.lblFldProdStatus = new System.Windows.Forms.Label();
            this.pnlBoxProdStatus = new System.Windows.Forms.Panel();
            this.cmbModalProdStatus = new System.Windows.Forms.ComboBox();

            this.btnModalProdBatal = new System.Windows.Forms.Button();
            this.btnModalProdSimpan = new System.Windows.Forms.Button();

            
            // Setor Panen Page
            this.pnlSetorPanen = new System.Windows.Forms.Panel();
            this.pnlSetorHeader = new System.Windows.Forms.Panel();
            this.lblSetorTitle = new System.Windows.Forms.Label();
            this.lblSetorSubtitle = new System.Windows.Forms.Label();
            this.pnlSetorFormCard = new System.Windows.Forms.Panel();
            this.lblFldSetorPetani = new System.Windows.Forms.Label();
            this.pnlBoxSetorPetani = new System.Windows.Forms.Panel();
            this.cmbSetorPetani = new System.Windows.Forms.ComboBox();
            this.lblFldSetorProduk = new System.Windows.Forms.Label();
            this.pnlBoxSetorProduk = new System.Windows.Forms.Panel();
            this.cmbSetorProduk = new System.Windows.Forms.ComboBox();
            this.lblFldSetorKualitas = new System.Windows.Forms.Label();
            this.pnlBoxSetorKualitas = new System.Windows.Forms.Panel();
            this.cmbSetorKualitas = new System.Windows.Forms.ComboBox();
            this.lblFldSetorBerat = new System.Windows.Forms.Label();
            this.pnlBoxSetorBerat = new System.Windows.Forms.Panel();
            this.txtSetorBerat = new System.Windows.Forms.TextBox();
            this.lblSetorUnitKg = new System.Windows.Forms.Label();
            this.lblFldSetorTotal = new System.Windows.Forms.Label();
            this.pnlBoxSetorTotal = new System.Windows.Forms.Panel();
            this.lblSetorTotalValue = new System.Windows.Forms.Label();
            this.lblSetorTotalHelp = new System.Windows.Forms.Label();
            this.btnSetorKosongkan = new System.Windows.Forms.Button();
            this.btnSetorSimpan = new System.Windows.Forms.Button();
            this.lblSetorTableTitle = new System.Windows.Forms.Label();
            this.pnlSetorTableOuter = new System.Windows.Forms.Panel();
            this.pnlSetorTableInner = new System.Windows.Forms.Panel();
            this.pnlSetorTableHeader = new System.Windows.Forms.Panel();
            this.dgvSetorPanen = new System.Windows.Forms.DataGridView();
            this.lblEmptySetor = new System.Windows.Forms.Label();

            // Muatan Barang Page
            this.pnlMuatanBarang = new System.Windows.Forms.Panel();
            this.pnlMuatanHeader = new System.Windows.Forms.Panel();
            this.lblMuatanTitle = new System.Windows.Forms.Label();
            this.lblMuatanSubtitle = new System.Windows.Forms.Label();
            this.pnlMuatanFilterBar = new System.Windows.Forms.Panel();
            this.lblFldMuatanDari = new System.Windows.Forms.Label();
            this.pnlBoxMuatanDari = new System.Windows.Forms.Panel();
            this.dtpMuatanDari = new System.Windows.Forms.DateTimePicker();
            this.lblFldMuatanSampai = new System.Windows.Forms.Label();
            this.pnlBoxMuatanSampai = new System.Windows.Forms.Panel();
            this.dtpMuatanSampai = new System.Windows.Forms.DateTimePicker();
            this.lblFldMuatanStatus = new System.Windows.Forms.Label();
            this.pnlBoxMuatanStatus = new System.Windows.Forms.Panel();
            this.cmbMuatanStatus = new System.Windows.Forms.ComboBox();
            this.pnlMuatanTableOuter = new System.Windows.Forms.Panel();
            this.pnlMuatanTableInner = new System.Windows.Forms.Panel();
            this.pnlMuatanTableHeader = new System.Windows.Forms.Panel();
            this.dgvMuatanBarang = new System.Windows.Forms.DataGridView();
            this.lblEmptyMuatan = new System.Windows.Forms.Label();
            this.pnlMuatanSummaryBar = new System.Windows.Forms.Panel();
            this.lblMuatanSummaryJumlah = new System.Windows.Forms.Label();
            this.lblMuatanSummaryBerat = new System.Windows.Forms.Label();
            this.lblMuatanSummaryTotal = new System.Windows.Forms.Label();
            this.btnMuatanEksporCsv = new System.Windows.Forms.Button();
            this.lblMuatanError = new System.Windows.Forms.Label();
            this.pnlMuatanDipilihBox = new System.Windows.Forms.Panel();
            this.lblDipilihHeader = new System.Windows.Forms.Label();
            this.lblDipilihCount = new System.Windows.Forms.Label();
            this.lblDipilihBerat = new System.Windows.Forms.Label();
            this.btnBuatSuratJalan = new System.Windows.Forms.Button();

            // Modal Pembatalan Transaksi
            this.pnlModalBatalCard = new System.Windows.Forms.Panel();
            this.pnlBatalHeader = new System.Windows.Forms.Panel();
            this.lblModalBatalTitle = new System.Windows.Forms.Label();
            this.lblModalBatalSubtitle = new System.Windows.Forms.Label();
            this.lblModalBatalClose = new System.Windows.Forms.Label();
            this.pnlBatalInfoBox = new System.Windows.Forms.Panel();
            this.lblBatalTrxNo = new System.Windows.Forms.Label();
            this.lblBatalTrxTgl = new System.Windows.Forms.Label();
            this.lblBatalPetani = new System.Windows.Forms.Label();
            this.lblBatalDetail = new System.Windows.Forms.Label();
            this.lblBatalTotal = new System.Windows.Forms.Label();
            this.lblFldAlasanBatal = new System.Windows.Forms.Label();
            this.pnlBoxAlasanBatal = new System.Windows.Forms.Panel();
            this.txtAlasanBatal = new System.Windows.Forms.TextBox();
            this.btnBatalKembali = new System.Windows.Forms.Button();
            this.btnBatalKonfirmasi = new System.Windows.Forms.Button();

            // Modal Tambah/Edit Pengguna
            this.pnlModalUserCard = new System.Windows.Forms.Panel();
            this.lblModalUserTitle = new System.Windows.Forms.Label();
            this.lblModalUserSubtitle = new System.Windows.Forms.Label();
            this.lblModalUserClose = new System.Windows.Forms.Label();
            this.lblFldUserNama = new System.Windows.Forms.Label();
            this.pnlBoxUserNama = new System.Windows.Forms.Panel();
            this.txtModalUserNama = new System.Windows.Forms.TextBox();
            this.lblErrUserNama = new System.Windows.Forms.Label();
            this.lblFldUserUname = new System.Windows.Forms.Label();
            this.pnlBoxUserUname = new System.Windows.Forms.Panel();
            this.txtModalUserUname = new System.Windows.Forms.TextBox();
            this.lblErrUserUname = new System.Windows.Forms.Label();
            this.lblFldUserPeran = new System.Windows.Forms.Label();
            this.pnlBoxUserPeran = new System.Windows.Forms.Panel();
            this.cmbModalUserPeran = new System.Windows.Forms.ComboBox();
            this.lblFldUserStatus = new System.Windows.Forms.Label();
            this.pnlBoxUserStatus = new System.Windows.Forms.Panel();
            this.cmbModalUserStatus = new System.Windows.Forms.ComboBox();
            this.btnModalUserBatal = new System.Windows.Forms.Button();
            this.btnModalUserSimpan = new System.Windows.Forms.Button();

            // Other pages
            this.pnlOtherPage = new System.Windows.Forms.Panel();
            this.pnlOtherHeader = new System.Windows.Forms.Panel();
            this.pnlOtherTableInner = new System.Windows.Forms.Panel();
            this.pnlOtherTableHeader = new System.Windows.Forms.Panel();
            this.btnTambahUser = new System.Windows.Forms.Button();
            this.lblOtherTitle = new System.Windows.Forms.Label();
            this.lblOtherSub = new System.Windows.Forms.Label();
            this.pnlOtherTableOuter = new System.Windows.Forms.Panel();
            this.dgvOther = new System.Windows.Forms.DataGridView();

            this.pnlSidebar.SuspendLayout();
            this.pnlNavArea.SuspendLayout();
            this.pnlLogoArea.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlToast.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.pnlCardsContainer.SuspendLayout();
            this.pnlBackupCard.SuspendLayout();
            this.pnlPetani.SuspendLayout();
            this.pnlPetaniHeader.SuspendLayout();
            this.pnlPetaniTableOuter.SuspendLayout();
            this.pnlPetaniTableInner.SuspendLayout();
            this.pnlPetaniTableHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPetani)).BeginInit();
            this.pnlProdukPanen.SuspendLayout();
            this.pnlProdukPanenHeader.SuspendLayout();
            this.pnlProdukPanenTableOuter.SuspendLayout();
            this.pnlProdukPanenTableInner.SuspendLayout();
            this.pnlProdukPanenTableHeader.SuspendLayout();
            this.pnlSetorPanen.SuspendLayout();
            this.pnlSetorHeader.SuspendLayout();
            this.pnlSetorFormCard.SuspendLayout();
            this.pnlBoxSetorPetani.SuspendLayout();
            this.pnlBoxSetorProduk.SuspendLayout();
            this.pnlBoxSetorKualitas.SuspendLayout();
            this.pnlBoxSetorBerat.SuspendLayout();
            this.pnlBoxSetorTotal.SuspendLayout();
            this.pnlSetorTableOuter.SuspendLayout();
            this.pnlSetorTableInner.SuspendLayout();
            this.pnlSetorTableHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetorPanen)).BeginInit();

            this.pnlMuatanBarang.SuspendLayout();
            this.pnlMuatanHeader.SuspendLayout();
            this.pnlMuatanFilterBar.SuspendLayout();
            this.pnlBoxMuatanDari.SuspendLayout();
            this.pnlBoxMuatanSampai.SuspendLayout();
            this.pnlBoxMuatanStatus.SuspendLayout();
            this.pnlMuatanTableOuter.SuspendLayout();
            this.pnlMuatanTableInner.SuspendLayout();
            this.pnlMuatanTableHeader.SuspendLayout();
            this.pnlMuatanSummaryBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuatanBarang)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProdukPanen)).BeginInit();
            this.pnlModalOverlay.SuspendLayout();
            this.pnlModalCard.SuspendLayout();
            this.pnlBoxNama.SuspendLayout();
            this.pnlBoxDesa.SuspendLayout();
            this.pnlBoxNoHp.SuspendLayout();
            this.pnlBoxLuas.SuspendLayout();
            this.pnlBoxStatus.SuspendLayout();
            this.pnlModalProdukCard.SuspendLayout();
            this.pnlBoxProdNama.SuspendLayout();
            this.pnlBoxProdHarga.SuspendLayout();
            this.pnlBoxProdStatus.SuspendLayout();
            this.pnlOtherPage.SuspendLayout();
            this.pnlOtherTableOuter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOther)).BeginInit();
            this.SuspendLayout();

            // ════════════════════════════════════════════════════════
            // pnlSidebar
            // ════════════════════════════════════════════════════════
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.pnlSidebar.Controls.Add(this.pnlNavArea);
            this.pnlSidebar.Controls.Add(this.pnlLogoArea);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(240, 720);
            this.pnlSidebar.TabIndex = 0;

            // pnlLogoArea
            this.pnlLogoArea.Controls.Add(this.lblLogoSub);
            this.pnlLogoArea.Controls.Add(this.lblLogoMain);
            this.pnlLogoArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogoArea.Location = new System.Drawing.Point(0, 0);
            this.pnlLogoArea.Name = "pnlLogoArea";
            this.pnlLogoArea.Size = new System.Drawing.Size(240, 110);
            this.pnlLogoArea.TabIndex = 0;

            this.lblLogoMain.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblLogoMain.ForeColor = System.Drawing.Color.FromArgb(245, 242, 235);
            this.lblLogoMain.Location = new System.Drawing.Point(26, 30);
            this.lblLogoMain.Name = "lblLogoMain";
            this.lblLogoMain.Size = new System.Drawing.Size(200, 36);
            this.lblLogoMain.Text = "🌱 AGRIVA";
            this.lblLogoMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblLogoSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLogoSub.ForeColor = System.Drawing.Color.FromArgb(200, 183, 143);
            this.lblLogoSub.Location = new System.Drawing.Point(30, 68);
            this.lblLogoSub.Name = "lblLogoSub";
            this.lblLogoSub.Size = new System.Drawing.Size(190, 20);
            this.lblLogoSub.Text = "Koperasi Tani Desa";

            // pnlNavArea
            this.pnlNavArea.Controls.Add(this.btnNavManajemenUser);
            this.pnlNavArea.Controls.Add(this.btnNavLaporan);
            this.pnlNavArea.Controls.Add(this.btnNavMuatanBarang);
            this.pnlNavArea.Controls.Add(this.btnNavSetorPanen);
            this.pnlNavArea.Controls.Add(this.btnNavProdukPanen);
            this.pnlNavArea.Controls.Add(this.btnNavPetani);
            this.pnlNavArea.Controls.Add(this.btnNavDashboard);
            this.pnlNavArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavArea.Location = new System.Drawing.Point(0, 110);
            this.pnlNavArea.Name = "pnlNavArea";
            this.pnlNavArea.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlNavArea.Size = new System.Drawing.Size(240, 610);
            this.pnlNavArea.TabIndex = 1;

            SetupNavButton(this.btnNavManajemenUser, "  👥  Manajemen User");
            SetupNavButton(this.btnNavLaporan, "  📄  Laporan");
            SetupNavButton(this.btnNavMuatanBarang, "  🚚  Muatan Barang");
            SetupNavButton(this.btnNavSetorPanen, "  ⚖  Setor Panen");
            SetupNavButton(this.btnNavProdukPanen, "  🌾  Produk Panen");
            SetupNavButton(this.btnNavPetani, "  👨‍🌾  Petani");
            SetupNavButton(this.btnNavDashboard, "  ⊞  Dashboard");

            // ════════════════════════════════════════════════════════
            // pnlRight
            // ════════════════════════════════════════════════════════
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(250, 245, 234);
            this.pnlRight.Controls.Add(this.pnlContent);
            this.pnlRight.Controls.Add(this.pnlHeader);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(240, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(960, 720);
            this.pnlRight.TabIndex = 1;

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(250, 245, 234);
            this.pnlHeader.Controls.Add(this.btnKeluar);
            this.pnlHeader.Controls.Add(this.lblUsername);
            this.pnlHeader.Controls.Add(this.lblAdminBadge);
            this.pnlHeader.Controls.Add(this.pnlHeaderBorder);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 70;
            this.pnlHeader.Name = "pnlHeader";

            this.pnlHeaderBorder.BackColor = System.Drawing.Color.FromArgb(232, 222, 202);
            this.pnlHeaderBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderBorder.Height = 1;

            this.lblAdminBadge.Text = "Admin";
            this.lblAdminBadge.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblAdminBadge.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblAdminBadge.BackColor = System.Drawing.Color.FromArgb(240, 190, 83);
            this.lblAdminBadge.Size = new System.Drawing.Size(62, 24);
            this.lblAdminBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblUsername.Text = "Bapak Budi";
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblUsername.AutoSize = true;

            this.btnKeluar.Text = "↪ Keluar";
            this.btnKeluar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnKeluar.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnKeluar.BackColor = System.Drawing.Color.Transparent;
            this.btnKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeluar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnKeluar.FlatAppearance.BorderSize = 1;
            this.btnKeluar.Size = new System.Drawing.Size(95, 34);
            this.btnKeluar.Cursor = System.Windows.Forms.Cursors.Hand;

            // pnlContent
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(250, 245, 234);
            this.pnlContent.Controls.Add(this.pnlModalOverlay);
            this.pnlContent.Controls.Add(this.pnlToast);
            this.pnlContent.Controls.Add(this.pnlDashboard);
            this.pnlContent.Controls.Add(this.pnlPetani);
            this.pnlContent.Controls.Add(this.pnlProdukPanen);
            this.pnlContent.Controls.Add(this.pnlSetorPanen);
            this.pnlContent.Controls.Add(this.pnlMuatanBarang);

            this.pnlContent.Controls.Add(this.pnlOtherPage);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(36, 20, 36, 20);

            // ════════════════════════════════════════════════════════
            // TOAST NOTIFICATION (Exact Figma Pill)
            // ════════════════════════════════════════════════════════
            this.pnlToast.BackColor = System.Drawing.Color.FromArgb(234, 247, 238);
            this.pnlToast.Controls.Add(this.lblToastText);
            this.pnlToast.Size = new System.Drawing.Size(260, 42);
            this.pnlToast.Visible = false;

            this.lblToastText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblToastText.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblToastText.ForeColor = System.Drawing.Color.FromArgb(46, 125, 78);
            this.lblToastText.Text = "✓ Data petani berhasil disimpan";
            this.lblToastText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ════════════════════════════════════════════════════════
            // DASHBOARD PAGE
            // ════════════════════════════════════════════════════════
            this.pnlDashboard.BackColor = System.Drawing.Color.Transparent;
            this.pnlDashboard.Controls.Add(this.pnlBackupCard);
            this.pnlDashboard.Controls.Add(this.pnlCardsContainer);
            this.pnlDashboard.Controls.Add(this.lblDashSubtitle);
            this.pnlDashboard.Controls.Add(this.lblDashGreeting);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;

            this.lblDashGreeting.Text = "Selamat sore, Bapak Budi";
            this.lblDashGreeting.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblDashGreeting.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblDashGreeting.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDashGreeting.Height = 44;

            this.lblDashSubtitle.Text = "Ringkasan gudang hari ini - 17 November 2026";
            this.lblDashSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDashSubtitle.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblDashSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDashSubtitle.Height = 32;

            this.pnlCardsContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlCardsContainer.Controls.Add(this.pnlStatCard3);
            this.pnlCardsContainer.Controls.Add(this.pnlStatCard2);
            this.pnlCardsContainer.Controls.Add(this.pnlStatCard1);
            this.pnlCardsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCardsContainer.Height = 180;
            this.pnlCardsContainer.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);

            this.pnlBackupCard.BackColor = System.Drawing.Color.FromArgb(250, 245, 234);
            this.pnlBackupCard.Controls.Add(this.btnBackupDatabase);
            this.pnlBackupCard.Controls.Add(this.lblBackupSub);
            this.pnlBackupCard.Controls.Add(this.lblBackupTitle);
            this.pnlBackupCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBackupCard.Height = 88;

            this.lblBackupTitle.Text = "Cadangan Data";
            this.lblBackupTitle.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblBackupTitle.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblBackupTitle.Location = new System.Drawing.Point(24, 20);
            this.lblBackupTitle.Size = new System.Drawing.Size(300, 24);

            this.lblBackupSub.Text = "Simpan seluruh data ke komputer ini";
            this.lblBackupSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBackupSub.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblBackupSub.Location = new System.Drawing.Point(24, 46);
            this.lblBackupSub.Size = new System.Drawing.Size(350, 20);

            this.btnBackupDatabase.Text = "💾  Backup Database";
            this.btnBackupDatabase.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBackupDatabase.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnBackupDatabase.BackColor = System.Drawing.Color.FromArgb(162, 168, 100);
            this.btnBackupDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupDatabase.FlatAppearance.BorderSize = 0;
            this.btnBackupDatabase.Size = new System.Drawing.Size(175, 40);
            this.btnBackupDatabase.Cursor = System.Windows.Forms.Cursors.Hand;

            // ════════════════════════════════════════════════════════
            // PETANI PAGE (EXACT FIGMA REPLICA)
            // ════════════════════════════════════════════════════════
            this.pnlPetani.BackColor = System.Drawing.Color.Transparent;
            this.pnlPetani.Controls.Add(this.pnlPetaniTableOuter);
            this.pnlPetani.Controls.Add(this.pnlPetaniHeader);
            this.pnlPetani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPetani.Visible = false;

            // Header
            this.pnlPetaniHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlPetaniHeader.Controls.Add(this.btnTambahPetani);
            this.pnlPetaniHeader.Controls.Add(this.lblPetaniSubtitle);
            this.pnlPetaniHeader.Controls.Add(this.lblPetaniTitle);
            this.pnlPetaniHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPetaniHeader.Height = 84;

            this.lblPetaniTitle.Text = "Data Petani";
            this.lblPetaniTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblPetaniTitle.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblPetaniTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPetaniTitle.Height = 44;

            this.lblPetaniSubtitle.Text = "Daftar petani anggota koperasi";
            this.lblPetaniSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.8F);
            this.lblPetaniSubtitle.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblPetaniSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPetaniSubtitle.Height = 28;

            this.btnTambahPetani.Text = "+ Tambah Data";
            this.btnTambahPetani.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTambahPetani.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnTambahPetani.BackColor = System.Drawing.Color.FromArgb(154, 161, 119);
            this.btnTambahPetani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambahPetani.FlatAppearance.BorderSize = 0;
            this.btnTambahPetani.Size = new System.Drawing.Size(155, 40);
            this.btnTambahPetani.Cursor = System.Windows.Forms.Cursors.Hand;

            // Table Outer (Neo-Brutalist Shadow & Border Container)
            this.pnlPetaniTableOuter.BackColor = System.Drawing.Color.Transparent;
            this.pnlPetaniTableOuter.Controls.Add(this.pnlPetaniTableInner);
            this.pnlPetaniTableOuter.Location = new System.Drawing.Point(0, 88);
            this.pnlPetaniTableOuter.Size = new System.Drawing.Size(880, 360);

            // Table Inner (Clipped to 14px rounded rectangle)
            this.pnlPetaniTableInner.BackColor = System.Drawing.Color.White;
            this.pnlPetaniTableInner.Controls.Add(this.lblEmptyState);
            this.pnlPetaniTableInner.Controls.Add(this.dgvPetani);
            this.pnlPetaniTableInner.Controls.Add(this.pnlPetaniTableHeader);
            this.pnlPetaniTableInner.Dock = System.Windows.Forms.DockStyle.Fill;

            // Table Header Panel (Olive #9AA177)
            this.pnlPetaniTableHeader.BackColor = System.Drawing.Color.FromArgb(154, 161, 119);
            this.pnlPetaniTableHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPetaniTableHeader.Height = 46;

            // Empty state label
            this.lblEmptyState.BackColor = System.Drawing.Color.FromArgb(250, 244, 230);
            this.lblEmptyState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmptyState.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmptyState.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblEmptyState.Text = "Belum ada data petani terdaftar. Klik \"+ Tambah Data\" untuk membuat.";
            this.lblEmptyState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmptyState.Visible = false;

            // DataGridView
            this.dgvPetani.BackgroundColor = System.Drawing.Color.FromArgb(250, 244, 230);
            this.dgvPetani.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPetani.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPetani.RowHeadersVisible = false;
            this.dgvPetani.AllowUserToAddRows = false;
            this.dgvPetani.AllowUserToDeleteRows = false;
            this.dgvPetani.AllowUserToResizeRows = false;
            this.dgvPetani.AllowUserToResizeColumns = false;
            this.dgvPetani.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPetani.MultiSelect = false;
            this.dgvPetani.ReadOnly = true;
            this.dgvPetani.ColumnHeadersVisible = false;
            this.dgvPetani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPetani.RowTemplate.Height = 52;

            // ════════════════════════════════════════════════════════
            // PRODUK PANEN PAGE (EXACT FIGMA REPLICA)
            // ════════════════════════════════════════════════════════
            this.pnlProdukPanen.BackColor = System.Drawing.Color.Transparent;
            this.pnlProdukPanen.Controls.Add(this.pnlProdukPanenTableOuter);
            this.pnlProdukPanen.Controls.Add(this.pnlProdukPanenHeader);
            this.pnlProdukPanen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProdukPanen.Visible = false;

            // Header
            this.pnlProdukPanenHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlProdukPanenHeader.Controls.Add(this.btnTambahProduk);
            this.pnlProdukPanenHeader.Controls.Add(this.lblProdukPanenSubtitle);
            this.pnlProdukPanenHeader.Controls.Add(this.lblProdukPanenTitle);
            this.pnlProdukPanenHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProdukPanenHeader.Height = 84;

            this.lblProdukPanenTitle.Text = "Data Produk Panen";
            this.lblProdukPanenTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblProdukPanenTitle.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblProdukPanenTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProdukPanenTitle.Height = 44;

            this.lblProdukPanenSubtitle.Text = "Jenis hasil panen dan harga beli per Kg";
            this.lblProdukPanenSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.8F);
            this.lblProdukPanenSubtitle.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblProdukPanenSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProdukPanenSubtitle.Height = 28;

            this.btnTambahProduk.Text = "+ Tambah Data";
            this.btnTambahProduk.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTambahProduk.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnTambahProduk.BackColor = System.Drawing.Color.FromArgb(154, 161, 119);
            this.btnTambahProduk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambahProduk.FlatAppearance.BorderSize = 0;
            this.btnTambahProduk.Size = new System.Drawing.Size(155, 40);
            this.btnTambahProduk.Cursor = System.Windows.Forms.Cursors.Hand;

            // Table Outer (Neo-Brutalist Shadow & Border Container)
            this.pnlProdukPanenTableOuter.BackColor = System.Drawing.Color.Transparent;
            this.pnlProdukPanenTableOuter.Controls.Add(this.pnlProdukPanenTableInner);
            this.pnlProdukPanenTableOuter.Location = new System.Drawing.Point(0, 88);
            this.pnlProdukPanenTableOuter.Size = new System.Drawing.Size(880, 360);

            // Table Inner (Clipped to 14px rounded rectangle)
            this.pnlProdukPanenTableInner.BackColor = System.Drawing.Color.White;
            this.pnlProdukPanenTableInner.Controls.Add(this.lblEmptyProduk);
            this.pnlProdukPanenTableInner.Controls.Add(this.dgvProdukPanen);
            this.pnlProdukPanenTableInner.Controls.Add(this.pnlProdukPanenTableHeader);
            this.pnlProdukPanenTableInner.Dock = System.Windows.Forms.DockStyle.Fill;

            // Table Header Panel (Olive #9AA177)
            this.pnlProdukPanenTableHeader.BackColor = System.Drawing.Color.FromArgb(154, 161, 119);
            this.pnlProdukPanenTableHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProdukPanenTableHeader.Height = 46;

            // Empty state label
            this.lblEmptyProduk.BackColor = System.Drawing.Color.FromArgb(250, 244, 230);
            this.lblEmptyProduk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmptyProduk.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmptyProduk.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblEmptyProduk.Text = "Belum ada komoditas data produk panen. Klik \"+ Tambah Data\" untuk membuat.";
            this.lblEmptyProduk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmptyProduk.Visible = false;

            // DataGridView
            this.dgvProdukPanen.BackgroundColor = System.Drawing.Color.FromArgb(250, 244, 230);
            this.dgvProdukPanen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProdukPanen.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProdukPanen.RowHeadersVisible = false;
            this.dgvProdukPanen.AllowUserToAddRows = false;
            this.dgvProdukPanen.AllowUserToDeleteRows = false;
            this.dgvProdukPanen.AllowUserToResizeRows = false;
            this.dgvProdukPanen.AllowUserToResizeColumns = false;
            this.dgvProdukPanen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdukPanen.MultiSelect = false;
            this.dgvProdukPanen.ReadOnly = true;
            this.dgvProdukPanen.ColumnHeadersVisible = false;
            this.dgvProdukPanen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdukPanen.RowTemplate.Height = 52;

            // ════════════════════════════════════════════════════════
            // MODAL TAMBAH/EDIT PETANI (Exact Figma Cards)
            // ════════════════════════════════════════════════════════
            this.pnlModalOverlay.BackColor = System.Drawing.Color.FromArgb(110, 0, 0, 0);
            this.pnlModalOverlay.Controls.Add(this.pnlModalBatalCard);
            this.pnlModalOverlay.Controls.Add(this.pnlModalUserCard);
            this.pnlModalOverlay.Controls.Add(this.pnlModalProdukCard);
            this.pnlModalOverlay.Controls.Add(this.pnlModalCard);
            this.pnlModalOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModalOverlay.Visible = false;

            this.pnlModalCard.BackColor = System.Drawing.Color.FromArgb(250, 245, 234);
            this.pnlModalCard.Controls.Add(this.btnModalSimpan);
            this.pnlModalCard.Controls.Add(this.btnModalBatal);
            this.pnlModalCard.Controls.Add(this.pnlBoxStatus);
            this.pnlModalCard.Controls.Add(this.lblFldStatus);
            this.pnlModalCard.Controls.Add(this.lblErrLuas);
            this.pnlModalCard.Controls.Add(this.pnlBoxLuas);
            this.pnlModalCard.Controls.Add(this.lblFldLuas);
            this.pnlModalCard.Controls.Add(this.lblErrNoHp);
            this.pnlModalCard.Controls.Add(this.pnlBoxNoHp);
            this.pnlModalCard.Controls.Add(this.lblFldNoHp);
            this.pnlModalCard.Controls.Add(this.lblErrDesa);
            this.pnlModalCard.Controls.Add(this.pnlBoxDesa);
            this.pnlModalCard.Controls.Add(this.lblFldDesa);
            this.pnlModalCard.Controls.Add(this.lblErrNama);
            this.pnlModalCard.Controls.Add(this.pnlBoxNama);
            this.pnlModalCard.Controls.Add(this.lblFldNama);
            this.pnlModalCard.Controls.Add(this.lblModalClose);
            this.pnlModalCard.Controls.Add(this.lblModalSubtitle);
            this.pnlModalCard.Controls.Add(this.lblModalTitle);
            this.pnlModalCard.Size = new System.Drawing.Size(430, 500);

            this.lblModalClose.Text = "✕";
            this.lblModalClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblModalClose.ForeColor = System.Drawing.Color.FromArgb(107, 96, 82);
            this.lblModalClose.Location = new System.Drawing.Point(385, 18);
            this.lblModalClose.Size = new System.Drawing.Size(28, 28);
            this.lblModalClose.Cursor = System.Windows.Forms.Cursors.Hand;

            this.lblModalTitle.Text = "Tambah Petani Baru";
            this.lblModalTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblModalTitle.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblModalTitle.Location = new System.Drawing.Point(28, 20);
            this.lblModalTitle.Size = new System.Drawing.Size(340, 26);

            this.lblModalSubtitle.Text = "Isi data di bawah ini, lalu tekan Simpan";
            this.lblModalSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblModalSubtitle.ForeColor = System.Drawing.Color.FromArgb(122, 112, 98);
            this.lblModalSubtitle.Location = new System.Drawing.Point(28, 48);
            this.lblModalSubtitle.Size = new System.Drawing.Size(340, 18);

            // Field: Nama Petani
            this.lblFldNama.Text = "Nama Petani";
            this.lblFldNama.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldNama.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldNama.Location = new System.Drawing.Point(28, 76);
            this.lblFldNama.Size = new System.Drawing.Size(374, 18);

            this.pnlBoxNama.BackColor = System.Drawing.Color.White;
            this.pnlBoxNama.Controls.Add(this.txtModalNama);
            this.pnlBoxNama.Location = new System.Drawing.Point(28, 96);
            this.pnlBoxNama.Size = new System.Drawing.Size(374, 34);

            this.txtModalNama.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtModalNama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtModalNama.Location = new System.Drawing.Point(10, 7);
            this.txtModalNama.Size = new System.Drawing.Size(354, 18);

            this.lblErrNama.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblErrNama.ForeColor = System.Drawing.Color.FromArgb(224, 82, 82);
            this.lblErrNama.Location = new System.Drawing.Point(28, 132);
            this.lblErrNama.Size = new System.Drawing.Size(374, 16);
            this.lblErrNama.Text = "ⓘ Mohon isi nama petani";
            this.lblErrNama.Visible = false;

            // Field: Desa
            this.lblFldDesa.Text = "Desa";
            this.lblFldDesa.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldDesa.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldDesa.Location = new System.Drawing.Point(28, 150);
            this.lblFldDesa.Size = new System.Drawing.Size(374, 18);

            this.pnlBoxDesa.BackColor = System.Drawing.Color.White;
            this.pnlBoxDesa.Controls.Add(this.txtModalDesa);
            this.pnlBoxDesa.Location = new System.Drawing.Point(28, 170);
            this.pnlBoxDesa.Size = new System.Drawing.Size(374, 34);

            this.txtModalDesa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtModalDesa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtModalDesa.Location = new System.Drawing.Point(10, 7);
            this.txtModalDesa.Size = new System.Drawing.Size(354, 18);

            this.lblErrDesa.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblErrDesa.ForeColor = System.Drawing.Color.FromArgb(224, 82, 82);
            this.lblErrDesa.Location = new System.Drawing.Point(28, 206);
            this.lblErrDesa.Size = new System.Drawing.Size(374, 16);
            this.lblErrDesa.Text = "ⓘ Mohon isi asal desa petani";
            this.lblErrDesa.Visible = false;

            // 2 Cols: No. HP & Luas Lahan
            this.lblFldNoHp.Text = "No. HP";
            this.lblFldNoHp.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldNoHp.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldNoHp.Location = new System.Drawing.Point(28, 224);
            this.lblFldNoHp.Size = new System.Drawing.Size(180, 18);

            this.pnlBoxNoHp.BackColor = System.Drawing.Color.White;
            this.pnlBoxNoHp.Controls.Add(this.txtModalNoHp);
            this.pnlBoxNoHp.Location = new System.Drawing.Point(28, 244);
            this.pnlBoxNoHp.Size = new System.Drawing.Size(180, 34);

            this.txtModalNoHp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtModalNoHp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtModalNoHp.Location = new System.Drawing.Point(10, 7);
            this.txtModalNoHp.Size = new System.Drawing.Size(160, 18);

            this.lblErrNoHp.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblErrNoHp.ForeColor = System.Drawing.Color.FromArgb(224, 82, 82);
            this.lblErrNoHp.Location = new System.Drawing.Point(28, 280);
            this.lblErrNoHp.Size = new System.Drawing.Size(180, 16);
            this.lblErrNoHp.Text = "ⓘ Mohon isi no. HP";
            this.lblErrNoHp.Visible = false;

            this.lblFldLuas.Text = "Luas Lahan (Hektar)";
            this.lblFldLuas.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldLuas.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldLuas.Location = new System.Drawing.Point(222, 224);
            this.lblFldLuas.Size = new System.Drawing.Size(180, 18);

            this.pnlBoxLuas.BackColor = System.Drawing.Color.White;
            this.pnlBoxLuas.Controls.Add(this.txtModalLuas);
            this.pnlBoxLuas.Location = new System.Drawing.Point(222, 244);
            this.pnlBoxLuas.Size = new System.Drawing.Size(180, 34);

            this.txtModalLuas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtModalLuas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtModalLuas.Location = new System.Drawing.Point(10, 7);
            this.txtModalLuas.Size = new System.Drawing.Size(160, 18);

            this.lblErrLuas.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblErrLuas.ForeColor = System.Drawing.Color.FromArgb(224, 82, 82);
            this.lblErrLuas.Location = new System.Drawing.Point(222, 280);
            this.lblErrLuas.Size = new System.Drawing.Size(180, 16);
            this.lblErrLuas.Text = "ⓘ Mohon isi luas lahan";
            this.lblErrLuas.Visible = false;

            // Status
            this.lblFldStatus.Text = "Status";
            this.lblFldStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldStatus.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldStatus.Location = new System.Drawing.Point(28, 298);
            this.lblFldStatus.Size = new System.Drawing.Size(374, 18);

            this.pnlBoxStatus.BackColor = System.Drawing.Color.White;
            this.pnlBoxStatus.Controls.Add(this.cmbModalStatus);
            this.pnlBoxStatus.Location = new System.Drawing.Point(28, 318);
            this.pnlBoxStatus.Size = new System.Drawing.Size(374, 34);

            this.cmbModalStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbModalStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbModalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModalStatus.Location = new System.Drawing.Point(6, 4);
            this.cmbModalStatus.Size = new System.Drawing.Size(362, 25);
            this.cmbModalStatus.Items.AddRange(new object[] { "Aktif", "Tidak Aktif" });
            this.cmbModalStatus.SelectedIndex = 0;

            // Buttons
            this.btnModalBatal.Text = "Batal";
            this.btnModalBatal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModalBatal.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnModalBatal.BackColor = System.Drawing.Color.White;
            this.btnModalBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalBatal.FlatAppearance.BorderSize = 0;
            this.btnModalBatal.Size = new System.Drawing.Size(85, 36);
            this.btnModalBatal.Location = new System.Drawing.Point(208, 436);
            this.btnModalBatal.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnModalSimpan.Text = "💾 Simpan";
            this.btnModalSimpan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModalSimpan.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnModalSimpan.BackColor = System.Drawing.Color.FromArgb(162, 168, 100);
            this.btnModalSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalSimpan.FlatAppearance.BorderSize = 0;
            this.btnModalSimpan.Size = new System.Drawing.Size(100, 36);
            this.btnModalSimpan.Location = new System.Drawing.Point(302, 436);
            this.btnModalSimpan.Cursor = System.Windows.Forms.Cursors.Hand;

            // ════════════════════════════════════════════════════════
            // MODAL TAMBAH/EDIT PRODUK PANEN (Exact Figma Cards)
            // ════════════════════════════════════════════════════════
            this.pnlModalProdukCard.BackColor = System.Drawing.Color.FromArgb(250, 245, 234);
            this.pnlModalProdukCard.Controls.Add(this.btnModalProdSimpan);
            this.pnlModalProdukCard.Controls.Add(this.btnModalProdBatal);
            this.pnlModalProdukCard.Controls.Add(this.pnlBoxProdStatus);
            this.pnlModalProdukCard.Controls.Add(this.lblFldProdStatus);
            this.pnlModalProdukCard.Controls.Add(this.lblErrProdHarga);
            this.pnlModalProdukCard.Controls.Add(this.lblHelpProdHarga);
            this.pnlModalProdukCard.Controls.Add(this.pnlBoxProdHarga);
            this.pnlModalProdukCard.Controls.Add(this.lblFldProdHarga);
            this.pnlModalProdukCard.Controls.Add(this.lblErrProdNama);
            this.pnlModalProdukCard.Controls.Add(this.pnlBoxProdNama);
            this.pnlModalProdukCard.Controls.Add(this.lblFldProdNama);
            this.pnlModalProdukCard.Controls.Add(this.lblModalProdClose);
            this.pnlModalProdukCard.Controls.Add(this.lblModalProdSubtitle);
            this.pnlModalProdukCard.Controls.Add(this.lblModalProdTitle);
            this.pnlModalProdukCard.Size = new System.Drawing.Size(430, 410);

            this.lblModalProdClose.Text = "✕";
            this.lblModalProdClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblModalProdClose.ForeColor = System.Drawing.Color.FromArgb(107, 96, 82);
            this.lblModalProdClose.Location = new System.Drawing.Point(385, 18);
            this.lblModalProdClose.Size = new System.Drawing.Size(28, 28);
            this.lblModalProdClose.Cursor = System.Windows.Forms.Cursors.Hand;

            this.lblModalProdTitle.Text = "Tambah Produk Panen baru";
            this.lblModalProdTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblModalProdTitle.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblModalProdTitle.Location = new System.Drawing.Point(28, 20);
            this.lblModalProdTitle.Size = new System.Drawing.Size(340, 26);

            this.lblModalProdSubtitle.Text = "Isi data di bawah ini, lalu tekan Simpan";
            this.lblModalProdSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblModalProdSubtitle.ForeColor = System.Drawing.Color.FromArgb(122, 112, 98);
            this.lblModalProdSubtitle.Location = new System.Drawing.Point(28, 48);
            this.lblModalProdSubtitle.Size = new System.Drawing.Size(340, 18);

            // Field: Nama Produk Panen
            this.lblFldProdNama.Text = "Nama Produk Panen";
            this.lblFldProdNama.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldProdNama.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldProdNama.Location = new System.Drawing.Point(28, 76);
            this.lblFldProdNama.Size = new System.Drawing.Size(374, 18);

            this.pnlBoxProdNama.BackColor = System.Drawing.Color.White;
            this.pnlBoxProdNama.Controls.Add(this.txtModalProdNama);
            this.pnlBoxProdNama.Location = new System.Drawing.Point(28, 96);
            this.pnlBoxProdNama.Size = new System.Drawing.Size(374, 36);

            this.txtModalProdNama.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtModalProdNama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtModalProdNama.Location = new System.Drawing.Point(10, 8);
            this.txtModalProdNama.Size = new System.Drawing.Size(354, 18);

            this.lblErrProdNama.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblErrProdNama.ForeColor = System.Drawing.Color.FromArgb(224, 82, 82);
            this.lblErrProdNama.Location = new System.Drawing.Point(28, 134);
            this.lblErrProdNama.Size = new System.Drawing.Size(374, 16);
            this.lblErrProdNama.Text = "ⓘ Mohon isi nama produk panen";
            this.lblErrProdNama.Visible = false;

            // Field: Harga per Kg
            this.lblFldProdHarga.Text = "Harga per Kg";
            this.lblFldProdHarga.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldProdHarga.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldProdHarga.Location = new System.Drawing.Point(28, 154);
            this.lblFldProdHarga.Size = new System.Drawing.Size(374, 18);

            this.pnlBoxProdHarga.BackColor = System.Drawing.Color.White;
            this.pnlBoxProdHarga.Controls.Add(this.txtModalProdHarga);
            this.pnlBoxProdHarga.Location = new System.Drawing.Point(28, 174);
            this.pnlBoxProdHarga.Size = new System.Drawing.Size(374, 36);

            this.txtModalProdHarga.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtModalProdHarga.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtModalProdHarga.Location = new System.Drawing.Point(10, 8);
            this.txtModalProdHarga.Size = new System.Drawing.Size(354, 18);

            this.lblHelpProdHarga.Text = "Tulis angka saja, tanpa titik. Contoh: 5900";
            this.lblHelpProdHarga.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.lblHelpProdHarga.ForeColor = System.Drawing.Color.FromArgb(122, 112, 98);
            this.lblHelpProdHarga.Location = new System.Drawing.Point(28, 212);
            this.lblHelpProdHarga.Size = new System.Drawing.Size(374, 16);

            this.lblErrProdHarga.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblErrProdHarga.ForeColor = System.Drawing.Color.FromArgb(224, 82, 82);
            this.lblErrProdHarga.Location = new System.Drawing.Point(28, 228);
            this.lblErrProdHarga.Size = new System.Drawing.Size(374, 16);
            this.lblErrProdHarga.Text = "ⓘ Mohon isi harga produk panen";
            this.lblErrProdHarga.Visible = false;

            // Field: Status
            this.lblFldProdStatus.Text = "Status";
            this.lblFldProdStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldProdStatus.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldProdStatus.Location = new System.Drawing.Point(28, 248);
            this.lblFldProdStatus.Size = new System.Drawing.Size(374, 18);

            this.pnlBoxProdStatus.BackColor = System.Drawing.Color.White;
            this.pnlBoxProdStatus.Controls.Add(this.cmbModalProdStatus);
            this.pnlBoxProdStatus.Location = new System.Drawing.Point(28, 268);
            this.pnlBoxProdStatus.Size = new System.Drawing.Size(374, 36);

            this.cmbModalProdStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModalProdStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbModalProdStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbModalProdStatus.FormattingEnabled = true;
            this.cmbModalProdStatus.Items.AddRange(new object[] { "Aktif", "Tidak Aktif" });
            this.cmbModalProdStatus.SelectedIndex = 0;
            this.cmbModalProdStatus.Location = new System.Drawing.Point(8, 6);
            this.cmbModalProdStatus.Size = new System.Drawing.Size(358, 25);

            // Buttons
            this.btnModalProdBatal.Text = "Batal";
            this.btnModalProdBatal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnModalProdBatal.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnModalProdBatal.BackColor = System.Drawing.Color.White;
            this.btnModalProdBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalProdBatal.FlatAppearance.BorderSize = 0;
            this.btnModalProdBatal.Location = new System.Drawing.Point(208, 335);
            this.btnModalProdBatal.Size = new System.Drawing.Size(86, 36);
            this.btnModalProdBatal.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnModalProdSimpan.Text = "💾 Simpan";
            this.btnModalProdSimpan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnModalProdSimpan.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnModalProdSimpan.BackColor = System.Drawing.Color.FromArgb(154, 161, 119);
            this.btnModalProdSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalProdSimpan.FlatAppearance.BorderSize = 0;
            this.btnModalProdSimpan.Location = new System.Drawing.Point(302, 335);
            this.btnModalProdSimpan.Size = new System.Drawing.Size(100, 36);
            this.btnModalProdSimpan.Cursor = System.Windows.Forms.Cursors.Hand;

            
            // ════════════════════════════════════════════════════════
            // SETOR PANEN PAGE (EXACT FIGMA REPLICA)
            // ════════════════════════════════════════════════════════
            this.pnlSetorPanen.BackColor = System.Drawing.Color.Transparent;
            this.pnlSetorPanen.Controls.Add(this.pnlSetorTableOuter);
            this.pnlSetorPanen.Controls.Add(this.lblSetorTableTitle);
            this.pnlSetorPanen.Controls.Add(this.pnlSetorFormCard);
            this.pnlSetorPanen.Controls.Add(this.pnlSetorHeader);
            this.pnlSetorPanen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSetorPanen.AutoScroll = true;
            this.pnlSetorPanen.Visible = false;

            // Setor Header
            this.pnlSetorHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlSetorHeader.Controls.Add(this.lblSetorSubtitle);
            this.pnlSetorHeader.Controls.Add(this.lblSetorTitle);
            this.pnlSetorHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSetorHeader.Height = 74;

            this.lblSetorTitle.Text = "Setor Panen";
            this.lblSetorTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblSetorTitle.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblSetorTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSetorTitle.Height = 44;

            this.lblSetorSubtitle.Text = "Catat hasil panen yang ditimbang di gudang";
            this.lblSetorSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.8F);
            this.lblSetorSubtitle.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblSetorSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSetorSubtitle.Height = 26;

            // Form Card
            this.pnlSetorFormCard.BackColor = System.Drawing.Color.FromArgb(250, 245, 234);
            this.pnlSetorFormCard.Controls.Add(this.btnSetorSimpan);
            this.pnlSetorFormCard.Controls.Add(this.btnSetorKosongkan);
            this.pnlSetorFormCard.Controls.Add(this.lblSetorTotalHelp);
            this.pnlSetorFormCard.Controls.Add(this.pnlBoxSetorTotal);
            this.pnlSetorFormCard.Controls.Add(this.lblFldSetorTotal);
            this.pnlSetorFormCard.Controls.Add(this.pnlBoxSetorBerat);
            this.pnlSetorFormCard.Controls.Add(this.lblFldSetorBerat);
            this.pnlSetorFormCard.Controls.Add(this.pnlBoxSetorKualitas);
            this.pnlSetorFormCard.Controls.Add(this.lblFldSetorKualitas);
            this.pnlSetorFormCard.Controls.Add(this.pnlBoxSetorProduk);
            this.pnlSetorFormCard.Controls.Add(this.lblFldSetorProduk);
            this.pnlSetorFormCard.Controls.Add(this.pnlBoxSetorPetani);
            this.pnlSetorFormCard.Controls.Add(this.lblFldSetorPetani);
            this.pnlSetorFormCard.Location = new System.Drawing.Point(0, 78);
            this.pnlSetorFormCard.Size = new System.Drawing.Size(880, 256);

            // Petani
            this.lblFldSetorPetani.Text = "Petani";
            this.lblFldSetorPetani.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldSetorPetani.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldSetorPetani.Location = new System.Drawing.Point(24, 14);
            this.lblFldSetorPetani.Size = new System.Drawing.Size(200, 18);

            this.pnlBoxSetorPetani.BackColor = System.Drawing.Color.White;
            this.pnlBoxSetorPetani.Controls.Add(this.cmbSetorPetani);
            this.pnlBoxSetorPetani.Location = new System.Drawing.Point(24, 34);
            this.pnlBoxSetorPetani.Size = new System.Drawing.Size(400, 36);

            this.cmbSetorPetani.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSetorPetani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSetorPetani.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbSetorPetani.Location = new System.Drawing.Point(8, 6);
            this.cmbSetorPetani.Size = new System.Drawing.Size(384, 25);

            // Produk Panen
            this.lblFldSetorProduk.Text = "Produk Panen";
            this.lblFldSetorProduk.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldSetorProduk.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldSetorProduk.Location = new System.Drawing.Point(450, 14);
            this.lblFldSetorProduk.Size = new System.Drawing.Size(200, 18);

            this.pnlBoxSetorProduk.BackColor = System.Drawing.Color.White;
            this.pnlBoxSetorProduk.Controls.Add(this.cmbSetorProduk);
            this.pnlBoxSetorProduk.Location = new System.Drawing.Point(450, 34);
            this.pnlBoxSetorProduk.Size = new System.Drawing.Size(400, 36);

            this.cmbSetorProduk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSetorProduk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSetorProduk.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbSetorProduk.Location = new System.Drawing.Point(8, 6);
            this.cmbSetorProduk.Size = new System.Drawing.Size(384, 25);

            // Kualitas
            this.lblFldSetorKualitas.Text = "Kualitas";
            this.lblFldSetorKualitas.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldSetorKualitas.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldSetorKualitas.Location = new System.Drawing.Point(24, 76);
            this.lblFldSetorKualitas.Size = new System.Drawing.Size(200, 18);

            this.pnlBoxSetorKualitas.BackColor = System.Drawing.Color.White;
            this.pnlBoxSetorKualitas.Controls.Add(this.cmbSetorKualitas);
            this.pnlBoxSetorKualitas.Location = new System.Drawing.Point(24, 96);
            this.pnlBoxSetorKualitas.Size = new System.Drawing.Size(400, 36);

            this.cmbSetorKualitas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSetorKualitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSetorKualitas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbSetorKualitas.Location = new System.Drawing.Point(8, 6);
            this.cmbSetorKualitas.Size = new System.Drawing.Size(384, 25);

            // Berat (Kg)
            this.lblFldSetorBerat.Text = "Berat (Kg)";
            this.lblFldSetorBerat.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldSetorBerat.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldSetorBerat.Location = new System.Drawing.Point(450, 76);
            this.lblFldSetorBerat.Size = new System.Drawing.Size(200, 18);

            this.pnlBoxSetorBerat.BackColor = System.Drawing.Color.White;
            this.pnlBoxSetorBerat.Controls.Add(this.lblSetorUnitKg);
            this.pnlBoxSetorBerat.Controls.Add(this.txtSetorBerat);
            this.pnlBoxSetorBerat.Location = new System.Drawing.Point(450, 96);
            this.pnlBoxSetorBerat.Size = new System.Drawing.Size(400, 36);

            this.txtSetorBerat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSetorBerat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSetorBerat.Location = new System.Drawing.Point(10, 8);
            this.txtSetorBerat.Size = new System.Drawing.Size(340, 18);

            this.lblSetorUnitKg.Text = "Kg";
            this.lblSetorUnitKg.Font = new System.Drawing.Font("Segoe UI", 9.2F, System.Drawing.FontStyle.Bold);
            this.lblSetorUnitKg.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblSetorUnitKg.Location = new System.Drawing.Point(360, 8);
            this.lblSetorUnitKg.Size = new System.Drawing.Size(30, 20);

            // Total Uang
            this.lblFldSetorTotal.Text = "Total Uang";
            this.lblFldSetorTotal.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldSetorTotal.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldSetorTotal.Location = new System.Drawing.Point(24, 138);
            this.lblFldSetorTotal.Size = new System.Drawing.Size(200, 18);

            this.pnlBoxSetorTotal.BackColor = System.Drawing.Color.White;
            this.pnlBoxSetorTotal.Controls.Add(this.lblSetorTotalValue);
            this.pnlBoxSetorTotal.Location = new System.Drawing.Point(24, 158);
            this.pnlBoxSetorTotal.Size = new System.Drawing.Size(826, 46);

            this.lblSetorTotalValue.Text = "Rp";
            this.lblSetorTotalValue.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblSetorTotalValue.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblSetorTotalValue.Location = new System.Drawing.Point(12, 8);
            this.lblSetorTotalValue.Size = new System.Drawing.Size(800, 30);

            this.lblSetorTotalHelp.Text = "Pilih produk panen dan kualitas untuk melihat harga";
            this.lblSetorTotalHelp.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSetorTotalHelp.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblSetorTotalHelp.Location = new System.Drawing.Point(24, 212);
            this.lblSetorTotalHelp.Size = new System.Drawing.Size(450, 18);

            // Action Buttons
            this.btnSetorKosongkan.Text = "🔄 Kosongkan";
            this.btnSetorKosongkan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSetorKosongkan.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnSetorKosongkan.BackColor = System.Drawing.Color.White;
            this.btnSetorKosongkan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetorKosongkan.FlatAppearance.BorderSize = 0;
            this.btnSetorKosongkan.Location = new System.Drawing.Point(580, 208);
            this.btnSetorKosongkan.Size = new System.Drawing.Size(125, 36);
            this.btnSetorKosongkan.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnSetorSimpan.Text = "💾 Simpan Setoran";
            this.btnSetorSimpan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSetorSimpan.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnSetorSimpan.BackColor = System.Drawing.Color.FromArgb(154, 161, 119);
            this.btnSetorSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetorSimpan.FlatAppearance.BorderSize = 0;
            this.btnSetorSimpan.Location = new System.Drawing.Point(715, 208);
            this.btnSetorSimpan.Size = new System.Drawing.Size(135, 36);
            this.btnSetorSimpan.Cursor = System.Windows.Forms.Cursors.Hand;

            // Section Label
            this.lblSetorTableTitle.Text = "Setoran Hari Ini";
            this.lblSetorTableTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblSetorTableTitle.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblSetorTableTitle.Location = new System.Drawing.Point(0, 350);
            this.lblSetorTableTitle.Size = new System.Drawing.Size(300, 26);

            // Setor Table Outer
            this.pnlSetorTableOuter.BackColor = System.Drawing.Color.Transparent;
            this.pnlSetorTableOuter.Controls.Add(this.pnlSetorTableInner);
            this.pnlSetorTableOuter.Location = new System.Drawing.Point(0, 384);
            this.pnlSetorTableOuter.Size = new System.Drawing.Size(880, 220);

            this.pnlSetorTableInner.BackColor = System.Drawing.Color.White;
            this.pnlSetorTableInner.Controls.Add(this.lblEmptySetor);
            this.pnlSetorTableInner.Controls.Add(this.dgvSetorPanen);
            this.pnlSetorTableInner.Controls.Add(this.pnlSetorTableHeader);
            this.pnlSetorTableInner.Dock = System.Windows.Forms.DockStyle.Fill;

            this.pnlSetorTableHeader.BackColor = System.Drawing.Color.FromArgb(154, 161, 119);
            this.pnlSetorTableHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSetorTableHeader.Height = 44;

            this.lblEmptySetor.BackColor = System.Drawing.Color.FromArgb(250, 244, 230);
            this.lblEmptySetor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmptySetor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmptySetor.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblEmptySetor.Text = "Belum ada setoran hari ini";
            this.lblEmptySetor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmptySetor.Visible = false;

            this.dgvSetorPanen.BackgroundColor = System.Drawing.Color.FromArgb(250, 244, 230);
            this.dgvSetorPanen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSetorPanen.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSetorPanen.RowHeadersVisible = false;
            this.dgvSetorPanen.AllowUserToAddRows = false;
            this.dgvSetorPanen.AllowUserToDeleteRows = false;
            this.dgvSetorPanen.AllowUserToResizeRows = false;
            this.dgvSetorPanen.AllowUserToResizeColumns = false;
            this.dgvSetorPanen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSetorPanen.MultiSelect = false;
            this.dgvSetorPanen.ReadOnly = true;
            this.dgvSetorPanen.ColumnHeadersVisible = false;
            this.dgvSetorPanen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSetorPanen.RowTemplate.Height = 48;

            // ════════════════════════════════════════════════════════
            // MUATAN BARANG & LAPORAN PAGE (EXACT FIGMA REPLICA)
            // ════════════════════════════════════════════════════════
            this.pnlMuatanBarang.BackColor = System.Drawing.Color.Transparent;
            this.pnlMuatanBarang.Controls.Add(this.lblMuatanError);
            this.pnlMuatanBarang.Controls.Add(this.pnlMuatanDipilihBox);
            this.pnlMuatanBarang.Controls.Add(this.pnlMuatanSummaryBar);
            this.pnlMuatanBarang.Controls.Add(this.pnlMuatanTableOuter);
            this.pnlMuatanBarang.Controls.Add(this.pnlMuatanFilterBar);
            this.pnlMuatanBarang.Controls.Add(this.pnlMuatanHeader);
            this.pnlMuatanBarang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMuatanBarang.Visible = false;

            // Header
            this.pnlMuatanHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlMuatanHeader.Controls.Add(this.lblMuatanSubtitle);
            this.pnlMuatanHeader.Controls.Add(this.lblMuatanTitle);
            this.pnlMuatanHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMuatanHeader.Height = 74;

            this.lblMuatanTitle.Text = "Muatan Barang";
            this.lblMuatanTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblMuatanTitle.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblMuatanTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMuatanTitle.Height = 44;

            this.lblMuatanSubtitle.Text = "Status pengangkutan dan pengiriman muatan hasil panen";
            this.lblMuatanSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.8F);
            this.lblMuatanSubtitle.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblMuatanSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMuatanSubtitle.Height = 26;

            // Filter Bar
            this.pnlMuatanFilterBar.BackColor = System.Drawing.Color.Transparent;
            this.pnlMuatanFilterBar.Controls.Add(this.pnlBoxMuatanStatus);
            this.pnlMuatanFilterBar.Controls.Add(this.lblFldMuatanStatus);
            this.pnlMuatanFilterBar.Controls.Add(this.pnlBoxMuatanSampai);
            this.pnlMuatanFilterBar.Controls.Add(this.lblFldMuatanSampai);
            this.pnlMuatanFilterBar.Controls.Add(this.pnlBoxMuatanDari);
            this.pnlMuatanFilterBar.Controls.Add(this.lblFldMuatanDari);
            this.pnlMuatanFilterBar.Location = new System.Drawing.Point(0, 78);
            this.pnlMuatanFilterBar.Size = new System.Drawing.Size(880, 58);

            this.lblFldMuatanDari.Text = "Dari Tanggal";
            this.lblFldMuatanDari.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblFldMuatanDari.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldMuatanDari.Location = new System.Drawing.Point(0, 2);
            this.lblFldMuatanDari.Size = new System.Drawing.Size(120, 16);

            this.pnlBoxMuatanDari.BackColor = System.Drawing.Color.White;
            this.pnlBoxMuatanDari.Controls.Add(this.dtpMuatanDari);
            this.pnlBoxMuatanDari.Location = new System.Drawing.Point(0, 20);
            this.pnlBoxMuatanDari.Size = new System.Drawing.Size(140, 34);

            this.dtpMuatanDari.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMuatanDari.CustomFormat = "dd/MM/yy";
            this.dtpMuatanDari.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpMuatanDari.Location = new System.Drawing.Point(6, 4);
            this.dtpMuatanDari.Size = new System.Drawing.Size(128, 25);

            this.lblFldMuatanSampai.Text = "Sampai Tanggal";
            this.lblFldMuatanSampai.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblFldMuatanSampai.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldMuatanSampai.Location = new System.Drawing.Point(155, 2);
            this.lblFldMuatanSampai.Size = new System.Drawing.Size(120, 16);

            this.pnlBoxMuatanSampai.BackColor = System.Drawing.Color.White;
            this.pnlBoxMuatanSampai.Controls.Add(this.dtpMuatanSampai);
            this.pnlBoxMuatanSampai.Location = new System.Drawing.Point(155, 20);
            this.pnlBoxMuatanSampai.Size = new System.Drawing.Size(140, 34);

            this.dtpMuatanSampai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMuatanSampai.CustomFormat = "dd/MM/yy";
            this.dtpMuatanSampai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpMuatanSampai.Location = new System.Drawing.Point(6, 4);
            this.dtpMuatanSampai.Size = new System.Drawing.Size(128, 25);

            this.lblFldMuatanStatus.Text = "Status";
            this.lblFldMuatanStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblFldMuatanStatus.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldMuatanStatus.Location = new System.Drawing.Point(310, 2);
            this.lblFldMuatanStatus.Size = new System.Drawing.Size(120, 16);

            this.pnlBoxMuatanStatus.BackColor = System.Drawing.Color.White;
            this.pnlBoxMuatanStatus.Controls.Add(this.cmbMuatanStatus);
            this.pnlBoxMuatanStatus.Location = new System.Drawing.Point(310, 20);
            this.pnlBoxMuatanStatus.Size = new System.Drawing.Size(155, 34);

            this.cmbMuatanStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMuatanStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMuatanStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbMuatanStatus.Items.AddRange(new object[] { "Semua Status", "Di Gudang", "Terkirim", "Dibatalkan" });
            this.cmbMuatanStatus.SelectedIndex = 0;
            this.cmbMuatanStatus.Location = new System.Drawing.Point(6, 5);
            this.cmbMuatanStatus.Size = new System.Drawing.Size(143, 23);

            // Table Outer
            this.pnlMuatanTableOuter.BackColor = System.Drawing.Color.Transparent;
            this.pnlMuatanTableOuter.Controls.Add(this.pnlMuatanTableInner);
            this.pnlMuatanTableOuter.Location = new System.Drawing.Point(0, 142);
            this.pnlMuatanTableOuter.Size = new System.Drawing.Size(880, 310);

            this.pnlMuatanTableInner.BackColor = System.Drawing.Color.White;
            this.pnlMuatanTableInner.Controls.Add(this.lblEmptyMuatan);
            this.pnlMuatanTableInner.Controls.Add(this.dgvMuatanBarang);
            this.pnlMuatanTableInner.Controls.Add(this.pnlMuatanTableHeader);
            this.pnlMuatanTableInner.Dock = System.Windows.Forms.DockStyle.Fill;

            this.pnlMuatanTableHeader.BackColor = System.Drawing.Color.FromArgb(154, 161, 119);
            this.pnlMuatanTableHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMuatanTableHeader.Height = 44;

            this.lblEmptyMuatan.BackColor = System.Drawing.Color.FromArgb(250, 244, 230);
            this.lblEmptyMuatan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmptyMuatan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmptyMuatan.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblEmptyMuatan.Text = "Tidak ada data muatan/transaksi panen pada periode ini";
            this.lblEmptyMuatan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmptyMuatan.Visible = false;

            this.dgvMuatanBarang.BackgroundColor = System.Drawing.Color.FromArgb(250, 244, 230);
            this.dgvMuatanBarang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMuatanBarang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMuatanBarang.RowHeadersVisible = false;
            this.dgvMuatanBarang.AllowUserToAddRows = false;
            this.dgvMuatanBarang.AllowUserToDeleteRows = false;
            this.dgvMuatanBarang.AllowUserToResizeRows = false;
            this.dgvMuatanBarang.AllowUserToResizeColumns = false;
            this.dgvMuatanBarang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMuatanBarang.MultiSelect = false;
            this.dgvMuatanBarang.ReadOnly = true;
            this.dgvMuatanBarang.ColumnHeadersVisible = false;
            this.dgvMuatanBarang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMuatanBarang.RowTemplate.Height = 50;

            // Summary Footer
            this.pnlMuatanSummaryBar.BackColor = System.Drawing.Color.Transparent;
            this.pnlMuatanSummaryBar.Controls.Add(this.btnMuatanEksporCsv);
            this.pnlMuatanSummaryBar.Controls.Add(this.lblMuatanSummaryTotal);
            this.pnlMuatanSummaryBar.Controls.Add(this.lblMuatanSummaryBerat);
            this.pnlMuatanSummaryBar.Controls.Add(this.lblMuatanSummaryJumlah);
            this.pnlMuatanSummaryBar.Location = new System.Drawing.Point(0, 460);
            this.pnlMuatanSummaryBar.Size = new System.Drawing.Size(880, 46);

            this.lblMuatanSummaryJumlah.Text = "Jumlah: 04 Transaksi";
            this.lblMuatanSummaryJumlah.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMuatanSummaryJumlah.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblMuatanSummaryJumlah.Location = new System.Drawing.Point(4, 12);
            this.lblMuatanSummaryJumlah.Size = new System.Drawing.Size(160, 24);

            this.lblMuatanSummaryBerat.Text = "Berat: 24 Kg";
            this.lblMuatanSummaryBerat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMuatanSummaryBerat.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblMuatanSummaryBerat.Location = new System.Drawing.Point(170, 12);
            this.lblMuatanSummaryBerat.Size = new System.Drawing.Size(140, 24);

            this.lblMuatanSummaryTotal.Text = "Total: Rp 456.700";
            this.lblMuatanSummaryTotal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMuatanSummaryTotal.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblMuatanSummaryTotal.Location = new System.Drawing.Point(315, 12);
            this.lblMuatanSummaryTotal.Size = new System.Drawing.Size(200, 24);

            this.btnMuatanEksporCsv.Text = "⬇ Ekspor CSV";
            this.btnMuatanEksporCsv.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnMuatanEksporCsv.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnMuatanEksporCsv.BackColor = System.Drawing.Color.FromArgb(154, 161, 119);
            this.btnMuatanEksporCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuatanEksporCsv.FlatAppearance.BorderSize = 0;
            this.btnMuatanEksporCsv.Location = new System.Drawing.Point(740, 6);
            this.btnMuatanEksporCsv.Size = new System.Drawing.Size(135, 36);
            this.btnMuatanEksporCsv.Cursor = System.Windows.Forms.Cursors.Hand;

            // Error Label Muatan
            this.lblMuatanError.Text = "(!) Mohon pilih muatan yang ingin dikirim";
            this.lblMuatanError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblMuatanError.ForeColor = System.Drawing.Color.FromArgb(222, 82, 82);
            this.lblMuatanError.Location = new System.Drawing.Point(0, 470);
            this.lblMuatanError.Size = new System.Drawing.Size(400, 24);
            this.lblMuatanError.Visible = false;

            // Dipilih Card
            this.pnlMuatanDipilihBox.BackColor = System.Drawing.Color.White;
            this.pnlMuatanDipilihBox.Controls.Add(this.btnBuatSuratJalan);
            this.pnlMuatanDipilihBox.Controls.Add(this.lblDipilihBerat);
            this.pnlMuatanDipilihBox.Controls.Add(this.lblDipilihCount);
            this.pnlMuatanDipilihBox.Controls.Add(this.lblDipilihHeader);
            this.pnlMuatanDipilihBox.Location = new System.Drawing.Point(620, 455);
            this.pnlMuatanDipilihBox.Size = new System.Drawing.Size(260, 68);
            this.pnlMuatanDipilihBox.Visible = false;

            this.lblDipilihHeader.Text = "DIPILIH";
            this.lblDipilihHeader.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblDipilihHeader.ForeColor = System.Drawing.Color.FromArgb(140, 130, 117);
            this.lblDipilihHeader.Location = new System.Drawing.Point(12, 8);
            this.lblDipilihHeader.Size = new System.Drawing.Size(80, 14);

            this.lblDipilihCount.Text = "0 Barang";
            this.lblDipilihCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDipilihCount.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblDipilihCount.Location = new System.Drawing.Point(12, 22);
            this.lblDipilihCount.Size = new System.Drawing.Size(100, 24);

            this.lblDipilihBerat.Text = "0 Kg";
            this.lblDipilihBerat.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular);
            this.lblDipilihBerat.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblDipilihBerat.Location = new System.Drawing.Point(12, 46);
            this.lblDipilihBerat.Size = new System.Drawing.Size(100, 16);

            this.btnBuatSuratJalan.Text = "🖹 Buat Surat Jalan";
            this.btnBuatSuratJalan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuatSuratJalan.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnBuatSuratJalan.BackColor = System.Drawing.Color.FromArgb(154, 161, 119);
            this.btnBuatSuratJalan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuatSuratJalan.FlatAppearance.BorderSize = 0;
            this.btnBuatSuratJalan.Location = new System.Drawing.Point(115, 12);
            this.btnBuatSuratJalan.Size = new System.Drawing.Size(135, 44);
            this.btnBuatSuratJalan.Cursor = System.Windows.Forms.Cursors.Hand;


            // ════════════════════════════════════════════════════════
            // MODAL PEMBATALAN TRANSAKSI (Exact Figma Replica)
            // ════════════════════════════════════════════════════════
            this.pnlModalBatalCard.BackColor = System.Drawing.Color.FromArgb(250, 245, 234);
            this.pnlModalBatalCard.Controls.Add(this.btnBatalKonfirmasi);
            this.pnlModalBatalCard.Controls.Add(this.btnBatalKembali);
            this.pnlModalBatalCard.Controls.Add(this.pnlBoxAlasanBatal);
            this.pnlModalBatalCard.Controls.Add(this.lblFldAlasanBatal);
            this.pnlModalBatalCard.Controls.Add(this.pnlBatalInfoBox);
            this.pnlModalBatalCard.Controls.Add(this.pnlBatalHeader);
            this.pnlModalBatalCard.Location = new System.Drawing.Point(340, 100);
            this.pnlModalBatalCard.Size = new System.Drawing.Size(420, 390);

            // Batal Header (Warning Gold #F2B84B)
            this.pnlBatalHeader.BackColor = System.Drawing.Color.FromArgb(242, 184, 75);
            this.pnlBatalHeader.Controls.Add(this.lblModalBatalClose);
            this.pnlBatalHeader.Controls.Add(this.lblModalBatalSubtitle);
            this.pnlBatalHeader.Controls.Add(this.lblModalBatalTitle);
            this.pnlBatalHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBatalHeader.Height = 56;

            this.lblModalBatalClose.Text = "✕";
            this.lblModalBatalClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblModalBatalClose.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblModalBatalClose.Location = new System.Drawing.Point(385, 10);
            this.lblModalBatalClose.Size = new System.Drawing.Size(26, 26);
            this.lblModalBatalClose.Cursor = System.Windows.Forms.Cursors.Hand;

            this.lblModalBatalTitle.Text = "⚠  Pembatalan Transaksi";
            this.lblModalBatalTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblModalBatalTitle.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblModalBatalTitle.Location = new System.Drawing.Point(14, 8);
            this.lblModalBatalTitle.Size = new System.Drawing.Size(350, 22);

            this.lblModalBatalSubtitle.Text = "Tindakan ini tidak dapat diulang";
            this.lblModalBatalSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblModalBatalSubtitle.ForeColor = System.Drawing.Color.FromArgb(90, 69, 38);
            this.lblModalBatalSubtitle.Location = new System.Drawing.Point(16, 32);
            this.lblModalBatalSubtitle.Size = new System.Drawing.Size(350, 18);

            // Batal Info Box
            this.pnlBatalInfoBox.BackColor = System.Drawing.Color.White;
            this.pnlBatalInfoBox.Controls.Add(this.lblBatalTotal);
            this.pnlBatalInfoBox.Controls.Add(this.lblBatalDetail);
            this.pnlBatalInfoBox.Controls.Add(this.lblBatalPetani);
            this.pnlBatalInfoBox.Controls.Add(this.lblBatalTrxTgl);
            this.pnlBatalInfoBox.Controls.Add(this.lblBatalTrxNo);
            this.pnlBatalInfoBox.Location = new System.Drawing.Point(20, 72);
            this.pnlBatalInfoBox.Size = new System.Drawing.Size(380, 80);

            this.lblBatalTrxNo.Text = "STR-20241101-001";
            this.lblBatalTrxNo.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.lblBatalTrxNo.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblBatalTrxNo.Location = new System.Drawing.Point(12, 10);
            this.lblBatalTrxNo.Size = new System.Drawing.Size(180, 16);

            this.lblBatalTrxTgl.Text = "11 November 2024";
            this.lblBatalTrxTgl.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.lblBatalTrxTgl.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblBatalTrxTgl.Location = new System.Drawing.Point(200, 10);
            this.lblBatalTrxTgl.Size = new System.Drawing.Size(168, 16);
            this.lblBatalTrxTgl.TextAlign = System.Drawing.ContentAlignment.TopRight;

            this.lblBatalPetani.Text = "Bu Siti Rahayu";
            this.lblBatalPetani.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBatalPetani.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblBatalPetani.Location = new System.Drawing.Point(12, 28);
            this.lblBatalPetani.Size = new System.Drawing.Size(240, 24);

            this.lblBatalDetail.Text = "Padi (A)  6 Kg";
            this.lblBatalDetail.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            this.lblBatalDetail.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblBatalDetail.Location = new System.Drawing.Point(12, 54);
            this.lblBatalDetail.Size = new System.Drawing.Size(200, 18);

            this.lblBatalTotal.Text = "Rp 46.400";
            this.lblBatalTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBatalTotal.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblBatalTotal.Location = new System.Drawing.Point(200, 50);
            this.lblBatalTotal.Size = new System.Drawing.Size(168, 22);
            this.lblBatalTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // Alasan Box
            this.lblFldAlasanBatal.Text = "Alasan Pembatalan";
            this.lblFldAlasanBatal.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldAlasanBatal.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldAlasanBatal.Location = new System.Drawing.Point(20, 166);
            this.lblFldAlasanBatal.Size = new System.Drawing.Size(200, 18);

            this.pnlBoxAlasanBatal.BackColor = System.Drawing.Color.White;
            this.pnlBoxAlasanBatal.Controls.Add(this.txtAlasanBatal);
            this.pnlBoxAlasanBatal.Location = new System.Drawing.Point(20, 188);
            this.pnlBoxAlasanBatal.Size = new System.Drawing.Size(380, 110);

            this.txtAlasanBatal.BackColor = System.Drawing.Color.White;
            this.txtAlasanBatal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAlasanBatal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtAlasanBatal.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.txtAlasanBatal.Location = new System.Drawing.Point(8, 8);
            this.txtAlasanBatal.Multiline = true;
            this.txtAlasanBatal.Size = new System.Drawing.Size(364, 94);

            // Batal Buttons
            this.btnBatalKembali.Text = "Kembali";
            this.btnBatalKembali.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBatalKembali.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnBatalKembali.BackColor = System.Drawing.Color.White;
            this.btnBatalKembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatalKembali.FlatAppearance.BorderSize = 0;
            this.btnBatalKembali.Location = new System.Drawing.Point(20, 320);
            this.btnBatalKembali.Size = new System.Drawing.Size(160, 42);
            this.btnBatalKembali.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnBatalKonfirmasi.Text = "⊘ Ya, Batalkan";
            this.btnBatalKonfirmasi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBatalKonfirmasi.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnBatalKonfirmasi.BackColor = System.Drawing.Color.FromArgb(242, 184, 75);
            this.btnBatalKonfirmasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatalKonfirmasi.FlatAppearance.BorderSize = 0;
            this.btnBatalKonfirmasi.Location = new System.Drawing.Point(220, 320);
            this.btnBatalKonfirmasi.Size = new System.Drawing.Size(180, 42);
            this.btnBatalKonfirmasi.Cursor = System.Windows.Forms.Cursors.Hand;

            // ════════════════════════════════════════════════════════
            // MODAL TAMBAH/EDIT PENGGUNA
            // ════════════════════════════════════════════════════════
            this.pnlModalUserCard.BackColor = System.Drawing.Color.FromArgb(250, 245, 234);
            this.pnlModalUserCard.Controls.Add(this.btnModalUserSimpan);
            this.pnlModalUserCard.Controls.Add(this.btnModalUserBatal);
            this.pnlModalUserCard.Controls.Add(this.pnlBoxUserStatus);
            this.pnlModalUserCard.Controls.Add(this.lblFldUserStatus);
            this.pnlModalUserCard.Controls.Add(this.pnlBoxUserPeran);
            this.pnlModalUserCard.Controls.Add(this.lblFldUserPeran);
            this.pnlModalUserCard.Controls.Add(this.lblErrUserUname);
            this.pnlModalUserCard.Controls.Add(this.pnlBoxUserUname);
            this.pnlModalUserCard.Controls.Add(this.lblFldUserUname);
            this.pnlModalUserCard.Controls.Add(this.lblErrUserNama);
            this.pnlModalUserCard.Controls.Add(this.pnlBoxUserNama);
            this.pnlModalUserCard.Controls.Add(this.lblFldUserNama);
            this.pnlModalUserCard.Controls.Add(this.lblModalUserClose);
            this.pnlModalUserCard.Controls.Add(this.lblModalUserSubtitle);
            this.pnlModalUserCard.Controls.Add(this.lblModalUserTitle);
            this.pnlModalUserCard.Location = new System.Drawing.Point(340, 80);
            this.pnlModalUserCard.Size = new System.Drawing.Size(420, 440);

            this.lblModalUserClose.Text = "✕";
            this.lblModalUserClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblModalUserClose.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblModalUserClose.Location = new System.Drawing.Point(380, 16);
            this.lblModalUserClose.Size = new System.Drawing.Size(26, 26);
            this.lblModalUserClose.Cursor = System.Windows.Forms.Cursors.Hand;

            this.lblModalUserTitle.Text = "Tambah Pengguna Baru";
            this.lblModalUserTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblModalUserTitle.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblModalUserTitle.Location = new System.Drawing.Point(24, 16);
            this.lblModalUserTitle.Size = new System.Drawing.Size(350, 26);

            this.lblModalUserSubtitle.Text = "Isi data di bawah ini, lalu tekan Simpan";
            this.lblModalUserSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblModalUserSubtitle.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblModalUserSubtitle.Location = new System.Drawing.Point(24, 44);
            this.lblModalUserSubtitle.Size = new System.Drawing.Size(350, 20);

            // Nama Lengkap
            this.lblFldUserNama.Text = "Nama Lengkap";
            this.lblFldUserNama.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldUserNama.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldUserNama.Location = new System.Drawing.Point(24, 76);
            this.lblFldUserNama.Size = new System.Drawing.Size(200, 18);

            this.pnlBoxUserNama.BackColor = System.Drawing.Color.White;
            this.pnlBoxUserNama.Controls.Add(this.txtModalUserNama);
            this.pnlBoxUserNama.Location = new System.Drawing.Point(24, 98);
            this.pnlBoxUserNama.Size = new System.Drawing.Size(372, 38);

            this.txtModalUserNama.BackColor = System.Drawing.Color.White;
            this.txtModalUserNama.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtModalUserNama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtModalUserNama.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.txtModalUserNama.Location = new System.Drawing.Point(10, 9);
            this.txtModalUserNama.Size = new System.Drawing.Size(352, 22);

            this.lblErrUserNama.Text = "(!) Mohon isi nama lengkap";
            this.lblErrUserNama.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblErrUserNama.ForeColor = System.Drawing.Color.FromArgb(222, 82, 82);
            this.lblErrUserNama.Location = new System.Drawing.Point(24, 138);
            this.lblErrUserNama.Size = new System.Drawing.Size(200, 16);
            this.lblErrUserNama.Visible = false;

            // Nama Pengguna
            this.lblFldUserUname.Text = "Nama Pengguna";
            this.lblFldUserUname.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldUserUname.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldUserUname.Location = new System.Drawing.Point(24, 156);
            this.lblFldUserUname.Size = new System.Drawing.Size(200, 18);

            this.pnlBoxUserUname.BackColor = System.Drawing.Color.White;
            this.pnlBoxUserUname.Controls.Add(this.txtModalUserUname);
            this.pnlBoxUserUname.Location = new System.Drawing.Point(24, 178);
            this.pnlBoxUserUname.Size = new System.Drawing.Size(372, 38);

            this.txtModalUserUname.BackColor = System.Drawing.Color.White;
            this.txtModalUserUname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtModalUserUname.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtModalUserUname.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.txtModalUserUname.Location = new System.Drawing.Point(10, 9);
            this.txtModalUserUname.Size = new System.Drawing.Size(352, 22);

            this.lblErrUserUname.Text = "(!) Mohon isi nama pengguna";
            this.lblErrUserUname.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblErrUserUname.ForeColor = System.Drawing.Color.FromArgb(222, 82, 82);
            this.lblErrUserUname.Location = new System.Drawing.Point(24, 218);
            this.lblErrUserUname.Size = new System.Drawing.Size(200, 16);
            this.lblErrUserUname.Visible = false;

            // Peran
            this.lblFldUserPeran.Text = "Peran";
            this.lblFldUserPeran.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldUserPeran.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldUserPeran.Location = new System.Drawing.Point(24, 236);
            this.lblFldUserPeran.Size = new System.Drawing.Size(200, 18);

            this.pnlBoxUserPeran.BackColor = System.Drawing.Color.White;
            this.pnlBoxUserPeran.Controls.Add(this.cmbModalUserPeran);
            this.pnlBoxUserPeran.Location = new System.Drawing.Point(24, 258);
            this.pnlBoxUserPeran.Size = new System.Drawing.Size(372, 38);

            this.cmbModalUserPeran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModalUserPeran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbModalUserPeran.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbModalUserPeran.Items.AddRange(new object[] { "Admin", "Petugas Gudang", "Supir" });
            this.cmbModalUserPeran.SelectedIndex = 0;
            this.cmbModalUserPeran.Location = new System.Drawing.Point(6, 6);
            this.cmbModalUserPeran.Size = new System.Drawing.Size(360, 26);

            // Status
            this.lblFldUserStatus.Text = "Status";
            this.lblFldUserStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFldUserStatus.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblFldUserStatus.Location = new System.Drawing.Point(24, 304);
            this.lblFldUserStatus.Size = new System.Drawing.Size(200, 18);

            this.pnlBoxUserStatus.BackColor = System.Drawing.Color.White;
            this.pnlBoxUserStatus.Controls.Add(this.cmbModalUserStatus);
            this.pnlBoxUserStatus.Location = new System.Drawing.Point(24, 326);
            this.pnlBoxUserStatus.Size = new System.Drawing.Size(372, 38);

            this.cmbModalUserStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModalUserStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbModalUserStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbModalUserStatus.Items.AddRange(new object[] { "Aktif", "Tidak Aktif" });
            this.cmbModalUserStatus.SelectedIndex = 0;
            this.cmbModalUserStatus.Location = new System.Drawing.Point(6, 6);
            this.cmbModalUserStatus.Size = new System.Drawing.Size(360, 26);

            // User Modal Buttons
            this.btnModalUserBatal.Text = "Batal";
            this.btnModalUserBatal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnModalUserBatal.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnModalUserBatal.BackColor = System.Drawing.Color.White;
            this.btnModalUserBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalUserBatal.FlatAppearance.BorderSize = 0;
            this.btnModalUserBatal.Location = new System.Drawing.Point(180, 382);
            this.btnModalUserBatal.Size = new System.Drawing.Size(100, 40);
            this.btnModalUserBatal.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnModalUserSimpan.Text = "💾 Simpan";
            this.btnModalUserSimpan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnModalUserSimpan.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnModalUserSimpan.BackColor = System.Drawing.Color.FromArgb(154, 161, 119);
            this.btnModalUserSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalUserSimpan.FlatAppearance.BorderSize = 0;
            this.btnModalUserSimpan.Location = new System.Drawing.Point(296, 382);
            this.btnModalUserSimpan.Size = new System.Drawing.Size(100, 40);
            this.btnModalUserSimpan.Cursor = System.Windows.Forms.Cursors.Hand;
            // ════════════════════════════════════════════════════════
            // OTHER PAGE (MANAJEMEN PENGGUNA)
            // ════════════════════════════════════════════════════════
            this.pnlOtherPage.BackColor = System.Drawing.Color.Transparent;
            this.pnlOtherPage.Controls.Add(this.pnlOtherTableOuter);
            this.pnlOtherPage.Controls.Add(this.pnlOtherHeader);
            this.pnlOtherPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOtherPage.Visible = false;

            this.pnlOtherHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlOtherHeader.Controls.Add(this.btnTambahUser);
            this.pnlOtherHeader.Controls.Add(this.lblOtherSub);
            this.pnlOtherHeader.Controls.Add(this.lblOtherTitle);
            this.pnlOtherHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOtherHeader.Height = 74;

            this.lblOtherTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblOtherTitle.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.lblOtherTitle.Location = new System.Drawing.Point(0, 0);
            this.lblOtherTitle.Size = new System.Drawing.Size(600, 44);
            this.lblOtherTitle.Text = "Manajemen Pengguna";

            this.lblOtherSub.Font = new System.Drawing.Font("Segoe UI", 9.8F);
            this.lblOtherSub.ForeColor = System.Drawing.Color.FromArgb(120, 110, 94);
            this.lblOtherSub.Location = new System.Drawing.Point(0, 44);
            this.lblOtherSub.Size = new System.Drawing.Size(600, 26);
            this.lblOtherSub.Text = "Akun yang dapat menggunakan aplikasi";

            this.btnTambahUser.Text = "+ Tambah Data";
            this.btnTambahUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTambahUser.ForeColor = System.Drawing.Color.FromArgb(54, 44, 36);
            this.btnTambahUser.BackColor = System.Drawing.Color.FromArgb(154, 161, 119);
            this.btnTambahUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambahUser.FlatAppearance.BorderSize = 0;
            this.btnTambahUser.Location = new System.Drawing.Point(740, 10);
            this.btnTambahUser.Size = new System.Drawing.Size(140, 42);
            this.btnTambahUser.Cursor = System.Windows.Forms.Cursors.Hand;

            this.pnlOtherTableOuter.BackColor = System.Drawing.Color.Transparent;
            this.pnlOtherTableOuter.Controls.Add(this.pnlOtherTableInner);
            this.pnlOtherTableOuter.Location = new System.Drawing.Point(0, 85);
            this.pnlOtherTableOuter.Size = new System.Drawing.Size(880, 280);

            this.pnlOtherTableInner.BackColor = System.Drawing.Color.White;
            this.pnlOtherTableInner.Controls.Add(this.dgvOther);
            this.pnlOtherTableInner.Controls.Add(this.pnlOtherTableHeader);
            this.pnlOtherTableInner.Dock = System.Windows.Forms.DockStyle.Fill;

            this.pnlOtherTableHeader.BackColor = System.Drawing.Color.FromArgb(154, 161, 119);
            this.pnlOtherTableHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOtherTableHeader.Height = 44;

            this.dgvOther.BackgroundColor = System.Drawing.Color.White;
            this.dgvOther.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOther.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOther.GridColor = System.Drawing.Color.FromArgb(237, 229, 211);
            this.dgvOther.RowHeadersVisible = false;
            this.dgvOther.AllowUserToAddRows = false;
            this.dgvOther.AllowUserToDeleteRows = false;
            this.dgvOther.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOther.EnableHeadersVisualStyles = false;
            this.dgvOther.ColumnHeadersVisible = false;
            this.dgvOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOther.DefaultCellStyle = dgvRowStyle;
            this.dgvOther.RowTemplate.Height = 48;
            this.dgvOther.AlternatingRowsDefaultCellStyle = dgvAltRowStyle;

            // ════════════════════════════════════════════════════════
            // FORM
            // ════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(250, 245, 234);
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.MinimumSize = new System.Drawing.Size(1080, 660);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AGRIVA — Koperasi Tani Desa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardForm_Load);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlNavArea.ResumeLayout(false);
            this.pnlLogoArea.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToast.ResumeLayout(false);
            this.pnlDashboard.ResumeLayout(false);
            this.pnlCardsContainer.ResumeLayout(false);
            this.pnlBackupCard.ResumeLayout(false);
            this.pnlPetani.ResumeLayout(false);
            this.pnlPetaniHeader.ResumeLayout(false);
            this.pnlPetaniTableOuter.ResumeLayout(false);
            this.pnlPetaniTableInner.ResumeLayout(false);
            this.pnlPetaniTableHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPetani)).EndInit();
            this.pnlProdukPanen.ResumeLayout(false);
            this.pnlProdukPanenHeader.ResumeLayout(false);
            this.pnlProdukPanenTableOuter.ResumeLayout(false);
            this.pnlProdukPanenTableInner.ResumeLayout(false);
            this.pnlProdukPanenTableHeader.ResumeLayout(false);
            this.pnlSetorPanen.ResumeLayout(false);
            this.pnlSetorHeader.ResumeLayout(false);
            this.pnlSetorFormCard.ResumeLayout(false);
            this.pnlBoxSetorPetani.ResumeLayout(false);
            this.pnlBoxSetorProduk.ResumeLayout(false);
            this.pnlBoxSetorKualitas.ResumeLayout(false);
            this.pnlBoxSetorBerat.ResumeLayout(false);
            this.pnlBoxSetorBerat.PerformLayout();
            this.pnlBoxSetorTotal.ResumeLayout(false);
            this.pnlSetorTableOuter.ResumeLayout(false);
            this.pnlSetorTableInner.ResumeLayout(false);
            this.pnlSetorTableHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetorPanen)).EndInit();

            this.pnlMuatanBarang.ResumeLayout(false);
            this.pnlMuatanHeader.ResumeLayout(false);
            this.pnlMuatanFilterBar.ResumeLayout(false);
            this.pnlBoxMuatanDari.ResumeLayout(false);
            this.pnlBoxMuatanSampai.ResumeLayout(false);
            this.pnlBoxMuatanStatus.ResumeLayout(false);
            this.pnlMuatanTableOuter.ResumeLayout(false);
            this.pnlMuatanTableInner.ResumeLayout(false);
            this.pnlMuatanTableHeader.ResumeLayout(false);
            this.pnlMuatanSummaryBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuatanBarang)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProdukPanen)).EndInit();
            this.pnlModalOverlay.ResumeLayout(false);
            this.pnlModalCard.ResumeLayout(false);
            this.pnlBoxNama.ResumeLayout(false);
            this.pnlBoxNama.PerformLayout();
            this.pnlBoxDesa.ResumeLayout(false);
            this.pnlBoxDesa.PerformLayout();
            this.pnlBoxNoHp.ResumeLayout(false);
            this.pnlBoxNoHp.PerformLayout();
            this.pnlBoxLuas.ResumeLayout(false);
            this.pnlBoxLuas.PerformLayout();
            this.pnlBoxStatus.ResumeLayout(false);
            this.pnlModalProdukCard.ResumeLayout(false);
            this.pnlBoxProdNama.ResumeLayout(false);
            this.pnlBoxProdNama.PerformLayout();
            this.pnlBoxProdHarga.ResumeLayout(false);
            this.pnlBoxProdHarga.PerformLayout();
            this.pnlBoxProdStatus.ResumeLayout(false);
            this.pnlOtherPage.ResumeLayout(false);
            this.pnlOtherTableOuter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOther)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetupNavButton(System.Windows.Forms.Button btn, string text)
        {
            btn.Dock = System.Windows.Forms.DockStyle.Top;
            btn.Height = 46;
            btn.Text = ""; // Keep empty to prevent WinForms default text overlay glitch!
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btn.ForeColor = System.Drawing.Color.FromArgb(215, 205, 185);
            btn.BackColor = System.Drawing.Color.FromArgb(54, 44, 36);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
        }

        // Fields
        private System.Windows.Forms.Panel pnlSidebar, pnlLogoArea, pnlNavArea;
        private System.Windows.Forms.Label lblLogoMain, lblLogoSub;
        private System.Windows.Forms.Button btnNavDashboard, btnNavPetani, btnNavProdukPanen;
        private System.Windows.Forms.Button btnNavSetorPanen, btnNavMuatanBarang, btnNavLaporan, btnNavManajemenUser;
        private System.Windows.Forms.Panel pnlRight, pnlHeader, pnlHeaderBorder, pnlContent;
        private System.Windows.Forms.Label lblAdminBadge, lblUsername;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Panel pnlToast;
        private System.Windows.Forms.Label lblToastText;
        private System.Windows.Forms.Timer tmrToast;

        // Dashboard
        private System.Windows.Forms.Panel pnlDashboard, pnlCardsContainer;
        private System.Windows.Forms.Label lblDashGreeting, lblDashSubtitle;
        private System.Windows.Forms.Panel pnlStatCard1, pnlStatCard2, pnlStatCard3;
        private System.Windows.Forms.Panel pnlBackupCard;
        private System.Windows.Forms.Label lblBackupTitle, lblBackupSub;
        private System.Windows.Forms.Button btnBackupDatabase;

        // Petani
        private System.Windows.Forms.Panel pnlPetani, pnlPetaniHeader, pnlPetaniTableOuter, pnlPetaniTableInner, pnlPetaniTableHeader;
        private System.Windows.Forms.Label lblPetaniTitle, lblPetaniSubtitle, lblEmptyState;
        private System.Windows.Forms.Button btnTambahPetani;
        private System.Windows.Forms.DataGridView dgvPetani;

        // Produk Panen
        private System.Windows.Forms.Panel pnlProdukPanen, pnlProdukPanenHeader, pnlProdukPanenTableOuter, pnlProdukPanenTableInner, pnlProdukPanenTableHeader;
        private System.Windows.Forms.Label lblProdukPanenTitle, lblProdukPanenSubtitle, lblEmptyProduk;
        private System.Windows.Forms.Button btnTambahProduk;
        private System.Windows.Forms.DataGridView dgvProdukPanen;

        // Modal Petani
        private System.Windows.Forms.Panel pnlModalOverlay, pnlModalCard;
        private System.Windows.Forms.Label lblModalTitle, lblModalSubtitle, lblModalClose;
        private System.Windows.Forms.Label lblFldNama, lblErrNama;
        private System.Windows.Forms.Panel pnlBoxNama;
        private System.Windows.Forms.TextBox txtModalNama;
        private System.Windows.Forms.Label lblFldDesa, lblErrDesa;
        private System.Windows.Forms.Panel pnlBoxDesa;
        private System.Windows.Forms.TextBox txtModalDesa;
        private System.Windows.Forms.Label lblFldNoHp, lblErrNoHp;
        private System.Windows.Forms.Panel pnlBoxNoHp;
        private System.Windows.Forms.TextBox txtModalNoHp;
        private System.Windows.Forms.Label lblFldLuas, lblErrLuas;
        private System.Windows.Forms.Panel pnlBoxLuas;
        private System.Windows.Forms.TextBox txtModalLuas;
        private System.Windows.Forms.Label lblFldStatus;
        private System.Windows.Forms.Panel pnlBoxStatus;
        private System.Windows.Forms.ComboBox cmbModalStatus;
        private System.Windows.Forms.Button btnModalBatal, btnModalSimpan;

        // Modal Produk Panen
        private System.Windows.Forms.Panel pnlModalProdukCard;
        private System.Windows.Forms.Label lblModalProdTitle, lblModalProdSubtitle, lblModalProdClose;
        private System.Windows.Forms.Label lblFldProdNama, lblErrProdNama;
        private System.Windows.Forms.Panel pnlBoxProdNama;
        private System.Windows.Forms.TextBox txtModalProdNama;
        private System.Windows.Forms.Label lblFldProdHarga, lblErrProdHarga, lblHelpProdHarga;
        private System.Windows.Forms.Panel pnlBoxProdHarga;
        private System.Windows.Forms.TextBox txtModalProdHarga;
        private System.Windows.Forms.Label lblFldProdStatus;
        private System.Windows.Forms.Panel pnlBoxProdStatus;
        private System.Windows.Forms.ComboBox cmbModalProdStatus;
        private System.Windows.Forms.Button btnModalProdBatal, btnModalProdSimpan;

        
        // Setor Panen
        private System.Windows.Forms.Panel pnlSetorPanen, pnlSetorHeader, pnlSetorFormCard;
        private System.Windows.Forms.Label lblSetorTitle, lblSetorSubtitle;
        private System.Windows.Forms.Label lblFldSetorPetani, lblFldSetorProduk, lblFldSetorKualitas, lblFldSetorBerat, lblFldSetorTotal;
        private System.Windows.Forms.Panel pnlBoxSetorPetani, pnlBoxSetorProduk, pnlBoxSetorKualitas, pnlBoxSetorBerat, pnlBoxSetorTotal;
        private System.Windows.Forms.ComboBox cmbSetorPetani, cmbSetorProduk, cmbSetorKualitas;
        private System.Windows.Forms.TextBox txtSetorBerat;
        private System.Windows.Forms.Label lblSetorUnitKg, lblSetorTotalValue, lblSetorTotalHelp;
        private System.Windows.Forms.Button btnSetorKosongkan, btnSetorSimpan;
        private System.Windows.Forms.Label lblSetorTableTitle, lblEmptySetor;
        private System.Windows.Forms.Panel pnlSetorTableOuter, pnlSetorTableInner, pnlSetorTableHeader;
        private System.Windows.Forms.DataGridView dgvSetorPanen;

        // Muatan Barang / Laporan
        private System.Windows.Forms.Panel pnlMuatanBarang, pnlMuatanHeader, pnlMuatanFilterBar;
        private System.Windows.Forms.Label lblMuatanTitle, lblMuatanSubtitle;
        private System.Windows.Forms.Label lblFldMuatanDari, lblFldMuatanSampai, lblFldMuatanStatus;
        private System.Windows.Forms.Panel pnlBoxMuatanDari, pnlBoxMuatanSampai, pnlBoxMuatanStatus;
        private System.Windows.Forms.DateTimePicker dtpMuatanDari, dtpMuatanSampai;
        private System.Windows.Forms.ComboBox cmbMuatanStatus;
        private System.Windows.Forms.Panel pnlMuatanTableOuter, pnlMuatanTableInner, pnlMuatanTableHeader;
        private System.Windows.Forms.DataGridView dgvMuatanBarang;
        private System.Windows.Forms.Label lblEmptyMuatan;
        private System.Windows.Forms.Panel pnlMuatanSummaryBar;
        private System.Windows.Forms.Label lblMuatanSummaryJumlah, lblMuatanSummaryBerat, lblMuatanSummaryTotal;
        private System.Windows.Forms.Button btnMuatanEksporCsv;
        private System.Windows.Forms.Label lblMuatanError;
        private System.Windows.Forms.Panel pnlMuatanDipilihBox;
        private System.Windows.Forms.Label lblDipilihHeader;
        private System.Windows.Forms.Label lblDipilihCount;
        private System.Windows.Forms.Label lblDipilihBerat;
        private System.Windows.Forms.Button btnBuatSuratJalan;

        // Other pages
        private System.Windows.Forms.Panel pnlOtherPage, pnlOtherTableOuter, pnlOtherTableInner, pnlOtherTableHeader, pnlOtherHeader;
        private System.Windows.Forms.Label lblOtherTitle, lblOtherSub;
        private System.Windows.Forms.Button btnTambahUser;
        private System.Windows.Forms.DataGridView dgvOther;
        // Modal Pembatalan Transaksi
        private System.Windows.Forms.Panel pnlModalBatalCard, pnlBatalHeader, pnlBatalInfoBox, pnlBoxAlasanBatal;
        private System.Windows.Forms.Label lblModalBatalTitle, lblModalBatalSubtitle, lblModalBatalClose;
        private System.Windows.Forms.Label lblBatalTrxNo, lblBatalTrxTgl, lblBatalPetani, lblBatalDetail, lblBatalTotal;
        private System.Windows.Forms.Label lblFldAlasanBatal;
        private System.Windows.Forms.TextBox txtAlasanBatal;
        private System.Windows.Forms.Button btnBatalKembali, btnBatalKonfirmasi;

        // Modal Tambah/Edit Pengguna
        private System.Windows.Forms.Panel pnlModalUserCard, pnlBoxUserNama, pnlBoxUserUname, pnlBoxUserPeran, pnlBoxUserStatus;
        private System.Windows.Forms.Label lblModalUserTitle, lblModalUserSubtitle, lblModalUserClose;
        private System.Windows.Forms.Label lblFldUserNama, lblFldUserUname, lblFldUserPeran, lblFldUserStatus;
        private System.Windows.Forms.TextBox txtModalUserNama, txtModalUserUname;
        private System.Windows.Forms.ComboBox cmbModalUserPeran, cmbModalUserStatus;
        private System.Windows.Forms.Label lblErrUserNama, lblErrUserUname;
        private System.Windows.Forms.Button btnModalUserBatal, btnModalUserSimpan;
    }
}
