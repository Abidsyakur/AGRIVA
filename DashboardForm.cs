using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AGRIVA
{
    public partial class DashboardForm : Form
    {
        // ══════════════════════════════════════════════════════════
        // PALET WARNA PERSIS FIGMA
        // ══════════════════════════════════════════════════════════
        static readonly Color C_SIDEBAR       = Color.FromArgb(54, 44, 36);
        static readonly Color C_NAV_ACTIVE    = Color.FromArgb(154, 161, 119); // Olive #9AA177
        static readonly Color C_NAV_HOVER     = Color.FromArgb(70, 58, 48);
        static readonly Color C_BG_PAGE       = Color.FromArgb(250, 245, 234);
        static readonly Color C_DARK_BORDER   = Color.FromArgb(54, 44, 36);
        static readonly Color C_HEADER_GREEN  = Color.FromArgb(154, 161, 119); // Olive #9AA177
        static readonly Color C_ICON_BOX      = Color.FromArgb(240, 168, 59);
        static readonly Color C_TEXT_DARK     = Color.FromArgb(54, 44, 36);
        static readonly Color C_TEXT_MUTED    = Color.FromArgb(120, 110, 94);
        static readonly Color C_INPUT_BORDER  = Color.FromArgb(194, 185, 165);
        static readonly Color C_ERR_RED       = Color.FromArgb(224, 82, 82);

        // Status badges
        static readonly Color C_BADGE_AK_BG   = Color.FromArgb(120, 125, 67);  // Olive tua
        static readonly Color C_BADGE_TK_BG   = Color.FromArgb(250, 244, 230); // Krem
        static readonly Color C_BADGE_TK_BD   = Color.FromArgb(120, 125, 67);
        static readonly Color C_BADGE_GD_BG   = Color.FromArgb(235, 178, 85);  // Gold/Orange Di Gudang

        // State Petani
        private int editPetaniId = -1;
        private bool errNama = false;
        private bool errDesa = false;
        private bool errNoHp = false;
        private bool errLuas = false;

        // State Produk Panen
        private int editProdukId = -1;
        private bool errProdNama = false;
        private bool errProdHarga = false;

        // State Setor Panen
        private bool errSetorPetani = false;
        private bool errSetorProduk = false;
        private bool errSetorKualitas = false;
        private bool errSetorBerat = false;
        private double calculatedTotal = 0;
        private double currentHargaKg = 0;
        private double currentPenalti = 0;

        // UI State
        private Button activeNavBtn = null;
        private Button hoveredNavBtn = null;
        private string toastTitle = "Data Berhasil Disimpan";
        private string toastSubtitle = "Data petani berhasil diperbarui";

        // Stats
        private int statPetaniAktif = 8;
        private double statStokKg   = 2580;
        private int statTransaksi   = 0;

        // Dropdown Items Cache
        private class ComboItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public double Penalty { get; set; }
            public override string ToString() => Name;
        }

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            SetupPaints();
            SetupPetaniGrid();
            SetupProdukGrid();
            SetupSetorGrid();
            SetupMuatanGrid();
            SetupUserGrid();
            PopulateSetorDropdowns();
            WireNavigation();
            WireEvents();

            lblLogoMain.Visible = false;
            lblLogoSub.Visible = false;

            // Date picker defaults (Figma sample range)
            dtpMuatanDari.Value = new DateTime(2024, 11, 1);
            dtpMuatanSampai.Value = new DateTime(2026, 12, 31);

            // Dynamic greeting
            int hour = DateTime.Now.Hour;
            string greeting = "Selamat sore";
            if (hour >= 4 && hour < 11) greeting = "Selamat pagi";
            else if (hour >= 11 && hour < 15) greeting = "Selamat siang";
            else if (hour >= 18 || hour < 4) greeting = "Selamat malam";

            lblDashGreeting.Text = greeting + ", Bapak Budi";
            string dateStr = DateTime.Now.ToString("d MMMM yyyy", new CultureInfo("id-ID"));
            lblDashSubtitle.Text = "Ringkasan gudang hari ini - " + dateStr;

            // Default start on Setor Panen or Petani
            SwitchToPage(pnlPetani, btnNavPetani);
            LoadDashboardStats();
            LoadPetaniData();
            LoadProdukData();
            LoadSetorData();
            LoadMuatanData();
            LoadUserData();
        }

        // ══════════════════════════════════════════════════════════
        // VECTOR ICON DRAWING (KRISP & TAJAM ANTI-ALIAS)
        // ══════════════════════════════════════════════════════════
        private void DrawNavIcon(Graphics g, string iconType, RectangleF r, Color col)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float x = r.X, y = r.Y, w = r.Width, h = r.Height;
            using (var pen = new Pen(col, 1.7f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
            using (var br = new SolidBrush(col))
            {
                switch (iconType)
                {
                    case "dashboard":
                        // 4 rounded squares (2x2 grid)
                        float boxSz = (w - 4f) / 2f;
                        g.DrawRectangle(pen, x + 0.5f, y + 0.5f, boxSz, boxSz);
                        g.DrawRectangle(pen, x + boxSz + 3.5f, y + 0.5f, boxSz, boxSz);
                        g.DrawRectangle(pen, x + 0.5f, y + boxSz + 3.5f, boxSz, boxSz);
                        g.DrawRectangle(pen, x + boxSz + 3.5f, y + boxSz + 3.5f, boxSz, boxSz);
                        break;

                    case "petani":
                        // Farmer with conical hat & torso
                        float cx = x + w / 2f;
                        // Conical hat
                        g.DrawLines(pen, new PointF[] {
                            new PointF(x, y + 7),
                            new PointF(cx, y + 1.5f),
                            new PointF(x + w, y + 7)
                        });
                        g.DrawArc(pen, x, y + 5, w, 4, 0, 180);
                        // Head under hat
                        g.DrawArc(pen, cx - 3.5f, y + 6.5f, 7, 7, 0, 180);
                        // Torso / shoulders
                        g.DrawArc(pen, x + 1.5f, y + 11, w - 3f, 9, 180, 180);
                        break;

                    case "produk":
                        // Crisp wheat stalk with grains
                        float stX = x + 3f, stY = y + h - 1.5f;
                        float endX = x + w - 3f, endY = y + 2f;
                        g.DrawLine(pen, stX, stY, endX, endY);
                        // Pairs of wheat grains
                        for (int i = 1; i <= 3; i++)
                        {
                            float t = i * 0.26f;
                            float px = stX + t * (endX - stX);
                            float py = stY + t * (endY - stY);
                            // left grain
                            g.DrawLine(pen, px, py, px - 4.5f, py - 2.5f);
                            // right grain
                            g.DrawLine(pen, px, py, px + 2.5f, py - 4.5f);
                        }
                        // Tip grain
                        g.DrawLine(pen, endX, endY, endX + 1.5f, endY - 2.5f);
                        break;

                    case "setor":
                        // Balanced scale with two pans
                        float topCx = x + w / 2f;
                        g.DrawLine(pen, topCx, y + 2, topCx, y + h - 1);
                        g.DrawLine(pen, topCx - 4, y + h - 1, topCx + 4, y + h - 1);
                        g.DrawLine(pen, x + 1, y + 5, x + w - 1, y + 5);
                        // Left pan strings & dish
                        g.DrawLine(pen, x + 1, y + 5, x + 4.5f, y + 11);
                        g.DrawLine(pen, x + 8, y + 5, x + 4.5f, y + 11);
                        g.DrawArc(pen, x + 1, y + 9.5f, 7, 5, 0, 180);
                        // Right pan strings & dish
                        g.DrawLine(pen, x + w - 8, y + 5, x + w - 4.5f, y + 11);
                        g.DrawLine(pen, x + w - 1, y + 5, x + w - 4.5f, y + 11);
                        g.DrawArc(pen, x + w - 8, y + 9.5f, 7, 5, 0, 180);
                        break;

                    case "muatan":
                        // Crisp cargo truck
                        g.DrawRectangle(pen, x + 1, y + 2.5f, w - 7.5f, h - 8f); // cargo box
                        g.DrawLines(pen, new PointF[] {
                            new PointF(x + w - 6.5f, y + 6),
                            new PointF(x + w - 2.5f, y + 6),
                            new PointF(x + w, y + 9.5f),
                            new PointF(x + w, y + h - 5.5f),
                            new PointF(x + w - 6.5f, y + h - 5.5f)
                        });
                        // Windshield
                        g.DrawLine(pen, x + w - 6.5f, y + 7.5f, x + w - 3.5f, y + 7.5f);
                        // Wheels
                        g.DrawEllipse(pen, x + 3.5f, y + h - 5.5f, 4.5f, 4.5f);
                        g.DrawEllipse(pen, x + w - 5.5f, y + h - 5.5f, 4.5f, 4.5f);
                        break;

                    case "laporan":
                        // Document page with top-right fold and 3 horizontal lines
                        float fold = 4.5f;
                        g.DrawLines(pen, new PointF[] {
                            new PointF(x + w - 2 - fold, y + 1),
                            new PointF(x + 2, y + 1),
                            new PointF(x + 2, y + h - 1),
                            new PointF(x + w - 2, y + h - 1),
                            new PointF(x + w - 2, y + 1 + fold),
                            new PointF(x + w - 2 - fold, y + 1),
                            new PointF(x + w - 2 - fold, y + 1 + fold),
                            new PointF(x + w - 2, y + 1 + fold)
                        });
                        g.DrawLine(pen, x + 5, y + 7, x + w - 6, y + 7);
                        g.DrawLine(pen, x + 5, y + 10, x + w - 6, y + 10);
                        g.DrawLine(pen, x + 5, y + 13, x + w - 8, y + 13);
                        break;

                    case "user":
                        // Two crisp users (front and back)
                        // Back user (right)
                        g.DrawEllipse(pen, x + w - 7, y + 2.5f, 5, 5);
                        g.DrawArc(pen, x + w - 9.5f, y + 8.5f, 8.5f, 7, 210, 130);
                        // Front user (left)
                        g.DrawEllipse(pen, x + 2.5f, y + 4, 6, 6);
                        g.DrawArc(pen, x + 0.5f, y + 10.5f, 10, 8, 180, 180);
                        break;
                }
            }
        }

        private void DrawStatIcon(Graphics g, string type, Rectangle r)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float x = r.X, y = r.Y, w = r.Width, h = r.Height;
            using (var pen = new Pen(Color.White, 1.6f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
            {
                switch (type)
                {
                    case "users":
                        g.DrawEllipse(pen, x + 6, y + 5, 6, 6);
                        g.DrawArc(pen, x + 3, y + 13, 12, 10, 180, 180);
                        g.DrawEllipse(pen, x + 15, y + 7, 5, 5);
                        g.DrawArc(pen, x + 13, y + 14, 10, 8, 200, 130);
                        break;
                    case "box":
                        float cx = x + w / 2f, cy = y + h / 2f;
                        PointF[] topFace = {
                            new PointF(cx, cy - 7),
                            new PointF(cx + 8, cy - 3),
                            new PointF(cx, cy + 1),
                            new PointF(cx - 8, cy - 3)
                        };
                        g.DrawPolygon(pen, topFace);
                        g.DrawLine(pen, cx - 8, cy - 3, cx - 8, cy + 4);
                        g.DrawLine(pen, cx + 8, cy - 3, cx + 8, cy + 4);
                        g.DrawLine(pen, cx, cy + 1, cx, cy + 8);
                        g.DrawLine(pen, cx - 8, cy + 4, cx, cy + 8);
                        g.DrawLine(pen, cx + 8, cy + 4, cx, cy + 8);
                        break;
                    case "money":
                        g.DrawRectangle(pen, x + 4, y + 7, w - 8, h - 14);
                        g.DrawEllipse(pen, x + w / 2f - 3, y + h / 2f - 3, 6, 6);
                        g.DrawLine(pen, x + 6, y + 9, x + 6, y + 10);
                        g.DrawLine(pen, x + w - 7, y + h - 11, x + w - 7, y + h - 10);
                        break;
                }
            }
        }

        private void DrawExitIcon(Graphics g, RectangleF r, Color col)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float x = r.X, y = r.Y, w = r.Width, h = r.Height;
            using (var pen = new Pen(col, 1.5f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
            {
                g.DrawLines(pen, new PointF[] {
                    new PointF(x + w * 0.45f, y + 1),
                    new PointF(x + 1, y + 1),
                    new PointF(x + 1, y + h - 1),
                    new PointF(x + w * 0.45f, y + h - 1)
                });
                float arrowY = y + h / 2f;
                g.DrawLine(pen, x + 4, arrowY, x + w - 2, arrowY);
                g.DrawLine(pen, x + w - 6, arrowY - 4, x + w - 2, arrowY);
                g.DrawLine(pen, x + w - 6, arrowY + 4, x + w - 2, arrowY);
            }
        }

        // ══════════════════════════════════════════════════════════
        // CUSTOM PAINT & NEO-BRUTALIST SHADOWS
        // ══════════════════════════════════════════════════════════
        private string _muatanMode = "muatan";
        private Image _imgLogoSidebar = null;

        private Image GetLogoSidebar()
        {
            if (_imgLogoSidebar != null) return _imgLogoSidebar;
            try
            {
                string p1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo_sidebar_transparent.png");
                if (File.Exists(p1)) { _imgLogoSidebar = Image.FromFile(p1); return _imgLogoSidebar; }
                string p2 = @"D:\AGRIVA\Resources\logo_sidebar_transparent.png";
                if (File.Exists(p2)) { _imgLogoSidebar = Image.FromFile(p2); return _imgLogoSidebar; }
            }
            catch { }
            return null;
        }

        private void SetupPaints()
        {
            // Logo Area
            pnlLogoArea.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                pe.Graphics.Clear(pnlSidebar.BackColor);

                Image logo = GetLogoSidebar();
                if (logo != null)
                {
                    // Render exact Figma extracted logo
                    float targetW = 180f;
                    float targetH = targetW * ((float)logo.Height / logo.Width);
                    float drawX = 24f;
                    float drawY = (pnlLogoArea.Height - targetH) / 2f;
                    pe.Graphics.DrawImage(logo, new RectangleF(drawX, drawY, targetW, targetH));
                }
                else
                {
                    Color cGold = Color.FromArgb(226, 196, 129);
                    using (var penGold = new Pen(cGold, 2.5f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
                    using (var brGold = new SolidBrush(cGold))
                    {
                        pe.Graphics.DrawLines(penGold, new PointF[] {
                            new PointF(26, 52),
                            new PointF(38, 28),
                            new PointF(50, 52)
                        });
                        pe.Graphics.DrawLine(penGold, 31, 44, 45, 44);
                        pe.Graphics.FillEllipse(brGold, 35, 23, 7, 7);
                        pe.Graphics.DrawBezier(penGold, 38, 25, 46, 18, 52, 22, 48, 29);
                    }
                    using (var fnMain = new Font("Segoe UI", 16F, FontStyle.Bold))
                    using (var brMain = new SolidBrush(Color.FromArgb(245, 242, 235)))
                        pe.Graphics.DrawString("AGRIVA", fnMain, brMain, new PointF(58, 28));

                    using (var fnSub = new Font("Segoe UI", 8.5F, FontStyle.Regular))
                    using (var brSub = new SolidBrush(Color.FromArgb(200, 183, 143)))
                        pe.Graphics.DrawString("Koperasi Tani Desa", fnSub, brSub, new PointF(58, 54));
                }
            };

            // Admin Badge
            lblAdminBadge.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, lblAdminBadge.Width - 1, lblAdminBadge.Height - 1);
                using (var path = RoundedPath(rect, 10))
                using (var br = new SolidBrush(Color.FromArgb(226, 196, 129)))
                using (var pen = new Pen(C_DARK_BORDER, 1.2f))
                {
                    pe.Graphics.FillPath(br, path);
                    pe.Graphics.DrawPath(pen, path);
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    using (var tb = new SolidBrush(C_TEXT_DARK))
                        pe.Graphics.DrawString("Admin", lblAdminBadge.Font, tb, rect, sf);
                }
            };

            // Keluar button
            btnKeluar.Text = "";
            btnKeluar.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int bw = btnKeluar.Width;
                int bh = btnKeluar.Height;

                using (var pathShadow = RoundedPath(new Rectangle(2, 2, bw - 3, bh - 3), 8))
                using (var brShadow = new SolidBrush(C_DARK_BORDER))
                    pe.Graphics.FillPath(brShadow, pathShadow);

                var rect = new Rectangle(0, 0, bw - 3, bh - 3);
                using (var path = RoundedPath(rect, 8))
                using (var br = new SolidBrush(Color.FromArgb(250, 245, 234)))
                using (var pen = new Pen(C_DARK_BORDER, 1.2f))
                {
                    pe.Graphics.FillPath(br, path);
                    pe.Graphics.DrawPath(pen, path);
                    DrawExitIcon(pe.Graphics, new RectangleF(14, (bh - 16) / 2f, 16, 16), C_TEXT_DARK);
                    using (var tb = new SolidBrush(C_TEXT_DARK))
                    using (var fn = new Font("Segoe UI", 9.2F, FontStyle.Regular))
                        pe.Graphics.DrawString("Keluar", fn, tb, new PointF(36, (bh - 20) / 2f));
                }
            };

            // Stat Cards (Dashboard)
            pnlStatCard1.Paint += (s, pe) => DrawStatCard(pe.Graphics, pnlStatCard1, "Total Petani Aktif", "users", statPetaniAktif.ToString(), "orang", "Petani terdaftar dan aktif");
            pnlStatCard2.Paint += (s, pe) => DrawStatCard(pe.Graphics, pnlStatCard2, "Stok Gudang (Kg)", "box", statStokKg.ToString("N0", new CultureInfo("id-ID")), "Kg", "Barang siap dikirim");
            pnlStatCard3.Paint += (s, pe) => DrawStatCard(pe.Graphics, pnlStatCard3, "Transaksi Hari Ini", "money", statTransaksi.ToString(), "setoran", "Setoran panen yang masuk");

            // Backup Card
            pnlBackupCard.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int w = pnlBackupCard.Width;
                int h = pnlBackupCard.Height;
                using (var pathShadow = RoundedPath(new Rectangle(4, 4, w - 5, h - 5), 14))
                using (var brShadow = new SolidBrush(C_DARK_BORDER))
                    pe.Graphics.FillPath(brShadow, pathShadow);

                var rect = new Rectangle(0, 0, w - 5, h - 5);
                using (var path = RoundedPath(rect, 14))
                using (var br = new SolidBrush(Color.FromArgb(250, 245, 234)))
                using (var pen = new Pen(C_DARK_BORDER, 1.5f))
                {
                    pe.Graphics.FillPath(br, path);
                    pe.Graphics.DrawPath(pen, path);
                }
            };

            btnBackupDatabase.Paint += (s, pe) => DrawThemedButton(pe.Graphics, btnBackupDatabase, "💾  Backup Database");

            // Buttons: + Tambah Data
            btnTambahPetani.Paint += (s, pe) => DrawAddButton(pe.Graphics, btnTambahPetani);
            btnTambahProduk.Paint += (s, pe) => DrawAddButton(pe.Graphics, btnTambahProduk);

            // Table Containers & Headers (Petani & Produk)
            pnlPetaniTableOuter.Paint += (s, pe) => DrawTableOuter(pe.Graphics, pnlPetaniTableOuter);
            pnlPetaniTableHeader.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int w = pnlPetaniTableHeader.Width;
                int h = pnlPetaniTableHeader.Height;
                using (var br = new SolidBrush(C_HEADER_GREEN)) pe.Graphics.FillRectangle(br, 0, 0, w, h);
                using (var pen = new Pen(C_DARK_BORDER, 1.3f)) pe.Graphics.DrawLine(pen, 0, h - 1, w, h - 1);

                if (dgvPetani.Columns.Contains("colNama") && dgvPetani.Columns.Contains("colDesa"))
                {
                    using (var font = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                    using (var brText = new SolidBrush(C_TEXT_DARK))
                    {
                        var sfLeft = new StringFormat { LineAlignment = StringAlignment.Center };
                        var sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

                        int wNama = dgvPetani.Columns["colNama"].Width;
                        int xDesa = wNama;
                        int wDesa = dgvPetani.Columns["colDesa"].Width;
                        int xNoHp = xDesa + wDesa;
                        int wNoHp = dgvPetani.Columns["colNoHp"].Width;
                        int xLuas = xNoHp + wNoHp;
                        int wLuas = dgvPetani.Columns["colLuas"].Width;
                        int xStatus = xLuas + wLuas;
                        int wStatus = dgvPetani.Columns["colStatus"].Width;
                        int xAksi = xStatus + wStatus;
                        int wAksi = dgvPetani.Columns["colAksi"].Width;

                        pe.Graphics.DrawString("Nama Petani", font, brText, new RectangleF(24, 0, wNama - 24, h), sfLeft);
                        pe.Graphics.DrawString("Desa", font, brText, new RectangleF(xDesa + 16, 0, wDesa - 16, h), sfLeft);
                        pe.Graphics.DrawString("No. HP", font, brText, new RectangleF(xNoHp + 16, 0, wNoHp - 16, h), sfLeft);
                        pe.Graphics.DrawString("Luas Lahan", font, brText, new RectangleF(xLuas + 16, 0, wLuas - 16, h), sfLeft);
                        pe.Graphics.DrawString("Status", font, brText, new RectangleF(xStatus, 0, wStatus, h), sfCenter);
                        pe.Graphics.DrawString("Aksi", font, brText, new RectangleF(xAksi, 0, wAksi, h), sfCenter);
                    }
                }
            };

            pnlProdukPanenTableOuter.Paint += (s, pe) => DrawTableOuter(pe.Graphics, pnlProdukPanenTableOuter);
            pnlProdukPanenTableHeader.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int w = pnlProdukPanenTableHeader.Width;
                int h = pnlProdukPanenTableHeader.Height;
                using (var br = new SolidBrush(C_HEADER_GREEN)) pe.Graphics.FillRectangle(br, 0, 0, w, h);
                using (var pen = new Pen(C_DARK_BORDER, 1.3f)) pe.Graphics.DrawLine(pen, 0, h - 1, w, h - 1);

                if (dgvProdukPanen.Columns.Contains("colProdNama") && dgvProdukPanen.Columns.Contains("colProdHarga"))
                {
                    using (var font = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                    using (var brText = new SolidBrush(C_TEXT_DARK))
                    {
                        var sfLeft = new StringFormat { LineAlignment = StringAlignment.Center };
                        var sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

                        int wNama = dgvProdukPanen.Columns["colProdNama"].Width;
                        int xHarga = wNama;
                        int wHarga = dgvProdukPanen.Columns["colProdHarga"].Width;
                        int xTgl = xHarga + wHarga;
                        int wTgl = dgvProdukPanen.Columns["colProdTanggal"].Width;
                        int xStatus = xTgl + wTgl;
                        int wStatus = dgvProdukPanen.Columns["colProdStatus"].Width;
                        int xAksi = xStatus + wStatus;
                        int wAksi = dgvProdukPanen.Columns["colProdAksi"].Width;

                        pe.Graphics.DrawString("Nama Produk", font, brText, new RectangleF(24, 0, wNama - 24, h), sfLeft);
                        pe.Graphics.DrawString("Harga per Kg", font, brText, new RectangleF(xHarga + 16, 0, wHarga - 16, h), sfLeft);
                        pe.Graphics.DrawString("Tanggal", font, brText, new RectangleF(xTgl + 16, 0, wTgl - 16, h), sfLeft);
                        pe.Graphics.DrawString("Status", font, brText, new RectangleF(xStatus, 0, wStatus, h), sfCenter);
                        pe.Graphics.DrawString("Aksi", font, brText, new RectangleF(xAksi, 0, wAksi, h), sfCenter);
                    }
                }
            };

            // ════════════════════════════════════════════════════════
            // SETOR PANEN PAINTS (Neo-Brutalist Form & Table)
            // ════════════════════════════════════════════════════════
            pnlSetorFormCard.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int w = pnlSetorFormCard.Width;
                int h = pnlSetorFormCard.Height;
                using (var pathShadow = RoundedPath(new Rectangle(4, 4, w - 5, h - 5), 14))
                using (var brShadow = new SolidBrush(C_DARK_BORDER))
                    pe.Graphics.FillPath(brShadow, pathShadow);

                var rect = new Rectangle(0, 0, w - 5, h - 5);
                using (var path = RoundedPath(rect, 14))
                using (var br = new SolidBrush(Color.FromArgb(250, 245, 234)))
                using (var pen = new Pen(C_DARK_BORDER, 1.6f))
                {
                    pe.Graphics.FillPath(br, path);
                    pe.Graphics.DrawPath(pen, path);
                }
            };

            pnlBoxSetorPetani.Paint   += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxSetorPetani, errSetorPetani);
            pnlBoxSetorProduk.Paint   += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxSetorProduk, errSetorProduk);
            pnlBoxSetorKualitas.Paint += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxSetorKualitas, errSetorKualitas);
            pnlBoxSetorBerat.Paint    += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxSetorBerat, errSetorBerat);
            pnlBoxSetorTotal.Paint    += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxSetorTotal, false);

            btnSetorKosongkan.Paint += (s, pe) => DrawModalButton(pe.Graphics, btnSetorKosongkan, "🔄 Kosongkan", Color.White);
            btnSetorSimpan.Paint    += (s, pe) => DrawModalButton(pe.Graphics, btnSetorSimpan, "💾 Simpan Setoran", C_HEADER_GREEN);

            pnlSetorTableOuter.Paint += (s, pe) => DrawTableOuter(pe.Graphics, pnlSetorTableOuter);
            pnlSetorTableHeader.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int w = pnlSetorTableHeader.Width;
                int h = pnlSetorTableHeader.Height;
                using (var br = new SolidBrush(C_HEADER_GREEN)) pe.Graphics.FillRectangle(br, 0, 0, w, h);
                using (var pen = new Pen(C_DARK_BORDER, 1.3f)) pe.Graphics.DrawLine(pen, 0, h - 1, w, h - 1);

                if (dgvSetorPanen.Columns.Contains("colSetorTgl") && dgvSetorPanen.Columns.Contains("colSetorPetani"))
                {
                    using (var font = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                    using (var brText = new SolidBrush(C_TEXT_DARK))
                    {
                        var sfLeft = new StringFormat { LineAlignment = StringAlignment.Center };
                        var sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

                        int wTgl = dgvSetorPanen.Columns["colSetorTgl"].Width;
                        int xPetani = wTgl;
                        int wPetani = dgvSetorPanen.Columns["colSetorPetani"].Width;
                        int xProduk = xPetani + wPetani;
                        int wProduk = dgvSetorPanen.Columns["colSetorProduk"].Width;
                        int xKualitas = xProduk + wProduk;
                        int wKualitas = dgvSetorPanen.Columns["colSetorKualitas"].Width;
                        int xBerat = xKualitas + wKualitas;
                        int wBerat = dgvSetorPanen.Columns["colSetorBerat"].Width;
                        int xPetugas = xBerat + wBerat;
                        int wPetugas = dgvSetorPanen.Columns["colSetorPetugas"].Width;

                        pe.Graphics.DrawString("Tanggal", font, brText, new RectangleF(24, 0, wTgl - 24, h), sfLeft);
                        pe.Graphics.DrawString("Petani", font, brText, new RectangleF(xPetani + 16, 0, wPetani - 16, h), sfLeft);
                        pe.Graphics.DrawString("Produk Panen", font, brText, new RectangleF(xProduk + 16, 0, wProduk - 16, h), sfLeft);
                        pe.Graphics.DrawString("Kualitas", font, brText, new RectangleF(xKualitas, 0, wKualitas, h), sfCenter);
                        pe.Graphics.DrawString("Berat", font, brText, new RectangleF(xBerat + 16, 0, wBerat - 16, h), sfLeft);
                        pe.Graphics.DrawString("Petugas", font, brText, new RectangleF(xPetugas + 16, 0, wPetugas - 16, h), sfLeft);
                    }
                }
            };

            // ════════════════════════════════════════════════════════
            // MUATAN BARANG & LAPORAN PAINTS
            // ════════════════════════════════════════════════════════
            pnlBoxMuatanDari.Paint   += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxMuatanDari, false);
            pnlBoxMuatanSampai.Paint += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxMuatanSampai, false);
            pnlBoxMuatanStatus.Paint += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxMuatanStatus, false);
            btnMuatanEksporCsv.Paint += (s, pe) => DrawModalButton(pe.Graphics, btnMuatanEksporCsv, "⬇ Ekspor CSV", C_HEADER_GREEN);

            pnlMuatanDipilihBox.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int bw = pnlMuatanDipilihBox.Width, bh = pnlMuatanDipilihBox.Height;
                using (var pathShadow = RoundedPath(new Rectangle(3, 3, bw - 4, bh - 4), 10))
                using (var brShadow = new SolidBrush(Color.FromArgb(54, 44, 36)))
                    pe.Graphics.FillPath(brShadow, pathShadow);

                var rect = new Rectangle(0, 0, bw - 4, bh - 4);
                using (var path = RoundedPath(rect, 10))
                using (var br = new SolidBrush(Color.White))
                using (var pen = new Pen(C_DARK_BORDER, 1.4f))
                {
                    pe.Graphics.FillPath(br, path);
                    pe.Graphics.DrawPath(pen, path);
                }
            };
            btnBuatSuratJalan.Paint += (s, pe) => DrawModalButton(pe.Graphics, btnBuatSuratJalan, "🖹 Buat Surat Jalan", C_HEADER_GREEN);
            btnTambahUser.Paint += (s, pe) => DrawModalButton(pe.Graphics, btnTambahUser, "+ Tambah Data", C_HEADER_GREEN);

            pnlMuatanTableOuter.Paint += (s, pe) => DrawTableOuter(pe.Graphics, pnlMuatanTableOuter);
            pnlMuatanTableHeader.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int w = pnlMuatanTableHeader.Width;
                int h = pnlMuatanTableHeader.Height;
                using (var br = new SolidBrush(C_HEADER_GREEN)) pe.Graphics.FillRectangle(br, 0, 0, w, h);
                using (var pen = new Pen(C_DARK_BORDER, 1.3f)) pe.Graphics.DrawLine(pen, 0, h - 1, w, h - 1);

                using (var font = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var brText = new SolidBrush(C_TEXT_DARK))
                {
                    var sfLeft = new StringFormat { LineAlignment = StringAlignment.Center };
                    var sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

                    if (_muatanMode == "muatan" && dgvMuatanBarang.Columns.Contains("colMuatanCheck"))
                    {
                        int wChk = dgvMuatanBarang.Columns["colMuatanCheck"].Width;
                        int xM = wChk, wM = dgvMuatanBarang.Columns["colMuatanKomoditas"].Width;
                        int xP = xM + wM, wP = dgvMuatanBarang.Columns["colMuatanPetani"].Width;
                        int xQ = xP + wP, wQ = dgvMuatanBarang.Columns["colMuatanKualitas"].Width;
                        int xB = xQ + wQ, wB = dgvMuatanBarang.Columns["colMuatanBerat"].Width;
                        int xT = xB + wB, wT = dgvMuatanBarang.Columns["colMuatanTgl"].Width;
                        int xS = xT + wT, wS = dgvMuatanBarang.Columns["colMuatanStatus"].Width;

                        // Checkbox in header
                        var chkR = new Rectangle(16, (h - 16) / 2, 16, 16);
                        using (var penChk = new Pen(C_DARK_BORDER, 1.4f))
                            pe.Graphics.DrawRectangle(penChk, chkR);

                        pe.Graphics.DrawString("Muatan", font, brText, new RectangleF(xM + 16, 0, wM - 16, h), sfLeft);
                        pe.Graphics.DrawString("Petani", font, brText, new RectangleF(xP + 16, 0, wP - 16, h), sfLeft);
                        pe.Graphics.DrawString("Kualitas", font, brText, new RectangleF(xQ, 0, wQ, h), sfCenter);
                        pe.Graphics.DrawString("Berat", font, brText, new RectangleF(xB + 16, 0, wB - 16, h), sfLeft);
                        pe.Graphics.DrawString("Tanggal Masuk", font, brText, new RectangleF(xT + 16, 0, wT - 16, h), sfLeft);
                        pe.Graphics.DrawString("Status", font, brText, new RectangleF(xS, 0, wS, h), sfCenter);
                    }
                    else if (dgvMuatanBarang.Columns.Contains("colMuatanTgl") && dgvMuatanBarang.Columns.Contains("colMuatanPetani"))
                    {
                        int wTgl = dgvMuatanBarang.Columns["colMuatanTgl"].Width;
                        int xPetani = wTgl;
                        int wPetani = dgvMuatanBarang.Columns["colMuatanPetani"].Width;
                        int xMuatan = xPetani + wPetani;
                        int wMuatan = dgvMuatanBarang.Columns["colMuatanKomoditas"].Width;
                        int xBerat = xMuatan + wMuatan;
                        int wBerat = dgvMuatanBarang.Columns["colMuatanBerat"].Width;
                        int xTotal = xBerat + wBerat;
                        int wTotal = dgvMuatanBarang.Columns["colMuatanTotal"].Width;
                        int xStatus = xTotal + wTotal;
                        int wStatus = dgvMuatanBarang.Columns["colMuatanStatus"].Width;
                        int xAksi = xStatus + wStatus;
                        int wAksi = dgvMuatanBarang.Columns["colMuatanAksi"].Width;

                        pe.Graphics.DrawString("Tanggal", font, brText, new RectangleF(24, 0, wTgl - 24, h), sfLeft);
                        pe.Graphics.DrawString("Petani", font, brText, new RectangleF(xPetani + 16, 0, wPetani - 16, h), sfLeft);
                        pe.Graphics.DrawString("Muatan", font, brText, new RectangleF(xMuatan + 16, 0, wMuatan - 16, h), sfLeft);
                        pe.Graphics.DrawString("Berat", font, brText, new RectangleF(xBerat + 16, 0, wBerat - 16, h), sfLeft);
                        pe.Graphics.DrawString("Total", font, brText, new RectangleF(xTotal + 16, 0, wTotal - 16, h), sfLeft);
                        pe.Graphics.DrawString("Status", font, brText, new RectangleF(xStatus, 0, wStatus, h), sfCenter);
                        pe.Graphics.DrawString("Aksi", font, brText, new RectangleF(xAksi, 0, wAksi, h), sfCenter);
                    }
                }
            };

            // Other Table (Manajemen Pengguna)
            pnlOtherTableOuter.Paint += (s, pe) => DrawTableOuter(pe.Graphics, pnlOtherTableOuter);
            pnlOtherTableHeader.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int w = pnlOtherTableHeader.Width;
                int h = pnlOtherTableHeader.Height;
                using (var br = new SolidBrush(C_HEADER_GREEN)) pe.Graphics.FillRectangle(br, 0, 0, w, h);
                using (var pen = new Pen(C_DARK_BORDER, 1.3f)) pe.Graphics.DrawLine(pen, 0, h - 1, w, h - 1);

                using (var font = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var brText = new SolidBrush(C_TEXT_DARK))
                {
                    var sfLeft = new StringFormat { LineAlignment = StringAlignment.Center };
                    var sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

                    if (dgvOther.Columns.Contains("colUserNama"))
                    {
                        int xN = 20, wN = dgvOther.Columns["colUserNama"].Width;
                        int xU = xN + wN, wU = dgvOther.Columns["colUserUname"].Width;
                        int xP = xU + wU, wP = dgvOther.Columns["colUserPeran"].Width;
                        int xS = xP + wP, wS = dgvOther.Columns["colUserStatus"].Width;
                        int xA = xS + wS, wA = dgvOther.Columns["colUserAksi"].Width;

                        pe.Graphics.DrawString("Nama Lengkap", font, brText, new RectangleF(xN, 0, wN - 20, h), sfLeft);
                        pe.Graphics.DrawString("Nama Pengguna", font, brText, new RectangleF(xU + 16, 0, wU - 16, h), sfLeft);
                        pe.Graphics.DrawString("Peran", font, brText, new RectangleF(xP, 0, wP, h), sfCenter);
                        pe.Graphics.DrawString("Status", font, brText, new RectangleF(xS, 0, wS, h), sfCenter);
                        pe.Graphics.DrawString("Aksi", font, brText, new RectangleF(xA, 0, wA, h), sfCenter);
                    }
                }
            };

            // Modals Petani, Produk, Batal, & Pengguna
            pnlModalCard.Paint += (s, pe) => DrawModalCard(pe.Graphics, pnlModalCard);
            pnlModalBatalCard.Paint += (s, pe) => DrawModalCard(pe.Graphics, pnlModalBatalCard);
            pnlBatalInfoBox.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int w = pnlBatalInfoBox.Width, h = pnlBatalInfoBox.Height;
                var rect = new Rectangle(0, 0, w - 1, h - 1);
                using (var path = RoundedPath(rect, 8))
                using (var br = new SolidBrush(Color.White))
                using (var pen = new Pen(C_DARK_BORDER, 1.2f))
                {
                    pe.Graphics.FillPath(br, path);
                    pe.Graphics.DrawPath(pen, path);
                }
            };
            pnlBoxAlasanBatal.Paint += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxAlasanBatal, false);
            btnBatalKembali.Paint += (s, pe) => DrawModalButton(pe.Graphics, btnBatalKembali, "Kembali", Color.White);
            btnBatalKonfirmasi.Paint += (s, pe) => DrawModalButton(pe.Graphics, btnBatalKonfirmasi, "⊘ Ya, Batalkan", Color.FromArgb(242, 184, 75));

            pnlModalUserCard.Paint += (s, pe) => DrawModalCard(pe.Graphics, pnlModalUserCard);
            pnlBoxUserNama.Paint += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxUserNama, lblErrUserNama.Visible);
            pnlBoxUserUname.Paint += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxUserUname, lblErrUserUname.Visible);
            pnlBoxUserPeran.Paint += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxUserPeran, false);
            pnlBoxUserStatus.Paint += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxUserStatus, false);
            btnModalUserBatal.Paint += (s, pe) => DrawModalButton(pe.Graphics, btnModalUserBatal, "Batal", Color.White);
            btnModalUserSimpan.Paint += (s, pe) => DrawModalButton(pe.Graphics, btnModalUserSimpan, "💾 Simpan", C_HEADER_GREEN);
            pnlBoxNama.Paint   += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxNama, errNama);
            pnlBoxDesa.Paint   += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxDesa, errDesa);
            pnlBoxNoHp.Paint   += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxNoHp, errNoHp);
            pnlBoxLuas.Paint   += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxLuas, errLuas);
            pnlBoxStatus.Paint += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxStatus, false);
            btnModalSimpan.Paint += (s, pe) => DrawModalButton(pe.Graphics, btnModalSimpan, "💾 Simpan", C_HEADER_GREEN);
            btnModalBatal.Paint  += (s, pe) => DrawModalButton(pe.Graphics, btnModalBatal, "Batal", Color.White);

            pnlModalProdukCard.Paint += (s, pe) => DrawModalCard(pe.Graphics, pnlModalProdukCard);
            pnlBoxProdNama.Paint   += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxProdNama, errProdNama);
            pnlBoxProdHarga.Paint  += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxProdHarga, errProdHarga);
            pnlBoxProdStatus.Paint += (s, pe) => DrawInputBox(pe.Graphics, pnlBoxProdStatus, false);
            btnModalProdSimpan.Paint += (s, pe) => DrawModalButton(pe.Graphics, btnModalProdSimpan, "💾 Simpan", C_HEADER_GREEN);
            btnModalProdBatal.Paint  += (s, pe) => DrawModalButton(pe.Graphics, btnModalProdBatal, "Batal", Color.White);

            // Toast
            pnlToast.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int w = pnlToast.Width;
                int h = pnlToast.Height;

                using (var pathShadow = RoundedPath(new Rectangle(3, 3, w - 4, h - 4), 10))
                using (var brShadow = new SolidBrush(Color.FromArgb(170, 210, 180)))
                    pe.Graphics.FillPath(brShadow, pathShadow);

                var rect = new Rectangle(0, 0, w - 4, h - 4);
                using (var path = RoundedPath(rect, 10))
                using (var br = new SolidBrush(Color.FromArgb(235, 247, 238)))
                using (var pen = new Pen(Color.FromArgb(82, 183, 122), 1.3f))
                {
                    pe.Graphics.FillPath(br, path);
                    pe.Graphics.DrawPath(pen, path);

                    var circleRect = new Rectangle(14, (rect.Height - 26) / 2, 26, 26);
                    using (var circleBr = new SolidBrush(Color.FromArgb(76, 175, 80)))
                        pe.Graphics.FillEllipse(circleBr, circleRect);

                    using (var chkPen = new Pen(Color.White, 2.2f))
                    {
                        chkPen.StartCap = LineCap.Round;
                        chkPen.EndCap = LineCap.Round;
                        pe.Graphics.DrawLines(chkPen, new PointF[] {
                            new PointF(circleRect.X + 7, circleRect.Y + 13),
                            new PointF(circleRect.X + 11, circleRect.Y + 17),
                            new PointF(circleRect.X + 18, circleRect.Y + 9)
                        });
                    }

                    using (var tFn = new Font("Segoe UI", 9.2F, FontStyle.Bold))
                    using (var tBr = new SolidBrush(Color.FromArgb(45, 106, 79)))
                        pe.Graphics.DrawString(toastTitle, tFn, tBr, new PointF(48, 10));

                    using (var sFn = new Font("Segoe UI", 7.8F, FontStyle.Regular))
                    using (var sBr = new SolidBrush(Color.FromArgb(64, 145, 108)))
                        pe.Graphics.DrawString(toastSubtitle, sFn, sBr, new PointF(48, 30));
                }
            };

            // Resize handling
            pnlContent.Resize += (s, e) => LayoutAll();
            pnlCardsContainer.Resize += (s, e) => LayoutAll();
            pnlPetani.Resize += (s, e) => LayoutAll();
            pnlProdukPanen.Resize += (s, e) => LayoutAll();
            pnlSetorPanen.Resize += (s, e) => LayoutAll();
            pnlMuatanBarang.Resize += (s, e) => LayoutAll();
            this.Resize += (s, e) => LayoutAll();
            LayoutAll();
        }

        private void DrawTableOuter(Graphics g, Panel pnl)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = pnl.Width;
            int h = pnl.Height;

            using (var pathShadow = RoundedPath(new Rectangle(4, 4, w - 5, h - 5), 14))
            using (var brShadow = new SolidBrush(C_DARK_BORDER))
                g.FillPath(brShadow, pathShadow);

            using (var pathCard = RoundedPath(new Rectangle(0, 0, w - 5, h - 5), 14))
            using (var penCard = new Pen(C_DARK_BORDER, 1.8f))
                g.DrawPath(penCard, pathCard);
        }

        private void DrawModalCard(Graphics g, Panel card)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = card.Width;
            int h = card.Height;

            using (var pathShadow = RoundedPath(new Rectangle(5, 5, w - 6, h - 6), 16))
            using (var brShadow = new SolidBrush(C_DARK_BORDER))
                g.FillPath(brShadow, pathShadow);

            var rect = new Rectangle(0, 0, w - 6, h - 6);
            using (var path = RoundedPath(rect, 16))
            using (var br = new SolidBrush(Color.FromArgb(250, 245, 234)))
            using (var pen = new Pen(C_DARK_BORDER, 1.6f))
            {
                g.FillPath(br, path);
                g.DrawPath(pen, path);
            }
        }

        private void DrawAddButton(Graphics g, Button btn)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int bw = btn.Width;
            int bh = btn.Height;

            using (var pathShadow = RoundedPath(new Rectangle(3, 3, bw - 4, bh - 4), 9))
            using (var brShadow = new SolidBrush(C_DARK_BORDER))
                g.FillPath(brShadow, pathShadow);

            using (var pathBtn = RoundedPath(new Rectangle(0, 0, bw - 4, bh - 4), 9))
            using (var brBtn = new SolidBrush(C_HEADER_GREEN))
            using (var penBtn = new Pen(C_DARK_BORDER, 1.5f))
            {
                g.FillPath(brBtn, pathBtn);
                g.DrawPath(penBtn, pathBtn);

                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                using (var tb = new SolidBrush(C_TEXT_DARK))
                using (var fn = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                    g.DrawString("+ Tambah Data", fn, tb, new Rectangle(0, 0, bw - 4, bh - 4), sf);
            }
        }

        private void DrawModalButton(Graphics g, Button btn, string text, Color bg)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int bw = btn.Width;
            int bh = btn.Height;

            using (var pathShadow = RoundedPath(new Rectangle(2, 2, bw - 3, bh - 3), 8))
            using (var brShadow = new SolidBrush(C_DARK_BORDER))
                g.FillPath(brShadow, pathShadow);

            using (var pathBtn = RoundedPath(new Rectangle(0, 0, bw - 3, bh - 3), 8))
            using (var brBtn = new SolidBrush(bg))
            using (var penBtn = new Pen(C_DARK_BORDER, 1.3f))
            {
                g.FillPath(brBtn, pathBtn);
                g.DrawPath(penBtn, pathBtn);

                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                using (var tb = new SolidBrush(C_TEXT_DARK))
                using (var fn = new Font("Segoe UI", 9.2F, FontStyle.Bold))
                    g.DrawString(text, fn, tb, new Rectangle(0, 0, bw - 3, bh - 3), sf);
            }
        }

        private void LayoutAll()
        {
            // Cards layout
            int spacing = 18;
            int totalW = pnlCardsContainer.Width - 10;
            int cardW = Math.Max(220, (totalW - (spacing * 2)) / 3);

            pnlStatCard1.Location = new Point(0, 10);
            pnlStatCard1.Size = new Size(cardW, 160);

            pnlStatCard2.Location = new Point(cardW + spacing, 10);
            pnlStatCard2.Size = new Size(cardW, 160);

            pnlStatCard3.Location = new Point((cardW * 2) + (spacing * 2), 10);
            pnlStatCard3.Size = new Size(cardW, 160);

            btnBackupDatabase.Location = new Point(pnlBackupCard.Width - btnBackupDatabase.Width - 24, 24);

            btnKeluar.Location = new Point(pnlHeader.Width - btnKeluar.Width - 36, 18);
            lblUsername.Location = new Point(btnKeluar.Left - lblUsername.Width - 18, 25);
            lblAdminBadge.Location = new Point(lblUsername.Left - lblAdminBadge.Width - 12, 23);

            // Petani Header & Table
            btnTambahPetani.Location = new Point(pnlPetaniHeader.Width - btnTambahPetani.Width - 10, 18);
            pnlPetaniTableOuter.Location = new Point(0, 88);
            pnlPetaniTableOuter.Width = pnlPetani.Width - 20;

            if (dgvPetani.Columns.Contains("colNama") && dgvPetani.Columns.Contains("colDesa"))
            {
                int innerW = pnlPetaniTableOuter.Width - 5;
                int fixedCols = 170 + 130 + 120 + 70;
                int avail = Math.Max(370, innerW - fixedCols);
                dgvPetani.Columns["colNama"].Width = (int)(avail * 0.58);
                dgvPetani.Columns["colDesa"].Width = avail - dgvPetani.Columns["colNama"].Width;
                dgvPetani.Columns["colNoHp"].Width = 170;
                dgvPetani.Columns["colLuas"].Width = 130;
                dgvPetani.Columns["colStatus"].Width = 120;
                dgvPetani.Columns["colAksi"].Width = 70;
            }

            pnlPetaniTableInner.Size = new Size(pnlPetaniTableOuter.Width - 4, pnlPetaniTableOuter.Height - 4);
            using (var path = RoundedPath(new Rectangle(0, 0, pnlPetaniTableInner.Width, pnlPetaniTableInner.Height), 14))
                pnlPetaniTableInner.Region = new Region(path);

            pnlPetaniTableOuter.Invalidate();
            pnlPetaniTableHeader.Invalidate();

            // Produk Panen
            btnTambahProduk.Location = new Point(pnlProdukPanenHeader.Width - btnTambahProduk.Width - 10, 18);
            pnlProdukPanenTableOuter.Location = new Point(0, 88);
            pnlProdukPanenTableOuter.Width = pnlProdukPanen.Width - 20;

            if (dgvProdukPanen.Columns.Contains("colProdNama") && dgvProdukPanen.Columns.Contains("colProdHarga"))
            {
                int innerW = pnlProdukPanenTableOuter.Width - 5;
                int fixedCols = 160 + 180 + 120 + 70;
                int avail = Math.Max(260, innerW - fixedCols);
                dgvProdukPanen.Columns["colProdNama"].Width = avail;
                dgvProdukPanen.Columns["colProdHarga"].Width = 160;
                dgvProdukPanen.Columns["colProdTanggal"].Width = 180;
                dgvProdukPanen.Columns["colProdStatus"].Width = 120;
                dgvProdukPanen.Columns["colProdAksi"].Width = 70;
            }

            pnlProdukPanenTableInner.Size = new Size(pnlProdukPanenTableOuter.Width - 4, pnlProdukPanenTableOuter.Height - 4);
            using (var path = RoundedPath(new Rectangle(0, 0, pnlProdukPanenTableInner.Width, pnlProdukPanenTableInner.Height), 14))
                pnlProdukPanenTableInner.Region = new Region(path);

            pnlProdukPanenTableOuter.Invalidate();
            pnlProdukPanenTableHeader.Invalidate();

            // ════════════════════════════════════════════════════════
            // SETOR PANEN LAYOUT
            // ════════════════════════════════════════════════════════
            pnlSetorFormCard.Width = pnlSetorPanen.Width - 20;
            int cardWSetor = pnlSetorFormCard.Width;
            int halfInputW = (cardWSetor - 68) / 2;

            pnlBoxSetorPetani.Width = halfInputW;
            cmbSetorPetani.Width = halfInputW - 16;

            pnlBoxSetorProduk.Left = 24 + halfInputW + 20;
            pnlBoxSetorProduk.Width = halfInputW;
            cmbSetorProduk.Width = halfInputW - 16;
            lblFldSetorProduk.Left = pnlBoxSetorProduk.Left;

            pnlBoxSetorKualitas.Width = halfInputW;
            cmbSetorKualitas.Width = halfInputW - 16;

            pnlBoxSetorBerat.Left = 24 + halfInputW + 20;
            pnlBoxSetorBerat.Width = halfInputW;
            txtSetorBerat.Width = halfInputW - 48;
            lblSetorUnitKg.Left = halfInputW - 38;
            lblFldSetorBerat.Left = pnlBoxSetorBerat.Left;

            pnlBoxSetorTotal.Width = cardWSetor - 48;
            lblSetorTotalValue.Width = pnlBoxSetorTotal.Width - 24;

            btnSetorSimpan.Left = cardWSetor - btnSetorSimpan.Width - 24;
            btnSetorKosongkan.Left = btnSetorSimpan.Left - btnSetorKosongkan.Width - 12;

            pnlSetorTableOuter.Width = pnlSetorPanen.Width - 20;
            if (dgvSetorPanen.Columns.Contains("colSetorTgl") && dgvSetorPanen.Columns.Contains("colSetorPetani"))
            {
                int innerW = pnlSetorTableOuter.Width - 5;
                int fixedCols = 110 + 95 + 95 + 130; // 430
                int avail = Math.Max(260, innerW - fixedCols);
                dgvSetorPanen.Columns["colSetorTgl"].Width = 110;
                dgvSetorPanen.Columns["colSetorPetani"].Width = (int)(avail * 0.52);
                dgvSetorPanen.Columns["colSetorProduk"].Width = avail - dgvSetorPanen.Columns["colSetorPetani"].Width;
                dgvSetorPanen.Columns["colSetorKualitas"].Width = 95;
                dgvSetorPanen.Columns["colSetorBerat"].Width = 95;
                dgvSetorPanen.Columns["colSetorPetugas"].Width = 130;
            }

            pnlSetorTableInner.Size = new Size(pnlSetorTableOuter.Width - 4, pnlSetorTableOuter.Height - 4);
            using (var path = RoundedPath(new Rectangle(0, 0, pnlSetorTableInner.Width, pnlSetorTableInner.Height), 14))
                pnlSetorTableInner.Region = new Region(path);

            pnlSetorTableOuter.Invalidate();
            pnlSetorTableHeader.Invalidate();

            // ════════════════════════════════════════════════════════
            // MUATAN BARANG LAYOUT
            // ════════════════════════════════════════════════════════
            pnlMuatanTableOuter.Width = pnlMuatanBarang.Width - 20;

            if (_muatanMode == "muatan")
            {
                pnlMuatanFilterBar.Visible = false;
                pnlMuatanSummaryBar.Visible = false;
                pnlMuatanDipilihBox.Visible = true;
                pnlMuatanTableOuter.Location = new Point(0, 80);

                if (dgvMuatanBarang.Columns.Contains("colMuatanCheck") && dgvMuatanBarang.Columns.Contains("colMuatanPetani"))
                {
                    int innerW = pnlMuatanTableOuter.Width - 5;
                    int fixedCols = 50 + 90 + 90 + 160 + 120; // 510
                    int avail = Math.Max(240, innerW - fixedCols);
                    dgvMuatanBarang.Columns["colMuatanCheck"].Width = 50;
                    dgvMuatanBarang.Columns["colMuatanKomoditas"].Width = (int)(avail * 0.45);
                    dgvMuatanBarang.Columns["colMuatanPetani"].Width = avail - dgvMuatanBarang.Columns["colMuatanKomoditas"].Width;
                    dgvMuatanBarang.Columns["colMuatanKualitas"].Width = 90;
                    dgvMuatanBarang.Columns["colMuatanBerat"].Width = 90;
                    dgvMuatanBarang.Columns["colMuatanTgl"].Width = 160;
                    dgvMuatanBarang.Columns["colMuatanStatus"].Width = 120;
                }

                lblMuatanError.Location = new Point(0, pnlMuatanTableOuter.Bottom + 12);
                pnlMuatanDipilihBox.Location = new Point(pnlMuatanBarang.Width - pnlMuatanDipilihBox.Width - 20, pnlMuatanTableOuter.Bottom + 12);
            }
            else
            {
                pnlMuatanFilterBar.Visible = true;
                pnlMuatanSummaryBar.Visible = true;
                pnlMuatanDipilihBox.Visible = false;
                lblMuatanError.Visible = false;

                pnlMuatanFilterBar.Width = pnlMuatanBarang.Width - 20;
                pnlMuatanSummaryBar.Width = pnlMuatanBarang.Width - 20;
                btnMuatanEksporCsv.Left = pnlMuatanSummaryBar.Width - btnMuatanEksporCsv.Width - 10;
                pnlMuatanTableOuter.Location = new Point(0, 145);

                if (dgvMuatanBarang.Columns.Contains("colMuatanTgl") && dgvMuatanBarang.Columns.Contains("colMuatanPetani"))
                {
                    int innerW = pnlMuatanTableOuter.Width - 5;
                    int fixedCols = 110 + 90 + 130 + 120 + 100; // 550
                    int avail = Math.Max(250, innerW - fixedCols);
                    dgvMuatanBarang.Columns["colMuatanTgl"].Width = 110;
                    dgvMuatanBarang.Columns["colMuatanPetani"].Width = (int)(avail * 0.54);
                    dgvMuatanBarang.Columns["colMuatanKomoditas"].Width = avail - dgvMuatanBarang.Columns["colMuatanPetani"].Width;
                    dgvMuatanBarang.Columns["colMuatanBerat"].Width = 90;
                    dgvMuatanBarang.Columns["colMuatanTotal"].Width = 130;
                    dgvMuatanBarang.Columns["colMuatanStatus"].Width = 120;
                    dgvMuatanBarang.Columns["colMuatanAksi"].Width = 100;
                }

                pnlMuatanSummaryBar.Location = new Point(0, pnlMuatanTableOuter.Bottom + 12);
            }

            pnlMuatanTableInner.Size = new Size(pnlMuatanTableOuter.Width - 4, pnlMuatanTableOuter.Height - 4);
            using (var path = RoundedPath(new Rectangle(0, 0, pnlMuatanTableInner.Width, pnlMuatanTableInner.Height), 14))
                pnlMuatanTableInner.Region = new Region(path);

            pnlMuatanTableOuter.Invalidate();
            pnlMuatanTableHeader.Invalidate();

            // Other Page Layout (Manajemen Pengguna)
            pnlOtherHeader.Width = pnlOtherPage.Width - 20;
            btnTambahUser.Left = pnlOtherHeader.Width - btnTambahUser.Width - 10;
            pnlOtherTableOuter.Location = new Point(0, 80);
            pnlOtherTableOuter.Width = pnlOtherPage.Width - 20;
            if (dgvOther.Columns.Contains("colUserNama"))
            {
                int innerW = pnlOtherTableOuter.Width - 5;
                int fixedCols = 160 + 130 + 80; // 370
                int avail = Math.Max(260, innerW - fixedCols);
                dgvOther.Columns["colUserNama"].Width = (int)(avail * 0.55);
                dgvOther.Columns["colUserUname"].Width = avail - dgvOther.Columns["colUserNama"].Width;
                dgvOther.Columns["colUserPeran"].Width = 160;
                dgvOther.Columns["colUserStatus"].Width = 130;
                dgvOther.Columns["colUserAksi"].Width = 80;
            }

            pnlOtherTableInner.Size = new Size(pnlOtherTableOuter.Width - 4, pnlOtherTableOuter.Height - 4);
            using (var path = RoundedPath(new Rectangle(0, 0, pnlOtherTableInner.Width, pnlOtherTableInner.Height), 14))
                pnlOtherTableInner.Region = new Region(path);

            pnlOtherTableOuter.Invalidate();
            pnlOtherTableHeader.Invalidate();

            // Toast
            pnlToast.Location = new Point(pnlContent.Width - pnlToast.Width - 24, pnlContent.Height - pnlToast.Height - 20);

            // Modals
            pnlModalCard.Location = new Point((pnlModalOverlay.Width - pnlModalCard.Width) / 2, Math.Max(20, (pnlModalOverlay.Height - pnlModalCard.Height) / 2));
            pnlModalProdukCard.Location = new Point((pnlModalOverlay.Width - pnlModalProdukCard.Width) / 2, Math.Max(30, (pnlModalOverlay.Height - pnlModalProdukCard.Height) / 2));
            pnlModalBatalCard.Location = new Point((pnlModalOverlay.Width - pnlModalBatalCard.Width) / 2, Math.Max(20, (pnlModalOverlay.Height - pnlModalBatalCard.Height) / 2));
            pnlModalUserCard.Location = new Point((pnlModalOverlay.Width - pnlModalUserCard.Width) / 2, Math.Max(20, (pnlModalOverlay.Height - pnlModalUserCard.Height) / 2));
        }

        private void DrawStatCard(Graphics g, Panel card, string title, string iconType, string val, string unit, string sub)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = card.Width - 2;
            int h = card.Height - 2;
            var fullRect = new Rectangle(1, 1, w, h);

            using (var path = RoundedPath(fullRect, 14))
            using (var br = new SolidBrush(Color.White))
            using (var pen = new Pen(C_DARK_BORDER, 1.5f))
            {
                g.FillPath(br, path);

                int headerH = 42;
                using (var topPath = RoundedTopPath(new Rectangle(1, 1, w, headerH), 14))
                using (var hbr = new SolidBrush(C_HEADER_GREEN))
                    g.FillPath(hbr, topPath);

                using (var tf = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var tb = new SolidBrush(C_TEXT_DARK))
                    g.DrawString(title, tf, tb, new PointF(16, 12));

                int boxSize = 28;
                var iconRect = new Rectangle(w - boxSize - 12, (headerH - boxSize) / 2 + 1, boxSize, boxSize);
                using (var ipath = RoundedPath(iconRect, 6))
                using (var ibr = new SolidBrush(C_ICON_BOX))
                {
                    g.FillPath(ibr, ipath);
                    DrawStatIcon(g, iconType, iconRect);
                }

                using (var divPen = new Pen(C_DARK_BORDER, 1f))
                    g.DrawLine(divPen, 1, headerH + 1, w + 1, headerH + 1);

                using (var valFont = new Font("Segoe UI", 26F, FontStyle.Bold))
                using (var valBr = new SolidBrush(C_TEXT_DARK))
                {
                    g.DrawString(val, valFont, valBr, new PointF(16, 52));
                    var sz = g.MeasureString(val, valFont);

                    using (var unitFont = new Font("Segoe UI", 11F))
                    using (var unitBr = new SolidBrush(C_TEXT_DARK))
                        g.DrawString(unit, unitFont, unitBr, new PointF(18 + sz.Width, 68));
                }

                using (var subFont = new Font("Segoe UI", 8.5F))
                using (var subBr = new SolidBrush(C_TEXT_MUTED))
                    g.DrawString(sub, subFont, subBr, new PointF(16, 118));

                g.DrawPath(pen, path);
            }
        }

        private void DrawThemedButton(Graphics g, Button btn, string text)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
            using (var path = RoundedPath(rect, 8))
            using (var br = new SolidBrush(C_NAV_ACTIVE))
            using (var pen = new Pen(C_DARK_BORDER, 1.2f))
            {
                g.FillPath(br, path);
                g.DrawPath(pen, path);
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                using (var tb = new SolidBrush(C_TEXT_DARK))
                    g.DrawString(text, btn.Font, tb, rect, sf);
            }
        }

        private void DrawInputBox(Graphics g, Panel pnl, bool hasError)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            using (var path = RoundedPath(rect, 6))
            using (var br = new SolidBrush(Color.White))
            using (var pen = new Pen(hasError ? C_ERR_RED : C_INPUT_BORDER, hasError ? 1.4f : 1.1f))
            {
                g.FillPath(br, path);
                g.DrawPath(pen, path);
            }
        }

        // ══════════════════════════════════════════════════════════
        // PETANI & PRODUK PANEN GRIDS
        // ══════════════════════════════════════════════════════════
        private void SetupPetaniGrid()
        {
            dgvPetani.Columns.Clear();
            dgvPetani.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", HeaderText = "ID", Visible = false });
            dgvPetani.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNama", HeaderText = "Nama Petani", Width = 230 });
            dgvPetani.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDesa", HeaderText = "Desa", Width = 150 });
            dgvPetani.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNoHp", HeaderText = "No. HP", Width = 170 });
            dgvPetani.Columns.Add(new DataGridViewTextBoxColumn { Name = "colLuas", HeaderText = "Luas Lahan", Width = 130 });
            dgvPetani.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Status", Width = 120 });
            dgvPetani.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAksi", HeaderText = "Aksi", Width = 70 });

            dgvPetani.CellPainting += DgvPetani_CellPainting;
            dgvPetani.CellClick += DgvPetani_CellClick;
            dgvPetani.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dgvPetani.Columns["colAksi"].Index)
                    dgvPetani.Cursor = Cursors.Hand;
                else
                    dgvPetani.Cursor = Cursors.Default;
            };
        }

        private void DgvPetani_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Color rowBg = (e.RowIndex % 2 == 0) ? Color.FromArgb(250, 244, 230) : Color.White;
            if ((e.State & DataGridViewElementStates.Selected) != 0) rowBg = Color.FromArgb(242, 237, 224);

            using (var brBg = new SolidBrush(rowBg)) e.Graphics.FillRectangle(brBg, e.CellBounds);
            using (var penLine = new Pen(Color.FromArgb(238, 232, 220), 1f))
                e.Graphics.DrawLine(penLine, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);

            string val = e.Value?.ToString() ?? "";
            if (e.ColumnIndex == dgvPetani.Columns["colNama"].Index)
            {
                using (var bfn = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var tb = new SolidBrush(C_TEXT_DARK))
                    e.Graphics.DrawString(val, bfn, tb, new Rectangle(e.CellBounds.X + 24, e.CellBounds.Y, e.CellBounds.Width - 24, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (e.ColumnIndex == dgvPetani.Columns["colDesa"].Index ||
                     e.ColumnIndex == dgvPetani.Columns["colNoHp"].Index ||
                     e.ColumnIndex == dgvPetani.Columns["colLuas"].Index)
            {
                using (var rfn = new Font("Segoe UI", 9.5F, FontStyle.Regular))
                using (var tb = new SolidBrush(C_TEXT_DARK))
                    e.Graphics.DrawString(val, rfn, tb, new Rectangle(e.CellBounds.X + 16, e.CellBounds.Y, e.CellBounds.Width - 16, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (e.ColumnIndex == dgvPetani.Columns["colStatus"].Index)
            {
                DrawStatusBadge(e.Graphics, e.CellBounds, val == "Aktif", "Aktif", "Tidak Aktif");
            }
            else if (e.ColumnIndex == dgvPetani.Columns["colAksi"].Index)
            {
                DrawPencilAction(e.Graphics, e.CellBounds);
            }
            e.Handled = true;
        }

        private void DgvPetani_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvPetani.Columns["colAksi"].Index)
                OpenModalEdit(dgvPetani.Rows[e.RowIndex]);
        }

        private void SetupProdukGrid()
        {
            dgvProdukPanen.Columns.Clear();
            dgvProdukPanen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colProdId", HeaderText = "ID", Visible = false });
            dgvProdukPanen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colProdNama", HeaderText = "Nama Produk", Width = 230 });
            dgvProdukPanen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colProdHarga", HeaderText = "Harga per Kg", Width = 160 });
            dgvProdukPanen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colProdTanggal", HeaderText = "Tanggal", Width = 180 });
            dgvProdukPanen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colProdStatus", HeaderText = "Status", Width = 120 });
            dgvProdukPanen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colProdAksi", HeaderText = "Aksi", Width = 70 });

            dgvProdukPanen.CellPainting += DgvProduk_CellPainting;
            dgvProdukPanen.CellClick += DgvProduk_CellClick;
            dgvProdukPanen.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dgvProdukPanen.Columns["colProdAksi"].Index)
                    dgvProdukPanen.Cursor = Cursors.Hand;
                else
                    dgvProdukPanen.Cursor = Cursors.Default;
            };
        }

        private void DgvProduk_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Color rowBg = (e.RowIndex % 2 == 0) ? Color.FromArgb(250, 244, 230) : Color.White;
            if ((e.State & DataGridViewElementStates.Selected) != 0) rowBg = Color.FromArgb(242, 237, 224);

            using (var brBg = new SolidBrush(rowBg)) e.Graphics.FillRectangle(brBg, e.CellBounds);
            using (var penLine = new Pen(Color.FromArgb(238, 232, 220), 1f))
                e.Graphics.DrawLine(penLine, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);

            string val = e.Value?.ToString() ?? "";
            if (e.ColumnIndex == dgvProdukPanen.Columns["colProdNama"].Index)
            {
                using (var bfn = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var tb = new SolidBrush(C_TEXT_DARK))
                    e.Graphics.DrawString(val, bfn, tb, new Rectangle(e.CellBounds.X + 24, e.CellBounds.Y, e.CellBounds.Width - 24, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (e.ColumnIndex == dgvProdukPanen.Columns["colProdHarga"].Index ||
                     e.ColumnIndex == dgvProdukPanen.Columns["colProdTanggal"].Index)
            {
                using (var rfn = new Font("Segoe UI", 9.5F, FontStyle.Regular))
                using (var tb = new SolidBrush(C_TEXT_DARK))
                    e.Graphics.DrawString(val, rfn, tb, new Rectangle(e.CellBounds.X + 16, e.CellBounds.Y, e.CellBounds.Width - 16, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (e.ColumnIndex == dgvProdukPanen.Columns["colProdStatus"].Index)
            {
                DrawStatusBadge(e.Graphics, e.CellBounds, val == "Aktif", "Aktif", "Tidak Aktif");
            }
            else if (e.ColumnIndex == dgvProdukPanen.Columns["colProdAksi"].Index)
            {
                DrawPencilAction(e.Graphics, e.CellBounds);
            }
            e.Handled = true;
        }

        private void DgvProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvProdukPanen.Columns["colProdAksi"].Index)
                OpenModalEditProduk(dgvProdukPanen.Rows[e.RowIndex]);
        }

        // ══════════════════════════════════════════════════════════
        // SETOR PANEN GRID & REALTIME FORM
        // ══════════════════════════════════════════════════════════
        private void SetupSetorGrid()
        {
            dgvSetorPanen.Columns.Clear();
            dgvSetorPanen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSetorTgl", HeaderText = "Tanggal", Width = 110 });
            dgvSetorPanen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSetorPetani", HeaderText = "Petani", Width = 180 });
            dgvSetorPanen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSetorProduk", HeaderText = "Produk Panen", Width = 150 });
            dgvSetorPanen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSetorKualitas", HeaderText = "Kualitas", Width = 95 });
            dgvSetorPanen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSetorBerat", HeaderText = "Berat", Width = 95 });
            dgvSetorPanen.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSetorPetugas", HeaderText = "Petugas", Width = 130 });

            dgvSetorPanen.CellPainting += DgvSetor_CellPainting;
        }

        private void DgvSetor_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Color rowBg = (e.RowIndex % 2 == 0) ? Color.FromArgb(250, 244, 230) : Color.White;
            if ((e.State & DataGridViewElementStates.Selected) != 0) rowBg = Color.FromArgb(242, 237, 224);

            using (var brBg = new SolidBrush(rowBg)) e.Graphics.FillRectangle(brBg, e.CellBounds);
            using (var penLine = new Pen(Color.FromArgb(238, 232, 220), 1f))
                e.Graphics.DrawLine(penLine, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);

            string val = e.Value?.ToString() ?? "";

            if (e.ColumnIndex == dgvSetorPanen.Columns["colSetorTgl"].Index)
            {
                using (var rfn = new Font("Segoe UI", 9F, FontStyle.Regular))
                using (var tb = new SolidBrush(C_TEXT_MUTED))
                    e.Graphics.DrawString(val, rfn, tb, new Rectangle(e.CellBounds.X + 24, e.CellBounds.Y, e.CellBounds.Width - 24, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (e.ColumnIndex == dgvSetorPanen.Columns["colSetorPetani"].Index)
            {
                using (var bfn = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var tb = new SolidBrush(C_TEXT_DARK))
                    e.Graphics.DrawString(val, bfn, tb, new Rectangle(e.CellBounds.X + 16, e.CellBounds.Y, e.CellBounds.Width - 16, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (e.ColumnIndex == dgvSetorPanen.Columns["colSetorProduk"].Index ||
                     e.ColumnIndex == dgvSetorPanen.Columns["colSetorBerat"].Index ||
                     e.ColumnIndex == dgvSetorPanen.Columns["colSetorPetugas"].Index)
            {
                using (var rfn = new Font("Segoe UI", 9.2F, FontStyle.Regular))
                using (var tb = new SolidBrush(C_TEXT_DARK))
                    e.Graphics.DrawString(val, rfn, tb, new Rectangle(e.CellBounds.X + 16, e.CellBounds.Y, e.CellBounds.Width - 16, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (e.ColumnIndex == dgvSetorPanen.Columns["colSetorKualitas"].Index)
            {
                // Circular Grade badge (A, B, C) in gold/olive
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int sz = 24;
                int cx = e.CellBounds.X + (e.CellBounds.Width - sz) / 2;
                int cy = e.CellBounds.Y + (e.CellBounds.Height - sz) / 2;
                var circ = new Rectangle(cx, cy, sz, sz);

                using (var br = new SolidBrush(Color.FromArgb(226, 196, 129)))
                using (var pen = new Pen(C_DARK_BORDER, 1.2f))
                {
                    e.Graphics.FillEllipse(br, circ);
                    e.Graphics.DrawEllipse(pen, circ);
                    using (var fn = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                    using (var tb = new SolidBrush(C_TEXT_DARK))
                    {
                        var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        e.Graphics.DrawString(val, fn, tb, circ, sf);
                    }
                }
            }
            e.Handled = true;
        }

        private void PopulateSetorDropdowns()
        {
            try
            {
                cmbSetorPetani.Items.Clear();
                cmbSetorProduk.Items.Clear();
                cmbSetorKualitas.Items.Clear();

                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    // Petani
                    using (var cmd = new SQLiteCommand("SELECT id_petani, nama_petani FROM tb_petani WHERE is_aktif = 1 ORDER BY nama_petani", conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbSetorPetani.Items.Add(new ComboItem { Id = Convert.ToInt32(dr[0]), Name = dr[1].ToString() });
                        }
                    }

                    // Komoditas
                    using (var cmd = new SQLiteCommand("SELECT id_komoditas, nama_komoditas, harga_per_kg FROM tb_komoditas WHERE is_aktif = 1 ORDER BY nama_komoditas", conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbSetorProduk.Items.Add(new ComboItem {
                                Id = Convert.ToInt32(dr[0]),
                                Name = dr[1].ToString(),
                                Price = Convert.ToDouble(dr[2])
                            });
                        }
                    }

                    // Kualitas
                    using (var cmd = new SQLiteCommand("SELECT id_kualitas, nama_kualitas, persen_penalti FROM tb_kualitas ORDER BY id_kualitas", conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbSetorKualitas.Items.Add(new ComboItem {
                                Id = Convert.ToInt32(dr[0]),
                                Name = dr[1].ToString(),
                                Penalty = Convert.ToDouble(dr[2])
                            });
                        }
                    }
                }

                if (cmbSetorKualitas.Items.Count > 0) cmbSetorKualitas.SelectedIndex = 0;
            }
            catch { }
        }

        private void CalculateSetorTotal()
        {
            var selProd = cmbSetorProduk.SelectedItem as ComboItem;
            var selKual = cmbSetorKualitas.SelectedItem as ComboItem;

            if (selProd == null)
            {
                lblSetorTotalValue.Text = "Rp";
                lblSetorTotalHelp.Text = "Pilih produk panen dan kualitas untuk melihat harga";
                calculatedTotal = 0;
                return;
            }

            currentHargaKg = selProd.Price;
            currentPenalti = selKual != null ? selKual.Penalty : 0;
            double hargaBersih = currentHargaKg * (1.0 - (currentPenalti / 100.0));

            double berat = 0;
            string beratTxt = txtSetorBerat.Text.Replace(",", ".").Trim();
            if (double.TryParse(beratTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out berat) && berat > 0)
            {
                calculatedTotal = berat * hargaBersih;
                lblSetorTotalValue.Text = "Rp " + calculatedTotal.ToString("N0", new CultureInfo("id-ID"));
                lblSetorTotalHelp.Text = string.Format("Harga: Rp {0:N0}/Kg (Penalti {1}%: Rp {2:N0}/Kg)", currentHargaKg, currentPenalti, hargaBersih);
            }
            else
            {
                lblSetorTotalValue.Text = "Rp";
                lblSetorTotalHelp.Text = string.Format("Harga dasar: Rp {0:N0}/Kg — Masukkan berat (Kg) untuk hitung total", currentHargaKg);
                calculatedTotal = 0;
            }
        }

        private void ResetSetorForm()
        {
            cmbSetorPetani.SelectedIndex = -1;
            cmbSetorProduk.SelectedIndex = -1;
            if (cmbSetorKualitas.Items.Count > 0) cmbSetorKualitas.SelectedIndex = 0;
            txtSetorBerat.Text = "";
            lblSetorTotalValue.Text = "Rp";
            lblSetorTotalHelp.Text = "Pilih produk panen dan kualitas untuk melihat harga";
            calculatedTotal = 0;
            errSetorPetani = false;
            errSetorProduk = false;
            errSetorKualitas = false;
            errSetorBerat = false;
            pnlBoxSetorPetani.Invalidate();
            pnlBoxSetorProduk.Invalidate();
            pnlBoxSetorKualitas.Invalidate();
            pnlBoxSetorBerat.Invalidate();
        }

        private void LoadSetorData()
        {
            try
            {
                dgvSetorPanen.Rows.Clear();
                int rowCount = 0;

                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string sql = @"
SELECT p.tgl_masuk, pt.nama_petani, k.nama_komoditas, q.nama_kualitas, p.berat_kg, pg.username, p.no_transaksi
FROM tb_panen p
JOIN tb_petani pt ON p.id_petani = pt.id_petani
JOIN tb_komoditas k ON p.id_komoditas = k.id_komoditas
JOIN tb_kualitas q ON p.id_kualitas = q.id_kualitas
JOIN tb_pengguna pg ON p.id_petugas = pg.id_pengguna
ORDER BY p.id_panen DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            rowCount++;
                            string tglRaw = dr[0].ToString();
                            string tglStr = tglRaw;
                            DateTime dt;
                            if (DateTime.TryParse(tglRaw, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt) ||
                                DateTime.TryParse(tglRaw, out dt))
                            {
                                tglStr = dt.ToString("dd/MM/yy");
                            }

                            string petani = dr[1].ToString();
                            string produk = dr[2].ToString();
                            string kualitasRaw = dr[3].ToString();
                            string grade = kualitasRaw.Replace("Grade ", "").Trim();

                            double berat = Convert.ToDouble(dr[4]);
                            string beratStr = (berat % 1 == 0 ? berat.ToString("0") : berat.ToString("0.#")) + " Kg";
                            string petugas = "Bapak Budi";

                            dgvSetorPanen.Rows.Add(tglStr, petani, produk, grade, beratStr, petugas);
                        }
                    }
                }

                if (rowCount == 0)
                {
                    dgvSetorPanen.Visible = false;
                    lblEmptySetor.Visible = true;
                    pnlSetorTableOuter.Height = 44 + 80 + 5;
                }
                else
                {
                    lblEmptySetor.Visible = false;
                    dgvSetorPanen.Visible = true;
                    int maxDisplayRows = 5;
                    int displayRows = Math.Min(rowCount, maxDisplayRows);
                    pnlSetorTableOuter.Height = 44 + (displayRows * 48) + 5;
                    dgvSetorPanen.ScrollBars = rowCount > maxDisplayRows ? ScrollBars.Vertical : ScrollBars.None;
                }

                LayoutAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data setor: " + ex.Message);
            }
        }

        // ══════════════════════════════════════════════════════════
        // MUATAN BARANG & LAPORAN GRID
        // ══════════════════════════════════════════════════════════
        private void SetupMuatanGrid()
        {
            dgvMuatanBarang.Columns.Clear();
            dgvMuatanBarang.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMuatanId", HeaderText = "ID", Visible = false });
            dgvMuatanBarang.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMuatanTgl", HeaderText = "Tanggal", Width = 110 });
            dgvMuatanBarang.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMuatanPetani", HeaderText = "Petani", Width = 170 });
            dgvMuatanBarang.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMuatanKomoditas", HeaderText = "Muatan", Width = 150 });
            dgvMuatanBarang.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMuatanBerat", HeaderText = "Berat", Width = 90 });
            dgvMuatanBarang.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMuatanTotal", HeaderText = "Total", Width = 130 });
            dgvMuatanBarang.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMuatanStatus", HeaderText = "Status", Width = 120 });
            dgvMuatanBarang.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMuatanAksi", HeaderText = "Aksi", Width = 100 });

            dgvMuatanBarang.CellPainting += DgvMuatan_CellPainting;
            dgvMuatanBarang.CellClick += DgvMuatan_CellClick;
            dgvMuatanBarang.CellMouseEnter += (s, e) =>
            {
                if (_muatanMode == "laporan" && dgvMuatanBarang.Columns.Contains("colMuatanAksi"))
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex == dgvMuatanBarang.Columns["colMuatanAksi"].Index)
                    {
                        string st = dgvMuatanBarang.Rows[e.RowIndex].Cells["colMuatanStatus"].Value?.ToString();
                        if (st == "Di Gudang") dgvMuatanBarang.Cursor = Cursors.Hand;
                        else dgvMuatanBarang.Cursor = Cursors.Default;
                    }
                    else dgvMuatanBarang.Cursor = Cursors.Default;
                }
                else if (_muatanMode == "muatan" && dgvMuatanBarang.Columns.Contains("colMuatanCheck"))
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex == dgvMuatanBarang.Columns["colMuatanCheck"].Index)
                        dgvMuatanBarang.Cursor = Cursors.Hand;
                    else
                        dgvMuatanBarang.Cursor = Cursors.Default;
                }
                else dgvMuatanBarang.Cursor = Cursors.Default;
            };
        }

        private void DgvMuatan_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (_muatanMode != "laporan") return;
            if (e.RowIndex < 0) return;
            Color rowBg = (e.RowIndex % 2 == 0) ? Color.FromArgb(250, 244, 230) : Color.White;
            if ((e.State & DataGridViewElementStates.Selected) != 0) rowBg = Color.FromArgb(242, 237, 224);

            using (var brBg = new SolidBrush(rowBg)) e.Graphics.FillRectangle(brBg, e.CellBounds);
            using (var penLine = new Pen(Color.FromArgb(238, 232, 220), 1f))
                e.Graphics.DrawLine(penLine, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);

            string val = e.Value?.ToString() ?? "";

            if (e.ColumnIndex == dgvMuatanBarang.Columns["colMuatanTgl"].Index)
            {
                using (var rfn = new Font("Segoe UI", 9F, FontStyle.Regular))
                using (var tb = new SolidBrush(C_TEXT_MUTED))
                    e.Graphics.DrawString(val, rfn, tb, new Rectangle(e.CellBounds.X + 24, e.CellBounds.Y, e.CellBounds.Width - 24, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (e.ColumnIndex == dgvMuatanBarang.Columns["colMuatanPetani"].Index)
            {
                using (var bfn = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var tb = new SolidBrush(C_TEXT_DARK))
                    e.Graphics.DrawString(val, bfn, tb, new Rectangle(e.CellBounds.X + 16, e.CellBounds.Y, e.CellBounds.Width - 16, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (e.ColumnIndex == dgvMuatanBarang.Columns["colMuatanKomoditas"].Index ||
                     e.ColumnIndex == dgvMuatanBarang.Columns["colMuatanBerat"].Index)
            {
                using (var rfn = new Font("Segoe UI", 9.2F, FontStyle.Regular))
                using (var tb = new SolidBrush(C_TEXT_DARK))
                    e.Graphics.DrawString(val, rfn, tb, new Rectangle(e.CellBounds.X + 16, e.CellBounds.Y, e.CellBounds.Width - 16, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (e.ColumnIndex == dgvMuatanBarang.Columns["colMuatanTotal"].Index)
            {
                using (var bfn = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var tb = new SolidBrush(C_TEXT_DARK))
                    e.Graphics.DrawString(val, bfn, tb, new Rectangle(e.CellBounds.X + 16, e.CellBounds.Y, e.CellBounds.Width - 16, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (e.ColumnIndex == dgvMuatanBarang.Columns["colMuatanStatus"].Index)
            {
                DrawMuatanStatusBadge(e.Graphics, e.CellBounds, val);
            }
            else if (e.ColumnIndex == dgvMuatanBarang.Columns["colMuatanAksi"].Index)
            {
                string status = dgvMuatanBarang.Rows[e.RowIndex].Cells["colMuatanStatus"].Value?.ToString();
                if (status == "Di Gudang")
                {
                    // Action button "Batalkan" (Exact Figma Replica)
                    int btnW = 82, btnH = 26;
                    int bx = e.CellBounds.X + (e.CellBounds.Width - btnW) / 2;
                    int by = e.CellBounds.Y + (e.CellBounds.Height - btnH) / 2;
                    var bRect = new Rectangle(bx, by, btnW, btnH);

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (var path = RoundedPath(bRect, 7))
                    using (var br = new SolidBrush(Color.White))
                    using (var pen = new Pen(C_DARK_BORDER, 1.2f))
                    {
                        e.Graphics.FillPath(br, path);
                        e.Graphics.DrawPath(pen, path);

                        // Icon circle with slash (⊘) and text "Batalkan"
                        using (var penIcon = new Pen(C_TEXT_DARK, 1.3f))
                        {
                            e.Graphics.DrawEllipse(penIcon, bx + 8, by + 7, 11, 11);
                            e.Graphics.DrawLine(penIcon, bx + 10, by + 9, bx + 17, by + 16);
                        }
                        using (var fn = new Font("Segoe UI", 8F, FontStyle.Bold))
                        using (var tb = new SolidBrush(C_TEXT_DARK))
                        {
                            e.Graphics.DrawString("Batalkan", fn, tb, bx + 22, by + 5);
                        }
                    }
                }
                else
                {
                    using (var tb = new SolidBrush(C_TEXT_MUTED))
                    {
                        var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        e.Graphics.DrawString("—", new Font("Segoe UI", 9.5F), tb, e.CellBounds, sf);
                    }
                }
            }
            e.Handled = true;
        }

        private int _selectedBatalPanenId = -1;
        private string _selectedBatalNoTrx = "";

        private void DgvMuatan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_muatanMode != "laporan" || !dgvMuatanBarang.Columns.Contains("colMuatanAksi")) return;
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvMuatanBarang.Columns["colMuatanAksi"].Index)
            {
                string st = dgvMuatanBarang.Rows[e.RowIndex].Cells["colMuatanStatus"].Value?.ToString();
                if (st == "Di Gudang")
                {
                    int idPanen = Convert.ToInt32(dgvMuatanBarang.Rows[e.RowIndex].Cells["colMuatanId"].Value);
                    string petani = dgvMuatanBarang.Rows[e.RowIndex].Cells["colMuatanPetani"].Value?.ToString();
                    string komoditas = dgvMuatanBarang.Rows[e.RowIndex].Cells["colMuatanKomoditas"].Value?.ToString();
                    string berat = dgvMuatanBarang.Rows[e.RowIndex].Cells["colMuatanBerat"].Value?.ToString();
                    string total = dgvMuatanBarang.Rows[e.RowIndex].Cells["colMuatanTotal"].Value?.ToString();
                    string tgl = dgvMuatanBarang.Rows[e.RowIndex].Cells["colMuatanTgl"].Value?.ToString();

                    OpenModalBatalTransaksi(idPanen, petani, komoditas, berat, total, tgl);
                }
            }
        }

        private void OpenModalBatalTransaksi(int idPanen, string petani, string komoditas, string berat, string total, string tgl)
        {
            _selectedBatalPanenId = idPanen;
            _selectedBatalNoTrx = $"STR-{DateTime.Now.ToString("yyyyMMdd")}-{idPanen:D3}";

            lblBatalTrxNo.Text = _selectedBatalNoTrx;
            lblBatalTrxTgl.Text = DateTime.Now.ToString("d MMMM yyyy", new CultureInfo("id-ID"));
            lblBatalPetani.Text = petani;
            lblBatalDetail.Text = $"{komoditas}  {berat}";
            lblBatalTotal.Text = total;
            txtAlasanBatal.Text = "";

            pnlModalCard.Visible = false;
            pnlModalProdukCard.Visible = false;
            pnlModalUserCard.Visible = false;
            pnlModalBatalCard.Visible = true;
            pnlModalOverlay.Visible = true;
            pnlModalOverlay.BringToFront();
            LayoutAll();
        }

        private void CloseModalBatal()
        {
            pnlModalBatalCard.Visible = false;
            pnlModalOverlay.Visible = false;
        }

        private void BtnBatalKonfirmasi_Click()
        {
            if (_selectedBatalPanenId <= 0) return;

            try
            {
                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand("UPDATE tb_panen SET id_status_barang = 3 WHERE id_panen = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _selectedBatalPanenId);
                        cmd.ExecuteNonQuery();
                    }
                }

                CloseModalBatal();
                LoadMuatanData();
                LoadDashboardStats();
                ShowToast("Transaksi Berhasil Dibatalkan", $"{_selectedBatalNoTrx} telah dibatalkan");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membatalkan transaksi: " + ex.Message);
            }
        }

        private void LoadMuatanData()
        {
            try
            {
                dgvMuatanBarang.Rows.Clear();
                int totalCount = 0;
                double totalBerat = 0;
                double totalUang = 0;

                string statusFilter = cmbMuatanStatus.SelectedItem?.ToString() ?? "Semua Status";
                DateTime dari = dtpMuatanDari.Value.Date;
                DateTime sampai = dtpMuatanSampai.Value.Date.AddDays(1).AddSeconds(-1);

                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string sql = @"
SELECT p.id_panen, p.tgl_masuk, pt.nama_petani, k.nama_komoditas, p.berat_kg, p.total_uang, sb.nama_status
FROM tb_panen p
JOIN tb_petani pt ON p.id_petani = pt.id_petani
JOIN tb_komoditas k ON p.id_komoditas = k.id_komoditas
JOIN tb_status_barang sb ON p.id_status_barang = sb.id_status_barang
ORDER BY p.id_panen DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int id = Convert.ToInt32(dr[0]);
                            string tglRaw = dr[1].ToString();
                            DateTime dt;
                            if (!DateTime.TryParse(tglRaw, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                                DateTime.TryParse(tglRaw, out dt);

                            string status = dr[6].ToString();
                            // Status mapping
                            if (status == "Belum Muat") status = "Di Gudang";
                            else if (status == "Sudah Muat") status = "Terkirim";

                            // Filter status
                            if (statusFilter != "Semua Status" && status != statusFilter) continue;

                            string tglStr = dt.ToString("dd/MM/yy");
                            string petani = dr[2].ToString();
                            string komoditas = dr[3].ToString();
                            double berat = Convert.ToDouble(dr[4]);
                            double total = Convert.ToDouble(dr[5]);

                            totalCount++;
                            totalBerat += berat;
                            totalUang += total;

                            string beratStr = (berat % 1 == 0 ? berat.ToString("0") : berat.ToString("0.#")) + " Kg";
                            string totalStr = "Rp " + total.ToString("N0", new CultureInfo("id-ID"));

                            dgvMuatanBarang.Rows.Add(id, tglStr, petani, komoditas, beratStr, totalStr, status, "");
                        }
                    }
                }

                lblMuatanSummaryJumlah.Text = $"Jumlah: {totalCount:D2} Transaksi";
                lblMuatanSummaryBerat.Text = $"Berat: {(totalBerat % 1 == 0 ? totalBerat.ToString("0") : totalBerat.ToString("0.#"))} Kg";
                lblMuatanSummaryTotal.Text = $"Total: Rp {totalUang:N0}";

                if (totalCount == 0)
                {
                    dgvMuatanBarang.Visible = false;
                    lblEmptyMuatan.Visible = true;
                    pnlMuatanTableOuter.Height = 44 + 80 + 5;
                }
                else
                {
                    lblEmptyMuatan.Visible = false;
                    dgvMuatanBarang.Visible = true;
                    int maxDisplayRows = 6;
                    int displayRows = Math.Min(totalCount, maxDisplayRows);
                    pnlMuatanTableOuter.Height = 44 + (displayRows * 50) + 5;
                    dgvMuatanBarang.ScrollBars = totalCount > maxDisplayRows ? ScrollBars.Vertical : ScrollBars.None;
                }

                pnlMuatanSummaryBar.Location = new Point(0, pnlMuatanTableOuter.Bottom + 12);
                LayoutAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data muatan: " + ex.Message);
            }
        }

        private void DoExportMuatanCsv()
        {
            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("No,Tanggal,Petani,Muatan,Berat,Total,Status");

                int no = 1;
                foreach (DataGridViewRow row in dgvMuatanBarang.Rows)
                {
                    if (row.IsNewRow) continue;
                    string tgl = row.Cells["colMuatanTgl"].Value?.ToString();
                    string petani = row.Cells["colMuatanPetani"].Value?.ToString();
                    string muatan = row.Cells["colMuatanKomoditas"].Value?.ToString();
                    string berat = row.Cells["colMuatanBerat"].Value?.ToString();
                    string total = row.Cells["colMuatanTotal"].Value?.ToString()?.Replace("Rp ", "")?.Replace(".", "");
                    string status = row.Cells["colMuatanStatus"].Value?.ToString();

                    sb.AppendLine($"{no++},{tgl},\"{petani}\",\"{muatan}\",\"{berat}\",{total},\"{status}\"");
                }

                string backupDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
                if (!Directory.Exists(backupDir)) Directory.CreateDirectory(backupDir);

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string destFile = Path.Combine(backupDir, $"laporan_transaksi_{timestamp}.csv");
                File.WriteAllText(destFile, sb.ToString(), Encoding.UTF8);

                ShowToast("File CSV Telah Diunduh", $"File tersimpan di folder Backups");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengekspor CSV: " + ex.Message);
            }
        }

        // ══════════════════════════════════════════════════════════
        // BADGE & ACTION HELPERS
        // ══════════════════════════════════════════════════════════
        private void DrawStatusBadge(Graphics g, Rectangle bounds, bool isPositive, string textPos, string textNeg)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int pillW = isPositive ? 76 : 96;
            int pillH = 26;
            int px = bounds.X + (bounds.Width - pillW) / 2;
            int py = bounds.Y + (bounds.Height - pillH) / 2;
            var pillRect = new Rectangle(px, py, pillW, pillH);

            using (var path = RoundedPath(pillRect, 13))
            {
                if (isPositive)
                {
                    using (var br = new SolidBrush(C_BADGE_AK_BG)) g.FillPath(br, path);
                    using (var tb = new SolidBrush(Color.White))
                    using (var fn = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                        g.DrawString(textPos, fn, tb, pillRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                else
                {
                    using (var br = new SolidBrush(C_BADGE_TK_BG)) g.FillPath(br, path);
                    using (var pen = new Pen(C_BADGE_TK_BD, 1.3f)) g.DrawPath(pen, path);
                    using (var tb = new SolidBrush(C_TEXT_DARK))
                    using (var fn = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                        g.DrawString(textNeg, fn, tb, pillRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
            }
        }

        private void DrawMuatanStatusBadge(Graphics g, Rectangle bounds, string status)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int pillW = 90;
            int pillH = 26;
            int px = bounds.X + (bounds.Width - pillW) / 2;
            int py = bounds.Y + (bounds.Height - pillH) / 2;
            var pillRect = new Rectangle(px, py, pillW, pillH);

            using (var path = RoundedPath(pillRect, 13))
            {
                if (status == "Terkirim")
                {
                    using (var br = new SolidBrush(C_BADGE_AK_BG)) g.FillPath(br, path);
                    using (var tb = new SolidBrush(Color.White))
                    using (var fn = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                        g.DrawString("Terkirim", fn, tb, pillRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                else if (status == "Di Gudang")
                {
                    using (var br = new SolidBrush(Color.FromArgb(238, 178, 86))) g.FillPath(br, path);
                    using (var tb = new SolidBrush(C_TEXT_DARK))
                    using (var fn = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                        g.DrawString("Di Gudang", fn, tb, pillRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                else // Dibatalkan
                {
                    using (var br = new SolidBrush(C_BADGE_TK_BG)) g.FillPath(br, path);
                    using (var pen = new Pen(C_BADGE_TK_BD, 1.2f)) g.DrawPath(pen, path);
                    using (var tb = new SolidBrush(C_TEXT_MUTED))
                    using (var fn = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                        g.DrawString("Dibatalkan", fn, tb, pillRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
            }
        }

        private void DrawPencilAction(Graphics g, Rectangle bounds)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int sz = 16;
            int ix = bounds.X + (bounds.Width - sz) / 2;
            int iy = bounds.Y + (bounds.Height - sz) / 2;

            using (var pen = new Pen(C_TEXT_DARK, 1.5f))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round;

                PointF pTip = new PointF(ix + 1, iy + sz - 1);
                PointF pTipT = new PointF(ix + 1, iy + sz - 5);
                PointF pTipR = new PointF(ix + 5, iy + sz - 1);

                PointF pTopL = new PointF(ix + sz - 5, iy + 1);
                PointF pTopR = new PointF(ix + sz - 1, iy + 5);

                g.DrawPolygon(pen, new PointF[] { pTip, pTipT, pTipR });
                g.DrawPolygon(pen, new PointF[] { pTipT, pTopL, pTopR, pTipR });
                g.DrawLine(pen, new PointF(ix + sz - 7, iy + 3), new PointF(ix + sz - 3, iy + 7));
            }
        }

        // ══════════════════════════════════════════════════════════
        // DATA LOADERS & STATS
        // ══════════════════════════════════════════════════════════
        private void LoadPetaniData()
        {
            try
            {
                dgvPetani.Rows.Clear();
                int rowCount = 0;

                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT id_petani, nama_petani, desa, no_telepon, luas_lahan_hektar, is_aktif FROM tb_petani ORDER BY id_petani";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            rowCount++;
                            int id = Convert.ToInt32(dr[0]);
                            string nama = dr[1].ToString();
                            string desa = dr[2].ToString();
                            string noHp = dr[3].ToString();
                            double luas = Convert.ToDouble(dr[4]);

                            string luasStr = (luas % 1 == 0)
                                ? luas.ToString("0", new CultureInfo("id-ID")) + " ha"
                                : luas.ToString("0.#", new CultureInfo("id-ID")) + " ha";

                            int aktif = Convert.ToInt32(dr[5]);
                            string statusStr = aktif == 1 ? "Aktif" : "Tidak Aktif";

                            dgvPetani.Rows.Add(id, nama, desa, noHp, luasStr, statusStr, "✏");
                        }
                    }
                }

                if (rowCount == 0)
                {
                    dgvPetani.Visible = false;
                    lblEmptyState.Visible = true;
                    pnlPetaniTableOuter.Height = 46 + 80 + 5;
                }
                else
                {
                    lblEmptyState.Visible = false;
                    dgvPetani.Visible = true;
                    int maxDisplayRows = 7;
                    int displayRows = Math.Min(rowCount, maxDisplayRows);
                    pnlPetaniTableOuter.Height = 46 + (displayRows * 52) + 5;
                    dgvPetani.ScrollBars = rowCount > maxDisplayRows ? ScrollBars.Vertical : ScrollBars.None;
                }

                LayoutAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data petani: " + ex.Message);
            }
        }

        private void LoadProdukData()
        {
            try
            {
                dgvProdukPanen.Rows.Clear();
                int rowCount = 0;

                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT id_komoditas, nama_komoditas, harga_per_kg, tgl_update_harga, is_aktif FROM tb_komoditas ORDER BY id_komoditas";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            rowCount++;
                            int id = Convert.ToInt32(dr[0]);
                            string nama = dr[1].ToString();
                            double harga = Convert.ToDouble(dr[2]);
                            string hargaStr = "Rp " + harga.ToString("N0", new CultureInfo("id-ID"));

                            string tglRaw = dr[3].ToString();
                            string tglStr = tglRaw;
                            DateTime dt;
                            if (DateTime.TryParse(tglRaw, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt) ||
                                DateTime.TryParse(tglRaw, new CultureInfo("id-ID"), DateTimeStyles.None, out dt) ||
                                DateTime.TryParse(tglRaw, out dt))
                            {
                                tglStr = dt.ToString("dd MMMM yyyy", new CultureInfo("id-ID"));
                            }

                            int aktif = Convert.ToInt32(dr[4]);
                            string statusStr = aktif == 1 ? "Aktif" : "Tidak Aktif";

                            dgvProdukPanen.Rows.Add(id, nama, hargaStr, tglStr, statusStr, "✏");
                        }
                    }
                }

                if (rowCount == 0)
                {
                    dgvProdukPanen.Visible = false;
                    lblEmptyProduk.Visible = true;
                    pnlProdukPanenTableOuter.Height = 46 + 80 + 5;
                }
                else
                {
                    lblEmptyProduk.Visible = false;
                    dgvProdukPanen.Visible = true;
                    int maxDisplayRows = 7;
                    int displayRows = Math.Min(rowCount, maxDisplayRows);
                    pnlProdukPanenTableOuter.Height = 46 + (displayRows * 52) + 5;
                    dgvProdukPanen.ScrollBars = rowCount > maxDisplayRows ? ScrollBars.Vertical : ScrollBars.None;
                }

                LayoutAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data produk: " + ex.Message);
            }
        }

        private void LoadDashboardStats()
        {
            try
            {
                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM tb_petani WHERE is_aktif = 1", conn))
                        statPetaniAktif = Convert.ToInt32(cmd.ExecuteScalar() ?? 8);

                    using (var cmd = new SQLiteCommand("SELECT IFNULL(SUM(berat_kg), 2580) FROM tb_panen WHERE id_status_barang = 1", conn))
                        statStokKg = Convert.ToDouble(cmd.ExecuteScalar() ?? 2580);

                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM tb_panen WHERE date(tgl_masuk) = date('now') OR no_transaksi LIKE 'TRX-TODAY%'", conn))
                        statTransaksi = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                }
            }
            catch
            {
                statPetaniAktif = 8;
                statStokKg = 2580;
                statTransaksi = 0;
            }

            pnlStatCard1.Invalidate();
            pnlStatCard2.Invalidate();
            pnlStatCard3.Invalidate();
        }

        // ══════════════════════════════════════════════════════════
        // MODALS (PETANI & PRODUK)
        // ══════════════════════════════════════════════════════════
        private void OpenModalTambah()
        {
            editPetaniId = -1;
            lblModalTitle.Text = "Tambah Petani Baru";
            lblModalSubtitle.Text = "Isi data di bawah ini, lalu tekan Simpan";
            txtModalNama.Text = "";
            txtModalDesa.Text = "";
            txtModalNoHp.Text = "";
            txtModalLuas.Text = "";
            cmbModalStatus.SelectedIndex = 0;

            ClearValidationErrors();
            pnlModalCard.Visible = true;
            pnlModalProdukCard.Visible = false;
            pnlModalOverlay.Visible = true;
            pnlModalOverlay.BringToFront();
            txtModalNama.Focus();
        }

        private void OpenModalEdit(DataGridViewRow row)
        {
            editPetaniId = Convert.ToInt32(row.Cells["colId"].Value);
            lblModalTitle.Text = "Edit Data Petani";
            lblModalSubtitle.Text = "Isi data di bawah ini, lalu tekan Simpan";
            txtModalNama.Text = row.Cells["colNama"].Value?.ToString() ?? "";
            txtModalDesa.Text = row.Cells["colDesa"].Value?.ToString() ?? "";
            txtModalNoHp.Text = row.Cells["colNoHp"].Value?.ToString() ?? "";
            string luas = row.Cells["colLuas"].Value?.ToString()?.Replace(" ha", "") ?? "";
            txtModalLuas.Text = luas;

            string status = row.Cells["colStatus"].Value?.ToString() ?? "Aktif";
            cmbModalStatus.SelectedIndex = status == "Aktif" ? 0 : 1;

            ClearValidationErrors();
            pnlModalCard.Visible = true;
            pnlModalProdukCard.Visible = false;
            pnlModalOverlay.Visible = true;
            pnlModalOverlay.BringToFront();
            txtModalNama.Focus();
        }

        private void CloseModal()
        {
            pnlModalOverlay.Visible = false;
            pnlModalCard.Visible = false;
            ClearValidationErrors();
        }

        private void ClearValidationErrors()
        {
            errNama = false; errDesa = false; errNoHp = false; errLuas = false;
            lblErrNama.Visible = false; lblErrDesa.Visible = false; lblErrNoHp.Visible = false; lblErrLuas.Visible = false;
            pnlBoxNama.Invalidate(); pnlBoxDesa.Invalidate(); pnlBoxNoHp.Invalidate(); pnlBoxLuas.Invalidate();
        }

        private void BtnModalSimpan_Click(object sender, EventArgs e)
        {
            bool hasErr = false;
            double luas = 0;

            if (string.IsNullOrWhiteSpace(txtModalNama.Text)) { errNama = true; lblErrNama.Visible = true; hasErr = true; }
            else { errNama = false; lblErrNama.Visible = false; }
            pnlBoxNama.Invalidate();

            if (string.IsNullOrWhiteSpace(txtModalDesa.Text)) { errDesa = true; lblErrDesa.Visible = true; hasErr = true; }
            else { errDesa = false; lblErrDesa.Visible = false; }
            pnlBoxDesa.Invalidate();

            if (string.IsNullOrWhiteSpace(txtModalNoHp.Text)) { errNoHp = true; lblErrNoHp.Visible = true; hasErr = true; }
            else { errNoHp = false; lblErrNoHp.Visible = false; }
            pnlBoxNoHp.Invalidate();

            if (string.IsNullOrWhiteSpace(txtModalLuas.Text) || !double.TryParse(txtModalLuas.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out luas))
            {
                errLuas = true; lblErrLuas.Visible = true; hasErr = true;
            }
            else { errLuas = false; lblErrLuas.Visible = false; }
            pnlBoxLuas.Invalidate();

            if (hasErr) return;

            int isAktif = cmbModalStatus.SelectedIndex == 0 ? 1 : 0;
            try
            {
                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    if (editPetaniId == -1)
                    {
                        string insertSql = "INSERT INTO tb_petani (nama_petani, desa, no_telepon, luas_lahan_hektar, is_aktif) VALUES (@nama, @desa, @hp, @luas, @aktif)";
                        using (var cmd = new SQLiteCommand(insertSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@nama", txtModalNama.Text.Trim());
                            cmd.Parameters.AddWithValue("@desa", txtModalDesa.Text.Trim());
                            cmd.Parameters.AddWithValue("@hp", txtModalNoHp.Text.Trim());
                            cmd.Parameters.AddWithValue("@luas", luas);
                            cmd.Parameters.AddWithValue("@aktif", isAktif);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string updateSql = "UPDATE tb_petani SET nama_petani=@nama, desa=@desa, no_telepon=@hp, luas_lahan_hektar=@luas, is_aktif=@aktif WHERE id_petani=@id";
                        using (var cmd = new SQLiteCommand(updateSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@nama", txtModalNama.Text.Trim());
                            cmd.Parameters.AddWithValue("@desa", txtModalDesa.Text.Trim());
                            cmd.Parameters.AddWithValue("@hp", txtModalNoHp.Text.Trim());
                            cmd.Parameters.AddWithValue("@luas", luas);
                            cmd.Parameters.AddWithValue("@aktif", isAktif);
                            cmd.Parameters.AddWithValue("@id", editPetaniId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                CloseModal();
                LoadPetaniData();
                PopulateSetorDropdowns();
                LoadDashboardStats();
                ShowToast("Data Berhasil Disimpan", editPetaniId == -1 ? "Petani baru berhasil ditambahkan" : "Data petani berhasil diperbarui");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message);
            }
        }

        private void OpenModalTambahProduk()
        {
            editProdukId = -1;
            lblModalProdTitle.Text = "Tambah Produk Panen baru";
            lblModalProdSubtitle.Text = "Isi data di bawah ini, lalu tekan Simpan";
            txtModalProdNama.Text = "";
            txtModalProdHarga.Text = "";
            cmbModalProdStatus.SelectedIndex = 0;

            ClearProdukValidationErrors();
            pnlModalCard.Visible = false;
            pnlModalProdukCard.Visible = true;
            pnlModalOverlay.Visible = true;
            pnlModalOverlay.BringToFront();
            txtModalProdNama.Focus();
        }

        private void OpenModalEditProduk(DataGridViewRow row)
        {
            editProdukId = Convert.ToInt32(row.Cells["colProdId"].Value);
            lblModalProdTitle.Text = "Edit Produk Panen";
            lblModalProdSubtitle.Text = "Isi data di bawah ini, lalu tekan Simpan";
            txtModalProdNama.Text = row.Cells["colProdNama"].Value?.ToString() ?? "";
            string hargaStr = row.Cells["colProdHarga"].Value?.ToString() ?? "";
            txtModalProdHarga.Text = hargaStr.Replace("Rp", "").Replace(".", "").Replace(" ", "").Trim();

            string status = row.Cells["colProdStatus"].Value?.ToString() ?? "Aktif";
            cmbModalProdStatus.SelectedIndex = status == "Aktif" ? 0 : 1;

            ClearProdukValidationErrors();
            pnlModalCard.Visible = false;
            pnlModalProdukCard.Visible = true;
            pnlModalOverlay.Visible = true;
            pnlModalOverlay.BringToFront();
            txtModalProdNama.Focus();
        }

        private void CloseModalProduk()
        {
            pnlModalOverlay.Visible = false;
            pnlModalProdukCard.Visible = false;
            ClearProdukValidationErrors();
        }

        private void ClearProdukValidationErrors()
        {
            errProdNama = false; errProdHarga = false;
            lblErrProdNama.Visible = false; lblErrProdHarga.Visible = false;
            pnlBoxProdNama.Invalidate(); pnlBoxProdHarga.Invalidate();
        }

        private void BtnModalProdSimpan_Click(object sender, EventArgs e)
        {
            bool hasErr = false;
            double hargaVal = 0;

            if (string.IsNullOrWhiteSpace(txtModalProdNama.Text)) { errProdNama = true; lblErrProdNama.Visible = true; hasErr = true; }
            else { errProdNama = false; lblErrProdNama.Visible = false; }
            pnlBoxProdNama.Invalidate();

            string cleanedHarga = txtModalProdHarga.Text.Replace("Rp", "").Replace(".", "").Replace(" ", "").Trim();
            if (string.IsNullOrWhiteSpace(cleanedHarga) || !double.TryParse(cleanedHarga, NumberStyles.Any, CultureInfo.InvariantCulture, out hargaVal) || hargaVal <= 0)
            {
                errProdHarga = true; lblErrProdHarga.Visible = true; hasErr = true;
            }
            else { errProdHarga = false; lblErrProdHarga.Visible = false; }
            pnlBoxProdHarga.Invalidate();

            if (hasErr) return;

            int isAktif = cmbModalProdStatus.SelectedIndex == 0 ? 1 : 0;
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            try
            {
                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    if (editProdukId == -1)
                    {
                        string insertSql = "INSERT INTO tb_komoditas (nama_komoditas, harga_per_kg, tgl_update_harga, is_aktif) VALUES (@nama, @harga, @tgl, @aktif)";
                        using (var cmd = new SQLiteCommand(insertSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@nama", txtModalProdNama.Text.Trim());
                            cmd.Parameters.AddWithValue("@harga", hargaVal);
                            cmd.Parameters.AddWithValue("@tgl", today);
                            cmd.Parameters.AddWithValue("@aktif", isAktif);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string updateSql = "UPDATE tb_komoditas SET nama_komoditas=@nama, harga_per_kg=@harga, tgl_update_harga=@tgl, is_aktif=@aktif WHERE id_komoditas=@id";
                        using (var cmd = new SQLiteCommand(updateSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@nama", txtModalProdNama.Text.Trim());
                            cmd.Parameters.AddWithValue("@harga", hargaVal);
                            cmd.Parameters.AddWithValue("@tgl", today);
                            cmd.Parameters.AddWithValue("@aktif", isAktif);
                            cmd.Parameters.AddWithValue("@id", editProdukId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                CloseModalProduk();
                LoadProdukData();
                PopulateSetorDropdowns();
                ShowToast("Data Berhasil Disimpan", editProdukId == -1 ? "Produk panen baru berhasil ditambahkan" : "Data produk panen berhasil diperbarui");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message);
            }
        }

        // ══════════════════════════════════════════════════════════
        // SETOR PANEN ACTIONS
        // ══════════════════════════════════════════════════════════
        private void BtnSetorSimpan_Click(object sender, EventArgs e)
        {
            var selPetani = cmbSetorPetani.SelectedItem as ComboItem;
            var selProduk = cmbSetorProduk.SelectedItem as ComboItem;
            var selKualitas = cmbSetorKualitas.SelectedItem as ComboItem;

            bool hasErr = false;
            if (selPetani == null) { errSetorPetani = true; hasErr = true; } else errSetorPetani = false;
            pnlBoxSetorPetani.Invalidate();

            if (selProduk == null) { errSetorProduk = true; hasErr = true; } else errSetorProduk = false;
            pnlBoxSetorProduk.Invalidate();

            if (selKualitas == null) { errSetorKualitas = true; hasErr = true; } else errSetorKualitas = false;
            pnlBoxSetorKualitas.Invalidate();

            double berat = 0;
            string beratTxt = txtSetorBerat.Text.Replace(",", ".").Trim();
            if (string.IsNullOrWhiteSpace(beratTxt) || !double.TryParse(beratTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out berat) || berat <= 0)
            {
                errSetorBerat = true; hasErr = true;
            }
            else errSetorBerat = false;
            pnlBoxSetorBerat.Invalidate();

            if (hasErr)
            {
                MessageBox.Show("Mohon lengkapi semua data setoran (Petani, Produk Panen, Kualitas, dan Berat).", "Validasi Setor Panen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CalculateSetorTotal();
            if (calculatedTotal <= 0) return;

            string noTrx = "TRX-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            try
            {
                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string insertSql = @"
INSERT INTO tb_panen (no_transaksi, tgl_masuk, id_petani, id_komoditas, id_kualitas, id_petugas, id_status_barang, id_status_bayar, berat_kg, harga_saat_transaksi, persen_penalti, total_uang)
VALUES (@no, datetime('now', 'localtime'), @petani, @komoditas, @kualitas, 1, 1, 2, @berat, @harga, @penalti, @total)";

                    using (var cmd = new SQLiteCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@no", noTrx);
                        cmd.Parameters.AddWithValue("@petani", selPetani.Id);
                        cmd.Parameters.AddWithValue("@komoditas", selProduk.Id);
                        cmd.Parameters.AddWithValue("@kualitas", selKualitas.Id);
                        cmd.Parameters.AddWithValue("@berat", berat);
                        cmd.Parameters.AddWithValue("@harga", currentHargaKg);
                        cmd.Parameters.AddWithValue("@penalti", currentPenalti);
                        cmd.Parameters.AddWithValue("@total", calculatedTotal);
                        cmd.ExecuteNonQuery();
                    }
                }

                ResetSetorForm();
                LoadSetorData();
                LoadMuatanData();
                LoadDashboardStats();
                ShowToast("Data Berhasil Disimpan", $"Setoran panen {selProduk.Name} berhasil dicatat");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan setoran: " + ex.Message);
            }
        }

        // ══════════════════════════════════════════════════════════
        // BACKUP & TOAST
        // ══════════════════════════════════════════════════════════
        private void DoBackupDatabase()
        {
            try
            {
                string dbSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "agriva.db");
                string backupDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
                if (!Directory.Exists(backupDir)) Directory.CreateDirectory(backupDir);

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string destFile = Path.Combine(backupDir, "agriva_backup_" + timestamp + ".db");

                if (File.Exists(dbSource))
                {
                    File.Copy(dbSource, destFile, true);
                }

                ShowToast("Data Berhasil Disimpan", "File cadangan sudah diunduh ke komputer");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Backup gagal: " + ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowToast(string title, string subtitle)
        {
            toastTitle = title;
            toastSubtitle = subtitle;
            lblToastText.Visible = false;
            pnlToast.Size = new Size(295, 56);
            pnlToast.Location = new Point(pnlContent.Width - pnlToast.Width - 24, pnlContent.Height - pnlToast.Height - 20);
            pnlToast.Visible = true;
            pnlToast.BringToFront();
            pnlToast.Invalidate();

            tmrToast.Stop();
            tmrToast.Interval = 3500;
            tmrToast.Start();
        }

        // ══════════════════════════════════════════════════════════
        // NAVIGATION & EVENTS
        // ══════════════════════════════════════════════════════════
        private void SetupNavButtonPaint(Button btn, string iconType, string labelText)
        {
            btn.Text = "";
            btn.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                bool isActive = (btn == activeNavBtn);
                bool isHover = (btn == hoveredNavBtn && !isActive);

                var rect = new Rectangle(0, 2, btn.Width - 1, btn.Height - 5);

                if (isActive)
                {
                    using (var path = RoundedPath(rect, 10))
                    using (var br = new SolidBrush(C_NAV_ACTIVE))
                    {
                        pe.Graphics.FillPath(br, path);
                        DrawNavIcon(pe.Graphics, iconType, new RectangleF(16, (btn.Height - 18) / 2f, 18, 18), C_TEXT_DARK);
                        using (var tb = new SolidBrush(C_TEXT_DARK))
                        using (var lfn = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                            pe.Graphics.DrawString(labelText, lfn, tb, new PointF(46, (btn.Height - 20) / 2f));
                    }
                }
                else
                {
                    if (isHover)
                    {
                        using (var path = RoundedPath(rect, 10))
                        using (var br = new SolidBrush(Color.FromArgb(70, 58, 48)))
                            pe.Graphics.FillPath(br, path);
                    }

                    Color cInactive = Color.FromArgb(220, 210, 192);
                    DrawNavIcon(pe.Graphics, iconType, new RectangleF(16, (btn.Height - 18) / 2f, 18, 18), cInactive);
                    using (var tb = new SolidBrush(cInactive))
                    using (var lfn = new Font("Segoe UI", 9.5F, FontStyle.Regular))
                        pe.Graphics.DrawString(labelText, lfn, tb, new PointF(46, (btn.Height - 20) / 2f));
                }
            };

            btn.MouseEnter += (s, e) => { hoveredNavBtn = btn; btn.Invalidate(); };
            btn.MouseLeave += (s, e) => { if (hoveredNavBtn == btn) hoveredNavBtn = null; btn.Invalidate(); };
        }

        private void WireNavigation()
        {
            SetupNavButtonPaint(btnNavDashboard, "dashboard", "Dashboard");
            SetupNavButtonPaint(btnNavPetani, "petani", "Petani");
            SetupNavButtonPaint(btnNavProdukPanen, "produk", "Produk Panen");
            SetupNavButtonPaint(btnNavSetorPanen, "setor", "Setor Panen");
            SetupNavButtonPaint(btnNavMuatanBarang, "muatan", "Muatan Barang");
            SetupNavButtonPaint(btnNavLaporan, "laporan", "Laporan");
            SetupNavButtonPaint(btnNavManajemenUser, "user", "Manajemen User");

            btnNavDashboard.Click += (s, e) => { SwitchToPage(pnlDashboard, btnNavDashboard); LoadDashboardStats(); };
            btnNavPetani.Click += (s, e) => { SwitchToPage(pnlPetani, btnNavPetani); LoadPetaniData(); };
            btnNavProdukPanen.Click += (s, e) => { SwitchToPage(pnlProdukPanen, btnNavProdukPanen); LoadProdukData(); };
            btnNavSetorPanen.Click += (s, e) => { SwitchToPage(pnlSetorPanen, btnNavSetorPanen); LoadSetorData(); };
            btnNavMuatanBarang.Click += (s, e) => SwitchToMuatanPage("Muatan Barang", "Centang barang muatan, isi tujuan, lalu buat surat jalan", btnNavMuatanBarang);
            btnNavLaporan.Click += (s, e) => SwitchToMuatanPage("Laporan Transaksi", "Lihat semua setoran panen", btnNavLaporan);
            btnNavManajemenUser.Click += (s, e) => SwitchToUserPage(btnNavManajemenUser);
        }

        private void WireEvents()
        {
            tmrToast.Tick += (s, e) =>
            {
                pnlToast.Visible = false;
                tmrToast.Stop();
            };

            btnKeluar.Click += (s, e) =>
            {
                if (MessageBox.Show("Yakin ingin keluar dari akun?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FormLogin login = new FormLogin();
                    login.Show();
                    this.Dispose();
                }
            };

            btnBackupDatabase.Click += (s, e) => DoBackupDatabase();

            // Muatan Barang events
            btnBuatSuratJalan.Click += (s, e) => BtnBuatSuratJalan_Click();
            btnTambahUser.Click += (s, e) => OpenModalTambahUser();

            // Modal Batal Transaksi events
            lblModalBatalClose.Click += (s, e) => CloseModalBatal();
            btnBatalKembali.Click += (s, e) => CloseModalBatal();
            btnBatalKonfirmasi.Click += (s, e) => BtnBatalKonfirmasi_Click();

            // Modal Pengguna events
            lblModalUserClose.Click += (s, e) => CloseModalUser();
            btnModalUserBatal.Click += (s, e) => CloseModalUser();
            btnModalUserSimpan.Click += (s, e) => BtnModalUserSimpan_Click();

            // Petani modal events
            btnTambahPetani.Click   += (s, e) => OpenModalTambah();
            lblModalClose.Click     += (s, e) => CloseModal();
            btnModalBatal.Click     += (s, e) => CloseModal();
            btnModalSimpan.Click    += BtnModalSimpan_Click;

            // Produk Panen modal events
            btnTambahProduk.Click     += (s, e) => OpenModalTambahProduk();
            lblModalProdClose.Click   += (s, e) => CloseModalProduk();
            btnModalProdBatal.Click   += (s, e) => CloseModalProduk();
            btnModalProdSimpan.Click  += BtnModalProdSimpan_Click;

            // Setor Panen events
            cmbSetorProduk.SelectedIndexChanged += (s, e) => CalculateSetorTotal();
            cmbSetorKualitas.SelectedIndexChanged += (s, e) => CalculateSetorTotal();
            txtSetorBerat.TextChanged += (s, e) => CalculateSetorTotal();
            btnSetorKosongkan.Click += (s, e) => ResetSetorForm();
            btnSetorSimpan.Click += BtnSetorSimpan_Click;

            // Muatan Barang events
            cmbMuatanStatus.SelectedIndexChanged += (s, e) => LoadMuatanData();
            dtpMuatanDari.ValueChanged += (s, e) => LoadMuatanData();
            dtpMuatanSampai.ValueChanged += (s, e) => LoadMuatanData();
            btnMuatanEksporCsv.Click += (s, e) => DoExportMuatanCsv();
        }

        private void SwitchToPage(Panel page, Button navBtn)
        {
            pnlDashboard.Visible = false;
            pnlPetani.Visible = false;
            pnlProdukPanen.Visible = false;
            pnlSetorPanen.Visible = false;
            pnlMuatanBarang.Visible = false;
            pnlOtherPage.Visible = false;

            page.Visible = true;
            page.BringToFront();

            activeNavBtn = navBtn;
            pnlNavArea.Invalidate(true);
        }

        private void SwitchToMuatanPage(string title, string subtitle, Button navBtn)
        {
            lblMuatanTitle.Text = title;
            lblMuatanSubtitle.Text = subtitle;

            if (title == "Muatan Barang")
            {
                _muatanMode = "muatan";
                SetupMuatanBarangGrid();
                SwitchToPage(pnlMuatanBarang, navBtn);
                LoadMuatanBarangData();
            }
            else
            {
                _muatanMode = "laporan";
                SetupMuatanGrid();
                SwitchToPage(pnlMuatanBarang, navBtn);
                LoadMuatanData();
            }
            LayoutAll();
        }

        // ══════════════════════════════════════════════════════════
        // MUATAN BARANG (EXACT FIGMA REPLICA)
        // ══════════════════════════════════════════════════════════
        private void SetupMuatanBarangGrid()
        {
            dgvMuatanBarang.Columns.Clear();

            var chkCol = new DataGridViewCheckBoxColumn
            {
                Name = "colMuatanCheck",
                HeaderText = "",
                Width = 50,
                TrueValue = true,
                FalseValue = false,
                ThreeState = false
            };
            dgvMuatanBarang.Columns.Add(chkCol);
            dgvMuatanBarang.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMuatanId", HeaderText = "ID", Visible = false });
            dgvMuatanBarang.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMuatanKomoditas", HeaderText = "Muatan", Width = 150 });
            dgvMuatanBarang.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMuatanPetani", HeaderText = "Petani", Width = 180 });
            dgvMuatanBarang.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMuatanKualitas", HeaderText = "Kualitas", Width = 90 });
            dgvMuatanBarang.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMuatanBerat", HeaderText = "Berat", Width = 90 });
            dgvMuatanBarang.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMuatanTgl", HeaderText = "Tanggal Masuk", Width = 160 });
            dgvMuatanBarang.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMuatanStatus", HeaderText = "Status", Width = 120 });

            dgvMuatanBarang.ReadOnly = false;
            foreach (DataGridViewColumn c in dgvMuatanBarang.Columns)
            {
                if (c.Name != "colMuatanCheck") c.ReadOnly = true;
            }

            dgvMuatanBarang.CellPainting -= DgvMuatan_CellPainting;
            dgvMuatanBarang.CellPainting += DgvMuatanBarang_CellPainting;
            dgvMuatanBarang.CellValueChanged -= DgvMuatanBarang_CellValueChanged;
            dgvMuatanBarang.CellValueChanged += DgvMuatanBarang_CellValueChanged;
            dgvMuatanBarang.CurrentCellDirtyStateChanged -= DgvMuatanBarang_CurrentCellDirtyStateChanged;
            dgvMuatanBarang.CurrentCellDirtyStateChanged += DgvMuatanBarang_CurrentCellDirtyStateChanged;
            dgvMuatanBarang.CellContentClick += DgvMuatanBarang_CellContentClick;
            dgvMuatanBarang.CellClick += DgvMuatanBarang_CellClick;
        }

                private void DgvMuatanBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMuatanBarang.Columns.Contains("colMuatanCheck") && e.ColumnIndex == dgvMuatanBarang.Columns["colMuatanCheck"].Index)
            {
                dgvMuatanBarang.CommitEdit(DataGridViewDataErrorContexts.Commit);
                UpdateMuatanDipilihSummary();
            }
        }

        private void DgvMuatanBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && _muatanMode == "muatan" && dgvMuatanBarang.Columns.Contains("colMuatanCheck"))
            {
                // Jika user klik cell selain checkbox, toggle juga checkboxnya agar user-friendly
                if (e.ColumnIndex != dgvMuatanBarang.Columns["colMuatanCheck"].Index)
                {
                    bool current = Convert.ToBoolean(dgvMuatanBarang.Rows[e.RowIndex].Cells["colMuatanCheck"].Value);
                    dgvMuatanBarang.Rows[e.RowIndex].Cells["colMuatanCheck"].Value = !current;
                    dgvMuatanBarang.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    UpdateMuatanDipilihSummary();
                    dgvMuatanBarang.InvalidateRow(e.RowIndex);
                }
            }
        }

        private void DgvMuatanBarang_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvMuatanBarang.IsCurrentCellDirty)
            {
                dgvMuatanBarang.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvMuatanBarang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvMuatanBarang.Columns["colMuatanCheck"].Index)
            {
                UpdateMuatanDipilihSummary();
            }
        }

        private void UpdateMuatanDipilihSummary()
        {
            int selCount = 0;
            double selBerat = 0;

            foreach (DataGridViewRow row in dgvMuatanBarang.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["colMuatanCheck"].Value);
                if (isChecked)
                {
                    selCount++;
                    string bStr = row.Cells["colMuatanBerat"].Value?.ToString() ?? "0";
                    bStr = bStr.Replace("Kg", "").Trim();
                    double bVal;
                    if (double.TryParse(bStr, out bVal)) selBerat += bVal;
                }
            }

            lblDipilihCount.Text = $"{selCount} Barang";
            lblDipilihBerat.Text = $"{selBerat:N0} Kg";

            if (selCount > 0)
            {
                lblMuatanError.Visible = false;
            }
        }

        private void LoadMuatanBarangData()
        {
            try
            {
                dgvMuatanBarang.Rows.Clear();
                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string sql = @"
SELECT p.id_panen, k.nama_komoditas, pt.nama_petani, q.nama_kualitas, p.berat_kg, p.tgl_masuk, sb.nama_status
FROM tb_panen p
JOIN tb_petani pt ON p.id_petani = pt.id_petani
JOIN tb_komoditas k ON p.id_komoditas = k.id_komoditas
JOIN tb_kualitas q ON p.id_kualitas = q.id_kualitas
JOIN tb_status_barang sb ON p.id_status_barang = sb.id_status_barang
WHERE p.id_status_barang = 1 OR sb.nama_status = 'Di Gudang' OR sb.nama_status = 'Belum Muat'
ORDER BY p.id_panen DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int id = Convert.ToInt32(dr[0]);
                            string komoditas = dr[1].ToString();
                            string petani = dr[2].ToString();
                            string kualitas = dr[3].ToString();
                            double berat = Convert.ToDouble(dr[4]);
                            string tglRaw = dr[5].ToString();
                            DateTime dt;
                            if (!DateTime.TryParse(tglRaw, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                                DateTime.TryParse(tglRaw, out dt);

                            string tglFmt = dt.ToString("d MMMM yyyy", new CultureInfo("id-ID"));
                            string status = "Di Gudang";

                            dgvMuatanBarang.Rows.Add(false, id, komoditas, petani, kualitas, $"{berat:N0} Kg", tglFmt, status);
                        }
                    }
                }

                int rowCount = dgvMuatanBarang.Rows.Count;
                if (rowCount == 0)
                {
                    dgvMuatanBarang.Visible = false;
                    lblEmptyMuatan.Visible = true;
                    pnlMuatanTableOuter.Height = 44 + 80 + 5;
                }
                else
                {
                    lblEmptyMuatan.Visible = false;
                    dgvMuatanBarang.Visible = true;
                    int maxDisplayRows = 5;
                    int displayRows = Math.Min(rowCount, maxDisplayRows);
                    pnlMuatanTableOuter.Height = 44 + (displayRows * 50) + 5;
                    dgvMuatanBarang.ScrollBars = rowCount > maxDisplayRows ? ScrollBars.Vertical : ScrollBars.None;
                }

                UpdateMuatanDipilihSummary();
                LayoutAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat muatan barang: " + ex.Message);
            }
        }

        private void DgvMuatanBarang_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (_muatanMode != "muatan") return;
            if (e.RowIndex < 0) return;
            Color rowBg = (e.RowIndex % 2 == 0) ? Color.FromArgb(250, 244, 230) : Color.White;
            if ((e.State & DataGridViewElementStates.Selected) != 0) rowBg = Color.FromArgb(242, 237, 224);

            using (var brBg = new SolidBrush(rowBg)) e.Graphics.FillRectangle(brBg, e.CellBounds);
            using (var penLine = new Pen(Color.FromArgb(238, 232, 220), 1f))
                e.Graphics.DrawLine(penLine, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);

            string colName = dgvMuatanBarang.Columns[e.ColumnIndex].Name;
            string val = e.Value?.ToString() ?? "";

            if (colName == "colMuatanCheck")
            {
                bool isChecked = Convert.ToBoolean(e.Value);
                int sz = 18;
                int cx = e.CellBounds.X + (e.CellBounds.Width - sz) / 2;
                int cy = e.CellBounds.Y + (e.CellBounds.Height - sz) / 2;
                var chkRect = new Rectangle(cx, cy, sz, sz);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = RoundedPath(chkRect, 4))
                using (var brBox = new SolidBrush(isChecked ? Color.FromArgb(54, 44, 36) : Color.White))
                using (var penBox = new Pen(Color.FromArgb(54, 44, 36), 1.4f))
                {
                    e.Graphics.FillPath(brBox, path);
                    e.Graphics.DrawPath(penBox, path);

                    if (isChecked)
                    {
                        using (var penTick = new Pen(Color.White, 2f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                        {
                            e.Graphics.DrawLine(penTick, cx + 4, cy + 9, cx + 8, cy + 13);
                            e.Graphics.DrawLine(penTick, cx + 8, cy + 13, cx + 14, cy + 5);
                        }
                    }
                }
            }
            else if (colName == "colMuatanKomoditas")
            {
                using (var bfn = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var tb = new SolidBrush(C_TEXT_DARK))
                    e.Graphics.DrawString(val, bfn, tb, new Rectangle(e.CellBounds.X + 16, e.CellBounds.Y, e.CellBounds.Width - 16, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (colName == "colMuatanPetani")
            {
                using (var rfn = new Font("Segoe UI", 9F, FontStyle.Regular))
                using (var tb = new SolidBrush(C_TEXT_DARK))
                    e.Graphics.DrawString(val, rfn, tb, new Rectangle(e.CellBounds.X + 16, e.CellBounds.Y, e.CellBounds.Width - 16, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (colName == "colMuatanKualitas")
            {
                string grade = val.Replace("Grade", "").Trim();
                int circleSize = 24;
                int cx = e.CellBounds.X + (e.CellBounds.Width - circleSize) / 2;
                int cy = e.CellBounds.Y + (e.CellBounds.Height - circleSize) / 2;
                var crRect = new Rectangle(cx, cy, circleSize, circleSize);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brCr = new SolidBrush(Color.FromArgb(243, 224, 169)))
                using (var penCr = new Pen(Color.FromArgb(198, 137, 47), 1.2f))
                {
                    e.Graphics.FillEllipse(brCr, crRect);
                    e.Graphics.DrawEllipse(penCr, crRect);
                    using (var fn = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                    using (var tb = new SolidBrush(Color.FromArgb(122, 75, 26)))
                    {
                        var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        e.Graphics.DrawString(grade, fn, tb, crRect, sf);
                    }
                }
            }
            else if (colName == "colMuatanBerat")
            {
                using (var bfn = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var tb = new SolidBrush(C_TEXT_DARK))
                    e.Graphics.DrawString(val, bfn, tb, new Rectangle(e.CellBounds.X + 16, e.CellBounds.Y, e.CellBounds.Width - 16, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (colName == "colMuatanTgl")
            {
                using (var rfn = new Font("Segoe UI", 9F, FontStyle.Regular))
                using (var tb = new SolidBrush(C_TEXT_MUTED))
                    e.Graphics.DrawString(val, rfn, tb, new Rectangle(e.CellBounds.X + 16, e.CellBounds.Y, e.CellBounds.Width - 16, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (colName == "colMuatanStatus")
            {
                DrawMuatanStatusBadge(e.Graphics, e.CellBounds, "Di Gudang");
            }
            e.Handled = true;
        }

        private void BtnBuatSuratJalan_Click()
        {
            var selectedIds = new List<int>();
            foreach (DataGridViewRow row in dgvMuatanBarang.Rows)
            {
                if (Convert.ToBoolean(row.Cells["colMuatanCheck"].Value))
                {
                    selectedIds.Add(Convert.ToInt32(row.Cells["colMuatanId"].Value));
                }
            }

            if (selectedIds.Count == 0)
            {
                lblMuatanError.Visible = true;
                return;
            }

            lblMuatanError.Visible = false;

            try
            {
                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    foreach (int id in selectedIds)
                    {
                        using (var cmd = new SQLiteCommand("UPDATE tb_panen SET id_status_barang = 2 WHERE id_panen = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                ShowToast("Surat Jalan telah dibuat", $"{selectedIds.Count} muatan barang siap dikirim");
                LoadMuatanBarangData();
                LoadDashboardStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuat surat jalan: " + ex.Message);
            }
        }

        // ══════════════════════════════════════════════════════════
        // MANAJEMEN PENGGUNA (EXACT FIGMA REPLICA)
        // ══════════════════════════════════════════════════════════
        private void SwitchToUserPage(Button navBtn)
        {
            lblOtherTitle.Text = "Manajemen Pengguna";
            lblOtherSub.Text = "Akun yang dapat menggunakan aplikasi";
            SetupUserGrid();
            SwitchToPage(pnlOtherPage, navBtn);
            LoadUserData();
            LayoutAll();
        }

        private void SetupUserGrid()
        {
            dgvOther.Columns.Clear();
            dgvOther.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUserId", HeaderText = "ID", Visible = false });
            dgvOther.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUserNama", HeaderText = "Nama Lengkap", Width = 200 });
            dgvOther.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUserUname", HeaderText = "Nama Pengguna", Width = 180 });
            dgvOther.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUserPeran", HeaderText = "Peran", Width = 160 });
            dgvOther.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUserStatus", HeaderText = "Status", Width = 130 });
            dgvOther.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUserAksi", HeaderText = "Aksi", Width = 80 });

            dgvOther.CellPainting -= DgvUser_CellPainting;
            dgvOther.CellPainting += DgvUser_CellPainting;
            dgvOther.CellClick -= DgvUser_CellClick;
            dgvOther.CellClick += DgvUser_CellClick;
            dgvOther.CellMouseEnter -= DgvUser_CellMouseEnter;
            dgvOther.CellMouseEnter += DgvUser_CellMouseEnter;
        }

        private void DgvUser_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvOther.Columns["colUserAksi"].Index)
                dgvOther.Cursor = Cursors.Hand;
            else
                dgvOther.Cursor = Cursors.Default;
        }

        private void LoadUserData()
        {
            try
            {
                dgvOther.Rows.Clear();
                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT id_pengguna, COALESCE(nama_lengkap, username), username, COALESCE(peran, 'Admin'), is_aktif FROM tb_pengguna ORDER BY id_pengguna ASC";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int id = Convert.ToInt32(dr[0]);
                            string nama = dr[1].ToString();
                            string uname = dr[2].ToString();
                            string peran = dr[3].ToString();
                            int aktif = Convert.ToInt32(dr[4]);

                            dgvOther.Rows.Add(id, nama, uname, peran, aktif == 1 ? "Aktif" : "Tidak Aktif", "✎");
                        }
                    }
                }

                pnlOtherTableOuter.Height = 44 + (dgvOther.Rows.Count * 48) + 5;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat pengguna: " + ex.Message);
            }
        }

        private void DgvUser_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Color rowBg = (e.RowIndex % 2 == 0) ? Color.FromArgb(250, 244, 230) : Color.White;
            if ((e.State & DataGridViewElementStates.Selected) != 0) rowBg = Color.FromArgb(242, 237, 224);

            using (var brBg = new SolidBrush(rowBg)) e.Graphics.FillRectangle(brBg, e.CellBounds);
            using (var penLine = new Pen(Color.FromArgb(238, 232, 220), 1f))
                e.Graphics.DrawLine(penLine, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);

            string colName = dgvOther.Columns[e.ColumnIndex].Name;
            string val = e.Value?.ToString() ?? "";

            if (colName == "colUserNama")
            {
                using (var bfn = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var tb = new SolidBrush(C_TEXT_DARK))
                    e.Graphics.DrawString(val, bfn, tb, new Rectangle(e.CellBounds.X + 20, e.CellBounds.Y, e.CellBounds.Width - 20, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (colName == "colUserUname")
            {
                using (var rfn = new Font("Segoe UI", 9.2F, FontStyle.Regular))
                using (var tb = new SolidBrush(C_TEXT_MUTED))
                    e.Graphics.DrawString(val, rfn, tb, new Rectangle(e.CellBounds.X + 16, e.CellBounds.Y, e.CellBounds.Width - 16, e.CellBounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            else if (colName == "colUserPeran")
            {
                // Orange/Gold Badge for Role
                int badgeW = 100, badgeH = 26;
                int bx = e.CellBounds.X + (e.CellBounds.Width - badgeW) / 2;
                int by = e.CellBounds.Y + (e.CellBounds.Height - badgeH) / 2;
                var bRect = new Rectangle(bx, by, badgeW, badgeH);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = RoundedPath(bRect, 13))
                using (var br = new SolidBrush(Color.FromArgb(253, 229, 180)))
                using (var pen = new Pen(Color.FromArgb(224, 167, 69), 1.2f))
                {
                    e.Graphics.FillPath(br, path);
                    e.Graphics.DrawPath(pen, path);
                    using (var fn = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                    using (var tb = new SolidBrush(Color.FromArgb(122, 75, 26)))
                    {
                        var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        e.Graphics.DrawString(val, fn, tb, bRect, sf);
                    }
                }
            }
            else if (colName == "colUserStatus")
            {
                bool isAktif = val == "Aktif";
                int badgeW = isAktif ? 76 : 96;
                int badgeH = 26;
                int bx = e.CellBounds.X + (e.CellBounds.Width - badgeW) / 2;
                int by = e.CellBounds.Y + (e.CellBounds.Height - badgeH) / 2;
                var bRect = new Rectangle(bx, by, badgeW, badgeH);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = RoundedPath(bRect, 13))
                {
                    if (isAktif)
                    {
                        // Olive Green solid badge
                        using (var br = new SolidBrush(Color.FromArgb(154, 161, 119)))
                        using (var pen = new Pen(C_DARK_BORDER, 1.2f))
                        {
                            e.Graphics.FillPath(br, path);
                            e.Graphics.DrawPath(pen, path);
                            using (var fn = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                            using (var tb = new SolidBrush(Color.White))
                            {
                                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                                e.Graphics.DrawString("Aktif", fn, tb, bRect, sf);
                            }
                        }
                    }
                    else
                    {
                        // White badge with dark border
                        using (var br = new SolidBrush(Color.White))
                        using (var pen = new Pen(C_DARK_BORDER, 1.2f))
                        {
                            e.Graphics.FillPath(br, path);
                            e.Graphics.DrawPath(pen, path);
                            using (var fn = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                            using (var tb = new SolidBrush(C_TEXT_DARK))
                            {
                                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                                e.Graphics.DrawString("Tidak Aktif", fn, tb, bRect, sf);
                            }
                        }
                    }
                }
            }
            else if (colName == "colUserAksi")
            {
                // Pencil action icon
                int iconSz = 22;
                int ix = e.CellBounds.X + (e.CellBounds.Width - iconSz) / 2;
                int iy = e.CellBounds.Y + (e.CellBounds.Height - iconSz) / 2;
                DrawPencilAction(e.Graphics, e.CellBounds);
            }

            e.Handled = true;
        }

        private int _selectedEditUserId = -1;

        private void DgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOther.Columns.Contains("colUserAksi") && e.ColumnIndex == dgvOther.Columns["colUserAksi"].Index)
            {
                int idUser = Convert.ToInt32(dgvOther.Rows[e.RowIndex].Cells["colUserId"].Value);
                string nama = dgvOther.Rows[e.RowIndex].Cells["colUserNama"].Value?.ToString();
                string uname = dgvOther.Rows[e.RowIndex].Cells["colUserUname"].Value?.ToString();
                string peran = dgvOther.Rows[e.RowIndex].Cells["colUserPeran"].Value?.ToString();
                string status = dgvOther.Rows[e.RowIndex].Cells["colUserStatus"].Value?.ToString();

                OpenModalEditUser(idUser, nama, uname, peran, status);
            }
        }

        private void OpenModalTambahUser()
        {
            _selectedEditUserId = -1;
            lblModalUserTitle.Text = "Tambah Pengguna Baru";
            lblModalUserSubtitle.Text = "Isi data di bawah ini, lalu tekan Simpan";
            txtModalUserNama.Text = "";
            txtModalUserUname.Text = "";
            cmbModalUserPeran.SelectedIndex = 0;
            cmbModalUserStatus.SelectedIndex = 0;
            lblErrUserNama.Visible = false;
            lblErrUserUname.Visible = false;

            pnlModalCard.Visible = false;
            pnlModalProdukCard.Visible = false;
            pnlModalBatalCard.Visible = false;
            pnlModalUserCard.Visible = true;
            pnlModalOverlay.Visible = true;
            pnlModalOverlay.BringToFront();
            LayoutAll();
        }

        private void OpenModalEditUser(int id, string nama, string uname, string peran, string status)
        {
            _selectedEditUserId = id;
            lblModalUserTitle.Text = "Edit Pengguna";
            lblModalUserSubtitle.Text = "Perbarui data pengguna, lalu tekan Simpan";
            txtModalUserNama.Text = nama;
            txtModalUserUname.Text = uname;

            int peranIdx = cmbModalUserPeran.FindStringExact(peran);
            cmbModalUserPeran.SelectedIndex = peranIdx >= 0 ? peranIdx : 0;

            int stIdx = cmbModalUserStatus.FindStringExact(status);
            cmbModalUserStatus.SelectedIndex = stIdx >= 0 ? stIdx : 0;

            lblErrUserNama.Visible = false;
            lblErrUserUname.Visible = false;

            pnlModalCard.Visible = false;
            pnlModalProdukCard.Visible = false;
            pnlModalBatalCard.Visible = false;
            pnlModalUserCard.Visible = true;
            pnlModalOverlay.Visible = true;
            pnlModalOverlay.BringToFront();
            LayoutAll();
        }

        private void CloseModalUser()
        {
            pnlModalUserCard.Visible = false;
            pnlModalOverlay.Visible = false;
        }

        private void BtnModalUserSimpan_Click()
        {
            string nama = txtModalUserNama.Text.Trim();
            string uname = txtModalUserUname.Text.Trim();
            string peran = cmbModalUserPeran.SelectedItem?.ToString() ?? "Admin";
            int isAktif = (cmbModalUserStatus.SelectedItem?.ToString() == "Aktif") ? 1 : 0;

            bool hasErr = false;
            if (string.IsNullOrEmpty(nama))
            {
                lblErrUserNama.Visible = true;
                hasErr = true;
            }
            else lblErrUserNama.Visible = false;

            if (string.IsNullOrEmpty(uname))
            {
                lblErrUserUname.Visible = true;
                hasErr = true;
            }
            else lblErrUserUname.Visible = false;

            if (hasErr) return;

            int roleId = (peran == "Admin") ? 1 : (peran == "Petugas Gudang") ? 2 : 3;

            try
            {
                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    if (_selectedEditUserId == -1)
                    {
                        using (var cmd = new SQLiteCommand("INSERT INTO tb_pengguna (nama_lengkap, username, peran, id_role, is_aktif) VALUES (@n, @u, @p, @r, @a)", conn))
                        {
                            cmd.Parameters.AddWithValue("@n", nama);
                            cmd.Parameters.AddWithValue("@u", uname);
                            cmd.Parameters.AddWithValue("@p", peran);
                            cmd.Parameters.AddWithValue("@r", roleId);
                            cmd.Parameters.AddWithValue("@a", isAktif);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (var cmd = new SQLiteCommand("UPDATE tb_pengguna SET nama_lengkap = @n, username = @u, peran = @p, id_role = @r, is_aktif = @a WHERE id_pengguna = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@n", nama);
                            cmd.Parameters.AddWithValue("@u", uname);
                            cmd.Parameters.AddWithValue("@p", peran);
                            cmd.Parameters.AddWithValue("@r", roleId);
                            cmd.Parameters.AddWithValue("@a", isAktif);
                            cmd.Parameters.AddWithValue("@id", _selectedEditUserId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                CloseModalUser();
                LoadUserData();
                ShowToast($"Akun {nama} berhasil diperbarui", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data pengguna: " + ex.Message);
            }
        }

        private GraphicsPath RoundedPath(Rectangle r, int radius)
        {
            var p = new GraphicsPath();
            int d = radius * 2;
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        private GraphicsPath RoundedTopPath(Rectangle r, int radius)
        {
            var p = new GraphicsPath();
            int d = radius * 2;
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddLine(r.Right, r.Bottom, r.X, r.Bottom);
            p.CloseFigure();
            return p;
        }
    }
}
