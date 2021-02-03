using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace DataCore
{
   public class personelHelper
    {
        private string ConnectionString { get; set; }

        public personelHelper()
        {
            string Exception = string.Empty;
            try
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["personelConf"].ConnectionString;
            }
            catch (Exception ex)
            {

                Exception = ex.GetType().ToString();

            }
        }
            public int ExecuteCommand(string command, List<SqlParameter> parameters = null)
            {

                int result = 0;

                using (SqlConnection con = new SqlConnection(ConnectionString))

                {
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters.ToArray());
                        }
                        con.Open();

                        result = cmd.ExecuteNonQuery();
                        con.Close();


                    }

                }

                return result;

            }

            public SqlDataReader GetData(string cmdtext, List<SqlParameter> parameters = null)
            {
                SqlDataReader dr = null;

                SqlConnection con = new SqlConnection(ConnectionString);

                SqlCommand cmd = new SqlCommand(cmdtext, con);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());

                }

                string ese = string.Empty;
                try
                {
                    con.Open();
                    dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {

                    ese = ex.GetType().ToString();
                }

                return dr;

            }
            public SqlDataReader GetData1(string cmdtext, List<SqlParameter> parameter = null)
            {
                SqlDataReader dr = null;

                SqlConnection con = new SqlConnection(ConnectionString);

                SqlCommand cmd = new SqlCommand(cmdtext, con);

                if (parameter != null)
                {
                    cmd.Parameters.AddRange(parameter.ToArray());

                }
                con.Open();
                dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);




                return dr;


            }

        public int scalarLokasyon(int sayi)
        {
           

            SqlConnection con = new SqlConnection(ConnectionString);         
            SqlCommand command = new SqlCommand("select count(*) from sicil where Lokasyon=@Id", con);            
            con.Open();
            command.Parameters.AddWithValue("@Id", sayi);
            int sonuc = Convert.ToInt32(command.ExecuteScalar());
            return sonuc;                                        


        }
        public int scalarCinsiyet(int sayi)
        {


            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("select count(*) from sicil where cinsiyet=@Id", con);
            con.Open();
            command.Parameters.AddWithValue("@Id", sayi);
            int sonuc = Convert.ToInt32(command.ExecuteScalar());
            return sonuc;

        }
        public int hizmetsayisi1(int yas1,int yas2,DateTime tarih)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("select count(*) from tumListe2 where (dbo.FN_YAS_HESAPLA1(kurumaBaslamaTarihi,@sontarih)>=@yas1) and (dbo.FN_YAS_HESAPLA1(kurumaBaslamaTarihi,@sontarih)<@yas2) and (cetvel='1') ", con);
            con.Open();
            command.Parameters.AddWithValue("@yas1", yas1);
            command.Parameters.AddWithValue("@yas2", yas2);
            command.Parameters.AddWithValue("@sontarih", tarih);
            int sonuc = Convert.ToInt32(command.ExecuteScalar());
            return sonuc;
        }
        public int hizmetsayisi2(int yas1, int yas2, DateTime tarih)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("select count(*) from tumListe2 where (dbo.FN_YAS_HESAPLA1(kurumaBaslamaTarihi,@sontarih)>=@yas1) and (dbo.FN_YAS_HESAPLA1(kurumaBaslamaTarihi,@sontarih)<@yas2) and (cetvel='2') ", con);
            con.Open();
            command.Parameters.AddWithValue("@yas1", yas1);
            command.Parameters.AddWithValue("@yas2", yas2);
            command.Parameters.AddWithValue("@sontarih", tarih);
            int sonuc = Convert.ToInt32(command.ExecuteScalar());
            return sonuc;
        }
        public int emeklilik1(DateTime tarih)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("select count(*) from tumListe2 where (dbo.FN_YAS_HESAPLA1(kurumaBaslamaTarihi,@sontarih)>=25) and (cetvel='1') ", con);
            con.Open();           
            command.Parameters.AddWithValue("@sontarih", tarih);
            int sonuc = Convert.ToInt32(command.ExecuteScalar());
            return sonuc;
        }

        public int emeklilik2(DateTime tarih)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("select count(*) from tumListe2 where (dbo.FN_YAS_HESAPLA1(kurumaBaslamaTarihi,@sontarih)>=25) and (cetvel='2') ", con);
            con.Open();
            command.Parameters.AddWithValue("@sontarih", tarih);
            int sonuc = Convert.ToInt32(command.ExecuteScalar());
            return sonuc;
        }

        public int yas1(int yas1, int yas2, DateTime tarih)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("select count(*) from tumListe2 where (dbo.FN_YAS_HESAPLA1(dogumTarihi,@sontarih)>=@yas1) and (dbo.FN_YAS_HESAPLA1(dogumTarihi,@sontarih)<@yas2) and (cetvel='1') ", con);
            con.Open();
            command.Parameters.AddWithValue("@yas1", yas1);
            command.Parameters.AddWithValue("@yas2", yas2);
            command.Parameters.AddWithValue("@sontarih", tarih);
            int sonuc = Convert.ToInt32(command.ExecuteScalar());
            return sonuc;
        }
        public int yas2(int yas1, int yas2, DateTime tarih)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("select count(*) from tumListe2 where (dbo.FN_YAS_HESAPLA1(dogumTarihi,@sontarih)>=@yas1) and (dbo.FN_YAS_HESAPLA1(dogumTarihi,@sontarih)<@yas2) and (cetvel='2') ", con);
            con.Open();
            command.Parameters.AddWithValue("@yas1", yas1);
            command.Parameters.AddWithValue("@yas2", yas2);
            command.Parameters.AddWithValue("@sontarih", tarih);
            int sonuc = Convert.ToInt32(command.ExecuteScalar());
            return sonuc;
        }

        public int egitim1(int egitim)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("select count(*) from sicil where (egitimDurumu=@egitim) and (cetvel='1')", con);
            con.Open();
            command.Parameters.AddWithValue("@egitim", egitim);
            
            int sonuc = Convert.ToInt32(command.ExecuteScalar());
            return sonuc;
        }
        public int egitim2(int egitim)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("select count(*) from sicil where (egitimDurumu=@egitim) and (cetvel='2')", con);
            con.Open();
            command.Parameters.AddWithValue("@egitim", egitim);

            int sonuc = Convert.ToInt32(command.ExecuteScalar());
            return sonuc;
        }
    }
}
