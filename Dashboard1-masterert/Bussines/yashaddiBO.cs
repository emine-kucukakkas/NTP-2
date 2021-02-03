using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DataCore;

using Bussines;
using Bussiness;
using Model;

namespace Bussines
{
  public  class yashaddiBO : baseBO, IBaseBO<yashaddi>
    {
        public bool ekle(yashaddi nesne)
        {
            throw new NotImplementedException();
        }

        public yashaddi getir(int id)
        {
            throw new NotImplementedException();
        }

        public bool guncelle(yashaddi nesne)
        {
            throw new NotImplementedException();
        }

        public List<yashaddi> ListeyiGetir()
        {
            throw new NotImplementedException();
        }

        public bool sil(int id)
        {
            throw new NotImplementedException();
        }

        public List<yashaddi> yashaddi()
        {



            List<yashaddi> il = null;
            try
            {
                personelHelper helper = new personelHelper();

                var reader = helper.GetData("SET language turkish select adSoyad,  day(dogumtarihi-1),DATENAME( Month,(dbo.sicil.dogumTarihi)) as month from sicil where dbo.FN_YAS_HESAPLA1(dogumTarihi,GETDATE())<65 and dbo.FN_YAS_HESAPLA1(dogumTarihi,(GETDATE()-335))>=64");
                if (reader.HasRows)
                {


                    il = new List<yashaddi>();
                    while (reader.Read())
                    {
                        yashaddi se = new Model.yashaddi();
                        se.adSoyad = reader[0].ToString();
                        se.gun = Convert.ToInt32(reader[1]);
                        se.ay = reader[2].ToString();


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
        public List<yashaddi> asaletTasdiki()
        {



            List<yashaddi> il = null;
            try
            {
                personelHelper helper = new personelHelper();

                var reader = helper.GetData("SET language turkish select adSoyad,  day(kurumaBaslamaTarihi),DATENAME( Month,(dbo.sicil.kurumaBaslamaTarihi+180)) as month from sicil where getdate()-(kurumaBaslamaTarihi)<180 and getdate()-(kurumaBaslamaTarihi)>165");
                if (reader.HasRows)
                {


                    il = new List<yashaddi>();
                    while (reader.Read())
                    {
                        yashaddi se = new Model.yashaddi();
                        se.adSoyad = reader[0].ToString();
                        se.gun = Convert.ToInt32(reader[1]);
                        se.ay = reader[2].ToString();


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
    }
}
