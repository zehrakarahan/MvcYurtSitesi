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
    public class ArsivManager : IArsivService
    {
        private IArsivDal _ArsivDal;
        public ArsivManager(IArsivDal ArsivDal)
        {
            _ArsivDal = ArsivDal;
        }

        public Arsiv Add(Arsiv entity)
        {
            return _ArsivDal.Add(entity);
        }

        public void Delete(Arsiv entity)
        {
            _ArsivDal.Delete(entity);
        }

        public List<Arsiv> GetAll()
        {
            return _ArsivDal.GetAll();
        }

        public Arsiv Update(Arsiv entity)
        {
            return _ArsivDal.Update(entity);
        }
    }
}
