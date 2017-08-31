using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace WpfHotelZavrsni01
{
    class SobaDal
    {
        //0=false 1=true
        SqlHelper<Soba> hlp = new SqlHelper<Soba>(Konekcija.Con);

        public List<Soba> VratiSobe()
        {
            return hlp.ReturnSelect();
        }
        public List<Soba> VratiSobe(int id)
        {
            return hlp.ReturnListObjById(id, "TipSobeid");
        }

        public List<Soba>VratiSlobodne(int?tipId)
        {
            SqlConnection con = Konekcija.Con;
            SqlCommand cmd = new SqlCommand("PrikaziSlobodne", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (tipId != null)
                cmd.Parameters.AddWithValue("@TipId ",tipId);

            try
            {
                con.Open();
               return SqlHelper<Soba>.ReturnSelect(cmd.ExecuteReader());
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Soba>VratiZauzete(int?tipId)
        {
            if(tipId.HasValue)
                return hlp.ReturnListObjById(tipId, "TipSobeId", "StatusSobe=0");

            else return hlp.ReturnListObjById(0, "StatusSobe");
        }  

        public Soba PronadjiSobu(int sobaiD)
        {
          return  hlp.ReturnObjById(sobaiD, "SobaId");
        }
        
    }
}
