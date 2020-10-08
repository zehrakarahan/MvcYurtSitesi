using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Bll.Abstract;
using YurtYesilKaya.Dal.Abstract;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Concrete
{
    public class OgrenciManager : IOgrenciService
    {
        private IOgrenciDal _OgrenciDal;
        public OgrenciManager(IOgrenciDal OgrenciDal)
        {
            _OgrenciDal = OgrenciDal;
        }
 
        public void Delete(Ogrenci entity)
        {
            _OgrenciDal.Delete(entity);
        }

        public Ogrenci Get(int OgrenciId)
        {
            return _OgrenciDal.Get(p=>p.Id==OgrenciId);
        }

        public Ogrenci Getadsoyad(string adsoyad)
        {
           
            return  _OgrenciDal.Get(p=>p.ogrenciadisoyadi.ToUpper()==adsoyad.ToUpper());
        }

        public List<Ogrenci> GetAll()
        {
            return _OgrenciDal.GetAll();
        }

        public List<Ogrenci> Getkisiler(int odaid)
        {
            return _OgrenciDal.Getsayi(x => x.OdaBilgileriId == odaid).ToList();
        }

        Ogrenci IOgrenciService.Add(Ogrenci entity)
        {
            return _OgrenciDal.Add(entity);
        }

        Ogrenci IOgrenciService.Update(Ogrenci entity)
        {
            return _OgrenciDal.Update(entity);
        }
    }
}
