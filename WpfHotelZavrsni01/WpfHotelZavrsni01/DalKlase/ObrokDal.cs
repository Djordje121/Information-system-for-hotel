using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfHotelZavrsni01
{
    class ObrokDal
    {
       
        public static List<DodatnaUsluga>VratiObrok()
        {
            return new SqlHelper<DodatnaUsluga>(Konekcija.Con).ReturnSelect();
        }
    }
}
