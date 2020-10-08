using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using YurtYesilKaya.Bll.Abstract;
using YurtYesilKaya.Entity.Entity;
using YurtYesilKaya.WebUI.Helper;
using YurtYesilKaya.WebUI.Models;
using PagedList.Mvc;
using System.Web.Helpers;
using System.IO;

namespace YurtYesilKaya.WebUI.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        IKurumBilgileriService _kurumservice;
        IOzelDurumIndirimService _ozeldurumservice;
     
        IOgrenciService _ogrenciservice;
        IOgrenciHareketleriService _ogrencihareketservice;
        IOdaBilgileriService _odabilgileriservice;
        IVeliBilgilerService _velibilgileriservice;
        ITaksitOdemeTuruService _taksitodemeturuservice;
        public OgrenciController(IKurumBilgileriService kurumservice, IOzelDurumIndirimService ozeldurumservice,IOgrenciService ogrenciservice, IOgrenciHareketleriService ogrencihareketservice, IVeliBilgilerService velibilgileriservice, IOdaBilgileriService odabilgileriservice, ITaksitOdemeTuruService taksitodemeturuservice)
        {
            this._kurumservice = kurumservice;
            this._ozeldurumservice = ozeldurumservice;
           
            this._ogrenciservice = ogrenciservice;
            this._ogrencihareketservice = ogrencihareketservice;
            this._odabilgileriservice = odabilgileriservice;
            this._velibilgileriservice = velibilgileriservice;
            this._taksitodemeturuservice = taksitodemeturuservice;
        }

        // GET: Ogrenci
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult OgrenciListele(int sayfa=1)
        {
            Ogrenci dene = new Ogrenci();
            OgrenciViewModel model = new OgrenciViewModel();
            var ogrenci = _ogrenciservice.GetAll();
            var oda = _odabilgileriservice.GetAll();
            var taksit = _taksitodemeturuservice.GetAll();
            var veli = _velibilgileriservice.GetAll();
            model.OgrenciListesi = new List<OgrenciModel>();
            //controllerdan dolayı bilgin olsun cunku dıger sayfada ogrencıvıew model var burda ogrencı gıdıyor vıewe dün kodla mvc install ettin ya onu silebilir misin grid icin miydi
            //hatirlamıyrum tam core grid miydi yoksa gridmvc mi 

            foreach (var item in ogrenci)
            {
        

                for (int i = 0; i < 5; i++)
                {
                    OgrenciModel o = new OgrenciModel();
                    o.Ogrenci = item;

                    OdaBilgileri odabil = new OdaBilgileri();
                    odabil = _odabilgileriservice.Get((int)item.OdaBilgileriId);
                    o.OdaBilgisi = odabil;
                    model.OgrenciListesi.Add(o);
                }
                



            }


            var liste = _ogrenciservice.GetAll().ToPagedList(sayfa, 5);
            
            return View(model);
        }
      
     
        public IEnumerable<SelectListItem> ozeldurumlistesi()
        {
            List<OzelDurum> liste = _ozeldurumservice.GetAll();
            IEnumerable<SelectListItem> items = liste.Select(i => new SelectListItem { Text = i.OzelDurumadi, Value = i.OzelDurumadi });
            return items;
        }
        public ActionResult OgrenciTanimlama()

        {

          
            ViewBag.oliste = ozeldurumlistesi();
            List<KurumBilgileri> i = _kurumservice.GetAll();
            int count = i.Count;

            if (i.Count == 1)
            {
                var degerler = _kurumservice.Getir("99966031");

                var kullanicilar = new KurumBilgileri()
                {
                    KurumCode = degerler.KurumCode,
                    KurumAdi = degerler.KurumAdi,
                    KurucuTemsilciAdi = degerler.KurucuTemsilciAdi,
                    kurucuadi = degerler.kurucuadi,
                    KurumAdresi = degerler.KurumAdresi,
                    KurumTelefon = degerler.KurumTelefon,
                    MudurAdi = degerler.MudurAdi,
                    kayittarihi=degerler.kayittarihi,
                    Id = degerler.Id
                };
                ViewData["vieweGonderilenVeri"] = kullanicilar;
                return View();
            }
            else
            {
                if (i.Count <= 0)
                {
                    return RedirectToAction("KurumBilgisiEkle", "KurumveTaslaklar");
                }
                else
                {
                    var degerler = _kurumservice.Getir("99966031");

                    return View();
                }
            }



            return View();
        }
        [HttpPost]
        public ActionResult OgrenciKaydet(Veritabanisiniflari model)
        {
            OgrenciHesap hesap = new OgrenciHesap();
            //Mailgonderecek(model);


            if (model.Ogrenci.OdemeSekli == "Pesin")
            {
                hesap.kalanborc = 0.0;
                hesap.odenenborc = Convert.ToDouble(model.Ogrenci.Ogrencininkayitedildigimiktar);

            }
            if (model.Ogrenci.OdemeSekli == "Taksit")
            {
                hesap.odenenborc = odenecekborcmiktari.odenecektutar(model).odenenborc;
                hesap.kalanborc = odenecekborcmiktari.odenecektutar(model).kalanborc;
                hesap.indirimmiktari = odenecekborcmiktari.odenecektutar(model).indirimmiktari;
                hesap.PesinatMiktari = odenecekborcmiktari.odenecektutar(model).PesinatMiktari;
                hesap.DepozitoMiktari = odenecekborcmiktari.odenecektutar(model).DepozitoMiktari;
                hesap.yillikodenecektutar = odenecekborcmiktari.odenecektutar(model).yillikodenecektutar;
            }
             if (model.Foto != null)
             {
                 WebImage img = new WebImage(model.Foto.InputStream);
                 FileInfo fotoinfo = new FileInfo(model.Foto.FileName);

                 string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                 img.Resize(150, 120);
                 img.Save("~/Uploads/OgrenciFoto/" + newfoto);
                 model.Ogrenci.OgrenciResmi = "/Uploads/OgrenciFoto/" + newfoto;
                 model.Ogrenci.kayittarihi = DateTime.Now;
               
             }
            // 
            _odabilgileriservice.Add(model.OdaBilgileri);
            _taksitodemeturuservice.Add(model.TaksitOdeme);
            _velibilgileriservice.Add(model.VeliBilgileri);
            var ogrencibig = model.Ogrenci;
            _ogrenciservice.Add(ogrencibig);

            var oda = _odabilgileriservice.GetAll().Last();
            var veli = _velibilgileriservice.GetAll().Last();
            var taksit = _taksitodemeturuservice.GetAll().Last();
            var ogrencibilgisi = _ogrenciservice.GetAll().Last();
             model.Ogrenci.OdaBilgileriId = oda.Id;
             model.Ogrenci.VeliId = veli.Id;
            model.Ogrenci.TaksitOdemeId = taksit.Id;
            ViewBag.odabilgileri = _odabilgileriservice.GetAll();
            ViewBag.VeliBilgi = _velibilgileriservice.GetAll();
            ViewBag.TaksitBilgi = _taksitodemeturuservice.GetAll();
            OgrenciHareket modeli = new OgrenciHareket();
            modeli.islemtarihi = DateTime.Now;
            modeli.kalanborc = Convert.ToDecimal(hesap.kalanborc);
            modeli.odenenborc = Convert.ToDecimal(hesap.odenenborc);
            modeli.OgrenciId = ogrencibilgisi.Id;
            modeli.TaksitOdemeId = taksit.Id;
           
            
            _ogrencihareketservice.Add(modeli);
            return RedirectToAction("OgrenciListele");


        }
        [HttpPost]
        public ActionResult OgrenciEkle(Veritabanisiniflari model)
        {
            return View();
        }
        public ActionResult OgrenciListesi()
        {
            return View();
        }
        public ActionResult BakiyeTanimlama(veriler ogrenciadsoyadi)
        {
          
           var bilgiler=_ogrenciservice.Getadsoyad(ogrenciadsoyadi.OgrenciAdiSoyadi);
            ViewData["OgrenciBilgileri"] = bilgiler;
      
            OgrenciModelVerileri model=new OgrenciModelVerileri();
            var ogrenci = _ogrenciservice.GetAll();
            model.Ogrenciliste =new OgrenciModel();
            OgrenciModel o = new OgrenciModel();
            o.Ogrenci = bilgiler;
            
            foreach (var item in ogrenci)
            {

                    OdaBilgileri odabil = new OdaBilgileri();
                    TaksitOdeme taksitbil = new TaksitOdeme();
                    OgrenciHareket ogrencihareketbil=new OgrenciHareket();
                    odabil = _odabilgileriservice.Get((int)bilgiler.OdaBilgileriId);
                    o.OdaBilgisi = odabil;
                    taksitbil = _taksitodemeturuservice.Get((int)bilgiler.TaksitOdemeId);
                    o.TaksitOdeme = taksitbil;
                    ogrencihareketbil = _ogrencihareketservice.GetirOgrenciID(bilgiler.Id);
                    o.OgrenciHareket = ogrencihareketbil;
                   
               




            }

            return View();
        }
        [HttpPost]
        public ActionResult BakiyeKaydet(OgrenciHareket bakiye)
        {
            return View();
        }
        public ActionResult BakiyeListesi()
        {
            return View();
        }
        public ActionResult Mailgonder()
        {
            return View();
        }


        public void Mailgonderecek(Veritabanisiniflari model)
        {

            string isim = model.Ogrenci.ogrenciadisoyadi.ToUpper();

            MailMessage mailim = new MailMessage();
            mailim.To.Add(model.VeliBilgileri.mailadresi);
            mailim.To.Add("zehrakarahan1995@hotmail.com");
            mailim.From = new MailAddress("zehrakarahan95@gmail.com");
            mailim.Subject = "YEŞİLKAYA ERKEK ÖĞRENCİ YURDU";
            mailim.Body = "SAYIN VELİ ÖNCELİKLE MERHABA " + "  " + isim + "  " + "ADLI ÇOCUĞUNUZ YURDUMUZA KAYIT İŞLEMİ YAPILMIŞTIR.";
            mailim.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("zehrakarahan95@gmail.com", "05366932521.");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mailim);
                //TempData["Message"] = "Mail basarili gonderildi";
            }
            catch (Exception ex)
            {
                // TempData["Message"] = "Mesaj gonderilemedi" + ex.Message;

            }



        }
    }
}