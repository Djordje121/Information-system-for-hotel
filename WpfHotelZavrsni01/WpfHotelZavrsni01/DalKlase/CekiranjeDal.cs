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
    class CekiranjeDal : IQueryHeleper<Cekiranje>
    {
        private SqlHelper<Cekiranje> hlp = new SqlHelper<Cekiranje>(Konekcija.Con);
        private GostDal gDal = new GostDal();
        public List<Cekiranje> ReturnSelect()
        {
            return hlp.ReturnSelect();
        }

        public bool InsertInto(Cekiranje obj)
        {

            SqlConnection con = Konekcija.Con;
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand("DodajGosta", con, tran);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ime ", obj.GostProp.Ime);
            cmd.Parameters.AddWithValue("@Prezime", obj.GostProp.Prezime);
            cmd.Parameters.AddWithValue("@Jmbg", obj.GostProp.Jmbg);
            cmd.Parameters.AddWithValue("@KontaktTelefon", obj.GostProp.KontaktTelefon);
            cmd.Parameters.AddWithValue("@Email", obj.GostProp.Email);
            SqlParameter idPar = new SqlParameter("@GostId", SqlDbType.Int);
            idPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(idPar);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                con.Close();
                return false;
            }
            int gostId = (int)idPar.Value;
            SqlCommand cmdCekiranje = new SqlCommand("DodajCekiranje", con, tran);
            cmdCekiranje.CommandType = CommandType.StoredProcedure;
            cmdCekiranje.Parameters.AddWithValue("@GostId", gostId);
            cmdCekiranje.Parameters.AddWithValue("@SobaId ", obj.SobaId);
            cmdCekiranje.Parameters.AddWithValue("@UslugaId", obj.UslugaId);
            cmdCekiranje.Parameters.AddWithValue("@DatumCekiranja", obj.DatumCekiranja);
            cmdCekiranje.Parameters.AddWithValue("@DatumOdjave", obj.DatumOdjave);
            cmdCekiranje.Parameters.AddWithValue("@UkupnaCena", obj.UkupnaCenaPoDanu);
            SqlParameter UbacenaSobaIdParametar = new SqlParameter("@UbacenaSobaId", SqlDbType.Int);
            UbacenaSobaIdParametar.Direction = ParameterDirection.Output;
            cmdCekiranje.Parameters.Add(UbacenaSobaIdParametar);

            try
            {
                cmdCekiranje.ExecuteNonQuery();
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                tran.Rollback();
                con.Close();
                return false;
            }
            int ubacenSobaId = (int)UbacenaSobaIdParametar.Value;

            SqlCommand cmdSobaInfo = new SqlCommand("DodajRezervaciju", con, tran);
            cmdSobaInfo.CommandType = CommandType.StoredProcedure;
            cmdSobaInfo.Parameters.AddWithValue("@SobaId", ubacenSobaId);
            cmdSobaInfo.Parameters.AddWithValue("@DatumCekiranja", obj.DatumCekiranja);
            cmdSobaInfo.Parameters.AddWithValue("@DatumOdjave", obj.DatumOdjave);
            try
            {
                cmdSobaInfo.ExecuteNonQuery();
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                tran.Rollback();
                con.Close();
                return false;
            }
            tran.Commit();
            con.Close();
            return true;


        }

        public bool Update(Cekiranje obj)
        {
            
            if (gDal.Update(obj.GostProp))
            {
                return hlp.Update(obj);
            }
            else return false;
         
        }
        public bool Delete(Cekiranje obj)
        {
           if(hlp.Delete(obj))
            {
                return gDal.Delete(obj.GostProp);
            }
            return false;
        }

        public Cekiranje PronadjiCekiranjePoGostu(int Id)
        {
            return hlp.ReturnObjById(Id, "CekiranjeId");
        }

        public bool PromeniStanjeSobe(int id1, int id2)
        {
            SqlConnection con = Konekcija.Con;
            SqlCommand cmd = new SqlCommand("PromeniStanjeSobe", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SobaId1 ", id1);
            cmd.Parameters.AddWithValue("@SobaId2", id2);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}
