using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfHotelZavrsni01
{
    class TipSobeDal
    {
        public static List<TipSobe>VratiTip()
        {
            return new SqlHelper<TipSobe>(Konekcija.Con).ReturnSelect();
        }
    }
}
