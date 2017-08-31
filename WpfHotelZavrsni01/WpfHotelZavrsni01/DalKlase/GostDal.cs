using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfHotelZavrsni01
{
    class GostDal : IQueryHeleper<Gost>
    {
        private SqlHelper<Gost> hlp = new SqlHelper<Gost>(Konekcija.Con);
      
        public List<Gost> ReturnSelect()
        {
            return hlp.ReturnSelect();
        }
        public bool InsertInto(Gost obj)
        {
            return hlp.InsertInto(obj);
        }
       
       
        public bool Update(Gost obj)
        {
            return hlp.Update(obj);
        }
        public bool Delete(Gost obj)
        {
            return hlp.Delete(obj);
        }

        public Gost PronadjiGosta(int id)
        {
            return hlp.ReturnObjById(id, "GostId");
        }
    }
}
