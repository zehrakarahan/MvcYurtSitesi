using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Abstract
{
    public interface ISifreDegisiklikService
    {
        List<SifreDegisiklik> GetAll();
        SifreDegisiklik Get(string guid);
        SifreDegisiklik Update(SifreDegisiklik entity);
       
        void Delete(SifreDegisiklik entity);
        SifreDegisiklik Add(SifreDegisiklik entity);
    }
}
