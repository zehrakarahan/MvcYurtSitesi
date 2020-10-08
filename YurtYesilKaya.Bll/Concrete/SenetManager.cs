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
    public class SenetManager : ISenetService
    {
        private ISenetDal _SenetDal;
        public SenetManager(ISenetDal SenetDal)
        {
            _SenetDal = SenetDal;
        }
      
       

        public void Delete(Senet entity)
        {
            _SenetDal.Delete(entity);
        }

        public List<Senet> GetAll()
        {
            return _SenetDal.GetAll();
        }

       

      

        Senet ISenetService.Add(Senet entity)
        {
            return _SenetDal.Add(entity);
        }

        Senet ISenetService.Update(Senet entity)
        {
            return _SenetDal.Update(entity);
        }
    }
}
