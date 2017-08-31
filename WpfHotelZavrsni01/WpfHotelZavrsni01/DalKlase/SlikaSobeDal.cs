using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHotelZavrsni01
{
    class SlikaSobeDal : IQueryHeleper<SlikaSobe>
    {
        private SqlHelper<SlikaSobe> hlp = new SqlHelper<SlikaSobe>(Konekcija.Con);
        public List<SlikaSobe> ReturnSelect()
        {
            return hlp.ReturnSelect();
        }
        public List<SlikaSobe>FiltrirajSlike(int tipId)
        {
            return hlp.ReturnListObjById(tipId, "TipSobeId");
        }
        public bool InsertInto(SlikaSobe obj)
        {
           return hlp.InsertInto(obj);
        }
        public bool Update(SlikaSobe obj)
        {
          return hlp.Update(obj);
        }
        public bool Delete(SlikaSobe obj)
        {
            return hlp.Delete(obj);
        }

       
    }
}
