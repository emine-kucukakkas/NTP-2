using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
   public class sicil:BaseModel
    {
        public int sicilNo { get; set; }
        public string tcKimlikNo { get; set; }
        public string adSoyad { get; set; }
        public int Lokasyon { get; set; }
        public int Birim { get; set; }
        public int Unvan { get; set; }
        public int dogumYeri { get; set; }
        public DateTime dogumTarihi { get; set; }
        public int okulAdi { get; set; }
        public int Bolumu { get; set; }
        public DateTime bitirdigiTarih  { get; set; }
        public DateTime kurumaBaslamaTarihi { get; set; }
        public DateTime askereGidis { get; set; }
        public DateTime askerdenDonus { get; set; }
        public bool borclanma { get; set; }
        public DateTime sigortaBaslangic { get; set; }
        public DateTime sigortaBitis { get; set; }
        public int sigortaliHizmetSuresi { get; set; }
        public int UcretsizAskerlikBorclanma { get; set; }
        public int emekliSandigiHizmeti { get; set; }
        public int cinsiyet { get; set; }
        public DateTime sonGuncelleme { get; set; }
        public string guncelleyen { get; set; }

        public int egitimDurumu { get; set; }

        public int askerlikDurumu { get; set; }

        public DateTime sonaltmisdort { get; set; }

        public int emekliyeEsas { get; set; }

        public int kazanilmisHak { get; set; }

        public DateTime emestertar { get; set; }

        public DateTime kazhaktertar { get; set; }

        public DateTime disiplin { get; set; }

        public int kanGrubu { get; set; }

        public string cepTel { get; set; }

        public string isTel { get; set; }
        public string adres { get; set; }
        public int cetvel { get; set; }

    }
}
