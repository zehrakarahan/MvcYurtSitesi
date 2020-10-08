using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Core.DatabaseAccess.EntityFramework;
using YurtYesilKaya.Dal.Abstract;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Dal.Concrete.EntityFramework.Repository
{
    
    public class ArsivDal:EfEntityRepositoryBase<Arsiv, YesilKayaContext>,IArsivDal
    {
    }
}
