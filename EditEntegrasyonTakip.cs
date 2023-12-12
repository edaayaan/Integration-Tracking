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
    public partial class EditEntegrasyonTakip : Form
    {
        EntegrasyonTakipDL entegrasyonTakipDL = new EntegrasyonTakipDL();
        public int id;
        public ListEntegrasyonTakip parentForm; // Üst formu tanımla

        public EditEntegrasyonTakip()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                LoadRecord(id);
            }
            else
            {
                ClearAllComponents(this);

            }

            labelBaslık.Font = new Font(labelBaslık.Font.FontFamily, 20);
            tbArac.MaxLength = 8;
            tbEıo.MaxLength = 7;

            dtpTarih.Format = DateTimePickerFormat.Custom;
            dtpTarih.CustomFormat = "dd.MM.yyyy  HH:mm";


        }

        public void LoadRecord(int recordId)
        {
            DataTable dt = entegrasyonTakipDL.GetDataByID(recordId);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                tbArac.Text = row["ARAC"].ToString();
                dtpTarih.Value = DateTime.Parse(row["TARIH"].ToString());
                tbEıo.Text = row["EIO"].ToString();
                rtbGuncelleme.Text = row["GUNCELLEMELER"].ToString();
                tbEntegratör.Text = row["ENTEGRATOR"].ToString();
                tbKisi.Text = row["TALEPEDEN"].ToString();
                tbAsw.Text = row["ASWLINKI"].ToString();
                tbLink.Text = row["ENTEGRASYONLINKI"].ToString();
            }
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            // Eğer insert ise
            if (id == 0)
            {
                entegrasyonTakipDL.InsertEntegrasyon(tbArac.Text, dtpTarih.Value, tbEıo.Text, rtbGuncelleme.Text, tbEntegratör.Text, tbKisi.Text, tbAsw.Text, tbLink.Text);
                MessageBox.Show("Kayıt başarıyla eklendi!");
            }

            else // Eğer update ise
            {
                Console.WriteLine($"Updating record with ID: {id}");

                entegrasyonTakipDL.UpdateEntegrasyon(id, tbArac.Text, dtpTarih.Value, tbEıo.Text, rtbGuncelleme.Text, tbEntegratör.Text, tbKisi.Text, tbAsw.Text, tbLink.Text);
                MessageBox.Show("Kayıt başarıyla güncellendi!");
            }

            this.Close();
            parentForm.FillGrid(); // Üst formdaki veriyi güncelle

        }
        public void ClearAllComponents(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else if (c is RichTextBox)
                    ((RichTextBox)c).Clear();
                else if (c is DateTimePicker)
                    ((DateTimePicker)c).Value = DateTime.Now;
                else if (c is NumericUpDown)
                    ((NumericUpDown)c).Value = 0;
                else if (c is ComboBox)
                    ((ComboBox)c).SelectedValue = 0;
                else
                    ClearAllComponents(c);
            }//yusufkayabm@gmail.com
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
                this.Close();
        }
    }
}

