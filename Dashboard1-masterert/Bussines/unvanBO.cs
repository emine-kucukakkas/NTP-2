using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DataCore;

namespace Bussiness
{
    public class unvanBO : baseBO, IBaseBO<unvan>
    {
        public bool ekle(unvan nesne)
        {
            throw new NotImplementedException();
        }

        public unvan getir(int id)
        {
            throw new NotImplementedException();
        }

        public bool guncelle(unvan nesne)
        {
            throw new NotImplementedException();
        }

        public List<unvan> ListeyiGetir()
        {
            List<unvan> unvan = null;
            try
            {
                personelHelper helper = new personelHelper();
                var reader = helper.GetData("Select * from Unvan");
                if (reader.HasRows)
                {
                    unvan = new List<unvan>();
                    while (reader.Read())
                    {
                        unvan se = new unvan();
                        se.id = Convert.ToInt32(reader["id"]);
                        se.Unvan = reader["unvan"].ToString();


                        unvan.Add(se);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return unvan;
        }

        public bool sil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
