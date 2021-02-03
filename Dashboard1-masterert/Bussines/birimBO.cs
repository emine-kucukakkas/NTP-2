using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DataCore;

namespace Bussiness
{
   public class birimBO : baseBO, IBaseBO<birim>
    {
        public bool ekle(birim nesne)
        {
            throw new NotImplementedException();
        }

        public birim getir(int id)
        {
            throw new NotImplementedException();
        }

        public bool guncelle(birim nesne)
        {
            throw new NotImplementedException();
        }

        public List<birim> ListeyiGetir()
        {
            List<birim> birim = null;
            try
            {
                personelHelper helper = new personelHelper();
                var reader = helper.GetData("Select * from birim");
                if (reader.HasRows)
                {
                    birim = new List<birim>();
                    while (reader.Read())
                    {
                        birim se = new birim();
                        se.id = Convert.ToInt32(reader["id"]);
                        se.Birim = reader["Birim"].ToString();


                        birim.Add(se);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return birim;
        }

        public bool sil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
