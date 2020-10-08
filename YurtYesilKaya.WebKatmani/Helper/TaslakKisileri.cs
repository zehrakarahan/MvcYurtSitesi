using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YurtYesilKaya.Entity.Entity;
using YurtYesilKaya.WebKatmani.Models;

namespace YurtYesilKaya.WebKatmani.Helper
{
    public class TaslakKisileri
    {
        public static OgrenciViewModel OgrenciListesi(List<Ogrenci> model, List<OdaBilgileri> odabilgi)
        {
            OgrenciViewModel modelbilgi = new OgrenciViewModel();
            List<OdaBilgileri> oda = new List<OdaBilgileri>();
            oda = odabilgi.Where(x => x.odakisisayisi == "2 Kişilik yatakhane").ToList();
            List<Ogrenci> veri = new List<Ogrenci>();
            modelbilgi.OgrenciListesi = new List<OgrenciModel>();
            foreach (var deger in model)
            {
                foreach (var deg in oda)
                {
                    if (deg.Id == deger.OdaBilgileriId)
                    {
                        OgrenciModel oo = new OgrenciModel();
                        oo.Ogrenci = deger;
                        OdaBilgileri odabilgil = new OdaBilgileri();
                        odabilgil = odabilgi.Where(x => x.Id == (int)deger.OdaBilgileriId).FirstOrDefault();
                        oo.OdaBilgisi = odabilgil;
                        modelbilgi.OgrenciListesi.Add(oo);
                    }
                }
            }
            return modelbilgi;
        }
    }
}