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
    public class MuracatFormuManager : IMuracatFormuService
    {
        private IMuracatFormuDal _MuracatFormuDal;
        public MuracatFormuManager(IMuracatFormuDal MuracatFormuDal)
        {
            _MuracatFormuDal = MuracatFormuDal;
        }

        public MuracatFormu Add(MuracatFormu entity)
        {
            return _MuracatFormuDal.Add(entity);
        }

        public void Delete(MuracatFormu entity)
        {
            _MuracatFormuDal.Delete(entity);
        }

        public List<MuracatFormu> GetAll()
        {
            return _MuracatFormuDal.GetAll();
        }

        public MuracatFormu Update(MuracatFormu entity)
        {
            return _MuracatFormuDal.Update(entity);
        }
    }
}
