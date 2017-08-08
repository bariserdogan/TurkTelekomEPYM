using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.Office.Core;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Deneme1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        //SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-REUDUMU;Initial Catalog=staj;Integrated Security=true");

        private void Form1_Load(object sender, EventArgs e)
        {
            //Excel.Application sourceApp;
            //sourceApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            //sourceApp.Visible = true;
            //Excel.Workbook sourceWorkBook = sourceApp.ActiveWorkbook;

            //Excel.Worksheet sourceWorkSheet = sourceWorkBook.ActiveSheet;

            //Excel.Range sourceRange = sourceWorkSheet.UsedRange;   
        }
        public void connectDB()
        {
            OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\BARIS\Desktop\Projeler Yeni - Kopya.xlsm; Extended Properties='Excel 12.0 xml;HDR=YES;'");
            baglanti.Open();  //www.ahmetcansever.com
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [Aksiyonlar$]", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewExceldenGelen.DataSource = dt.DefaultView;
            baglanti.Close();
        }

        private void btn_VerileriGetir_Click(object sender, EventArgs e)
        {
            connectDB();
        }

        private void btn_transferSql_Click(object sender, EventArgs e)
        {
            //transferSql();
        }
        //public void transferSql()
        //{
        //    for (int j = 0; j < dataGridViewExceldenGelen.Rows.Count - 1; j++)
        //    {

        //            //SqlCommand komut = new SqlCommand("INSERT INTO YeniListe(CBS_ID,Proje_Türü,Proje_Adı,Çizim_Adı,Telekom_Müd,Santral,Altyapı_Maliyeti,Açık_Kazı,Fider,Trencher,Kazser,Yeraltı_Güzergahıncan,Yeni_Havi_Güzergahtan,Mevcut_Havai_Güzergahtan,Kazser_Güzergahtan,FTTC_OFSD_OFTK,FTTB_3_48U_Kabin,Aktarma,Bina_içi_Kablolama,İşlem,İşlem_Tarih,Gerekçe,Kullanıcı,Başlangic_Tarih,Bitiş_Tarih,Proje_Süre,Proje_Adet,Proje_Sıra,Mükerrer,Kalan_Süre,Eski_İşlem_Tarih,Aktif_İşlem,Aktif_Süre,Cezalı_Gün_Sayısı,Ceza_Tutarı,Tarih,Proje_Genel_Durumu,PROJE_REVIZE_BUTCE,GERCEKLESEN_IMALAT_TUTARI,Karşılaştırma) VALUES ('" + dataGridView1["CBS_ID", j].Value.ToString() + "','" + dataGridView1["Proje_Türü", j].Value.ToString() + "','" + dataGridView1["Proje_Adı", j].Value.ToString() + "','" + dataGridView1["Çizim_Adı", j].Value.ToString() + "','" + dataGridView1["Telekom_Müd", j].Value.ToString() + "','" + dataGridView1["Santral", j].Value.ToString() + "','" + dataGridView1["Altyapı_Maliyeti", j].Value.ToString() + "','" + dataGridView1["Açık_Kazı", j].Value.ToString() + "','" + dataGridView1["Fider", j].Value.ToString() + "','" + dataGridView1["Trencher", j].Value.ToString() + "','" + dataGridView1["Kazser", j].Value.ToString() + "','" + dataGridView1["Yeraltı_Güzergahıncan", j].Value.ToString() + "','" + dataGridView1["Yeni_Havi_Güzergahtan", j].Value.ToString() + "','" + dataGridView1["Mevcut_Havai_Güzergahtan", j].Value.ToString() + "','" + dataGridView1["Kazser_Güzergahtan", j].Value.ToString() + "','" + dataGridView1["FTTC_OFSD_OFTK", j].Value.ToString() + "','" + dataGridView1["FTTB_3_48U_Kabin", j].Value.ToString() + "','" + dataGridView1["Aktarma", j].Value.ToString() + "','" + dataGridView1["Bina_içi_Kablolama", j].Value.ToString() + "','" + dataGridView1["İşlem", j].Value.ToString() + "','" + dataGridView1["İşlem_Tarih", j].Value.ToString() + "','" + dataGridView1["Gerekçe", j].Value.ToString() + "','" + dataGridView1["Kullanıcı", j].Value.ToString() + "','" + dataGridView1["Başlangic_Tarih", j].Value.ToString() + "','" + dataGridView1["Bitiş_Tarih", j].Value.ToString() + "','" + dataGridView1["Proje_Süre", j].Value.ToString() + "','" + dataGridView1["Proje_Adet", j].Value.ToString() + "','" + dataGridView1["Proje_Sıra", j].Value.ToString() + "','" + dataGridView1["Mükerrer", j].Value.ToString() + "','" + dataGridView1["Kalan_Süre", j].Value.ToString() + "','" + dataGridView1["Eski_İşlem_Tarih", j].Value.ToString() + "','" + dataGridView1["Aktif_İşlem", j].Value.ToString() + "','" + dataGridView1["Aktif_Süre", j].Value.ToString() + "','" + dataGridView1["Cezalı_Gün_Sayısı", j].Value.ToString() + "','" + dataGridView1["Ceza_Tutarı", j].Value.ToString() + "','" + dataGridView1["Tarih", j].Value.ToString() + "','" + dataGridView1["Proje_Genel_Durumu", j].Value.ToString() + "','" + dataGridView1["PROJE_REVIZE_BUTCE", j].Value.ToString() + "','" + dataGridView1["GERCEKLESEN_IMALAT_TUTARI", j].Value.ToString() + "','" + dataGridView1["Karşılaştırma", j].Value.ToString() + "' )", bag);
        //            //SqlCommand komut = new SqlCommand("INSERT INTO deneme(CBS_ID,Proje_Turu,Proje_Adi,Cizim_Adi) VALUES ('" + dataGridView1["CBS_ID", j].Value.ToString() + "','" + dataGridView1["Proje_Turu", j].Value.ToString() + "','" + dataGridView1["Proje_Adi", j].Value.ToString() + "','" + dataGridView1["Cizim_Adi", j].Value.ToString() + "')", bag);
        //            SqlCommand komut = new SqlCommand("INSERT INTO aksiyonlar1(CBS_ID,Proje_Turu,Proje_Adi,Cizim_Adi,Telekom_Mud,Santral,Altyapi_Maliyeti,Acik_Kazi,Fider,Trencher,Kazser,Yeralti_Guzergahincan,Yeni_Havi_Guzergahtan,Mevcut_Havai_Guzergahtan,Kazser_Guzergahtan,FTTC_OFSD_OFTK,FTTB_3_48U_Kabin,Aktarma,Bina_ici_Kablolama,Islem,Islem_Tarih,Gerekce,Kullanici,Baslangic_Tarih,Bitis_Tarih,Proje_Sure,Proje_Adet,Proje_Sira,Mukerrer,Kalan_Sure,Eski_Islem_Tarih,Aktif_Islem,Aktif_Sure,Cezali_Gun_Sayisi,Ceza_Tutari,Tarih,Proje_Genel_Durumu,PROJE_REVIZE_BUTCE,GERCEKLESEN_IMALAT_TUTARI,Karsilastirma) VALUES ('" + dataGridViewExceldenGelen["CBS_ID", j].Value.ToString() + "','" + dataGridViewExceldenGelen["Proje_Turu", j].Value.ToString() + "','" + dataGridViewExceldenGelen["Proje_Adi", j].Value.ToString() + "','" + dataGridViewExceldenGelen["Cizim_Adi", j].Value.ToString() + "','" + dataGridViewExceldenGelen["Telekom_Mud", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Santral", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Altyapi_Maliyeti", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Acik_Kazi", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Fider", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Trencher", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Kazser", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Yeralti_Guzergahincan", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Yeni_Havi_Guzergahtan", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Mevcut_Havai_Guzergahtan", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Kazser_Guzergahtan", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["FTTC_OFSD_OFTK", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["FTTB_3_48U_Kabin", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Aktarma", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Bina_ici_Kablolama", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Islem", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Islem_Tarih", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Gerekce", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Kullanici", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Baslangic_Tarih", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Bitis_Tarih", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Proje_Sure", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Proje_Adet", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Proje_Sira", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Mukerrer", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Kalan_Sure", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Eski_Islem_Tarih", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Aktif_Islem", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Aktif_Sure", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Cezali_Gun_Sayisi", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Ceza_Tutari", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Tarih", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Proje_Genel_Durumu", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["PROJE_REVIZE_BUTCE", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["GERCEKLESEN_IMALAT_TUTARI", j].Value.ToString() + "', '" + dataGridViewExceldenGelen["Karsilastirma", j].Value.ToString() + "')", bag);

        //            bag.Open();
        //            komut.ExecuteNonQuery();
        //            bag.Close();
        //    }
        //    MessageBox.Show("İşlem Gerçekleştirildi", "Info",MessageBoxButtons.OK);
            
        //}

        private void btn_ilerle_Click(object sender, EventArgs e)
        {
            ProjeIslemleri open = new ProjeIslemleri();
            open.ShowDialog();
        }
    }
}
