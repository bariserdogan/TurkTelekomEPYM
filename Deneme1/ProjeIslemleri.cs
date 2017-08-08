using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deneme1
{
    public partial class ProjeIslemleri : Form
    {
        public ProjeIslemleri()
        {
            InitializeComponent();
        }
        ProjeTakipSistEntities db = new ProjeTakipSistEntities();
        private void txt_AltyapiMaliyeti_TextChanged(object sender, EventArgs e)
        {
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void btn_Arama_Click(object sender, EventArgs e)
        {
            int girilen = int.Parse(textBox_ID.Text);
            string girilen2 = textBox_ID.Text;
            var cbs = db.Ilerleme.Where(x => x.ID == girilen).FirstOrDefault();
            if (cbs != null)
            {
                var gelen = db.Aksiyonlar.Where(x => x.CBS_ID == girilen2).FirstOrDefault();
                if (gelen == null)
                    MessageBox.Show("Yeni kayıt oluşturmanız gerekmektedir", "Info", MessageBoxButtons.OK);
                else
                {
                    textBoxCBS_ID.Text = cbs.ID.ToString();
                    textBoxCIZIM_ADI.Text = cbs.CIZIM_ADI.ToString();
                    textBoxTelekom_Mudurlugu.Text = cbs.TELEKOM_MUDURLUGU.ToString();
                    textBoxpProjeOzelligi.Text = cbs.PROJE_OZELLIGI.ToString();
                    textBoxProjeAdi.Text = cbs.PROJE_ADI.ToString();
                    textBoxSantral_Adi.Text = cbs.SANTRAL_ADI.ToString();
                    txt_Sure.Text = gelen.Proje_Sure.ToString();
                }
            }
            else
                MessageBox.Show("İlerleme tablosunda girilen CBS ID'ye ait kayıt bulunamadı", "Info", MessageBoxButtons.OK);

        }
    }
}
