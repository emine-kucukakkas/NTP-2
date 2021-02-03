using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Login:BaseModel
    {
        public int Id { get; set; }

        public string KullaniciAdi { get; set; }

        public string Sifre { get; set; }

        public string AdSoyad { get; set; }

        public bool Aktifmi { get; set; }

        public bool Silindimi { get; set; }

        public DateTime SonGirisTarihi { get; set; }

        public DateTime KayitTarihi { get; set; }

        public string email { get; set; }

        public string resim { get; set; }
        public int yetki { get; set; }
    }
}
