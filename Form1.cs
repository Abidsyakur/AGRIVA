using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace AGRIVA
{
    public partial class FormLogin : Form
    {
        private bool _userError = false;
        private bool _passError = false;
        private bool _showPassword = false;
        private Image _imgLogoLogin = null;

        public FormLogin()
        {
            InitializeComponent();
            SetupStylesAndEvents();
        }

        private void SetupStylesAndEvents()
        {
            // Center the card & logo dynamically
            this.Resize += (s, e) =>
            {
                picLogo.Left = (this.ClientSize.Width - picLogo.Width) / 2;
                pnlCard.Left = (this.ClientSize.Width - pnlCard.Width) / 2;
            };

            // Load exact Figma login logo
            try
            {
                string p1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo_login_clean.png");
                if (File.Exists(p1)) _imgLogoLogin = Image.FromFile(p1);
                else
                {
                    string p2 = @"D:\AGRIVA\Resources\logo_login_clean.png";
                    if (File.Exists(p2)) _imgLogoLogin = Image.FromFile(p2);
                }
                if (_imgLogoLogin != null)
                {
                    picLogo.Image = _imgLogoLogin;
                }
            }
            catch { }

            // Card Paint (Neo-Brutalist Solid Shadow + Rounded Card)
            pnlCard.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int rad = 16;
                int off = 5;
                int w = pnlCard.Width - off - 3;
                int h = pnlCard.Height - off - 3;

                // Solid Shadow
                using (var pathShadow = CreateRoundedRect(off, off, w, h, rad))
                using (var brShadow = new SolidBrush(Color.FromArgb(54, 44, 36)))
                {
                    pe.Graphics.FillPath(brShadow, pathShadow);
                }

                // White Card Body
                using (var pathCard = CreateRoundedRect(0, 0, w, h, rad))
                using (var brWhite = new SolidBrush(Color.White))
                using (var penDark = new Pen(Color.FromArgb(54, 44, 36), 1.6f))
                {
                    pe.Graphics.FillPath(brWhite, pathCard);
                    pe.Graphics.DrawPath(penDark, pathCard);
                }
            };

            // Username Box Paint
            pnlUserBox.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int rad = 8;
                var rect = new Rectangle(1, 1, pnlUserBox.Width - 3, pnlUserBox.Height - 3);
                using (var path = CreateRoundedRect(rect.X, rect.Y, rect.Width, rect.Height, rad))
                using (var br = new SolidBrush(Color.White))
                using (var pen = new Pen(_userError ? Color.FromArgb(222, 82, 82) : Color.FromArgb(60, 50, 42), _userError ? 1.6f : 1.2f))
                {
                    pe.Graphics.FillPath(br, path);
                    pe.Graphics.DrawPath(pen, path);
                }
            };

            // Password Box Paint
            pnlPassBox.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int rad = 8;
                var rect = new Rectangle(1, 1, pnlPassBox.Width - 3, pnlPassBox.Height - 3);
                using (var path = CreateRoundedRect(rect.X, rect.Y, rect.Width, rect.Height, rad))
                using (var br = new SolidBrush(Color.White))
                using (var pen = new Pen(_passError ? Color.FromArgb(222, 82, 82) : Color.FromArgb(60, 50, 42), _passError ? 1.6f : 1.2f))
                {
                    pe.Graphics.FillPath(br, path);
                    pe.Graphics.DrawPath(pen, path);
                }
            };

            // Eye Toggle Paint & Click
            pnlToggleEye.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Color col = Color.FromArgb(70, 60, 50);

                // Eye icon
                using (var penEye = new Pen(col, 1.4f))
                using (var brEye = new SolidBrush(col))
                {
                    float cx = 14f, cy = 14f;
                    // Upper and lower eye lids
                    pe.Graphics.DrawArc(penEye, cx - 8, cy - 6, 16, 12, 190, 160);
                    pe.Graphics.DrawArc(penEye, cx - 8, cy - 6, 16, 12, 10, 160);
                    pe.Graphics.FillEllipse(brEye, cx - 2.5f, cy - 2.5f, 5, 5);

                    if (_showPassword)
                    {
                        // Slash line over eye
                        pe.Graphics.DrawLine(penEye, cx - 7, cy + 6, cx + 7, cy - 6);
                    }
                }

                // Text "Lihat"
                using (var font = new Font("Segoe UI", 8.5F, FontStyle.Regular))
                using (var brush = new SolidBrush(col))
                {
                    pe.Graphics.DrawString("Lihat", font, brush, 26, 6);
                }
            };

            pnlToggleEye.Click += (s, e) =>
            {
                _showPassword = !_showPassword;
                txtPassword.PasswordChar = _showPassword ? '\0' : '●';
                pnlToggleEye.Invalidate();
            };

            // Button Masuk Paint
            btnMasuk.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int rad = 8;
                int off = 3;
                int w = btnMasuk.Width - off - 2;
                int h = btnMasuk.Height - off - 2;

                // Clear background with parent's backcolor (white)
                pe.Graphics.Clear(Color.White);

                // Shadow
                using (var pathShadow = CreateRoundedRect(off, off, w, h, rad))
                using (var brShadow = new SolidBrush(Color.FromArgb(54, 44, 36)))
                {
                    pe.Graphics.FillPath(brShadow, pathShadow);
                }

                // Button Body (#9DA272 - Olive Green)
                using (var pathBtn = CreateRoundedRect(0, 0, w, h, rad))
                using (var brBody = new SolidBrush(Color.FromArgb(157, 162, 114)))
                using (var penBorder = new Pen(Color.FromArgb(54, 44, 36), 1.5f))
                {
                    pe.Graphics.FillPath(brBody, pathBtn);
                    pe.Graphics.DrawPath(penBorder, pathBtn);
                }

                // Text & Arrow Icon
                Color textCol = Color.FromArgb(54, 44, 36);
                using (var font = new Font("Segoe UI", 10.5F, FontStyle.Bold))
                using (var brText = new SolidBrush(textCol))
                using (var penIcon = new Pen(textCol, 1.8f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                {
                    float midY = h / 2f;
                    float startX = (w - 75) / 2f;

                    // Arrow inside square login glyph
                    pe.Graphics.DrawLines(penIcon, new PointF[] {
                        new PointF(startX + 8, midY - 6),
                        new PointF(startX + 14, midY - 6),
                        new PointF(startX + 14, midY + 6),
                        new PointF(startX + 8, midY + 6)
                    });
                    pe.Graphics.DrawLine(penIcon, startX + 2, midY, startX + 11, midY);
                    pe.Graphics.DrawLine(penIcon, startX + 7, midY - 4, startX + 11, midY);
                    pe.Graphics.DrawLine(penIcon, startX + 7, midY + 4, startX + 11, midY);

                    pe.Graphics.DrawString("Masuk", font, brText, startX + 20, midY - 10);
                }
            };

            // Realtime Validation Reset on typing
            txtUsername.TextChanged += (s, e) =>
            {
                if (_userError && !string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    _userError = false;
                    lblErrUsername.Visible = false;
                    pnlUserBox.Invalidate();
                }
            };

            txtPassword.TextChanged += (s, e) =>
            {
                if (_passError && !string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    _passError = false;
                    lblErrPassword.Visible = false;
                    pnlPassBox.Invalidate();
                }
            };
        }

        private GraphicsPath CreateRoundedRect(int x, int y, int width, int height, int radius)
        {
            var path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(x, y, diameter, diameter);

            path.AddArc(arc, 180, 90);
            arc.X = x + width - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = y + height - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = x;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void btnMasuk_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            bool hasError = false;

            if (string.IsNullOrEmpty(username))
            {
                _userError = true;
                lblErrUsername.Visible = true;
                hasError = true;
            }
            else
            {
                _userError = false;
                lblErrUsername.Visible = false;
            }

            if (string.IsNullOrEmpty(password))
            {
                _passError = true;
                lblErrPassword.Visible = true;
                hasError = true;
            }
            else
            {
                _passError = false;
                lblErrPassword.Visible = false;
            }

            pnlUserBox.Invalidate();
            pnlPassBox.Invalidate();

            if (hasError)
            {
                return;
            }

            DashboardForm dashboard = new DashboardForm();
            dashboard.FormClosed += (s, args) => this.Close();
            dashboard.Show();

            this.Hide();
        }
    }
}
