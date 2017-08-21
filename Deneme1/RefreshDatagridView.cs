using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme1
{
    public class RefreshDatagridView:Connector
    {
        // listelenebilir bir yapıda döneceği için dönüş tipi IQueryable olacak 
        public static IQueryable Refresh(string id) 
        {
            IQueryable query = from a in db.Aksiyonlar // işlem sonrası datagridview'i yeniliyoruz.
                        where a.CBS_ID == id
                        select new
                        {
                            cbs_id = a.CBS_ID,
                            islem = a.Islem,
                            gerekce = a.Gerekce,
                            islem_tarihi = a.Islem_Tarih,
                            kalan_sure = a.Kalan_Sure,
                            calisilan_sure = a.Kalan_Sure
                        };
            return query;
        }
    }
}
