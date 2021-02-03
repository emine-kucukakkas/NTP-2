using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussines;
using Bussiness;
using Model;
using MODEL;
using DataCore;

namespace Bussines
{
   public class kanGrubuBO : baseBO, IBaseBO<kanGrubu>
    {
        public bool ekle(kanGrubu nesne)
        {
            throw new NotImplementedException();
        }

        public kanGrubu getir(int id)
        {
            throw new NotImplementedException();
        }

        public bool guncelle(kanGrubu nesne)
        {
            throw new NotImplementedException();
        }

        public List<kanGrubu> ListeyiGetir()
        {
            List<kanGrubu> il = null;
            try
            {
                personelHelper helper = new personelHelper();
                var reader = helper.GetData("Select * from kanGrubu");
                if (reader.HasRows)
                {
                    il = new List<kanGrubu>();
                    while (reader.Read())
                    {
                        kanGrubu se = new kanGrubu();
                        se.id = Convert.ToInt32(reader["id"]);
                        se.kangrup = reader["kangrup"].ToString();


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
