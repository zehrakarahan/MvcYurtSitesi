using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Abstract
{
    public interface IDevamsizlikService
    {
        List<DevamsizlikSayisi> GetAll();
        DevamsizlikSayisi Get(int devamid);
        DevamsizlikSayisi Update(DevamsizlikSayisi entity);
        void Delete(DevamsizlikSayisi entity);
        DevamsizlikSayisi Add(DevamsizlikSayisi entity);
    }
}
