using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Bll.Abstract;
using YurtYesilKaya.Dal.Abstract;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Concrete
{
    public class FaturaManager : IFaturaService
    {
        private IFaturaDal _FaturaDal;
        public FaturaManager(IFaturaDal FaturaDal)
        {
            _FaturaDal = FaturaDal;
        }
      
        public void Delete(Fatura entity)
        {
            _FaturaDal.Delete(entity);
        }

        public List<Fatura> GetAll()
        {
            return _FaturaDal.GetAll();
        }
        Fatura IFaturaService.Add(Fatura entity)
        {
            return _FaturaDal.Add(entity);
        }

        Fatura IFaturaService.Update(Fatura entity)
        {
            return _FaturaDal.Update(entity);
        }
    }
}
