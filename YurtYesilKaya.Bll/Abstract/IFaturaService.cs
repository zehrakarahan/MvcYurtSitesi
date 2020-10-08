using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Abstract
{
    public interface IFaturaService
    {
        List<Fatura> GetAll();

        Fatura Update(Fatura entity);
        void Delete(Fatura entity);
        Fatura Add(Fatura entity);
    }
}
