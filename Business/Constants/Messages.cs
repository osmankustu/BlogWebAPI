using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ArticleAdd = "Makale Eklendi";
        public static string ArticleListted = "Makale Listelendi";
        public static string MaintanceTime = "Sistem Bakımda";
        public static string ArticleDetails = "Makale Detayları Listelendi";
        internal static string ArticleCountOfCategoryError = "Bir Kategoride Sadece 10 Adet Makale Olabilir";
        internal static string ArticleNameExists = "Bu Makale İsmi Zaten Mevcut";
        internal static string CategoryLimitExceded = "Kategori Limiti Aşıldı";
        internal static string AuthorizationDenied="Bu Sayfaya Giriş İçin Yetkiniz Yoktur";
        internal static string UserRegistered="Kullanıcı Kayıt Edildi";
        internal static string UserNotFound = "Kullanıcı Bulunamadı";
        internal static string PasswordError="Hatalı Şifre";
        internal static string SuccessfulLogin="Giriş Başarılı";
        internal static string UserAlreadyExists=" Güvenli Çıkış Başarılı";
        internal static string AccessTokenCreated="Token Oluşturuldu";
    }
}
