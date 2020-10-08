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
    public class TaksitOdemeTuruManager : ITaksitOdemeTuruService
    {
        private ITaksitOdemeTuruDal _taksitodemeturuDal;
        public TaksitOdemeTuruManager(ITaksitOdemeTuruDal taksitodemeturuDal)
        {
            _taksitodemeturuDal = taksitodemeturuDal;
        }
        public TaksitOdeme Add(TaksitOdeme entity)
        {
            return _taksitodemeturuDal.Add(entity);
        }

        public void Delete(TaksitOdeme entity)
        {
            _taksitodemeturuDal.Delete(entity);
        }

        public TaksitOdeme Get(int id)
        {
            return _taksitodemeturuDal.Get(p=>p.Id==id);
        }

        public List<TaksitOdeme> GetAll()
        {
            return _taksitodemeturuDal.GetAll();
        }

        public TaksitOdeme Update(TaksitOdeme entity)
        {
            return _taksitodemeturuDal.Update(entity);
        }
    }
}
