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
    public class OgrenciHareketleriManager : IOgrenciHareketleriService
    {
        private IOgrenciHareketleriDal _OgrenciHareketleriDal;
        public OgrenciHareketleriManager(IOgrenciHareketleriDal OgrenciHareketleriDal)
        {
            _OgrenciHareketleriDal = OgrenciHareketleriDal;
        }
     

        public void Delete(OgrenciHareket entity)
        {
            _OgrenciHareketleriDal.Delete(entity);
        }

        public OgrenciHareket Get(int id)
        {
            return _OgrenciHareketleriDal.Get(p=>p.Id==id);
        }

        public List<OgrenciHareket> GetAll()
        {
            return _OgrenciHareketleriDal.GetAll();
        }

        public OgrenciHareket GetirOgrenciID(int ogrenciId)
        {
            return _OgrenciHareketleriDal.Get(p=>p.OgrenciId==ogrenciId);
        }

        OgrenciHareket IOgrenciHareketleriService.Add(OgrenciHareket entity)
        {
            return _OgrenciHareketleriDal.Add(entity);
        }

        OgrenciHareket IOgrenciHareketleriService.Update(OgrenciHareket entity)
        {
            return _OgrenciHareketleriDal.Update(entity);
        }
    }
}
