using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Core.DatabaseAccess;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Dal.Abstract
{
    public interface IYetkiDal: IEntityRepository<Yetki>
    {
    }
}
