using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Abstract
{
    public interface ITaksitOdemeTuruService
    {
        List<TaksitOdeme> GetAll();
        TaksitOdeme Get(int id);
        TaksitOdeme Update(TaksitOdeme entity);
        void Delete(TaksitOdeme entity);
        TaksitOdeme Add(TaksitOdeme entity);
    }
}
