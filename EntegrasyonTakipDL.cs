using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace EntegrasyonTakip
{
    public class EntegrasyonTakipDL
    {
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ToString();

        internal DataTable GetListe()
        {
            DataTable resultTable = new DataTable();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_GetAllEntegrasyon", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            dr.Fill(resultTable);
            con.Close();
            return resultTable;
        }
        public DataTable GetDataByID(int id)
        {
            DataTable resultTable = new DataTable();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_GetDataByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter dr = new SqlDataAdapter(cmd);
                dr.Fill(resultTable);
            }
            return resultTable;
        }

        public void InsertEntegrasyon(string arac, DateTime tarih, string eıo, string güncelleme,
            string entegratör, string kisi, string aswlinkİ, string entegrasyonlinki)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertEntegrasyon", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ARAC",arac);
                cmd.Parameters.AddWithValue("@TARIH",tarih);
                cmd.Parameters.AddWithValue("@EIO",eıo);
                cmd.Parameters.AddWithValue("@GUNCELLEMELER", güncelleme);
                cmd.Parameters.AddWithValue("@ENTEGRATOR", entegratör);
                cmd.Parameters.AddWithValue("@TALEPEDEN", kisi);
                cmd.Parameters.AddWithValue("@ASWLINKI", aswlinkİ);
                cmd.Parameters.AddWithValue("@ENTEGRASYONLINKI", entegrasyonlinki);
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteEntegrasyon(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteEntegrasyon", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
               cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
        }
       

        public void UpdateEntegrasyon( int id,string arac, DateTime tarih, string eıo, string güncelleme, 
            string entegratör, string kisi, string aswlinkİ, string entegrasyonlinki)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateEntegrasyon", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@ARAC", arac);
                cmd.Parameters.AddWithValue("@TARIH", tarih);
                cmd.Parameters.AddWithValue("@EIO", eıo);
                cmd.Parameters.AddWithValue("@GUNCELLEMELER", güncelleme);
                cmd.Parameters.AddWithValue("@ENTEGRATOR", entegratör);
                cmd.Parameters.AddWithValue("@TALEPEDEN", kisi);
                cmd.Parameters.AddWithValue("@ASWLINKI", aswlinkİ);
                cmd.Parameters.AddWithValue("@ENTEGRASYONLINKI", entegrasyonlinki);
                cmd.ExecuteNonQuery();
            }
        }
    }




}
        

    

