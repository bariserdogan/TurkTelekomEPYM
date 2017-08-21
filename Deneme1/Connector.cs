using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme1
{
    public class Connector
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
    }
}
