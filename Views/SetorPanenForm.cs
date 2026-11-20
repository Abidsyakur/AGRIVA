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
    public partial class SetorPanenForm : Form
    {
        public SetorPanenForm()
        {
            InitializeComponent();
        }

        private void SetorPanenForm_Load(object sender, EventArgs e)
        {

        }

        private void btnKosongkan_Click(object sender, EventArgs e)
        {
            cmbPetani.SelectedIndex = -1;
            cmbProduk.SelectedIndex = -1;
            txtBerat.Text = "";
            cmbKualitas.SelectedIndex = -1;
        }
    }
}
