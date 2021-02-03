using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataCore;


namespace Bussiness
{
   public class LoginBO : baseBO, IBaseBO<Login>
    {
        public bool ekle(Login nesne)
        {
            throw new NotImplementedException();
        }

        public Login getir(int id)
        {
            throw new NotImplementedException();
        }
        public Login getir2(string id)        {
           
                Login sey = null;
                try
                {
                    var parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@Id", id));
                    personelHelper helper = new personelHelper();
                    var reader = helper.GetData("Select * from login where KullaniciAdi=@Id", parameters);
                    if (reader.HasRows)
                    {
                        reader.Read();
                        sey = new Login();
                    sey.yetki =Convert.ToInt32(reader["yetki"]);

                    }

                }
                catch (Exception)
                {

                    throw;
                }
                return sey;

            }

            public bool guncelle(Login nesne)
        {
            throw new NotImplementedException();
        }

        public List<Login> ListeyiGetir()
        {
            throw new NotImplementedException();
        }

        public bool sil(int id)
        {
            throw new NotImplementedException();
        }
        public bool login(string KullaniciAdi, string Pass)
        {
            bool result = false;
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@KullaniciAdi", KullaniciAdi));
                parameters.Add(new SqlParameter("@Sifre", Pass));
                parameters.Add(new SqlParameter("@SonGirisTarihi", DateTime.Now));



                 personelHelper helper = new personelHelper();
                result = helper.ExecuteCommand("Update login set SonGirisTarihi=@SonGirisTarihi where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre", parameters) > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public bool UserExist(string email)
        {
            bool result = false;
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@p1", email));


                personelHelper h = new personelHelper();
                var reader = h.GetData(("select * from login where email=@p1"), parameters);

                if (reader.HasRows)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public string GenerateCode()
        {
            Random rastgele = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                int ascii = rastgele.Next(32, 127);
                char Karakter = Convert.ToChar(ascii);
                sb.Append(Karakter);

            }
            return sb.ToString();

        }
        public bool ChangePass(string code, string email)
        {
            bool result = false;
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@p1", code));
                parameters.Add(new SqlParameter("@p3", email));

               personelHelper h = new personelHelper();

                result = h.ExecuteCommand(("Update login set Sifre=@p1 where email=@p3 "), parameters) > 0;


            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    



    }
}
