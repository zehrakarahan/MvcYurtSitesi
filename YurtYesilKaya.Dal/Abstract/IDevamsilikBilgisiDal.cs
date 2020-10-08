using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YurtYesilKaya.Entity.Entity;
using YurtYesilKaya.Core.DatabaseAccess;

namespace YurtYesilKaya.Dal.Abstract
{
    public interface IDevamsilikBilgisiDal: IEntityRepository<DevamsizlikSayisi>
    {
    }
}
