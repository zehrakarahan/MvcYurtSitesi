using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Abstract
{
    public interface IYemeklerService
    {
        List<Yemekler> GetAll();
        Yemekler Update(Yemekler entity);
        void Delete(Yemekler entity);
        Yemekler Add(Yemekler entity);
        Yemekler Get(int yemekid);
    }
}
