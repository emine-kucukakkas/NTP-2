using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
  public  class ikitarihfark
    {
        public int[] ikiTarihFarki(DateTime sonTarih, DateTime ilkTarih)

        {

            int ilkGun, ilkAy, ilkYil;

            int sonGun, sonAy, sonYil;

            int farkYil, farkAy, farkGun;

            farkYil = 0; farkAy = 0; farkGun = 0;



            ilkYil = ilkTarih.Year;

            ilkAy = ilkTarih.Month;

            ilkGun = ilkTarih.Day;



            sonGun = sonTarih.Day;

            sonAy = sonTarih.Month;

            sonYil = sonTarih.Year;



            if (sonGun < ilkGun)

            {

                sonGun += DateTime.DaysInMonth(sonYil, sonAy);

                farkGun = sonGun - ilkGun;

                sonAy--;

                if (sonAy < ilkAy)

                {

                    sonAy += 12;

                    sonYil--;

                    farkAy = sonAy - ilkAy;

                    farkYil = sonYil - ilkYil;

                }

                else

                {

                    farkAy = sonAy - ilkAy;

                    farkYil = sonYil - ilkYil;

                }

            }

            else

            {

                farkGun = sonGun - ilkGun;

                if (sonAy < ilkAy)

                {

                    sonAy += 12;

                    sonYil--;

                    farkAy = sonAy - ilkAy;

                    farkYil = sonYil - ilkYil;

                }

                else

                {

                    farkAy = sonAy - ilkAy;

                    farkYil = sonYil - ilkYil;

                }

            }



            int[] sonuc = new int[3];

            sonuc[0] = farkYil;

            sonuc[1] = farkAy;

            sonuc[2] = farkGun;

            return sonuc;

        }
    }
}
