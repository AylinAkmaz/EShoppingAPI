using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EShoppingAPI.Entity.Result
{
    public class Sonuç<T>
    {
        public Sonuç(T _data, string _Mesaj, int _StatusCode, HataBilgisi _hataBilgisi)
        {
            this.Data = _data;
            this.Mesaj = _Mesaj;
            this.StatusCode = _StatusCode;
            this.HataBilgisi = _hataBilgisi;
        }

        public Sonuç(T _data, string _Mesaj, int _StatusCode)
        {
            this.Data = _data;
            this.Mesaj = _Mesaj;
            this.StatusCode = _StatusCode;
        }


        public Sonuç(string _Mesaj, int _StatusCode)
        {
            this.Mesaj = _Mesaj;
            this.StatusCode = _StatusCode;
        }


        public Sonuç(string _Mesaj, int _StatusCode, HataBilgisi _hataBilgisi)
        {
            this.Mesaj = _Mesaj;
            this.StatusCode = _StatusCode;
            this.HataBilgisi = _hataBilgisi;
        }

        public T Data { get; set; }
        public string Mesaj { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public HataBilgisi HataBilgisi { get; set; }


        public static Sonuç<T> SuccessWithData(T data, string mesaj = "İşlem Başarılı", int statusCode = (int)HttpStatusCode.OK)
        {
            return new Sonuç<T>(data, mesaj, statusCode);

        }

        public static Sonuç<T> SuccessWithoutData(string mesaj = "İşlem Başarılı", int statusCode = (int)HttpStatusCode.OK)
        {
            return new Sonuç<T>(mesaj, statusCode);

        }

        public static Sonuç<T> SuccessNoDataFound(string mesaj = "Sonuç Bulunamadı", int statusCode = (int)HttpStatusCode.NotFound)
        {
            return new Sonuç<T>(mesaj, statusCode, HataBilgisi.NotFound());
        }

        public static Sonuç<T> FieldValidationError(List<string>? errorMessages = null, string mesaj = " Hata Oluştu", int statusCode = (int)HttpStatusCode.BadRequest)
        {
            return new Sonuç<T>(mesaj, statusCode, HataBilgisi.FieldValidationError(errorMessages));
        }
        public static Sonuç<T> Error(HataBilgisi hataBilgisi, string mesaj = " Hata Oluştu", int statusCode = (int)HttpStatusCode.InternalServerError)
        {
            return new Sonuç<T>(mesaj, statusCode, HataBilgisi.Error());
        }


        public static Sonuç<T> AuthenticationError(string mesaj = "Kullanıcı Bulunamadı", int statusCode = (int)HttpStatusCode.NotFound)
        {
            return new Sonuç<T>(mesaj, statusCode, HataBilgisi.AuthenticationError());
        }

        public static Sonuç<T> TokenError(HataBilgisi hataBilgisi, int statusCode = (int)HttpStatusCode.Unauthorized)
        {
            return new Sonuç<T>("Hata Oluştu", statusCode, HataBilgisi.TokenError());
        }

        public static Sonuç<T> TokenNotFoundError(HataBilgisi hataBilgisi, int statusCode = (int)HttpStatusCode.Unauthorized)
        {
            return new Sonuç<T>("Hata Oluştu", statusCode, HataBilgisi.TokenNotFoundError());
        }


    }
}
