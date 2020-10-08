using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Abstract
{
    public interface IKullanicilarService
    {
        List<Kullanici> GetAll();
        List<Kullanici> GetKullanicisByKullaniciId(int KullaniciId);
        List<Kullanici> GetKullaniciByKullaniciName(string KullaniciName);
        Kullanici KullaniciGiris(string kullaniciadi,string parola);
        Kullanici GetKullaniciKullaniciName(string Kullaniciadi);
        Kullanici Update(Kullanici entity);
        void Delete(Kullanici entity);
        Kullanici Add(Kullanici entity);
        Kullanici KullaniciveEmail(string kullaniciadi, string email);
    }
}
