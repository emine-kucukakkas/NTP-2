using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bussiness
{
    public class baseBO 
    {
    }
    public interface IBaseBO<T>  where T :BaseModel
    {


        List<T> ListeyiGetir();

        T getir(int id);

        bool ekle(T nesne);

        bool sil(int id);

        bool guncelle(T nesne);
    }
}
