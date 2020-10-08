using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Abstract
{
    public interface IVeliBilgilerService
    {
        List<VeliBilgileri> GetAll();
        VeliBilgileri Get(int id);
        List<VeliBilgileri> GetVeliBilgilerTablosuByVeliName(string VeliName);
        VeliBilgileri Update(VeliBilgileri entity);
        void Delete(VeliBilgileri entity);
        VeliBilgileri Add(VeliBilgileri entity);
    }
}
