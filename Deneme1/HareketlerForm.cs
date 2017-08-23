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
    public partial class HareketlerForm : Form
    {
        public static ProjeTakipSistEntities entity;
        public static ProjeTakipSistEntities db
        {
            get
            {
                if (entity == null)
                    entity = new ProjeTakipSistEntities();
                return entity;
            }
        }
        Kullanici user;
        public HareketlerForm(Kullanici k)
        {
            InitializeComponent();
            this.user = k;
        }

        private void HareketlerForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Kullanıcı Hareket dökümü güncellenmiştir");
            var query = (from u in db.Kullanici
                         join kh in db.KullaniciHareket on u.ID equals kh.User_id
                         orderby u.ID descending
                         select new
                         {
                             u.FirstName,
                             u.LastName,
                             kh.Islem,
                             kh.Islemtarih,
                             kh.Gerekce,
                             u.Email,
                             u.Address
                         });
            dataGridViewHareketler.DataSource = query.ToList();
        }
    }
}
