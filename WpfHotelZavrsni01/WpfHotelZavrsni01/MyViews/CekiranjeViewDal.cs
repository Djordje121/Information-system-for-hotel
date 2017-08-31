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
    class CekiranjeViewDal
    {
       

      
        public static List<CekiranjeView> VratiView(string imeGosta="")
        {
            SqlConnection con = Konekcija.Con;
            SqlCommand cmd = new SqlCommand("Pretraga", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ime", imeGosta);

            try
            {
                con.Open();
                return SqlHelper<CekiranjeView>.ReturnSelect(cmd.ExecuteReader());
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}
