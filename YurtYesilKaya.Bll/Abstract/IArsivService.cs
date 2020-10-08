using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Abstract
{
    public interface IArsivService
    {

        List<Arsiv> GetAll();
        Arsiv Update(Arsiv entity);
        void Delete(Arsiv entity);
        Arsiv Add(Arsiv entity);
       
    }
}
