using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YurtYesilKaya.Entity.Entity;
namespace YurtYesilKaya.WebUI.Models
{
    public  class Yemektarihleri
    {
        public static YemekModelBilgileri tarihbilgileri(List<Yemekler> yemekbilgisi,YemekModel yemekmodel)
        {

            YemekModelBilgileri bilgiler = new YemekModelBilgileri();
            if (yemekbilgisi.Count != 0 )
            {
                if (yemekmodel.YemekTuru.yemekturu == "Sabah Kahvaltisi")
                {
                    bilgiler.Yemeklersonveyailkintumbilgisi = yemekbilgisi.Last();
                    bilgiler.ilkmisonmutarih = bilgiler.Yemeklersonveyailkintumbilgisi.bugununtarihi.Value;
                    bilgiler.kisatarih = bilgiler.ilkmisonmutarih.ToShortDateString();
                    bilgiler.gunbilgisi = bilgiler.ilkmisonmutarih.Day;
                    bilgiler.aybilgisi = bilgiler.ilkmisonmutarih.Month;
                    bilgiler.yilbilgisi = bilgiler.ilkmisonmutarih.Year;
                    bilgiler.yemekogunu = yemekmodel.YemekTuru.yemekturu;
                    bilgiler.baslangictarihi = bilgiler.ilkmisonmutarih.AddDays(1);
                    return bilgiler;
                }
                if (yemekmodel.YemekTuru.yemekturu == "Aksam Yemegi")
                {
                    bilgiler.Yemeklersonveyailkintumbilgisi = yemekbilgisi.FirstOrDefault();
                    bilgiler.ilkmisonmutarih = bilgiler.Yemeklersonveyailkintumbilgisi.bugununtarihi.Value;
                    bilgiler.kisatarih = bilgiler.ilkmisonmutarih.ToShortDateString();
                    bilgiler.gunbilgisi = bilgiler.ilkmisonmutarih.Day;
                    bilgiler.aybilgisi = bilgiler.ilkmisonmutarih.Month;
                    bilgiler.yilbilgisi = bilgiler.ilkmisonmutarih.Year;
                    bilgiler.yemekogunu = yemekmodel.YemekTuru.yemekturu;
                    bilgiler.baslangictarihi = bilgiler.ilkmisonmutarih;
                    return bilgiler;
                }
                
            }
            if(yemekbilgisi.Count==0 && yemekmodel.YemekTuru.yemekturu== "Sabah Kahvaltisi")
            {
                
                bilgiler.Yemeklersonveyailkintumbilgisi = null;
                bilgiler.ilkmisonmutarih = yemekmodel.Tarih;
                bilgiler.kisatarih = bilgiler.ilkmisonmutarih.ToShortDateString();
                bilgiler.gunbilgisi = bilgiler.ilkmisonmutarih.Day;
                bilgiler.yilbilgisi = bilgiler.ilkmisonmutarih.Year;
                bilgiler.aybilgisi = bilgiler.ilkmisonmutarih.Month;
                bilgiler.yemekogunu = yemekmodel.YemekTuru.yemekturu;
                bilgiler.baslangictarihi = new DateTime(yemekmodel.Tarih.Year,yemekmodel.Tarih.Month,1);
                return bilgiler;
            }
            if (yemekbilgisi.Count == 0 && yemekmodel.YemekTuru.yemekturu == "Aksam Yemegi")
            {

                bilgiler.Yemeklersonveyailkintumbilgisi = null;
                bilgiler.ilkmisonmutarih = yemekmodel.Tarih;
                bilgiler.kisatarih = bilgiler.ilkmisonmutarih.ToShortDateString();
                bilgiler.gunbilgisi = bilgiler.ilkmisonmutarih.Day;
                bilgiler.yilbilgisi = bilgiler.ilkmisonmutarih.Year;
                bilgiler.aybilgisi = bilgiler.ilkmisonmutarih.Month;
                bilgiler.yemekogunu = yemekmodel.YemekTuru.yemekturu;
                bilgiler.baslangictarihi = new DateTime(yemekmodel.Tarih.Year, yemekmodel.Tarih.Month, 1);
                return bilgiler;
            }
            return bilgiler;
        }
    }

}