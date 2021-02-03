using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DataCore;
namespace Bussiness
{
    public class okulBO : baseBO, IBaseBO<okul>
    {
        public bool ekle(okul nesne)
        {
            throw new NotImplementedException();
        }

        public okul getir(int id)
        {
            throw new NotImplementedException();
        }

        public bool guncelle(okul nesne)
        {
            throw new NotImplementedException();
        }

        public List<okul> ListeyiGetir()
        {
            List<okul> ok = null;
            try
            {
                personelHelper helper = new personelHelper();
                var reader = helper.GetData("Select * from okul");
                if (reader.HasRows)
                {
                    ok = new List<okul>();
                    while (reader.Read())
                    {
                        okul se = new okul();
                        se.id = Convert.ToInt32(reader["id"]);
                        se.Okul = reader["Okul"].ToString();


                        ok.Add(se);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        public bool sil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
