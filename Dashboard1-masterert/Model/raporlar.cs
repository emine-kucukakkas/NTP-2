using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
namespace Model
{
    public class raporlar:BaseModel
    {

        public int sicilNo { get; set; }
        public string tcKimlikNo { get; set; }
        public string adSoyad { get; set; }
        public string Lokasyon { get; set; }
        public string Birim { get; set; }
        public string Unvan { get; set; }
        public string dogumYeri { get; set; }
        public DateTime dogumTarihi { get; set; }
        public string okulAdi { get; set; }
        public string Bolumu { get; set; }
        public DateTime bitirdigiTarih { get; set; }
        public DateTime kurumaBaslamaTarihi { get; set; }
        public DateTime askereGidis { get; set; }
        public DateTime askerdenDonus { get; set; }
        public bool borclanma { get; set; }
        public DateTime sigortaBaslangic { get; set; }
        public DateTime sigortaBitis { get; set; }
        public int sigortaliHizmetSuresi { get; set; }
        public int UcretsizAskerlikBorclanma { get; set; }
        public int emekliSandigiHizmeti { get; set; }
        public string cinsiyet { get; set; }
        public DateTime sonGuncelleme { get; set; }
        public string guncelleyen { get; set; }

        public string egitimDurumu { get; set; }

        public string askerlikDurumu { get; set; }

        public DateTime sonaltmisdort { get; set; }

        public string emekliyeEsas { get; set; }

        public string kazanilmisHak { get; set; }

        public DateTime emestertar { get; set; }

        public DateTime kazhaktertar { get; set; }

        public DateTime disiplin { get; set; }

        public string kanGrubu { get; set; }

        public string cepTel { get; set; }

        public string isTel { get; set; }
        public string adres { get; set; }


        public string kurumHizmeti { get; set; }

        public string toplamHizmet { get; set; }



    }
}
