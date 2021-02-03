using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness;
using MODEL;
using DataCore;
using Model;
using System.Data.SqlClient;
namespace Bussines
{
    public class raporlarBO : baseBO, IBaseBO<raporlar>
    {
        public bool ekle(raporlar nesne)
        {
            throw new NotImplementedException();
        }

        public raporlar getir(int id)
        {
            raporlar sey = null;
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Id", id));
                personelHelper helper = new personelHelper();
                var reader = helper.GetData("Select * from tumListe2 where sicilNo=@Id", parameters);
                if (reader.HasRows)
                {
                    reader.Read();
                    sey = new raporlar();
                    sey.sicilNo = Convert.ToInt32(reader["sicilNo"]);
                    sey.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                    sey.adSoyad = (reader["adSoyad"]).ToString();
                    sey.Lokasyon = (reader["Lokasyon"]).ToString();
                    sey.Birim = (reader["Birim"]).ToString();
                    sey.Unvan = (reader["Unvan"]).ToString();
                    sey.dogumYeri = (reader["ilAdi"]).ToString();
                    sey.dogumTarihi = Convert.ToDateTime(reader["dogumTarihi"]);
                    sey.okulAdi = (reader["Okul"]).ToString();

                    if ((reader["lisans"]) != DBNull.Value)
                    {
                        sey.Bolumu = (reader["lisans"]).ToString();
                    }

                    if ((reader["bitirmeTarihi"]) != DBNull.Value)
                    {
                        sey.bitirdigiTarih = Convert.ToDateTime(reader["bitirmeTarihi"]);
                    }


                    sey.kurumaBaslamaTarihi = Convert.ToDateTime(reader["kurumaBaslamaTarihi"]);
                    if (reader["askereGidis"] != DBNull.Value)
                    {
                        sey.askereGidis = Convert.ToDateTime(reader["askereGidis"]);
                    }
                    if ((reader["askerdenDonus"]) != DBNull.Value)
                    {
                        sey.askerdenDonus = Convert.ToDateTime(reader["askerdenDonus"]);
                    }
                   

                    sey.cinsiyet = (reader["cinsiyet"]).ToString();
                    if ((reader["egitim"]) != DBNull.Value)
                    {
                        sey.egitimDurumu = (reader["egitim"]).ToString();
                    }
                    if ((reader["durumu"]) != DBNull.Value)
                    {
                        sey.askerlikDurumu = (reader["durumu"]).ToString();
                    }
                    sey.adres = reader["adres"].ToString();
                    sey.cepTel = reader["ceptel"].ToString();
                    sey.isTel = reader["istel"].ToString();

                }

            }
            catch (Exception)
            {

                throw;
            }
            return sey;
        }

        public bool guncelle(raporlar nesne)
        {
            throw new NotImplementedException();
        }

        public List<raporlar> ListeyiGetir()
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();

                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo , birim as bi, Unvan as u where li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan order by lo.id asc, bi.id, u.id asc");
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";







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
        int sig;
        int emsan;
        int ucr;
        public List<raporlar> DataGridDoldur()
        {

            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;

            int yas1 = 0;

            List<raporlar> sey = null;
            try
            {
                personelHelper helper = new personelHelper();
                var reader = helper.GetData("select * from tumListe2");
                if (reader.HasRows)
                {
                    sey = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[0]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[2]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[4]).ToString();
                        se.Unvan = (reader[5]).ToString();
                        se.dogumYeri = (reader[6]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[7]);
                        se.okulAdi = (reader[8]).ToString();
                        se.Bolumu = (reader[9]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[11]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";

                        if (sonuc[0] < 30 && sonuc[0] >= 20)
                        {
                            yas1++;
                        }

                        // se.kurumaBaslamaTarihi = Convert.ToDateTime(reader["kurumaBaslamaTarihi"]);
                        //se.askereGidis = Convert.ToDateTime(reader["askereGidis"]);
                        //se.askerdenDonus = Convert.ToDateTime(reader["askerdenDonus"]);
                        //se.borclanma = Convert.ToBoolean(reader["borclanma"]);
                        //se.sigortaBaslangic = Convert.ToDateTime(reader["sigortaBaslangic"]);
                        //se.sigortaBitis = Convert.ToDateTime(reader["sigortaBitis"]);

                        //se.cinsiyet = Convert.ToInt32(reader["cinsiyet"]);

                        //se.egitimDurumu = Convert.ToInt32(reader["egitimDurumu"]);
                        //se.askerlikDurumu = Convert.ToInt32(reader["askerlikDurumu"]);
                        //se.sonaltmisdort = Convert.ToDateTime(reader["sonaltmisdort"]);
                        //se.emekliyeEsas = Convert.ToInt32(reader["emekliyeEsas"]);
                        //se.kazanilmisHak = Convert.ToInt32(reader["kazanilmisHak"]);
                        //se.emestertar = Convert.ToDateTime(reader["emestertar"]);
                        //se.kazhaktertar = Convert.ToDateTime(reader["kazhaktertar"]);
                        //se.disiplin = Convert.ToDateTime(reader["disiplin"]);

                        sey.Add(se);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return sey;



        }


        // public int[] ikiTarihFarki2(DateTime sonTarih, DateTime ilkTarih)

        //{

        //    int ilkGun, ilkAy, ilkYil;

        //    int sonGun, sonAy, sonYil;

        //    int farkYil, farkAy, farkGun;

        //    farkYil = 0; farkAy = 0; farkGun = 0;



        //    ilkYil = ilkTarih.Year;

        //    ilkAy = ilkTarih.Month;

        //    ilkGun = ilkTarih.Day+sig+emsan+ucr;



        //    sonGun = sonTarih.Day;

        //    sonAy = sonTarih.Month;

        //    sonYil = sonTarih.Year;



        //    if (sonGun < ilkGun)

        //    {

        //        sonGun += DateTime.DaysInMonth(sonYil, sonAy);

        //        farkGun = sonGun - ilkGun;

        //        sonAy--;

        //        if (sonAy < ilkAy)

        //        {

        //            sonAy += 12;

        //            sonYil--;

        //            farkAy = sonAy - ilkAy;

        //            farkYil = sonYil - ilkYil;

        //        }

        //        else

        //        {

        //            farkAy = sonAy - ilkAy;

        //            farkYil = sonYil - ilkYil;

        //        }

        //    }

        //    else

        //    {

        //        farkGun = sonGun - ilkGun;

        //        if (sonAy < ilkAy)

        //        {

        //            sonAy += 12;

        //            sonYil--;

        //            farkAy = sonAy - ilkAy;

        //            farkYil = sonYil - ilkYil;

        //        }

        //        else

        //        {

        //            farkAy = sonAy - ilkAy;

        //            farkYil = sonYil - ilkYil;

        //        }

        //    }



        //    int[] sonuc = new int[3];

        //    sonuc[0] = farkYil;

        //    sonuc[1] = farkAy;

        //    sonuc[2] = farkGun;

        //    return sonuc;



        //    }
        public List<raporlar> ListeyiGetir2(int lokasyon)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> il = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Id", lokasyon));
                var reader = helper.GetData("Select * from sicil where lokasyon=@Id", parameters);
                if (reader.HasRows)
                {


                    il = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[0]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[2]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[4]).ToString();
                        se.Unvan = (reader[5]).ToString();
                        se.dogumYeri = (reader[6]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[7]);
                        se.okulAdi = (reader[8]).ToString();
                        se.Bolumu = (reader[9]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[11]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";


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
        public List<raporlar> sadecelokasyon(string a)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@p1", a));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo , birim as bi, Unvan as u where li.lokasyon=@p1 and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan  order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";







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
        public List<raporlar> sadecebirim(string a)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@p1", a));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo , birim as bi, Unvan as u where li.birim=@p1 and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan  order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";







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
        public List<raporlar> sadeceUnvan(string a)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@p1", a));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo , birim as bi, Unvan as u where li.Unvan=@p1 and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan  order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";







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
        public List<raporlar> sadeceCinsiyet(string a)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@p1", a));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo , birim as bi, Unvan as u where li.cinsiyet=@p1 and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan  order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";







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
        public List<raporlar> sadeceegitim(string a)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@p1", a));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo , birim as bi, Unvan as u, egitimDurumu as ed where li.egitim=@p1 and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan and li.egitim=ed.egitim  order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";







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

        public List<raporlar> sadeceasker(string a)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@p1", a));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo , birim as bi, Unvan as u, askerlikDurumu as ad , egitimDurumu as ed where li.durumu=@p1 and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan and li.egitim=ed.egitim and li.durumu=ad.durumu order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";
                                                                                                              
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
        public List<raporlar> sadecekan(string a)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@p1", a));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo ,  birim as bi, Unvan as u, askerlikDurumu as ad , egitimDurumu as ed, kanGrubu as kg where li.kangrup=@p1 and  li.kangrup=kg.kangrup and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan and li.egitim=ed.egitim and li.durumu=ad.durumu order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";

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
        public List<raporlar> lokasbirim(string a,string b)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@a1", a));
                parameters.Add(new SqlParameter("@b1", b));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo ,  birim as bi, Unvan as u, askerlikDurumu as ad , egitimDurumu as ed, kanGrubu as kg where li.lokasyon=@a1 and li.birim=@b1 and  li.kangrup=kg.kangrup and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan and li.egitim=ed.egitim and li.durumu=ad.durumu order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";

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
        public List<raporlar> lokasunvan(string a, string b)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@a1", a));
                parameters.Add(new SqlParameter("@b1", b));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo ,  birim as bi, Unvan as u, askerlikDurumu as ad , egitimDurumu as ed, kanGrubu as kg where li.lokasyon=@a1 and li.birim=@b1 and  li.kangrup=kg.kangrup and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan and li.egitim=ed.egitim and li.durumu=ad.durumu order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";

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
        public List<raporlar> lokacinsiyet(string a, string b)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@a1", a));
                parameters.Add(new SqlParameter("@b1", b));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo ,  birim as bi, Unvan as u, askerlikDurumu as ad , egitimDurumu as ed, kanGrubu as kg where li.lokasyon=@a1 and li.cinsiyet=@b1 and  li.kangrup=kg.kangrup and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan and li.egitim=ed.egitim and li.durumu=ad.durumu order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";

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
        public List<raporlar> lokaegitim(string a, string b)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@a1", a));
                parameters.Add(new SqlParameter("@b1", b));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo ,  birim as bi, Unvan as u, askerlikDurumu as ad , egitimDurumu as ed, kanGrubu as kg where li.lokasyon=@a1 and li.egitim=@b1 and  li.kangrup=kg.kangrup and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan and li.egitim=ed.egitim and li.durumu=ad.durumu order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";

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
        public List<raporlar> lokaeasker(string a, string b)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@a1", a));
                parameters.Add(new SqlParameter("@b1", b));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo ,  birim as bi, Unvan as u, askerlikDurumu as ad , egitimDurumu as ed, kanGrubu as kg where li.lokasyon=@a1 and li.durumu=@b1 and  li.kangrup=kg.kangrup and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan and li.egitim=ed.egitim and li.durumu=ad.durumu order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";

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
        public List<raporlar> lokakan(string a, string b)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@a1", a));
                parameters.Add(new SqlParameter("@b1", b));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo ,  birim as bi, Unvan as u, askerlikDurumu as ad , egitimDurumu as ed, kanGrubu as kg where li.lokasyon=@a1 and li.kangrup=@b1 and  li.kangrup=kg.kangrup and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan and li.egitim=ed.egitim and li.durumu=ad.durumu order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";

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
        public List<raporlar> lokabirimunvan(string a, string b,string c)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@a1", a));
                parameters.Add(new SqlParameter("@b1", b));
                parameters.Add(new SqlParameter("@c1", c));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo ,  birim as bi, Unvan as u, askerlikDurumu as ad , egitimDurumu as ed, kanGrubu as kg where li.lokasyon=@a1 and li.birim=@b1 and li.unvan=@c1 and li.kangrup=kg.kangrup and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan and li.egitim=ed.egitim and li.durumu=ad.durumu order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";

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

        public List<raporlar> lokabirimegitim(string a, string b, string c)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@a1", a));
                parameters.Add(new SqlParameter("@b1", b));
                parameters.Add(new SqlParameter("@c1", c));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo ,  birim as bi, Unvan as u, askerlikDurumu as ad , egitimDurumu as ed, kanGrubu as kg where li.lokasyon=@a1 and li.birim=@b1 and li.egitim=@c1 and li.kangrup=kg.kangrup and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan and li.egitim=ed.egitim and li.durumu=ad.durumu order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";

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
        public List<raporlar> lokabirimasker(string a, string b, string c)
        {
            DateTime ilktarih;

            DateTime sontarih = DateTime.Now;
            List<raporlar> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@a1", a));
                parameters.Add(new SqlParameter("@b1", b));
                parameters.Add(new SqlParameter("@c1", c));
                var reader = helper.GetData("Select * from tumListe2 as li,lokasyon as lo ,  birim as bi, Unvan as u, askerlikDurumu as ad , egitimDurumu as ed, kanGrubu as kg where li.lokasyon=@a1 and li.birim=@b1 and li.durumu=@c1 and li.kangrup=kg.kangrup and li.lokasyon=lo.lokasyon and li.birim=bi.birim and li.unvan=u.unvan and li.egitim=ed.egitim and li.durumu=ad.durumu order by lo.id asc, bi.id, u.id asc", parameters);
                if (reader.HasRows)
                {
                    lokas = new List<raporlar>();
                    while (reader.Read())
                    {
                        raporlar se = new raporlar();
                        se.sicilNo = Convert.ToInt32(reader[10]);
                        //se.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        se.adSoyad = (reader[12]).ToString();
                        //se.Lokasyon = Convert.ToInt32(reader[""]);
                        se.Birim = (reader[1]).ToString();
                        se.Unvan = (reader[2]).ToString();
                        se.dogumYeri = (reader[3]).ToString();
                        se.dogumTarihi = Convert.ToDateTime(reader[14]);
                        se.okulAdi = (reader[4]).ToString();
                        se.Bolumu = (reader[5]).ToString();
                        //se.bitirdigiTarih = Convert.ToDateTime(reader[10]);
                        ilktarih = Convert.ToDateTime(reader[16]);
                        metodlar me = new metodlar();
                        int[] sonuc = me.ikiTarihFarki(sontarih, ilktarih);
                        se.kurumHizmeti = sonuc[0].ToString() + " Yıl " + sonuc[1].ToString() + " Ay " + sonuc[2].ToString() + " Gün";

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
    }
}
