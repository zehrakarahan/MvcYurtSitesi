using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using YurtYesilKaya.WebKatmani.Models;

namespace YurtYesilKaya.WebKatmani.Helper
{
    public class odenecekborcmiktari
    {
        
        public static OgrenciHesap odenecektutar(Veritabanisiniflari model)
        {
            OgrenciHesap hesap = new OgrenciHesap();
            if (model.Ogrenci.pesinatmiktari == 0 && model.Ogrenci.depozitomiktari == 0 && model.Ogrenci.Ozeldurumindirimmiktari == 0)
            {
                hesap.odenenborc= 0.0;
                hesap.kalanborc = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar);
                hesap.PesinatMiktari = 0;
                hesap.DepozitoMiktari = 0;
                hesap.indirimmiktari = 0;
                hesap.yillikodenecektutar = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar);
                return hesap;
            }
            if (model.Ogrenci.pesinatmiktari != 0 && model.Ogrenci.depozitomiktari == 0 && model.Ogrenci.Ozeldurumindirimmiktari == 0)
            {

                hesap.odenenborc = Convert.ToDouble(model.Ogrenci.pesinatmiktari);
                hesap.kalanborc = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar) - Convert.ToDouble(model.Ogrenci.pesinatmiktari);
                hesap.DepozitoMiktari = 0;
                hesap.indirimmiktari = 0;
                hesap.PesinatMiktari = Convert.ToDouble(model.Ogrenci.pesinatmiktari);
                hesap.yillikodenecektutar = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar);
                return hesap;

            }
            if (model.Ogrenci.pesinatmiktari != 0 && model.Ogrenci.depozitomiktari != 0 && model.Ogrenci.Ozeldurumindirimmiktari == 0)
            {
                hesap.odenenborc = Convert.ToDouble(model.Ogrenci.pesinatmiktari) + Convert.ToDouble(model.Ogrenci.depozitomiktari);
                hesap.kalanborc = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar) - hesap.odenenborc;
                hesap.DepozitoMiktari = Convert.ToDouble(model.Ogrenci.depozitomiktari) ;
                hesap.indirimmiktari = 0;
                hesap.PesinatMiktari = Convert.ToDouble(model.Ogrenci.pesinatmiktari);
                hesap.yillikodenecektutar = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar);
                return hesap;
            }
            if (model.Ogrenci.pesinatmiktari != 0 && model.Ogrenci.depozitomiktari != 0 && model.Ogrenci.Ozeldurumindirimmiktari != 0)
            {
                hesap.odenenborc = Convert.ToDouble(model.Ogrenci.pesinatmiktari) + Convert.ToDouble(model.Ogrenci.depozitomiktari) + Convert.ToDouble(model.Ogrenci.Ozeldurumindirimmiktari);
                hesap.kalanborc = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar) - hesap.odenenborc;
                hesap.indirimmiktari = Convert.ToDouble(model.Ogrenci.Ozeldurumindirimmiktari);
                hesap.DepozitoMiktari =Convert.ToDouble(model.Ogrenci.depozitomiktari);
                hesap.PesinatMiktari = Convert.ToDouble(model.Ogrenci.pesinatmiktari);
                hesap.yillikodenecektutar = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar);
                return hesap;
            }
            if (model.Ogrenci.pesinatmiktari == 0 && model.Ogrenci.depozitomiktari != 0 && model.Ogrenci.Ozeldurumindirimmiktari == 0)
            {
                hesap.odenenborc = Convert.ToDouble(model.Ogrenci.pesinatmiktari) + Convert.ToDouble(model.Ogrenci.depozitomiktari) + Convert.ToDouble(model.Ogrenci.Ozeldurumindirimmiktari);
                hesap.kalanborc = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar) - hesap.odenenborc;
                hesap.indirimmiktari = 0;
                hesap.PesinatMiktari = 0;
                hesap.DepozitoMiktari= Convert.ToDouble(model.Ogrenci.depozitomiktari);
                hesap.yillikodenecektutar = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar);
                return hesap;
            }
            if (model.Ogrenci.pesinatmiktari == 0 && model.Ogrenci.depozitomiktari != 0 && model.Ogrenci.Ozeldurumindirimmiktari != 0)
            {
                hesap.odenenborc = Convert.ToDouble(model.Ogrenci.pesinatmiktari) + Convert.ToDouble(model.Ogrenci.depozitomiktari) + Convert.ToDouble(model.Ogrenci.Ozeldurumindirimmiktari);
                hesap.kalanborc = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar) - hesap.odenenborc;
                hesap.DepozitoMiktari = Convert.ToDouble(model.Ogrenci.depozitomiktari);
                hesap.indirimmiktari = Convert.ToDouble(model.Ogrenci.Ozeldurumindirimmiktari);
                hesap.yillikodenecektutar = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar);
                hesap.PesinatMiktari = 0;
                return hesap;
            }
            if (model.Ogrenci.pesinatmiktari == 0 && model.Ogrenci.depozitomiktari == 0 && model.Ogrenci.Ozeldurumindirimmiktari != 0)
            {
                hesap.odenenborc = Convert.ToDouble(model.Ogrenci.pesinatmiktari) + Convert.ToDouble(model.Ogrenci.depozitomiktari) + Convert.ToDouble(model.Ogrenci.Ozeldurumindirimmiktari);
                hesap.kalanborc = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar) - hesap.odenenborc;
                hesap.PesinatMiktari = 0;
                hesap.DepozitoMiktari = 0;
                hesap.indirimmiktari = Convert.ToDouble(model.Ogrenci.Ozeldurumindirimmiktari);
                hesap.yillikodenecektutar = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar);
                return hesap;
            }
            if (model.Ogrenci.pesinatmiktari != 0 && model.Ogrenci.depozitomiktari == 0 && model.Ogrenci.Ozeldurumindirimmiktari != 0)
            {
                hesap.odenenborc = Convert.ToDouble(model.Ogrenci.pesinatmiktari) + Convert.ToDouble(model.Ogrenci.depozitomiktari) + Convert.ToDouble(model.Ogrenci.Ozeldurumindirimmiktari);
                hesap.kalanborc = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar) - hesap.odenenborc;
                hesap.indirimmiktari = Convert.ToDouble(model.Ogrenci.Ozeldurumindirimmiktari);
                hesap.PesinatMiktari = Convert.ToDouble(model.Ogrenci.pesinatmiktari);
                hesap.DepozitoMiktari = Convert.ToDouble(model.Ogrenci.depozitomiktari);
                hesap.yillikodenecektutar = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar);
                return hesap;
            }
            return hesap;
        }
    }
}