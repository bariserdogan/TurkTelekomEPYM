using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Deneme1
{
    public partial class ProjeIslemleri : Form
    {
        public ProjeIslemleri()
        {
            InitializeComponent();
        }
        int pretime;
        private void ProjeIslemleri_Load(object sender, EventArgs e)
        {
            btn_Hesapla.Text = "H" + "\n" + "E" + "\n" + "S" + "\n" + "A" + "\n" + "P" + "\n" + "L" + "\n" + "A";
            btn_Hesapla.ForeColor = Color.White;
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
                writeDatatoTamamlama(cbs);                         
                var gelen = db.Aksiyonlar.Where(x => x.CBS_ID == girilen2).FirstOrDefault();             
                if (gelen != null)
                {
                    txt_baslangic_tarihi.Text = gelen.Baslangic_Tarih.ToString();
                    txt_bitis_tarihi.Text = gelen.Bitis_Tarih.ToString();
                    System.Threading.Thread.Sleep(1000);
                    tabControl1.SelectedTab = tabPage3;
                    var query = from a in db.Aksiyonlar
                                where a.CBS_ID == girilen2
                                select new
                                {
                                    cbs_id = a.CBS_ID,
                                    islem = a.Islem,
                                    gerekce = a.Gerekce,
                                    islem_tarihi = a.Islem_Tarih,
                                    kalan_sure = a.Kalan_Sure,
                                    calisilan_sure = a.Kalan_Sure
                                };

                    dataGridView1.DataSource = query.ToList();
                    
                    //TamamlamaTutanak tamamlama = new TamamlamaTutanak();
                    //tamamlama.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Belirtilen ID ile ilgili işlem geçmişi bulunamadı", "Info", MessageBoxButtons.OK);
                    writeDatatoBaslatma(cbs);
                    tabControl1.SelectedTab = tabPage2;

                }
            }
            else
            {
                MessageBox.Show("İlerleme tablosunda girilen CBS ID'ye ait kayıt bulunamadı", "Info", MessageBoxButtons.OK);
                textBox_ID.Clear();
            }
        }
        public void writeDatatoTamamlama(Ilerleme model)
        {
            tamamlama_cbs_id.Text = model.ID.ToString();
            tamamlama_cizim_adi.Text = model.CIZIM_ADI.ToString();
            tamamlama_telekom.Text = model.TELEKOM_MUDURLUGU.ToString();
            tamamlama_proje_ozelligi.Text = model.PROJE_OZELLIGI.ToString();
            tamamlama_proje_adi.Text = model.PROJE_ADI.ToString();
            tamamlama_santral_adi.Text = model.SANTRAL_ADI.ToString();
        }
        public void writeDatatoBaslatma(Ilerleme model)
        {
            textBoxCBS_ID.Text = model.ID.ToString();
            textBoxCIZIM_ADI.Text = model.CIZIM_ADI.ToString();
            textBoxTelekom_Mudurlugu.Text = model.TELEKOM_MUDURLUGU.ToString();
            textBoxpProjeOzelligi.Text = model.PROJE_OZELLIGI.ToString();
            textBoxProjeAdi.Text = model.PROJE_ADI.ToString();
            textBoxSantral_Adi.Text = model.SANTRAL_ADI.ToString();
        }
        public void sureHesapla()
        {
            DateTime aybasi = new DateTime(2017, 8, 1);
            pretime = Convert.ToInt32(aybasi - DateTime.Now);
            double acikkazi = Convert.ToDouble(txt_AcikKazi.Text);
            double fider = Convert.ToDouble(txt_Fider.Text);
            double trencher = Convert.ToDouble(txt_Trencher.Text);
            double kazser = Convert.ToDouble(txt_KAZSER1.Text);
            double yeralti = Convert.ToDouble(txt_yeralti.Text);
            double yenihavai = Convert.ToDouble(txt_yenihavai.Text);
            double mevcuthavai = Convert.ToDouble(txt_mevcuthavai.Text);
            double kazser2 = Convert.ToDouble(textbox_kazser2.Text);
            double outdoor = Convert.ToDouble(txt_outdoorkabin.Text);
            double indoor = Convert.ToDouble(txt_indoor_kabin.Text);
            double aktarma = Convert.ToDouble(txt_aktarma.Text);
            double binaici = Convert.ToDouble(txt_binaici.Text);
            

        }
        
        
    }
}
