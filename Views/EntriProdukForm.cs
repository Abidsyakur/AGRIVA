using System;
using System.Windows.Forms;
using AGRIVA.Controllers;
using AGRIVA.Models;

namespace AGRIVA
{
    public partial class EntriProdukForm : Form
    {
        private readonly int idProduk;
        private readonly KomoditasController controller = new KomoditasController();

        public EntriProdukForm() { InitializeComponent(); }

        public EntriProdukForm(int id) : this()
        {
            idProduk = id;
            Komoditas produk = controller.AmbilBerdasarkanId(id);
            if (produk != null)
            {
                txtNamaProduk.Text = produk.NamaKomoditas;
                txtHarga.Text = produk.HargaPerKg.ToString();
                cmbStatus.SelectedItem = produk.IsAktif == 1 ? "Aktif" : "Tidak Aktif";
            }
        }

        private void btnBatal_Click(object sender, EventArgs e) { Close(); }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaProduk.Text) ||
                string.IsNullOrWhiteSpace(txtHarga.Text) || cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Semua data harus diisi!");
                return;
            }
            int harga;
            if (!int.TryParse(txtHarga.Text, out harga) || harga <= 0)
            {
                MessageBox.Show("Harga harus berupa angka lebih dari 0!");
                return;
            }
            try
            {
                controller.Simpan(new Komoditas
                {
                    IdKomoditas = idProduk,
                    NamaKomoditas = txtNamaProduk.Text.Trim(),
                    HargaPerKg = harga,
                    IsAktif = cmbStatus.SelectedItem.ToString() == "Aktif" ? 1 : 0
                });
                MessageBox.Show("Produk berhasil disimpan!");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) { MessageBox.Show("Gagal menyimpan produk: " + ex.Message); }
        }
    }
}
