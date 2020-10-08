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
    public class SifreDegisiklikManager : ISifreDegisiklikService
    {
      
        private ISifreDegisiklikDal _SifreDegisiklikDal;
        public SifreDegisiklikManager(ISifreDegisiklikDal SifreDegisiklikDal)
        {
            _SifreDegisiklikDal = SifreDegisiklikDal;
        }
        public SifreDegisiklik Add(SifreDegisiklik entity)
        {
            return _SifreDegisiklikDal.Add(entity);
        }

        public void Delete(SifreDegisiklik entity)
        {
             _SifreDegisiklikDal.Delete(entity);
        }

        public SifreDegisiklik Get(string guid)
        {
            return _SifreDegisiklikDal.Get(x => x.guidimiz == guid);
        }

        public List<SifreDegisiklik> GetAll()
        {
            return _SifreDegisiklikDal.GetAll();
        }

        public SifreDegisiklik Update(SifreDegisiklik entity)
        {
            return _SifreDegisiklikDal.Update(entity);
        }
    }
}
