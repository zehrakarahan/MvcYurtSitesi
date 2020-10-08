using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurtYesilKaya.Bll.Abstract;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.WebUI.Controllers
{
    public class KurumveTaslaklarController : Controller
    {
        // GET: KurumveTaslaklar
        IKullanicilarService _kullanicilarService;
        IillerService _illerService;
        IilcelerService _ilcelerService;
        IKurumBilgileriService _kurumbilgileriservice;
        public KurumveTaslaklarController(IKullanicilarService kullanicilarService, IillerService illerService, IilcelerService ilcelerService, IKurumBilgileriService kurumbilgileriservice)
        {
            this._kullanicilarService = kullanicilarService;
            this._illerService = illerService;
            this._ilcelerService = ilcelerService;
            this._kurumbilgileriservice = kurumbilgileriservice;
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
    }
}