using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfHotelZavrsni01
{
   static class Konekcija
    {
        private static SqlConnection con;

        public static SqlConnection Con
        {
            get { return KreirajCon(); }
           private set { con = value; }
        }

        private static SqlConnection KreirajCon()
        {
            return new SqlConnection(new SqlConnectionStringBuilder
            {
                DataSource=@"(local)\SQLEXPRESS",
                InitialCatalog= "HotelDbZavrsniRad",
                IntegratedSecurity=true
            }.ToString());
        }

    }
}
