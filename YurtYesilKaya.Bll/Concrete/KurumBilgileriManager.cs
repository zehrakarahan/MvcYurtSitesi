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
    public class KurumBilgileriManager : IKurumBilgileriService
    {
        private IKurumBilgileriDal _KurumBilgileriDal;
        public KurumBilgileriManager(IKurumBilgileriDal KurumBilgileriDal)
        {
            _KurumBilgileriDal = KurumBilgileriDal;
        }
     

        public void Delete(KurumBilgileri entity)
        {
            _KurumBilgileriDal.Delete(entity);
        }

        public List<KurumBilgileri> GetAll()
        {
            return _KurumBilgileriDal.GetAll();
        }

        public KurumBilgileri Get(int kurumkodu)
        {
            return _KurumBilgileriDal.Get(x => x.Id == kurumkodu);
        }

       

       

        KurumBilgileri IKurumBilgileriService.Add(KurumBilgileri entity)
        {
            return _KurumBilgileriDal.Add(entity);
        }

        KurumBilgileri IKurumBilgileriService.Update(KurumBilgileri entity)
        {
            return _KurumBilgileriDal.Update(entity);
        }

        public KurumBilgileri Getir(string KurumKodu)
        {
            return _KurumBilgileriDal.Get(x => x.KurumCode == KurumKodu);
        }

        public KurumBilgileri KurumAdiGetir(string KurumAdi)
        {
            return _KurumBilgileriDal.Get(x=>x.KurumAdi.ToUpper()==KurumAdi);
        }

      
    }
}
