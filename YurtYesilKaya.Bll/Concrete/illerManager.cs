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
    public class illerManager : IillerService
    {
        private IillerDal _illerDal;
        public illerManager(IillerDal illerDal)
        {
            _illerDal = illerDal;
        }
        public List<il> GetAll()
        {
            return _illerDal.GetAll();
        }

        public List<il> GetProductsByilName(string ilName)
        {
            return _illerDal.GetAll(p=>p.iladi==ilName);
        }
    }
}
