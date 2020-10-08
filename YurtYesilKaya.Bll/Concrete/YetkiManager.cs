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
    public class YetkiManager : IYetkiService
    {
        private IYetkiDal _YetkiDal;
        public YetkiManager(IYetkiDal YetkiDal)
        {
            _YetkiDal = YetkiDal;
        }
        public List<Yetki> GetAll()
        {
            return _YetkiDal.GetAll();
        }

        public List<Yetki> GetProductsByYetkiName(string yetkiName)
        {
            return _YetkiDal.GetAll(p=>p.yetkiadi==yetkiName);
        }
    }
}
