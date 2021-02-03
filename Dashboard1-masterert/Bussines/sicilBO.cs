using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data.SqlClient;
using DataCore;


namespace Bussiness
{
    
    public class sicilBO : baseBO, IBaseBO<sicil>
    {
        
        public bool ekle(sicil nesne)
        {

            bool result = false;
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@sicilNo", nesne.sicilNo));
                parameters.Add(new SqlParameter("@tcKimlikNo", nesne.tcKimlikNo));
                parameters.Add(new SqlParameter("@adSoyad", nesne.adSoyad));
                parameters.Add(new SqlParameter("@Lokasyon", nesne.Lokasyon));
                parameters.Add(new SqlParameter("@Birim", nesne.Birim));
                parameters.Add(new SqlParameter("@Unvan", nesne.Unvan));
                parameters.Add(new SqlParameter("@dogumYeri", nesne.dogumYeri));
                parameters.Add(new SqlParameter("@dogumTarihi", nesne.dogumTarihi));
                parameters.Add(new SqlParameter("@okulAdi", nesne.okulAdi));
                parameters.Add(new SqlParameter("@Bolumu", nesne.Bolumu));
                parameters.Add(new SqlParameter("@bitirmeTarihi", nesne.bitirdigiTarih));
                parameters.Add(new SqlParameter("@kurumaBaslamaTarihi", nesne.kurumaBaslamaTarihi));
                parameters.Add(new SqlParameter("@askereGidis", nesne.askereGidis));
                parameters.Add(new SqlParameter("@askerdenDonus", nesne.askerdenDonus));
                parameters.Add(new SqlParameter("@borclanma", nesne.borclanma));
                parameters.Add(new SqlParameter("@sigortaBaslangic", nesne.sigortaBaslangic));
                parameters.Add(new SqlParameter("@sigortaBitis", nesne.sigortaBitis));
                parameters.Add(new SqlParameter("@sigortaliHizmetSuresi", nesne.sigortaliHizmetSuresi));
                parameters.Add(new SqlParameter("@UcretsizAskerlikBorclanma", nesne.UcretsizAskerlikBorclanma));
                parameters.Add(new SqlParameter("@emekliSandigiHizmeti", nesne.emekliSandigiHizmeti));
                parameters.Add(new SqlParameter("@cinsiyet", nesne.cinsiyet));
                parameters.Add(new SqlParameter("@sonGuncelleme", nesne.sonGuncelleme));
                parameters.Add(new SqlParameter("@guncelleyen", nesne.guncelleyen));
                parameters.Add(new SqlParameter("@kanGrubu", nesne.kanGrubu));
                parameters.Add(new SqlParameter("@cepTel", nesne.cepTel));
                parameters.Add(new SqlParameter("@isTel", nesne.isTel));
                parameters.Add(new SqlParameter("@adres", nesne.adres));
                parameters.Add(new SqlParameter("@egitimDurumu", nesne.egitimDurumu));
                parameters.Add(new SqlParameter("@askerlikDurumu", nesne.askerlikDurumu));
                parameters.Add(new SqlParameter("@sonaltmisdort", nesne.sonaltmisdort));
                parameters.Add(new SqlParameter("@emekliyeesas", nesne.emekliyeEsas));
                parameters.Add(new SqlParameter("@kazanilmishak", nesne.kazanilmisHak));
                parameters.Add(new SqlParameter("@kha", nesne.kazhaktertar));
                parameters.Add(new SqlParameter("@emes", nesne.emestertar));
                parameters.Add(new SqlParameter("@disiplin", nesne.disiplin));
                


                personelHelper helper = new personelHelper();
                result = helper.ExecuteCommand("Insert into sicil (sicilNo,tcKimlikNo,adSoyad,Lokasyon,Birim,Unvan,dogumYeri,dogumTarihi,okulAdi,Bolumu,bitirmeTarihi,kurumaBaslamaTarihi,askereGidis,askerdenDonus,borclanma,sigortaBaslangic,sigortaBitis,sigortaliHizmetSuresi,UcretsizAskerlikBorclanma,emekliSandigiHizmeti,cinsiyet,sonGuncelleme,guncelleyen,kanGrubu,cepTel,isTel,adres,egitimDurumu,askerlikDurumu,sonaltmisdort,emekliyeEsas,kazanilmisHak,emestertar,kazhaktertar,disiplin) values(@sicilNo,@tcKimlikNo,@adSoyad,@Lokasyon,@Birim,@Unvan,@dogumYeri,@dogumTarihi,@okulAdi,@Bolumu,@bitirmeTarihi,@kurumaBaslamaTarihi,@askereGidis,@askerdenDonus,@borclanma,@sigortaBaslangic,@sigortaBitis,@sigortaliHizmetSuresi,@UcretsizAskerlikBorclanma,@emekliSandigiHizmeti,@cinsiyet,@sonGuncelleme,@guncelleyen,@kanGrubu,@cepTel,@isTel,@adres,@egitimDurumu,@askerlikDurumu,@sonaltmisdort,@emekliyeesas,@kazanilmishak,@emes,@kha,@disiplin)", parameters) > 0;

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }


        public sicil getir(int id)
        {
            sicil sey = null;
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Id", id));
                personelHelper helper = new personelHelper();
                var reader = helper.GetData("Select * from sicil where sicilNo=@Id", parameters);
                if (reader.HasRows)
                {
                    reader.Read();
                    sey = new sicil();
                    sey.sicilNo = Convert.ToInt32(reader["sicilNo"]);
                    sey.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                    sey.adSoyad = (reader["adSoyad"]).ToString();
                    sey.Lokasyon = Convert.ToInt32(reader["Lokasyon"]);
                    sey.Birim = Convert.ToInt32(reader["Birim"]);
                    sey.Unvan = Convert.ToInt32(reader["Unvan"]);
                    sey.dogumYeri = Convert.ToInt32(reader["dogumYeri"]);
                    sey.dogumTarihi = Convert.ToDateTime(reader["dogumTarihi"]);
                    sey.okulAdi = Convert.ToInt32(reader["okulAdi"]);

                    if ((reader["Bolumu"])!=DBNull.Value)
                    {
                        sey.Bolumu = Convert.ToInt32(reader["Bolumu"]);
                    }

                    if ((reader["bitirmeTarihi"])!=DBNull.Value)
                    {
                        sey.bitirdigiTarih = Convert.ToDateTime(reader["bitirmeTarihi"]);
                    }

                   
                    sey.kurumaBaslamaTarihi = Convert.ToDateTime(reader["kurumaBaslamaTarihi"]);
                    if (reader["askereGidis"]!=DBNull.Value)
                    {
                        sey.askereGidis = Convert.ToDateTime(reader["askereGidis"]);
                    }
                    if ((reader["askerdenDonus"])!=DBNull.Value)
                    {
                        sey.askerdenDonus = Convert.ToDateTime(reader["askerdenDonus"]);
                    }
                    if ((reader["borclanma"])!=DBNull.Value)
                    {
                        sey.borclanma = Convert.ToBoolean(reader["borclanma"]);
                    }
                    if ((reader["sigortaBaslangic"])!=DBNull.Value)
                    {
                        sey.sigortaBaslangic = Convert.ToDateTime(reader["sigortaBaslangic"]);
                    }
                    if ((reader["sigortaBitis"])!=DBNull.Value)
                    {
                        sey.sigortaBitis = Convert.ToDateTime(reader["sigortaBitis"]);
                    }
                    if ((reader["sigortaliHizmetSuresi"])!=DBNull.Value)
                    {
                        sey.sigortaliHizmetSuresi = Convert.ToInt32(reader["sigortaliHizmetSuresi"]);
                    }
                    if ((reader["ucretsizAskerlikBorclanma"])!=DBNull.Value)
                    {
                        sey.UcretsizAskerlikBorclanma = Convert.ToInt32(reader["ucretsizAskerlikBorclanma"]);
                    }
                    if ((reader["emekliSandigiHizmeti"])!=DBNull.Value)
                    {
                        sey.emekliSandigiHizmeti = Convert.ToInt32(reader["emekliSandigiHizmeti"]);
                    }
                   
                    sey.cinsiyet = Convert.ToInt32(reader["cinsiyet"]);
                    if ((reader["egitimDurumu"])!=DBNull.Value)
                    {
                        sey.egitimDurumu = Convert.ToInt32(reader["egitimDurumu"]);
                    }
                    if ((reader["askerlikDurumu"])!=DBNull.Value)
                    {
                        sey.askerlikDurumu = Convert.ToInt32(reader["askerlikDurumu"]);
                    }
                    if ((reader["sonaltmisdort"])!=DBNull.Value)
                    {
                        sey.sonaltmisdort = Convert.ToDateTime(reader["sonaltmisdort"]);
                    }
                    if ((reader["emekliyeEsas"])!=DBNull.Value)
                    {
                        sey.emekliyeEsas = Convert.ToInt32(reader["emekliyeEsas"]);
                    }
                    if ((reader["kazanilmisHak"])!=DBNull.Value)
                    {
                        sey.kazanilmisHak = Convert.ToInt32(reader["kazanilmisHak"]);
                    }
                    if ((reader["emestertar"])!=DBNull.Value)
                    {
                        sey.emestertar = Convert.ToDateTime(reader["emestertar"]);
                    }
                    if ((reader["kazhaktertar"])!=DBNull.Value)
                    {
                        sey.kazhaktertar = Convert.ToDateTime(reader["kazhaktertar"]);
                    }
                    if ((reader["disiplin"])!=DBNull.Value)
                    {
                        sey.disiplin = Convert.ToDateTime(reader["disiplin"]);
                    }
                   
                }

            }
            catch (Exception)
            {

                throw;
            }
            return sey;
        }

        public bool guncelle(sicil nesne)
        {
            bool result = false;
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@sicilNo", nesne.sicilNo));
                parameters.Add(new SqlParameter("@tcKimlikNo", nesne.tcKimlikNo));
                parameters.Add(new SqlParameter("@adSoyad", nesne.adSoyad));
                parameters.Add(new SqlParameter("@Lokasyon", nesne.Lokasyon));
                parameters.Add(new SqlParameter("@Birim", nesne.Birim));
                parameters.Add(new SqlParameter("@Unvan", nesne.Unvan));
                parameters.Add(new SqlParameter("@dogumYeri", nesne.dogumYeri));
                parameters.Add(new SqlParameter("@dogumTarihi", nesne.dogumTarihi));
                parameters.Add(new SqlParameter("@okulAdi", nesne.okulAdi));
                parameters.Add(new SqlParameter("@Bolumu", nesne.Bolumu));
                parameters.Add(new SqlParameter("@bitirmeTarihi", nesne.bitirdigiTarih));
                parameters.Add(new SqlParameter("@kurumaBaslamaTarihi", nesne.kurumaBaslamaTarihi));
                parameters.Add(new SqlParameter("@askereGidis", nesne.askereGidis));
                parameters.Add(new SqlParameter("@askerdenDonus", nesne.askerdenDonus));
                parameters.Add(new SqlParameter("@borclanma", nesne.borclanma));
                parameters.Add(new SqlParameter("@sigortaBaslangic", nesne.sigortaBaslangic));
                parameters.Add(new SqlParameter("@sigortaBitis", nesne.sigortaBitis));
                parameters.Add(new SqlParameter("@sigortaliHizmetSuresi", nesne.sigortaliHizmetSuresi));
                parameters.Add(new SqlParameter("@UcretsizAskerlikBorclanma", nesne.UcretsizAskerlikBorclanma));
                parameters.Add(new SqlParameter("@emekliSandigiHizmeti", nesne.emekliSandigiHizmeti));
                parameters.Add(new SqlParameter("@cinsiyet", nesne.cinsiyet));
                parameters.Add(new SqlParameter("@sonGuncelleme", nesne.sonGuncelleme));
                parameters.Add(new SqlParameter("@guncelleyen", nesne.guncelleyen));
                parameters.Add(new SqlParameter("@kanGrubu", nesne.kanGrubu));
                parameters.Add(new SqlParameter("@cepTel", nesne.cepTel));
                parameters.Add(new SqlParameter("@isTel", nesne.isTel));
                parameters.Add(new SqlParameter("@adres", nesne.adres));
                parameters.Add(new SqlParameter("@egitimDurumu", nesne.egitimDurumu));
                parameters.Add(new SqlParameter("@askerlikDurumu", nesne.askerlikDurumu));
                parameters.Add(new SqlParameter("@sonaltmisdort", nesne.sonaltmisdort));
                parameters.Add(new SqlParameter("@emekliyeesas", nesne.emekliyeEsas));
                parameters.Add(new SqlParameter("@kazanilmishak", nesne.kazanilmisHak));
                parameters.Add(new SqlParameter("@kha", nesne.kazhaktertar));
                parameters.Add(new SqlParameter("@emes", nesne.emestertar));
                parameters.Add(new SqlParameter("@disiplin", nesne.disiplin));


                personelHelper helper = new personelHelper();
                result = helper.ExecuteCommand("Update sicil set tcKimlikNo=@tcKimlikNo,adSoyad=@adSoyad,Lokasyon=@Lokasyon,Birim=@Birim,Unvan=@Unvan,dogumYeri=@dogumYeri,dogumTarihi=@dogumTarihi,okulAdi=@okulAdi,Bolumu=@Bolumu,bitirmeTarihi=@bitirmeTarihi,kurumaBaslamaTarihi=@kurumaBaslamaTarihi,askereGidis=@askereGidis,askerdenDonus=@askerdenDonus,borclanma=@borclanma,sigortaBaslangic=@sigortaBaslangic,sigortaBitis=@sigortaBitis,sigortaliHizmetSuresi=@sigortaliHizmetSuresi,UcretsizAskerlikBorclanma=@UcretsizAskerlikBorclanma,emekliSandigiHizmeti=@emekliSandigiHizmeti,cinsiyet=@cinsiyet,sonGuncelleme=@sonGuncelleme,guncelleyen=@guncelleyen,kanGrubu=@kanGrubu,cepTel=@cepTel,isTel=@isTel,adres=@adres,egitimDurumu=@egitimDurumu,askerlikDurumu=@askerlikDurumu,sonaltmisdort=@sonaltmisdort,emekliyeesas=@emekliyeesas,kazanilmishak=@kazanilmishak,emestertar=@emes,kazhaktertar=@kha,disiplin=@disiplin  where sicilNo=@sicilNo", parameters) > 0;
            }
            catch (Exception)
            {

                throw; 
            }
            return result;
        }

        public List<sicil> ListeyiGetir()
        {
            List<sicil> lokas = null;
            try
            {
                personelHelper helper = new personelHelper();
                var reader = helper.GetData("Select * from sicil");
                if (reader.HasRows)
                {
                    lokas = new List<sicil>();
                    while (reader.Read())
                    {
                        sicil sey = new sicil();
                        sey.sicilNo = Convert.ToInt32(reader["sicilNo"]);
                        sey.tcKimlikNo = (reader["tcKimlikNo"]).ToString();
                        sey.adSoyad = (reader["adSoyad"]).ToString();
                        sey.Lokasyon = Convert.ToInt32(reader["Lokasyon"]);
                        sey.Birim = Convert.ToInt32(reader["Birim"]);
                        sey.Unvan = Convert.ToInt32(reader["Unvan"]);
                        sey.dogumYeri = Convert.ToInt32(reader["dogumYeri"]);
                        sey.dogumTarihi = Convert.ToDateTime(reader["dogumTarihi"]);
                        sey.okulAdi = Convert.ToInt32(reader["okulAdi"]);

                        if ((reader["Bolumu"]) != DBNull.Value)
                        {
                            sey.Bolumu = Convert.ToInt32(reader["Bolumu"]);
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
                        if ((reader["borclanma"]) != DBNull.Value)
                        {
                            sey.borclanma = Convert.ToBoolean(reader["borclanma"]);
                        }
                        if ((reader["sigortaBaslangic"]) != DBNull.Value)
                        {
                            sey.sigortaBaslangic = Convert.ToDateTime(reader["sigortaBaslangic"]);
                        }
                        if ((reader["sigortaBitis"]) != DBNull.Value)
                        {
                            sey.sigortaBitis = Convert.ToDateTime(reader["sigortaBitis"]);
                        }
                        if ((reader["sigortaliHizmetSuresi"]) != DBNull.Value)
                        {
                            sey.sigortaliHizmetSuresi = Convert.ToInt32(reader["sigortaliHizmetSuresi"]);
                        }
                        if ((reader["ucretsizAskerlikBorclanma"]) != DBNull.Value)
                        {
                            sey.UcretsizAskerlikBorclanma = Convert.ToInt32(reader["ucretsizAskerlikBorclanma"]);
                        }
                        if ((reader["emekliSandigiHizmeti"]) != DBNull.Value)
                        {
                            sey.emekliSandigiHizmeti = Convert.ToInt32(reader["emekliSandigiHizmeti"]);
                        }

                        sey.cinsiyet = Convert.ToInt32(reader["cinsiyet"]);
                        if ((reader["egitimDurumu"]) != DBNull.Value)
                        {
                            sey.egitimDurumu = Convert.ToInt32(reader["egitimDurumu"]);
                        }
                        if ((reader["askerlikDurumu"]) != DBNull.Value)
                        {
                            sey.askerlikDurumu = Convert.ToInt32(reader["askerlikDurumu"]);
                        }
                        if ((reader["sonaltmisdort"]) != DBNull.Value)
                        {
                            sey.sonaltmisdort = Convert.ToDateTime(reader["sonaltmisdort"]);
                        }
                        if ((reader["emekliyeEsas"]) != DBNull.Value)
                        {
                            sey.emekliyeEsas = Convert.ToInt32(reader["emekliyeEsas"]);
                        }
                        if ((reader["kazanilmisHak"]) != DBNull.Value)
                        {
                            sey.kazanilmisHak = Convert.ToInt32(reader["kazanilmisHak"]);
                        }
                        if ((reader["emestertar"]) != DBNull.Value)
                        {
                            sey.emestertar = Convert.ToDateTime(reader["emestertar"]);
                        }
                        if ((reader["kazhaktertar"]) != DBNull.Value)
                        {
                            sey.kazhaktertar = Convert.ToDateTime(reader["kazhaktertar"]);
                        }
                        if ((reader["disiplin"]) != DBNull.Value)
                        {
                            sey.disiplin = Convert.ToDateTime(reader["disiplin"]);
                        }




                        lokas.Add(sey);
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
            bool result = false;
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@sicilNo", id));
                personelHelper helper = new personelHelper();
                result = helper.ExecuteCommand("Delete from sicil where sicilNo=@sicilNo", parameters) > 0;
            }
            catch (Exception)
            {

            }
            return result;
        }

        public bool mukerrer(int id)
        {
            bool result = false;
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@p1", id));


                personelHelper h = new personelHelper();
                var reader = h.GetData1("select * from sicil where sicilNo=@p1)", parameters);

                if (reader.HasRows)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return result;



        }

       

    }
        
}
