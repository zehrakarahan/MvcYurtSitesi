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
    public class DevamsizlikManager : IDevamsizlikService
    {
        private IDevamsilikBilgisiDal _Devamsizlikbilgisi;
        public DevamsizlikManager(IDevamsilikBilgisiDal Devamsizlikbilgisi)
        {
            _Devamsizlikbilgisi = Devamsizlikbilgisi;
        }
        public DevamsizlikSayisi Add(DevamsizlikSayisi entity)
        {
            return _Devamsizlikbilgisi.Add(entity);
        }

        public void Delete(DevamsizlikSayisi entity)
        {
             _Devamsizlikbilgisi.Delete(entity);
        }

        public DevamsizlikSayisi Get(int devamid)
        {
            return _Devamsizlikbilgisi.Get(x=>x.Id==devamid);
        }

        public List<DevamsizlikSayisi> GetAll()
        {
            return _Devamsizlikbilgisi.GetAll();
        }

        public DevamsizlikSayisi Update(DevamsizlikSayisi entity)
        {
            return _Devamsizlikbilgisi.Update(entity);
        }
    }
}
