using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AGRIVA
{
    public partial class EntriProdukForm : Form
    {
        private int idProduk = 0;
        public EntriProdukForm()
        {
            InitializeComponent();
        }
        public EntriProdukForm(int id)
        {
            InitializeComponent();
            idProduk = id;

            using (SQLiteConnection conn = Koneksi.GetConnection())
            {
                conn.Open();

                string query = "SELECT * FROM tb_komoditas WHERE id_komoditas = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtNamaProduk.Text = reader["nama_komoditas"].ToString();
                            txtHarga.Text = reader["harga_per_kg"].ToString();
                            cmbStatus.SelectedItem =
                                Convert.ToInt32(reader["is_aktif"]) == 1
                                ? "Aktif" : "Tidak Aktif";
                        }
                    }
                }
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // Validasi data kosong
            if (string.IsNullOrWhiteSpace(txtNamaProduk.Text) ||
                string.IsNullOrWhiteSpace(txtHarga.Text) ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Semua data harus diisi!");
                return;
            }

            // Validasi harga
            if (!int.TryParse(txtHarga.Text, out int harga) || harga <= 0)
            {
                MessageBox.Show("Harga harus berupa angka lebih dari 0!");
                return;
            }

            // Konversi status
            int status = cmbStatus.SelectedItem.ToString() == "Aktif" ? 1 : 0;

            try
            {
                using (SQLiteConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();

                    string query;

                    if (idProduk == 0)
                    {
                        query = @"
    INSERT INTO tb_komoditas
    (nama_komoditas, harga_per_kg, tgl_update_harga, is_aktif)
    VALUES (@nama, @harga, @tanggal, @status)";
                    }
                    else
                    {
                        query = @"
    UPDATE tb_komoditas
    SET nama_komoditas = @nama,
        harga_per_kg = @harga,
        tgl_update_harga = @tanggal,
        is_aktif = @status
    WHERE id_komoditas = @id";
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", txtNamaProduk.Text.Trim());
                        cmd.Parameters.AddWithValue("@harga", harga);
                        cmd.Parameters.AddWithValue("@tanggal", DateTime.Now);
                        cmd.Parameters.AddWithValue("@status", status);

                        if (idProduk != 0)
                            cmd.Parameters.AddWithValue("@id", idProduk);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Produk berhasil disimpan!");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan produk: " + ex.Message);
            }
        }
    }
}
