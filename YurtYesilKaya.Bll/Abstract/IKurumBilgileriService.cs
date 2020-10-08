using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Abstract
{
    public interface IKurumBilgileriService
    {
        List<KurumBilgileri> GetAll();
        KurumBilgileri Get(int KurumId);
        KurumBilgileri Getir(string KurumKodu);
        KurumBilgileri KurumAdiGetir(string KurumAdi);
        KurumBilgileri Update(KurumBilgileri entity);
        void Delete(KurumBilgileri entity);
        KurumBilgileri Add(KurumBilgileri entity);
    }
}
