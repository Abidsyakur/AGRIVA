using System;
using System.Data;
using System.Windows.Forms;
using AGRIVA.Controllers;

namespace AGRIVA
{
    public partial class ProdukPanenForms : Form
    {
        private readonly KomoditasController controller = new KomoditasController();

        public ProdukPanenForms()
        {
            InitializeComponent();
            colAksi.Text = "Edit";
            colAksi.UseColumnTextForButtonValue = true;
            LoadDataProduk();
        }

        private void LoadDataProduk()
        {
            DataTable data = controller.AmbilSemua();
            dgvProdukPanen.AutoGenerateColumns = false;
            colNamaProduk.DataPropertyName = "nama_komoditas";
            colHarga.DataPropertyName = "harga_per_kg";
            colTanggal.DataPropertyName = "tgl_update_harga";
            colStatus.DataPropertyName = "status";
            dgvProdukPanen.DataSource = data;
        }

        private void dgvProdukPanen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRowView row = dgvProdukPanen.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (row == null) return;
            int id = Convert.ToInt32(row["id_komoditas"]);

            if (e.ColumnIndex == colAksi.Index)
            {
                using (EntriProdukForm form = new EntriProdukForm(id))
                    if (form.ShowDialog() == DialogResult.OK) LoadDataProduk();
            }
            else if (e.ColumnIndex == colNonaktifkan.Index)
            {
                DialogResult hasil = MessageBox.Show("Yakin ingin menonaktifkan produk ini?",
                    "Konfirmasi", MessageBoxButtons.YesNo);
                if (hasil == DialogResult.Yes)
                {
                    try
                    {
                        controller.Nonaktifkan(id);
                        LoadDataProduk();
                        MessageBox.Show("Produk berhasil dinonaktifkan!");
                    }
                    catch (Exception ex) { MessageBox.Show("Gagal menonaktifkan produk: " + ex.Message); }
                }
            }
        }

        private void btnTambahData_Click(object sender, EventArgs e)
        {
            using (EntriProdukForm form = new EntriProdukForm())
                if (form.ShowDialog() == DialogResult.OK) LoadDataProduk();
        }
    }
}
