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
    public class OzelDurumIndirimManager : IOzelDurumIndirimService
    {
        private IOzelDurumIndirimDal _OzelDurumIndirimDal;
        public OzelDurumIndirimManager(IOzelDurumIndirimDal OzelDurumIndirimDal)
        {
            _OzelDurumIndirimDal = OzelDurumIndirimDal;
        }
      

        public void Delete(OzelDurum entity)
        {
            _OzelDurumIndirimDal.Delete(entity);
        }

        public OzelDurum Get(int id)
        {
            return _OzelDurumIndirimDal.Get(p => p.Id == id);
        }

        public List<OzelDurum> GetAll()
        {
            return _OzelDurumIndirimDal.GetAll();
        }

        public List<OzelDurum> GetOzelDurumİndirimListesiByOzelDurumName(string OzelDurumName)
        {
            return _OzelDurumIndirimDal.GetAll(p=>p.OzelDurumadi==OzelDurumName);
        }

        public OzelDurum GetString(string ozeldurum)
        {
            return _OzelDurumIndirimDal.Get(x=>x.OzelDurumadi==ozeldurum);
        }

        OzelDurum IOzelDurumIndirimService.Add(OzelDurum entity)
        {
            return _OzelDurumIndirimDal.Add(entity);
        }

        OzelDurum IOzelDurumIndirimService.Update(OzelDurum entity)
        {
            return _OzelDurumIndirimDal.Update(entity);
        }
    }
}
