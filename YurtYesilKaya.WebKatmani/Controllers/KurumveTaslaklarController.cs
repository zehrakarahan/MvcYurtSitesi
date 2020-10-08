using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurtYesilKaya.Bll.Abstract;
using YurtYesilKaya.Entity.Entity;
using YurtYesilKaya.WebKatmani.Helper;
using YurtYesilKaya.WebKatmani.Models;

namespace YurtYesilKaya.WebKatmani.Controllers
{
    public class KurumveTaslaklarController : Controller
    {
        // GET: KurumveTaslaklar
        IKullanicilarService _kullanicilarService;
        IillerService _illerService;
        IilcelerService _ilcelerService;
        IKurumBilgileriService _kurumbilgileriservice;
        IOgrenciService _ogrenciservice;
        IOdaBilgileriService _odabilgileriservice;
        ITaksitOdemeTuruService _taksitodemeturuservice;
        IVeliBilgilerService _velibilgileriservice;
        IOgrenciHareketleriService _ogrencihareketservice;
        public KurumveTaslaklarController(IKullanicilarService kullanicilarService, IillerService illerService, IilcelerService ilcelerService, IKurumBilgileriService kurumbilgileriservice,IOgrenciService ogrenciservice,IOdaBilgileriService odabilgileriservice,ITaksitOdemeTuruService taksitodemeturuservice,IVeliBilgilerService velibilgileriservice,IOgrenciHareketleriService ogrencihareketservice)
        {
            this._kullanicilarService = kullanicilarService;
            this._illerService = illerService;
            this._ilcelerService = ilcelerService;
            this._kurumbilgileriservice = kurumbilgileriservice;
            this._ogrenciservice = ogrenciservice;
            this._odabilgileriservice = odabilgileriservice;
            this._taksitodemeturuservice = taksitodemeturuservice;
            this._velibilgileriservice = velibilgileriservice;
            this._ogrencihareketservice = ogrencihareketservice;
        }
        // GET: KurumveTaslaklar
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult KurumBilgisiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KurumBilgisiEkle(KurumBilgileri KurumBilgileri)
        {
            KurumBilgileri model = new KurumBilgileri();
            model.kurucuadi = KurumBilgileri.kurucuadi;
            model.kayittarihi = DateTime.Now;
            model.KurucuTemsilciAdi = KurumBilgileri.KurucuTemsilciAdi;
            model.KurumAdi = KurumBilgileri.KurumAdi;
            model.KurumAdresi = KurumBilgileri.KurumAdresi;
            model.KurumCode = KurumBilgileri.KurumCode;
            model.KurumTelefon = KurumBilgileri.KurumTelefon;
            model.MudurAdi = KurumBilgileri.MudurAdi;
            _kurumbilgileriservice.Add(model);

            return RedirectToAction("KurumListele", "KurumveTaslaklar");
        }
        public ActionResult KurumListele()
        {
            ViewBag.kurumlistesi = _kurumbilgileriservice.GetAll();
            return View();
        }


        public ActionResult Guncelle(int id)
        {
            var urun = _kurumbilgileriservice.Get(id);



            return View(urun);
        }
        [HttpPost]
        public ActionResult Guncelle(KurumBilgileri u)
        {

            var urun = _kurumbilgileriservice.Get(u.Id);

            urun.KurumCode = u.KurumCode;
            urun.kurucuadi = u.KurumAdi;
            urun.KurucuTemsilciAdi = u.KurucuTemsilciAdi;
            urun.KurumAdresi = u.KurumAdresi;
            urun.KurumTelefon = u.KurumTelefon;
            urun.MudurAdi = u.MudurAdi;
            urun.KurumAdi = u.KurumAdi;
            _kurumbilgileriservice.Update(urun);
            return RedirectToAction("KurumListele");
        }
        [HttpPost]
        public ActionResult Sil(int sayi)
        {
            /*KurumBilgileri k = db.Kategoriler.Where(x => x.KategoriID == id).FirstOrDefault();
            db.Kategoriler.Remove(k);
            db.SaveChanges();*/
            var d = _kurumbilgileriservice.Get(sayi);
            _kurumbilgileriservice.Delete(d);
            return RedirectToAction("KurumListele");

        }
     
        public ActionResult besbanyolu()
        {
            return View();
        }
        public ActionResult Taslaklar()
        {
            OgrenciViewModel modelbilgi = new OgrenciViewModel();
            var ogrencibilgi = _ogrenciservice.GetAll();
            List<OdaBilgileri> odalar = _odabilgileriservice.GetAll();
            
            List<Ogrenci> veri = new List<Ogrenci>();
            modelbilgi.OgrenciListesi = new List<OgrenciModel>();
            foreach (var deger in ogrencibilgi)
            {
                
                foreach (var deg in odalar)
                {
                    if (deg.Id == deger.OdaBilgileriId)
                    {
                        OgrenciModel oo = new OgrenciModel();
                        oo.Ogrenci = deger;
                        oo.IsChecked = false;//burda bak hepsı baslangıcta false olarak ısaretlı ıse true olacak 
                        OdaBilgileri odabilgil = new OdaBilgileri();
                        odabilgil = _odabilgileriservice.Get((int)deger.OdaBilgileriId);
                      
                        oo.OdaBilgisi = odabilgil;
                        modelbilgi.OgrenciListesi.Add(oo);
                    }
                }
            }
            ViewBag.modeldekiler2 = modelbilgi;

            return View();
        }
        public ActionResult birinci(int ogrenciid)
        {
            TempData["veriler"] = ogrenciid;
            return RedirectToAction("ikikisi");
        }
        public int sayac = 0;
        public ActionResult ikikisi()
        {

            OgrenciViewModel modelbilgi = new OgrenciViewModel();
            var ogrencibilgi = _ogrenciservice.GetAll();
            List<OdaBilgileri> oda = _odabilgileriservice.GetKisisayisi("2 Kişilik yatakhane");
            List<Ogrenci> veri = new List<Ogrenci>();
            modelbilgi.OgrenciListesi = new List<OgrenciModel>();
            foreach (var deger in ogrencibilgi)
            {
                foreach (var deg in oda)
                {
                    if (deg.Id == deger.OdaBilgileriId)
                    {
                        OgrenciModel oo = new OgrenciModel();
                        oo.Ogrenci = deger;
                        OdaBilgileri odabilgil = new OdaBilgileri();
                        OgrenciHareket ogrhareket = new OgrenciHareket();
                        TaksitOdeme takodeme = new TaksitOdeme();
                        odabilgil = _odabilgileriservice.Get((int)deger.OdaBilgileriId);
                        ogrhareket = _ogrencihareketservice.GetirOgrenciID(deger.Id);
                        takodeme = _taksitodemeturuservice.Get((int)deger.TaksitOdemeId);
                        oo.OdaBilgisi = odabilgil;
                        oo.OgrenciHareket = ogrhareket;
                        oo.TaksitOdeme = takodeme;
                        modelbilgi.OgrenciListesi.Add(oo);
                    }
                }
            }
            ViewBag.modeldekiler2 = modelbilgi;
            return View();
        }
        public ActionResult beskisibanyolu(int[] veril)
        {
           
            OgrenciViewModel modelbilgi = new OgrenciViewModel();
            var ogrencibilgi = _ogrenciservice.GetAll();
            List<OdaBilgileri> oda = _odabilgileriservice.GetKisisayisi("5 Kişilik yatakhane");
            List<Ogrenci> veri = new List<Ogrenci>();
            modelbilgi.OgrenciListesi = new List<OgrenciModel>();
            foreach (var deger in ogrencibilgi)
            {
                foreach (var deg in oda)
                {
                    if (deg.Id == deger.OdaBilgileriId)
                    {
                        OgrenciModel oo = new OgrenciModel();
                        oo.Ogrenci = deger;
                        oo.IsChecked = false;//burda bak hepsı baslangıcta false olarak ısaretlı ıse true olacak 
                        OdaBilgileri odabilgil = new OdaBilgileri();
                        OgrenciHareket ogrhareket = new OgrenciHareket();
                        TaksitOdeme takodeme = new TaksitOdeme();
                        odabilgil = _odabilgileriservice.Get((int)deger.OdaBilgileriId);
                        ogrhareket = _ogrencihareketservice.GetirOgrenciID(deger.Id);
                        takodeme = _taksitodemeturuservice.Get((int)deger.TaksitOdemeId);
                        oo.OdaBilgisi = odabilgil;
                        oo.OgrenciHareket = ogrhareket;
                        oo.TaksitOdeme = takodeme;
                        modelbilgi.OgrenciListesi.Add(oo);
                    }
                }
            }
            ViewBag.modeldekiler2 = modelbilgi;
           List<Ogrenci> oglistesi = new List<Ogrenci>();
            if (veril == null)
            {
                ViewBag.ogrencilistesi = null;
                oglistesi = null;
                ViewBag.ogrencilistesi = oglistesi;
            }

            else
            {
                for (int i = 0; i < veril.Length; i++)
                {
                    var deger = veril[i];
                    var ogrencil = _ogrenciservice.Get(deger);
                    oglistesi.Add(ogrencil);
                }
                ViewBag.ogrencilistesi = oglistesi;

            }
            return View(modelbilgi);
        }
        public ActionResult dortkisibanyosuz()
        {
            OgrenciViewModel modelbilgi = new OgrenciViewModel();
            var ogrencibilgi = _ogrenciservice.GetAll();
            List<OdaBilgileri> oda = _odabilgileriservice.GetKisisayisi("4 Kişilik yatakhane");
            List<Ogrenci> veri = new List<Ogrenci>();
            modelbilgi.OgrenciListesi = new List<OgrenciModel>();
            foreach (var deger in ogrencibilgi)
            {
                foreach (var deg in oda)
                {
                    if (deg.Id == deger.OdaBilgileriId)
                    {
                        OgrenciModel oo = new OgrenciModel();
                        oo.Ogrenci = deger;
                        OdaBilgileri odabilgil = new OdaBilgileri();
                        OgrenciHareket ogrhareket = new OgrenciHareket();
                        TaksitOdeme takodeme = new TaksitOdeme();
                        odabilgil = _odabilgileriservice.Get((int)deger.OdaBilgileriId);
                        ogrhareket = _ogrencihareketservice.GetirOgrenciID(deger.Id);
                        takodeme = _taksitodemeturuservice.Get((int)deger.TaksitOdemeId);
                        oo.OdaBilgisi = odabilgil;
                        oo.OgrenciHareket = ogrhareket;
                        oo.TaksitOdeme = takodeme;
                        modelbilgi.OgrenciListesi.Add(oo);
                    }
                }
            }
            ViewBag.modeldekiler2 = modelbilgi;
            return View();
        }
        public ActionResult dortkisibanyolu()
        {
            OgrenciViewModel modelbilgi = new OgrenciViewModel();
            var ogrencibilgi = _ogrenciservice.GetAll();
            List<OdaBilgileri> oda = _odabilgileriservice.GetKisisayisi("4 Kişilik yatakhane");
            List<Ogrenci> veri = new List<Ogrenci>();
            modelbilgi.OgrenciListesi = new List<OgrenciModel>();
            foreach (var deger in ogrencibilgi)
            {
                foreach (var deg in oda)
                {
                    if (deg.Id == deger.OdaBilgileriId)
                    {
                        OgrenciModel oo = new OgrenciModel();
                        oo.Ogrenci = deger;
                        OdaBilgileri odabilgil = new OdaBilgileri();
                        OgrenciHareket ogrhareket = new OgrenciHareket();
                        TaksitOdeme takodeme = new TaksitOdeme();
                        odabilgil = _odabilgileriservice.Get((int)deger.OdaBilgileriId);
                        ogrhareket = _ogrencihareketservice.GetirOgrenciID(deger.Id);
                        takodeme = _taksitodemeturuservice.Get((int)deger.TaksitOdemeId);
                        oo.OdaBilgisi = odabilgil;
                        oo.OgrenciHareket = ogrhareket;
                        oo.TaksitOdeme = takodeme;
                        modelbilgi.OgrenciListesi.Add(oo);
                    }
                }
            }
            ViewBag.modeldekiler2 = modelbilgi;
          
            return View(modelbilgi);
        }

  
      
        [HttpPost]
        public ActionResult OgrenciBul()
        {
            return View();
        
        }


    }
}