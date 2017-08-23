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
        Kullanici user; 
        public ProjeIslemleri(Kullanici k)
        {
            this.user = k;
            InitializeComponent();
            if (string.IsNullOrEmpty(this.txt_Sure.Text))
                btn_ProjeKaydet.Enabled = false;
            else
                btn_ProjeKaydet.Enabled = true;
            //btn_ProjeTeslim.Enabled = false;
        }
        int pretime;
        double jobtime;
        double acikkazi, fider, trencher, kazser, yeralti, yenihavai, mevcuthavai, kazser2, outdoor, indoor, aktarma, binaici;
        int girilen;
        string varMi = "Var";
        private void ProjeIslemleri_Load(object sender, EventArgs e)
        {
            btn_Hesapla.Text = "H" + "\n" + "E" + "\n" + "S" + "\n" + "A" + "\n" + "P" + "\n" + "L" + "\n" + "A";
            btn_ProjeKaydet.Text = "P" + "\n" + "R" + "\n" + "O" + "\n" + "J" + "\n" + "E" + "\n" + "K" + "\n" + "A" + "\n" + "Y" + "\n" + "D" + "\n" + "E" + "\n" + "T";
            btn_Hesapla.ForeColor = Color.White;
            btn_ProjeKaydet.ForeColor = Color.Red;
        }
        ProjeTakipSistEntities entity;
        ProjeTakipSistEntities db
        {
            get
            {
                if (entity == null)
                    entity = new ProjeTakipSistEntities();
                return entity;
            }
        }
        private void btn_ProjeTeslim_Click(object sender, EventArgs e)
        {
            string girilen2 = textBox_ID.Text;
            List<Aksiyonlar> gelenler = db.Aksiyonlar.Where(x => x.CBS_ID == girilen2).ToList();
            int sayı = gelenler.Count();
            var teslim = gelenler.First();
            DateTime tbt = DateTime.Parse(teslim.Baslangic_Tarih.ToString());
            DateTime ttt = DateTime.Parse(teslim.Bitis_Tarih.ToString());
            if (teslim != null)
            {
                teslim.Baslangic_Tarih = tbt.AddDays(7);
                teslim.Bitis_Tarih = ttt.AddDays(7);//dateTimePickerBaslangic.Value.AddDays((Convert.ToInt32(gelen.Proje_Sure) + 7));
                // Başlangıç ve Bitiş tarihine  7 gün avans eklendi.
                teslim.Islem = "Proje Teslim";
                teslim.Gerekce = "Proje Teslim";
                teslim.Islem_Tarih = DateTime.Now;
                Aksiyonlar aksiyon = new Aksiyonlar();
                aksiyon = teslim;
                db.Aksiyonlar.Add(aksiyon);
                db.SaveChanges();
                List<Aksiyonlar> actions = db.Aksiyonlar.Where(x => x.CBS_ID == girilen2).ToList();
                foreach (Aksiyonlar item in actions)
                {
                    // Aksiyonlar tablosundaki id ile ilgili satırların proje başlangıç ve bitiş tarihleri güncellendi.
                    item.Baslangic_Tarih = tbt.AddDays(7);
                    item.Bitis_Tarih = ttt.AddDays(7);
                    db.SaveChanges();
                }
                btn_ProjeTeslim.Enabled = false;
                KullaniciHareketleri(user, aksiyon);
                MessageBox.Show("Yeni bir aksiyon eklendi : Proje müteahhite teslim edilmiştir", "Info", MessageBoxButtons.OK);
                printTamamlama(teslim);
                tabControl1.SelectedTab = tabPage3;
            }
            else
                MessageBox.Show("Beklenmedik bir hata meydana geldi");
        }
        private void btn_Arama_Click(object sender, EventArgs e)
        {
            girilen = int.Parse(textBox_ID.Text);
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
        private void btn_sure_baslatma_Click(object sender, EventArgs e)
        {
            string girilen2 = textBox_ID.Text;
            var proje = db.Aksiyonlar.Where(x => x.CBS_ID == girilen2);
            string date = DateTime.Now.ToString("dd-MM-yyyy"); // İşlem tarihi o anki tarih olacak.
            string combo = "";
            try
            {
                combo = ((string)comboBoxsure_baslatma.SelectedItem).ToString(); // combobox gerekçe     
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString());
            }
            if (proje.Count() > 0)
            {
                if (combo != "") // bir gerekçe varsa
                {
                    var newaction = proje.FirstOrDefault();
                    newaction.Gerekce = combo.ToString();
                    newaction.Islem_Tarih = Convert.ToDateTime(date);
                    newaction.Islem = "Süre Başlatma";
                    Aksiyonlar aksiyon = new Aksiyonlar();
                    aksiyon = newaction;
                    db.Aksiyonlar.Add(aksiyon);
                    db.SaveChanges();
                    KullaniciHareketleri(user, aksiyon);
                    MessageBox.Show("Yeni bir işlem aksiyonlar tablosuna eklendi", "Süre Başlatma", MessageBoxButtons.OKCancel);
                    var query = from a in db.Aksiyonlar // işlem sonrası datagridview'i yeniliyoruz.
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
                    MessageBox.Show("Aksiyon Bilgileri yenilenmiştir");
                    btn_sure_baslatma.Enabled = false;
                    btn_Sure_Durdurma.Enabled = true;
                }
                else
                    MessageBox.Show("Lütfen süre başlatma için bir gerekçe seçiniz.");
            }
            else
                MessageBox.Show("Belirtilen Id numarası ile ilgili işlem kaydı bulunamadı");
        }

        private void btn_Sure_Durdurma_Click(object sender, EventArgs e)
        {
            string girilen2 = textBox_ID.Text;
            var proje = db.Aksiyonlar.Where(x => x.CBS_ID == girilen2);
            string date = DateTime.Now.ToString("dd-MM-yyyy"); // İşlem tarihi o anki tarih olacak.
            string combo = "";
            try
            {
                combo = ((string)comboBoxsure_durdurma.SelectedItem).ToString(); // combobox gerekçe     
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString());
            }
            if (proje.Count() > 0)
            {
                if (combo != "") // bir gerekçe varsa
                {
                    var newaction = proje.FirstOrDefault();
                    newaction.Gerekce = combo.ToString();
                    newaction.Islem_Tarih = Convert.ToDateTime(date);
                    newaction.Islem = "Süre Durdurma";
                    Aksiyonlar aksiyon = new Aksiyonlar();
                    aksiyon = newaction;
                    db.Aksiyonlar.Add(aksiyon);
                    db.SaveChanges();
                    KullaniciHareketleri(user, aksiyon);
                    MessageBox.Show("Yeni bir işlem aksiyonlar tablosuna eklendi", "Süre Durdurma", MessageBoxButtons.OKCancel);
                    var query = from a in db.Aksiyonlar // işlem sonrası datagridview'i yeniliyoruz.
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
                    //IQueryable query = RefreshDatagridView.Refresh(girilen2);
                    dataGridView1.DataSource = query.ToList();
                    MessageBox.Show("Aksiyon Bilgileri yenilenmiştir");
                    btn_Sure_Durdurma.Enabled = false;
                    btn_sure_baslatma.Enabled = true;
                }
                else
                    MessageBox.Show("Lütfen süre başlatma için bir gerekçe seçiniz.");
            }
            else
                MessageBox.Show("Belirtilen Id numarası ile ilgili işlem kaydı bulunamadı");
        }

        private void btn_Hesapla_Click(object sender, EventArgs e)
        {
            DateTime aybasi = new DateTime(2017, 8, 1);
            DateTime dt = DateTime.Now;
            TimeSpan tspan = dt.Subtract(aybasi);
            pretime = tspan.Days;
            int uygunmu = Convert.ToInt32(sureHesapla());
            if (uygunmu > pretime)
            {
                if (uygunmu < 7)
                {
                    jobtime = 7;
                    txt_Sure.Text = jobtime.ToString();
                    MessageBox.Show("Uygunluk sağlanmıştır");
                    if (!btn_ProjeKaydet.Enabled)
                        btn_ProjeKaydet.Enabled = true;
                }
                else
                {
                    jobtime = jobtime + 7;
                    txt_Sure.Text = jobtime.ToString();
                    MessageBox.Show("Uygunluk sağlanmıştır");
                    if (!btn_ProjeKaydet.Enabled)
                        btn_ProjeKaydet.Enabled = true;
                }
            }
            else
            {
                btn_ProjeKaydet.Enabled = false;
                MessageBox.Show("Süreç uygun değil.Kayıt yapabilmek için lütfen bilgileri kontrol ediniz.", "Bilgi", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HareketlerForm hareket = new HareketlerForm(user);
            hareket.ShowDialog();
        }

        private void btn_ProjeKaydet_Click_1(object sender, EventArgs e)
        {

            var cbs = db.Ilerleme.Where(x => x.ID == girilen).FirstOrDefault();
            if (comboBox_varyok.Text == varMi)
            {
                if (dateTimePickerBaslangic.Value != null)
                {
                    Aksiyonlar aksiyon = new Aksiyonlar
                    {
                        CBS_ID = girilen.ToString(),
                        Cizim_Adi = textBoxCIZIM_ADI.Text.ToString(),
                        Altyapi_Maliyeti = float.Parse(txt_AltyapiMaliyeti.Text),
                        Telekom_Mud = textBoxTelekom_Mudurlugu.Text.ToString(),
                        Proje_Turu = textBoxpProjeOzelligi.Text.ToString(),
                        Proje_Adi = textBoxProjeAdi.Text.ToString(),
                        Santral = textBoxSantral_Adi.Text.ToString(),
                        Acik_Kazi = float.Parse(txt_AcikKazi.Text),
                        Fider = txt_Fider.Text.ToString(),
                        Trencher = txt_Trencher.Text.ToString(),
                        Kazser = txt_KAZSER1.Text.ToString(),
                        Yeralti_Guzergahincan = float.Parse(txt_yeralti.Text),
                        Yeni_Havi_Guzergahtan = txt_yenihavai.Text.ToString(),
                        Mevcut_Havai_Guzergahtan = txt_mevcuthavai.Text.ToString(),
                        Kazser_Guzergahtan = textbox_kazser2.Text.ToString(),
                        FTTC_OFSD_OFTK = txt_outdoorkabin.Text.ToString(),
                        FTTB_3_48U_Kabin = float.Parse(txt_indoor_kabin.Text),
                        Aktarma = float.Parse(txt_aktarma.Text),
                        Bina_ici_Kablolama = txt_binaici.Text.ToString(),
                        Islem = "Yeni Kayıt",
                        Islem_Tarih = DateTime.Now,
                        Gerekce = "Yeni Kayıt",
                        Baslangic_Tarih = dateTimePickerBaslangic.Value,
                        Bitis_Tarih = dateTimePickerBaslangic.Value.AddDays(Convert.ToInt32(jobtime)),
                        Proje_Sure = float.Parse(jobtime.ToString()),
                    };
                    db.Aksiyonlar.Add(aksiyon);
                    db.SaveChanges();
                    btn_ProjeTeslim.Enabled = true;
                    KullaniciHareketleri(user, aksiyon);
                    MessageBox.Show("Yeni bir kayıt aksiyonlar tablosuna eklendi", "Bilgi", MessageBoxButtons.OKCancel);                    
                    writeDatatoTamamlama(cbs);
                    txt_baslangic_tarihi.Text = String.Format("{0:dd/MM/yyyy}", aksiyon.Baslangic_Tarih);// proje başlangıç tarihi
                    txt_bitis_tarihi.Text = String.Format("{0:dd/MM/yyyy}", aksiyon.Bitis_Tarih); // proje bitiş tarihi

                }
                else
                    MessageBox.Show("Tarih seçimi yapınız");
            }
            else
                MessageBox.Show("Kayıt yapabilmek için yeraltısız imalat var mı seçeneğini 'Var' yapmanız gerekir.");
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
        public void printTamamlama(Aksiyonlar model)
        {
            tamamlama_cbs_id.Text = model.CBS_ID.ToString();
            tamamlama_cizim_adi.Text = model.Cizim_Adi.ToString();
            tamamlama_telekom.Text = model.Telekom_Mud.ToString();
            tamamlama_proje_ozelligi.Text = model.Proje_Turu.ToString();
            tamamlama_proje_adi.Text = model.Proje_Adi.ToString();
            tamamlama_santral_adi.Text = model.Santral.ToString();
            txt_baslangic_tarihi.Text = model.Baslangic_Tarih.ToString();
            txt_bitis_tarihi.Text = model.Bitis_Tarih.ToString();
        }
        public void writeDatatoBaslatma(Ilerleme model)
        {
            textBoxCBS_ID.Text = model.ID.ToString();
            textBoxCIZIM_ADI.Text = model.CIZIM_ADI.ToString();
            textBoxTelekom_Mudurlugu.Text = model.TELEKOM_MUDURLUGU.ToString();
            textBoxpProjeOzelligi.Text = model.PROJE_OZELLIGI.ToString();
            textBoxProjeAdi.Text = model.PROJE_ADI.ToString();
            textBoxSantral_Adi.Text = model.SANTRAL_ADI.ToString();
            //dateTimePickerBaslangic.Value = Convert.ToDateTime(model.BASLANGIC_TARIH);
        }


        public double sureHesapla()
        {
            if (String.IsNullOrEmpty(txt_AcikKazi.Text))
                txt_AcikKazi.Text = "0";
            if (String.IsNullOrEmpty(txt_Fider.Text))
                txt_Fider.Text = "0";
            if (String.IsNullOrEmpty(txt_Trencher.Text))
                txt_Trencher.Text = "0";
            if (String.IsNullOrEmpty(txt_KAZSER1.Text))
                txt_KAZSER1.Text = "0";
            if (String.IsNullOrEmpty(txt_yeralti.Text))
                txt_yeralti.Text = "0";
            if (String.IsNullOrEmpty(txt_yenihavai.Text))
                txt_yenihavai.Text = "0";
            if (String.IsNullOrEmpty(txt_mevcuthavai.Text))
                txt_mevcuthavai.Text = "0";
            if (String.IsNullOrEmpty(textbox_kazser2.Text))
                textbox_kazser2.Text = "0";
            if (String.IsNullOrEmpty(txt_outdoorkabin.Text))
                txt_outdoorkabin.Text = "0";
            if (String.IsNullOrEmpty(txt_indoor_kabin.Text))
                txt_indoor_kabin.Text = "0";
            if (String.IsNullOrEmpty(txt_aktarma.Text))
                txt_aktarma.Text = "0";
            if (String.IsNullOrEmpty(txt_binaici.Text))
                txt_binaici.Text = "0";

            acikkazi = Convert.ToDouble(txt_AcikKazi.Text);
            fider = Convert.ToDouble(txt_Fider.Text);
            trencher = Convert.ToDouble(txt_Trencher.Text);
            kazser = Convert.ToDouble(txt_KAZSER1.Text);
            yeralti = Convert.ToDouble(txt_yeralti.Text);
            yenihavai = Convert.ToDouble(txt_yenihavai.Text);
            mevcuthavai = Convert.ToDouble(txt_mevcuthavai.Text);
            kazser2 = Convert.ToDouble(textbox_kazser2.Text);
            outdoor = Convert.ToDouble(txt_outdoorkabin.Text);
            indoor = Convert.ToDouble(txt_indoor_kabin.Text);
            aktarma = Convert.ToDouble(txt_aktarma.Text);
            binaici = Convert.ToDouble(txt_binaici.Text);

            jobtime = Math.Ceiling(((acikkazi / 250) * 1) + ((fider / 100) * 1) + ((trencher / 900) * 1) + ((kazser / 300) * 1) + ((yeralti / 1000) * 4) + ((yenihavai / 1000) * 4) + ((mevcuthavai / 1000) * 2) + ((kazser2 / 1000) * 2) + (outdoor * 3) + (indoor * 1) + ((aktarma / 5) * 1) + ((binaici / 30) * 1));
            return jobtime;
        }

        public void KullaniciHareketleri(Kullanici k, Aksiyonlar a)
        {
            if(k !=null && a != null)
            {
                var hareket = new KullaniciHareket
                {
                    User_id = k.ID,
                    Islem = a.Islem,
                    Gerekce = a.Gerekce,
                    Islemtarih = a.Islem_Tarih
                };
                db.KullaniciHareket.Add(hareket);
                db.SaveChanges();
            }           
        }
        private void btn_tamamlama_print_Click(object sender, EventArgs e)
        {

        }
        private void txt_AltyapiMaliyeti_TextChanged(object sender, EventArgs e)
        {
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void btn_ProjeKaydet_Click(object sender, EventArgs e)
        {


        }
    }
}
