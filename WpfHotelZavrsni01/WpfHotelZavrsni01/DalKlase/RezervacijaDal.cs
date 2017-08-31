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
    class RezervacijaDal
    {
        private static SqlConnection con = Konekcija.Con;
        private SqlHelper<Rezervacija> hlp = new SqlHelper<Rezervacija>(con);
        public int VratiBrojSlobodnih(int tipId)
        {
            SqlCommand cmd = new SqlCommand("SElECT COUNT(*) FROM Soba WHERE StatusSobe = 1 and TipSobeId=@TipSobeId", con);
            cmd.Parameters.AddWithValue("@TipSobeId", tipId);
            try
            {
                con.Open();

                return (int)cmd.ExecuteScalar();
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                return -1;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Rezervacija>VratiRezervisaneDistinct()
        {
            List<Rezervacija> lista = new List<Rezervacija>();
            SqlCommand cmd = new SqlCommand("PrikaziRezervisane", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(
                        new Rezervacija
                        {
                            RezervacijaId = dr.GetInt32(0),
                            SobaId = dr.GetInt32(1),
                            DatumCekiranja = dr.GetDateTime(2),
                            DatumOdjave = dr.GetDateTime(3),

                        });

                }
                return lista;
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
        public List<Rezervacija> PronadjiRezevacijuById(int id)
        {
            SqlConnection con = Konekcija.Con;
            SqlCommand cmd = new SqlCommand(" SELECT * FROM Rezervacija WHERE SobaId=@SobaId order by DatumCekiranja;", con);
            cmd.Parameters.AddWithValue("@SobaId", id);
            try
            {
                con.Open();
                return SqlHelper<Rezervacija>.ReturnSelect(cmd.ExecuteReader());
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

       
        public bool Update(Rezervacija obj)
        {
            return hlp.Update(obj);
        }
        public bool Delete(Rezervacija obj)
        {
            return hlp.Delete(obj);
        }
        
        public Rezervacija PronadjiRezervaciju(int id)
        {
            return hlp.ReturnObjById(id, "SobaRezervacijaId");
        }


    }
}
