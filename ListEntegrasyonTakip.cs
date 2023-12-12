using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntegrasyonTakip
{
    public partial class ListEntegrasyonTakip : Form
    {
        EditEntegrasyonTakip edtForm = new EditEntegrasyonTakip();
        EntegrasyonTakipDL entegrasyonTakipDL = new EntegrasyonTakipDL();
        public ListEntegrasyonTakip()
        {
            InitializeComponent();
            edtForm.parentForm = this; // Bu formu EditEntegrasyonTakip formuna referans olarak gönder

        }


       
        public void FillGrid()
        {
            dgView.DataSource = entegrasyonTakipDL.GetListe();
            dgView.Columns["ID"].Visible = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            edtForm.id = 0;
            edtForm.ShowDialog();
            FillGrid();
        }

      
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgView.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dgView.SelectedRows[0].Index;
                int idToDelete = int.Parse(dgView.Rows[selectedRowIndex].Cells["ID"].Value.ToString());

                DialogResult dialogResult = MessageBox.Show("Seçili satırı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    entegrasyonTakipDL.DeleteEntegrasyon(idToDelete);
                    MessageBox.Show("Kayıt başarıyla silindi!");
                    FillGrid();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçin.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgView.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dgView.SelectedRows[0].Index;
                int idToUpdate = int.Parse(dgView.Rows[selectedRowIndex].Cells["ID"].Value.ToString());

                edtForm.id = idToUpdate; // Seçili kaydın ID'sini EditEntegrasyonTakip formuna aktar
                edtForm.ShowDialog();
                FillGrid();
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz satırı seçin.");
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}
