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
    public partial class Login : Form 
    {
        public Login()
        {
            InitializeComponent();
        }
        public ProjeTakipSistEntities entity;
        public ProjeTakipSistEntities db
        {
            get
            {
                if (entity == null)
                    entity = new ProjeTakipSistEntities();
                return entity;
            }
        }
        private void btn_kayitol_Click(object sender, EventArgs e)
        {
            UyeKayit kayit = new UyeKayit();
            kayit.ShowDialog();
        }
        private void btn_girisYap_Click(object sender, EventArgs e)
        {
            if(db.Kullanici.Any(x => x.Username == txt_username.Text && x.Password == txt_parola.Text))
            {
                Kullanici user = db.Kullanici.Where(x => x.Username == txt_username.Text).FirstOrDefault();
                ProjeIslemleri proje = new ProjeIslemleri(user);
                proje.ShowDialog();
            }
            else
            {
                MessageBox.Show("Parola veya kullanıcı adı yanlış.Lütfen tekrar deneyiniz !","Bilgi",MessageBoxButtons.OK);
                txt_username.Clear();
                txt_parola.Clear();
            }
                    
        }
    }
    

}
