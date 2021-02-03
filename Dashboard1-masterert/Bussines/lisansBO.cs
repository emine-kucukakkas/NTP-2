using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DataCore;

namespace Bussiness
{
    public class lisansBO : baseBO, IBaseBO<lisans>
    {
        public bool ekle(lisans nesne)
        {
            throw new NotImplementedException();
        }

        public lisans getir(int id)
        {
            throw new NotImplementedException();
        }

        public bool guncelle(lisans nesne)
        {
            throw new NotImplementedException();
        }

        public List<lisans> ListeyiGetir()
        {
            List<lisans> lis = null;
            try
            {
                personelHelper helper = new personelHelper();
                var reader = helper.GetData("Select * from Lisans");
                if (reader.HasRows)
                {
                    lis = new List<lisans>();
                    while (reader.Read())
                    {
                        lisans se = new lisans();
                        se.id = Convert.ToInt32(reader["id"]);
                        se.Lisans = reader["lisans"].ToString();


                        lis.Add(se);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return lis;
        }

        public bool sil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
