using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGRIVA
{
    public partial class DataPetaniForms : Form
    {
        public DataPetaniForms()
        {
            InitializeComponent();
            LoadDataPetani();
        }
        private void LoadDataPetani()
        {
            try
            {
                using (var conn = Koneksi.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT
                id_petani,
                nama_petani,
                desa,
                no_telepon,
                luas_lahan_hektar,
                is_aktif
                FROM tb_petani";
                    using (var adapter = new System.Data.SQLite.SQLiteDataAdapter(query, conn))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        adapter.Fill(dt);

                        dgvTabelPetani.AutoGenerateColumns = false;

                        colNamaPetani.DataPropertyName = "nama_petani";
                        colDesa.DataPropertyName = "desa";
                        colNoHP.DataPropertyName = "no_telepon";
                        colLuasLahan.DataPropertyName = "luas_lahan_hektar";
                        colStatus.DataPropertyName = "is_aktif";

                        dgvTabelPetani.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data petani: " + ex.Message);
            }
        }

        private void lblNamaUser_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnPetani_Click(object sender, EventArgs e)
        {

        }

        private void btnTambahData_Click(object sender, EventArgs e)
        {
            EntriPetaniForms form = new EntriPetaniForms();
            form.ShowDialog();

            LoadDataPetani();
        }

        private void dgvTabelPetani_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnProdukPanen_Click(object sender, EventArgs e)
        {

        }

        private void DataPetaniForms_Load(object sender, EventArgs e)
        {

        }
    }
}
