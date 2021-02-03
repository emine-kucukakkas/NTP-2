using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DataCore;
namespace Bussiness
{
    public class egitimDurumuBO : baseBO, IBaseBO<EgitimDurumu>
    {
        public bool ekle(EgitimDurumu nesne)
        {
            throw new NotImplementedException();
        }

        public EgitimDurumu getir(int id)
        {
            throw new NotImplementedException();
        }

        public bool guncelle(EgitimDurumu nesne)
        {
            throw new NotImplementedException();
        }

        public List<EgitimDurumu> ListeyiGetir()
        {
            List<EgitimDurumu> il = null;
            try
            {
                personelHelper helper = new personelHelper();
                var reader = helper.GetData("Select * from egitimDurumu");
                if (reader.HasRows)
                {
                    il = new List<EgitimDurumu>();
                    while (reader.Read())
                    {
                        EgitimDurumu se = new EgitimDurumu();
                        se.id = Convert.ToInt32(reader["id"]);
                        se.egitim = reader["egitim"].ToString();


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
