using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Abstract
{
    public interface IOdaBilgileriService
    {
        List<OdaBilgileri> GetAll();
        OdaBilgileri Get(int OdaNo);
        List<OdaBilgileri> GetKisisayisi(string odakisisayisi);
        List<OdaBilgileri> GetOdaNo();
        OdaBilgileri Update(OdaBilgileri entity);
        void Delete(OdaBilgileri entity);
        OdaBilgileri Add(OdaBilgileri entity);
    }
}
