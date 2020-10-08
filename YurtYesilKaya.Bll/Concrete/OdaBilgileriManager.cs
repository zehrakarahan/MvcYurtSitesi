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
    public class OdaBilgileriManager : IOdaBilgileriService
    {
        private IOdaBilgileriDal _OdaKisiSayisiDal;
        public OdaBilgileriManager(IOdaBilgileriDal OdaKisiSayisiDal)
        {
            _OdaKisiSayisiDal = OdaKisiSayisiDal;
        }
       

        public void Delete(OdaBilgileri entity)
        {
            _OdaKisiSayisiDal.Delete(entity);
        }
       
        public OdaBilgileri Get(int OdaId)
        {
            return _OdaKisiSayisiDal.Get(x=>x.Id==OdaId);
        }

        public List<OdaBilgileri> GetAll()
        {
            return _OdaKisiSayisiDal.GetAll();
        }

        public List<OdaBilgileri> GetKisisayisi(string odakisisayisi)
        {
            return _OdaKisiSayisiDal.Getsayi(x => x.odakisisayisi == odakisisayisi).ToList();
        }

        public List<OdaBilgileri> GetOdaKisiSayisiByOdaNo(int OdaNo)
        {
            return _OdaKisiSayisiDal.GetAll(p=>p.OdaNo==OdaNo);
        }

        public List<OdaBilgileri> GetOdaNo()
        {
            return _OdaKisiSayisiDal.GetAll().OrderBy(x=>x.OdaNo).ToList();
        }

        OdaBilgileri IOdaBilgileriService.Add(OdaBilgileri entity)
        {
            return _OdaKisiSayisiDal.Add(entity);
        }

        OdaBilgileri IOdaBilgileriService.Update(OdaBilgileri entity)
        {
            return _OdaKisiSayisiDal.Update(entity);
        }
    }
}
