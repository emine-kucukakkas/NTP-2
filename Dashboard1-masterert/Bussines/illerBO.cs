using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DataCore;
namespace Bussiness
{
    public class illerBO : baseBO, IBaseBO<iller>
    {
        public bool ekle(iller nesne)
        {
            throw new NotImplementedException();
        }

        public iller getir(int id)
        {
            throw new NotImplementedException();
        }

        public bool guncelle(iller nesne)
        {
            throw new NotImplementedException();
        }

        public List<iller> ListeyiGetir()
        {
            List<iller> il = null;
            try
            {
                personelHelper helper = new personelHelper();
                var reader = helper.GetData("Select * from iller");
                if (reader.HasRows)
                {
                    il = new List<iller>();
                    while (reader.Read())
                    {
                        iller se = new iller();
                        se.Id = Convert.ToInt32(reader["Id"]);
                        se.ilAdi = reader["ilAdi"].ToString();


                        il.Add(se);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return il;
        }

        public bool sil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
