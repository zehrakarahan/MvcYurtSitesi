using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Bll.Abstract;
using YurtYesilKaya.Dal.Abstract;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Concrete
{
    public class KullanicilarManager : IKullanicilarService
    {
        
        private IKullanicilarDal _KullanicilarDal;
        public KullanicilarManager(IKullanicilarDal KullanicilarDal)
        {
            _KullanicilarDal = KullanicilarDal;
        }
        YesilKayaContext db = new YesilKayaContext();

        public void Delete(Kullanici entity)
        {
            _KullanicilarDal.Delete(entity);
        }

        public List<Kullanici> GetAll()
        {
            return _KullanicilarDal.GetAll();
        }

        public List<Kullanici> GetKullaniciByKullaniciName(string KullaniciName)
        {
            return _KullanicilarDal.GetAll(p=>p.KullaniciAdi==KullaniciName);
        }

        public List<Kullanici> GetKullanicisByKullaniciId(int KullaniciId)
        {
            return _KullanicilarDal.GetAll(p=>p.Id==KullaniciId);
        }

        public Kullanici KullaniciGiris(string kullaniciadi, string parola)
        {
          
                var sifre = new ToPasswordRepository().Md5(parola);
                var kullanici = db.Kullanici.Where(x => x.KullaniciAdi == kullaniciadi && x.Parola == sifre).SingleOrDefault();
                if (kullanici == null)
                {
                  return null;
                }
                if(kullanici!=null)
                {
                return kullanici;
                }
            return null;

        }
      
        Kullanici IKullanicilarService.Add(Kullanici entity)
        {

            return _KullanicilarDal.Add(entity);
        }

        Kullanici IKullanicilarService.Update(Kullanici entity)
        {
            return _KullanicilarDal.Update(entity);
        }
        
        public Kullanici KullaniciveEmail(string kullaniciadi, string email)
        {
            var kullanici = db.Kullanici.Where(x => x.KullaniciAdi == kullaniciadi && x.telefonno == email).FirstOrDefault();
            var kullanici2 = db.Kullanici.Where(x => x.KullaniciAdi == kullaniciadi).FirstOrDefault();
            var kullanici3 = db.Kullanici.Where(x =>x.telefonno == email).FirstOrDefault();
            if (kullanici==null)
            {
                if(kullanici2==null && kullanici3==null)
                {
                    throw new Exception("Malesef bu şekilde bir kullanıcı yok!!!");
                    
                }
                if(kullanici2 != null && kullanici3 == null)
                {
                    throw new Exception("Mail Adresi yanlış!!!");
                }
                if(kullanici2 == null && kullanici3 != null)
                {
                    throw new Exception("Girdiğiniz Kullanıcı Adı yanlış!!!");
                }
                return null;
            }
            else
            {
                return kullanici;
            }
           
        }

        public Kullanici GetKullaniciKullaniciName(string Kullaniciadi)
        {
            return _KullanicilarDal.Get(x=>x.KullaniciAdi==Kullaniciadi);
        }
    }
}
