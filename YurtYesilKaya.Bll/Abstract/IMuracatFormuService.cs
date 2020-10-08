using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Abstract
{
    public interface IMuracatFormuService
    {
        List<MuracatFormu> GetAll();
        MuracatFormu Update(MuracatFormu entity);
        void Delete(MuracatFormu entity);
        MuracatFormu Add(MuracatFormu entity);
    }
}
