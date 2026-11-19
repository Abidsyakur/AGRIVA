using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGRIVA
{
    public partial class ProdukPanenForms : Form
    {
        public ProdukPanenForms()
        {
            InitializeComponent();
            colAksi.Text = "Edit";
            colAksi.UseColumnTextForButtonValue = true;
            LoadDataProduk();
        }

        private void LoadDataProduk()
        {
            using (SQLiteConnection conn = Koneksi.GetConnection())
            {
                conn.Open();

                string query = @"SELECT
                         id_komoditas,
                         nama_Komoditas,
                         harga_per_kg,
                         tgl_update_harga,
                         CASE
                            WHEN is_aktif = 1 THEN 'Aktif' 
                            ELSE 'Tidak Aktif'
                         END AS status
                         FROM tb_komoditas";

                using (SQLiteDataAdapter adapter =
                       new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvProdukPanen.AutoGenerateColumns = false;
                    colNamaProduk.DataPropertyName = "nama_Komoditas";
                    colHarga.DataPropertyName = "harga_per_kg";
                    colTanggal.DataPropertyName = "tgl_update_harga";
                    colStatus.DataPropertyName = "status";

                    dgvProdukPanen.DataSource = dt;
                }
            }
        }

        private void dgvProdukPanen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataRowView row = (DataRowView)dgvProdukPanen.Rows[e.RowIndex].DataBoundItem;
            int id = Convert.ToInt32(row["id_komoditas"]);

            if (e.ColumnIndex == colAksi.Index)
            {
                using (EntriProdukForm form = new EntriProdukForm(id))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                        LoadDataProduk();
                }
            }
            else if (e.ColumnIndex == colNonaktifkan.Index)
            {
                DialogResult hasil = MessageBox.Show(
                    "Yakin ingin menonaktifkan produk ini?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo
                );

                if (hasil == DialogResult.Yes)
                {
                    using (SQLiteConnection conn = Koneksi.GetConnection())
                    {
                        conn.Open();

                        string query = "UPDATE tb_komoditas SET is_aktif = 0 WHERE id_komoditas = @id";

                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    LoadDataProduk();
                    MessageBox.Show("Produk berhasil dinonaktifkan!");
                }
            }
            LoadDataProduk();
                MessageBox.Show("Produk berhasil dinonaktifkan!");
            }
        private void btnTambahData_Click(object sender, EventArgs e)
        {
            using (EntriProdukForm form = new EntriProdukForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {

                    LoadDataProduk();
                }


            }
        }
    }
}