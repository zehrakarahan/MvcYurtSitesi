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
    public class VeliBilgilerManager : IVeliBilgilerService
    {
        private IVeliBilgilerDal _VeliBilgilerDal;
        public VeliBilgilerManager(IVeliBilgilerDal VeliBilgilerTablosuDal)
        {
            _VeliBilgilerDal = VeliBilgilerTablosuDal;
        }
       

        public void Delete(VeliBilgileri entity)
        {
            _VeliBilgilerDal.Delete(entity);
        }

        public VeliBilgileri Get(int id)
        {
            return _VeliBilgilerDal.Get(p=>p.Id==id);
        }

        public List<VeliBilgileri> GetAll()
        {
            return _VeliBilgilerDal.GetAll();
        }

      

        public List<VeliBilgileri> GetVeliBilgilerTablosuByVeliName(string VeliName)
        {
            return _VeliBilgilerDal.GetAll(p=>p.VeliAdiSoyadi==VeliName);
        }

     

        VeliBilgileri IVeliBilgilerService.Add(VeliBilgileri entity)
        {
            return _VeliBilgilerDal.Add(entity);
        }

        VeliBilgileri IVeliBilgilerService.Update(VeliBilgileri entity)
        {
            return _VeliBilgilerDal.Update(entity);
        }
    }
}
