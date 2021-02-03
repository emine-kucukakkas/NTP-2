using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DataCore;

namespace Bussiness
{
    public class lokasyonBO : baseBO, IBaseBO<lokasyon>
    {
        public bool ekle(lokasyon nesne)
        {
            throw new NotImplementedException();
        }

        public lokasyon getir(int id)
        {
            throw new NotImplementedException();
        }

        public bool guncelle(lokasyon nesne)
        {
            throw new NotImplementedException();
        }

        public List<lokasyon> ListeyiGetir()
        {
            List<lokasyon> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var reader = helper.GetData("Select * from lokasyon");
                if (reader.HasRows)
                {
                    lokas = new List<lokasyon>();
                    while (reader.Read())
                    {
                        lokasyon se = new lokasyon();
                        se.id = Convert.ToInt32(reader["id"]);
                        se.Lokasyon = reader["lokasyon"].ToString();


                        lokas.Add(se);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return lokas;
        }

        public bool sil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
