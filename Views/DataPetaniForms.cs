using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGRIVA.Controllers;

namespace AGRIVA
{
    public partial class DataPetaniForms : Form
    {
        public DataPetaniForms()
        {
            InitializeComponent();
            LoadDataPetani();
        }
        private readonly PetaniController petaniController = new PetaniController();

        private void LoadDataPetani()
        {
            try
            {
                System.Data.DataTable dt = petaniController.GetDataPetani();
                dgvTabelPetani.AutoGenerateColumns = false;
                colNamaPetani.DataPropertyName = "nama_petani";
                colDesa.DataPropertyName = "desa";
                colNoHP.DataPropertyName = "no_telepon";
                colLuasLahan.DataPropertyName = "luas_lahan_hektar";
                colStatus.DataPropertyName = "is_aktif";
                dgvTabelPetani.DataSource = dt;
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
