using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCore;
using Bussines;
using Model;
using Bussiness;

namespace Bussines
{
    public class derecekademeBO : baseBO, IBaseBO<derecekademe>
    {
        public bool ekle(derecekademe nesne)
        {
            throw new NotImplementedException();
        }

        public derecekademe getir(int id)
        {
            throw new NotImplementedException();
        }

        public bool guncelle(derecekademe nesne)
        {
            throw new NotImplementedException();
        }

        public List<derecekademe> ListeyiGetir()
        {
            List<derecekademe> il = null;
            try
            {
                personelHelper helper = new personelHelper();
                var reader = helper.GetData("Select * from dereceKademe");
                if (reader.HasRows)
                {
                    il = new List<derecekademe>();
                    while (reader.Read())
                    {
                        derecekademe se = new derecekademe();
                        se.id = Convert.ToInt32(reader["id"]);
                        se.derece = reader["derecekademe"].ToString();
                       

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

