using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;
using System.Windows;

namespace WpfHotelZavrsni01
{
    class SqlHelper<T> : IQueryHeleper<T> where T : new()
    {
        private PropertyInfo[] pInfo= typeof(T).GetProperties();
        private string tabela = typeof(T).Name;
        public SqlConnection Con { get; set; }
        private StringBuilder sb = new StringBuilder();
        private List<string> kolone = new List<string>();
        public SqlHelper(SqlConnection con)
        {
           this.Con = con;          
        }

        private void GetNames()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM " + tabela, Con);
            try
            {
                Con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    if (!kolone.Contains(dr.GetName(i)))
                        kolone.Add(dr.GetName(i));
                }
            }
            catch (Exception)
            {         
                return;
            }
            finally
            {
                Con.Close();
            }
        }
        public List<T> ReturnSelect()
        {
            List<T> listGen = new List<T>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM " + tabela, Con);
            try
            {
                Con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                 while(dr.Read())
                 {
                    T obj = new T();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {                      
                        if (!Convert.IsDBNull(dr[i]))
                            pInfo[i].SetValue(obj, dr.GetValue(i));
                        
                    }
                    listGen.Add(obj);
                   
                 }
                    
                return listGen;
            }
            catch (Exception xcp)
            {
                System.Windows.MessageBox.Show(xcp.Message);
                return null;
            }
            finally { Con.Close(); }
        }

        public static List<T> ReturnSelect(SqlDataReader dr)
        {
            if(dr==null)
            {
                throw new NotImplementedException("SqlDataReader is null");
            }

            List<T> listGen = new List<T>();
            PropertyInfo[] pinfoArray = typeof(T).GetProperties();
            while (dr.Read())
            {
                T obj = new T();
                for (int i = 0; i < dr.FieldCount; i++)
                {

                    if (!Convert.IsDBNull(dr[i]))
                        pinfoArray[i].SetValue(obj, dr.GetValue(i));


                }
                listGen.Add(obj);

            }

            return listGen;
        }
        public T ReturnObjById(int id,string parametar)
        {
            SqlCommand cmd = new SqlCommand("SElECT * FROM " + tabela + " WHERE " + parametar + "=" + id, Con);
            cmd.Parameters.AddWithValue("@" +parametar, id);
            try
            {
                Con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                T obj = new T();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                        pInfo[i].SetValue(obj, dr.GetValue(i));
                }

                return obj;
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                return default(T);
            }
            finally { Con.Close(); }
        }
        public List<T> ReturnListObjById<T1>(T1 parametar,string pretraga,string pretraga1="")
        {
            List<T> listGen = new List<T>();
            SqlCommand cmd = new SqlCommand();
            if(pretraga1==string.Empty)
            cmd.CommandText = "SElECT * FROM " + tabela + " WHERE " + pretraga + " = " + parametar;
            else cmd.CommandText = "SElECT * FROM " + tabela + " WHERE " + pretraga + " = " + parametar+ " and "+pretraga1;
            cmd.Connection = Con;
            cmd.Parameters.AddWithValue("@" + pretraga,parametar);
            try
            {
                Con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    T obj = new T();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                            pInfo[i].SetValue(obj, dr.GetValue(i));
                    }
                    listGen.Add(obj);
                }
                return listGen;
            }
            catch (Exception)
            {
                return null;
            }
            finally { Con.Close(); }
        }
        public bool InsertInto(T obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            sb.Clear();
            sb.Append("INSERT INTO " + tabela + " VALUES(");
            if (kolone.Count == 0)
                GetNames();
            string s1 = ",";
            for (int i = 1; i < kolone.Count; i++)
            {
                if (kolone.Count - 1 == i)
                    s1 = ")";
                sb.Append("@" + pInfo[i].Name + s1);
                cmd.Parameters.AddWithValue("@" + pInfo[i].Name, pInfo[i].GetValue(obj));

            }

            cmd.CommandText = sb.ToString();

            try
            {
                Con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {            
                return false;
            }
            finally
            {
                Con.Close();
            }
        }
        public bool Update(T obj)
        {
            sb.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            sb.Append("UPDATE " + tabela + " SET ");
            string s1 = ",";
            if (kolone.Count == 0)
                GetNames();
            for (int i = 1; i < kolone.Count; i++)
            {
                if (kolone.Count - 1 == i)
                    s1 = "";
                sb.Append(kolone[i] + "=" + "@" + pInfo[i].Name + s1);

                cmd.Parameters.AddWithValue("@" + pInfo[i].Name, pInfo[i].GetValue(obj));
            }
            sb.Append(" WHERE " + kolone[0] + "=" + "@" + pInfo[0].Name + ";");
            cmd.Parameters.AddWithValue("@" + pInfo[0].Name, pInfo[0].GetValue(obj));

            cmd.CommandText = sb.ToString();

            try
            {
                Con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Con.Close();
            }

        }
        public bool Delete(T obj)
        {
            if (kolone.Count == 0)
                GetNames();
            string id = $"@{pInfo[0].Name}";
                SqlCommand cmd = new SqlCommand("DELETE FROM " + tabela + " WHERE " + kolone[0] + "=" + id, Con);
                cmd.Parameters.AddWithValue(id, pInfo[0].GetValue(obj));          
                try
                {
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    Con.Close();
                }
            
        }


    }
}
