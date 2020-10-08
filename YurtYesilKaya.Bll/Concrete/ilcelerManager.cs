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
    public class ilcelerManager: IilcelerService
    {
        private IilcelerDal _ilcelerDal;
        
        public ilcelerManager(IilcelerDal ilcelerDal)
        {
            _ilcelerDal = ilcelerDal;
        }

        public List<ilceler> GetAll()
        {
            return _ilcelerDal.GetAll();
        }
    }
}
