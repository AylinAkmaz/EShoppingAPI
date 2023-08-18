using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Entity.Result
{
    public class HataBilgisi
    {
        public string HataAçıklama { get; set; }
        public object Hata { get; set; }

        public static HataBilgisi NotFound(string hataAçıklama = "Sonuç Bulunamadı", object? hata = null)
        {
            return new HataBilgisi { Hata = hata, HataAçıklama = hataAçıklama };

        }

        public static HataBilgisi Error(string hataAçıklama = "Genel Bir Hata Oluştu", object? hata = null)
        {
            return new HataBilgisi { Hata = hata, HataAçıklama = hataAçıklama };

        }


        public static HataBilgisi AuthenticationError(string hataAçıklama = "Kullanıcı Bulunamadı", object? hata = null)
        {
            return new HataBilgisi { Hata = hata, HataAçıklama = hataAçıklama };

        }

        public static HataBilgisi FieldValidationError(object? hata = null, string hataAçıklama = " Zorunlu Alanlarda Eksiklikler Var")
        {
            return new HataBilgisi { Hata = hata, HataAçıklama = hataAçıklama };

        }

        public static HataBilgisi TokenNotFoundError(object? hata = null, string hataAçıklama = " Token Bilgisi Gelmedi")
        {
            return new HataBilgisi { Hata = hata, HataAçıklama = hataAçıklama };

        }

        public static HataBilgisi TokenError(object? hata = null, string hataAçıklama = " Token Hatası")
        {
            return new HataBilgisi { Hata = hata, HataAçıklama = hataAçıklama };

        }


    }
}
