using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace AGRIVA
{
    public partial class EntriPetaniForms : Form
    {
        public EntriPetaniForms()
        {
            InitializeComponent();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void EntriPetaniForms_Click(object sender, EventArgs e)
        { 
        }


        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (string.IsNullOrWhiteSpace(txtNamaPetani.Text) ||
                string.IsNullOrWhiteSpace(txtNoHP.Text) ||
                string.IsNullOrWhiteSpace(txtLuasLahan.Text) ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Semua data harus diisi!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Validasi luas lahan
            if (!double.TryParse(
                txtLuasLahan.Text,
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out double luasLahan))
            {
                MessageBox.Show("Luas lahan harus berupa angka. Gunakan titik untuk desimal.");
                return;
            }

            // Status Aktif = 1, Tidak Aktif = 0
            int statusAktif = cmbStatus.Text == "Aktif" ? 1 : 0;

            try
            {
                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();

                    string query = @"INSERT INTO tb_petani
                (nama_petani, desa, no_telepon, luas_lahan_hektar, is_aktif)
                VALUES
                (@nama,  @desa, @telepon, @luas, @status)";

                    using (var cmd = new System.Data.SQLite.SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", txtNamaPetani.Text.Trim());
                        cmd.Parameters.AddWithValue("@desa", txtDesa.Text.Trim());
                        cmd.Parameters.AddWithValue("@telepon", txtNoHP.Text.Trim());
                        cmd.Parameters.AddWithValue("@luas", luasLahan);
                        cmd.Parameters.AddWithValue("@status", statusAktif);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Data petani berhasil disimpan!",
                    "Berhasil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menyimpan data: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }



        }
    }
}
