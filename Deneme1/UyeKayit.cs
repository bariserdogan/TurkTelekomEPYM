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
    public partial class UyeKayit : Form
    {
        public UyeKayit()
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
        private void button1_Click(object sender, EventArgs e)
        {
            Kullanici k1 = new Kullanici();
            if (db.Kullanici.Any(k=>k.Username == txt_username.Text))
                MessageBox.Show("Böyle bir kullanıcı adı sistemde mevcut");
            else
            {
                k1.FirstName = txt_firstname.Text;
                k1.LastName = txt_lastname.Text;
                k1.Email = txt_email.Text;
                k1.Username = txt_username.Text;
                k1.Password = txt_password.Text;
                k1.Address = txt_adres.Text;
                db.Kullanici.Add(k1);
                db.SaveChanges();
                MessageBox.Show("Kayıt başarıyla gerçekleşti","Tebrikler !!! ",MessageBoxButtons.OK);
                this.Close();
            }
        }
    }
}
