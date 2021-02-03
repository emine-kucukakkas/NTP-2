using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussines;
using Bussiness;
using Model;
using DataCore;
namespace Bussines
{
    public class askerlikBO : baseBO, IBaseBO<askerlikDurumu>
    {
        public bool ekle(askerlikDurumu nesne)
        {
            throw new NotImplementedException();
        }

        public askerlikDurumu getir(int id)
        {
            throw new NotImplementedException();
        }

        public bool guncelle(askerlikDurumu nesne)
        {
            throw new NotImplementedException();
        }

        public List<askerlikDurumu> ListeyiGetir()
        {
            List<askerlikDurumu> il = null;
            try
            {
                personelHelper helper = new personelHelper();
                var reader = helper.GetData("Select * from askerlikDurumu");
                if (reader.HasRows)
                {
                    il = new List<askerlikDurumu>();
                    while (reader.Read())
                    {
                        askerlikDurumu se = new askerlikDurumu();
                        se.id = Convert.ToInt32(reader["id"]);
                        se.durumu = reader["durumu"].ToString();


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
