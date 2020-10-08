using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Abstract
{
    public interface ISenetService
    {
        List<Senet> GetAll();

        Senet Update(Senet entity);
        void Delete(Senet entity);
        Senet Add(Senet entity);
    }
}
