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
using YurtYesilKaya.WebKatmani.Helper;
using YurtYesilKaya.WebKatmani.Models;
using PagedList.Mvc;
using System.Web.Helpers;
using System.IO;
using PagedList;
using excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Web.Routing;

namespace YurtYesilKaya.WebKatmani.Controllers
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
        IDevamsizlikService _devamsizliksayisi;
        IMuracatFormuService _MuracatFormuservice;
        public OgrenciController(IMuracatFormuService MuracatFormuservice, IKurumBilgileriService kurumservice, IOzelDurumIndirimService ozeldurumservice,IOgrenciService ogrenciservice, IOgrenciHareketleriService ogrencihareketservice, IVeliBilgilerService velibilgileriservice, IOdaBilgileriService odabilgileriservice, ITaksitOdemeTuruService taksitodemeturuservice,IDevamsizlikService devamsizliksayisi)
        {
            this._kurumservice = kurumservice;
            this._ozeldurumservice = ozeldurumservice;
           
            this._ogrenciservice = ogrenciservice;
            this._ogrencihareketservice = ogrencihareketservice;
            this._odabilgileriservice = odabilgileriservice;
            this._velibilgileriservice = velibilgileriservice;
            this._taksitodemeturuservice = taksitodemeturuservice;
            this._devamsizliksayisi = devamsizliksayisi;
            this._MuracatFormuservice = MuracatFormuservice;
        }
       
      
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Ogrencikametbelgesi()
        {
            return View();
        }
        public ActionResult MuracaatFormu()
        {
            var muracatlistesi=_MuracatFormuservice.GetAll().FirstOrDefault();
            return View(muracatlistesi);
        }
        public ActionResult Belgedegistir()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult BelgeKaydet(MuracatFormu muracatformu)
        {
            var muracatlistesi = _MuracatFormuservice.GetAll();
            foreach (var item in muracatlistesi)
            {
                _MuracatFormuservice.Delete(item);
            }
            _MuracatFormuservice.Add(muracatformu);
            return RedirectToAction("MuracaatFormu");
        }
        public ActionResult OgrenciListele()
       {  
           var ogrenci = _ogrenciservice.GetAll();
            OgrenciViewModel model = new OgrenciViewModel();

            var oda = _odabilgileriservice.GetAll();
            var taksit = _taksitodemeturuservice.GetAll();
            var veli = _velibilgileriservice.GetAll();
            model.OgrenciListesi = new List<OgrenciModel>();
          
            foreach (var item in ogrenci)
            {

                OgrenciModel o = new OgrenciModel();

                o.Ogrenci = item;


                OdaBilgileri odabil = new OdaBilgileri();
                odabil = _odabilgileriservice.Get((int)item.OdaBilgileriId);
                o.OdaBilgisi = odabil;
                model.OgrenciListesi.Add(o);
            }

            model.OgrenciListesi.ToList().ToPagedList(1,10);
            
           /* foreach (var item in ogrenci)
            {
        

                for (int i = 0; i < 50; i++)
                {
                    OgrenciModel o = new OgrenciModel();
                    o.Ogrenci = item;

                    OdaBilgileri odabil = new OdaBilgileri();
                    odabil = _odabilgileriservice.Get((int)item.OdaBilgileriId);
                    o.OdaBilgisi = odabil;
                    model.OgrenciListesi.Add(o);
                }
                



            }*/   
            return View(model);
        }
      
     
        public IEnumerable<SelectListItem> ozeldurumlistesi()
        {
            List<OzelDurum> liste = _ozeldurumservice.GetAll();
            IEnumerable<SelectListItem> 
                items = liste.Select(i => new SelectListItem { Text = i.OzelDurumadi, Value = i.OzelDurumadi });
            return items;
        }
        public ActionResult OgrenciTanimlama()

        {
            ViewBag.oliste = ozeldurumlistesi();
            List<KurumBilgileri> i = _kurumservice.GetAll();
            int count = i.Count;

            if (i.Count == 1)
            {
             
                 var degerler = _kurumservice.KurumAdiGetir("ÖZEL NİYAZİ VE MUHİBE YEŞİLKAYA YÜKSEKÖĞRENİM ERKEK ÖĞRENCİ YURDU");
                 
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
                    List<KurumBilgileri> veri = new List<KurumBilgileri>();
                    var kurumliste = _kurumservice.GetAll();
                    foreach (var item in kurumliste)
                    {
                        if(item.KurumCode== "ÖZEL NİYAZİ VE MUHİBE YEŞİLKAYA YÜKSEKÖĞRENİM ERKEK ÖĞRENCİ YURDU")
                        {
                            veri.Add(item);
                        }
                    }
                    for (int j = 0; j <veri.Count(); j++)
                    {
                        if (veri.Count() == 1)
                        {
                            var deger = veri[j];
                            ViewData["vieweGonderilenVeri"] = deger;
                        }
                        else
                        {
                            var deger = veri[0];
                            ViewData["vieweGonderilenVeri"] = deger;
                        }
                    }
                    
                    return View();
                }
            }



       
        }
        [HttpPost]
        public ActionResult OgrenciKaydet(Veritabanisiniflari model)
        {
            OgrenciHesap hesap = new OgrenciHesap();
            Mailgonderecek(model);


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
                 model.Ogrenci.OgrenciResmi =  newfoto;
                 model.Ogrenci.kayittarihi = DateTime.Now;
                 
               
             } 
            var ozeldurum = _ozeldurumservice.GetString(model.ozeldurumnedeni);
            _odabilgileriservice.Add(model.OdaBilgileri);
            _taksitodemeturuservice.Add(model.TaksitOdeme);
            _velibilgileriservice.Add(model.VeliBilgileri);
            var oda = _odabilgileriservice.GetAll().Last();

            var veli = _velibilgileriservice.GetAll().Last();
            var taksit = _taksitodemeturuservice.GetAll().Last();
            var velibilgisi = _velibilgileriservice.GetAll().Last();
            
          
            
             model.Ogrenci.OdaBilgileriId = oda.Id;
             model.Ogrenci.VeliBilgileriId = veli.Id;
            model.Ogrenci.TaksitOdemeId = taksit.Id;
            model.Ogrenci.VeliBilgileriId = velibilgisi.Id;
            if(ozeldurum!=null)
            {
                model.Ogrenci.OzelDurumId = ozeldurum.Id;
            }
           
            ViewBag.odabilgileri = _odabilgileriservice.GetAll();
            ViewBag.VeliBilgi = _velibilgileriservice.GetAll();
            ViewBag.TaksitBilgi = _taksitodemeturuservice.GetAll();

           
            var ogrencibig = model.Ogrenci;
            _devamsizliksayisi.Add(new DevamsizlikSayisi { Devamsizliksayi = 0 });
            var devamsizligi = _devamsizliksayisi.GetAll().Last();
            model.Ogrenci.DevamsizlikId = devamsizligi.Id;
            // model.Ogrenci.DevamsizlikId=
            _ogrenciservice.Add(ogrencibig);
            var ogrencibilgisi = _ogrenciservice.GetAll().Last();
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
      
        public ActionResult Sifirla()
        {
            TempData["degerim"] = null;
            return RedirectToAction("BakiyeTanimlama");
        }
        public ActionResult BakiyeBilgileri(int id)
        {
            TempData["degerim"] = id;
            return RedirectToAction("BakiyeTanimlama");
        }
        public ActionResult BakiyeTanimlama()
        {
            
            var ogrencibilgi = _ogrenciservice.GetAll();
            OgrenciViewModel modelbilgi = new OgrenciViewModel();

            var oda = _odabilgileriservice.GetAll();
            var taksit = _taksitodemeturuservice.GetAll();
            var veli = _velibilgileriservice.GetAll();
            modelbilgi.OgrenciListesi = new List<OgrenciModel>();
            foreach (var item in ogrencibilgi)
            {

                OgrenciModel oo = new OgrenciModel();

                oo.Ogrenci = item;


                OdaBilgileri odabilgil = new OdaBilgileri();
                OgrenciHareket ogrhareket = new OgrenciHareket();
                TaksitOdeme takodeme = new TaksitOdeme();
                VeliBilgileri velibilgi = new VeliBilgileri();
                odabilgil = _odabilgileriservice.Get((int)item.OdaBilgileriId);
                ogrhareket = _ogrencihareketservice.GetirOgrenciID(item.Id);
                takodeme = _taksitodemeturuservice.Get((int)item.TaksitOdemeId);
                velibilgi = _velibilgileriservice.Get((int)item.VeliBilgileriId);
                oo.OdaBilgisi = odabilgil;
                oo.VeliBilgileri = velibilgi;
                oo.OgrenciHareket = ogrhareket;
                oo.TaksitOdeme = takodeme;
                modelbilgi.OgrenciListesi.Add(oo);
            }
            ViewBag.modeldekiler2 = modelbilgi;

            OgrenciModel o = new OgrenciModel();
            var bakiyeid = TempData["degerim"];
            // var adsoyad = "ali demir";
            if (bakiyeid == null)
            {
                o.Ogrenci = null;
                o.OgrenciHareket = null;
                o.OdaBilgisi = null;
                o.TaksitOdeme = null;
                return View(o);
            }
            if(bakiyeid!=null)
            { 
                var bilgiler = _ogrenciservice.Get((int)bakiyeid);
                ViewData["OgrenciBilgileri"] = bilgiler;

                OgrenciModelVerileri model = new OgrenciModelVerileri();
                var ogrenci = _ogrenciservice.GetAll();
                model.Ogrenciliste = new OgrenciModel();

                o.Ogrenci = bilgiler;



                OdaBilgileri odabil = new OdaBilgileri();
                TaksitOdeme taksitbil = new TaksitOdeme();
                OgrenciHareket ogrencihareketbil = new OgrenciHareket();
                VeliBilgileri velibilgi2 = new VeliBilgileri();
                odabil = _odabilgileriservice.Get((int)bilgiler.OdaBilgileriId);
                o.OdaBilgisi = odabil;
                taksitbil = _taksitodemeturuservice.Get((int)bilgiler.TaksitOdemeId);
                o.TaksitOdeme = taksitbil;
                ogrencihareketbil = _ogrencihareketservice.GetirOgrenciID(bilgiler.Id);
                velibilgi2 = _velibilgileriservice.Get((int)bilgiler.VeliBilgileriId);
                o.VeliBilgileri = velibilgi2;
                o.OgrenciHareket = ogrencihareketbil;
                return View(o);
            }
            return View();

        }
        [HttpPost]
        public ActionResult BakiyeKaydet(OgrenciModel bakiye)
        {
            
            var ogrencihareketbilgisi = _ogrencihareketservice.GetirOgrenciID(bakiye.Ogrenci.Id);
            ogrencihareketbilgisi.islemtarihi = DateTime.Now;
            ogrencihareketbilgisi.kalanborc =bakiye.OgrenciHareket.kalanborc-bakiye.odenentutar;
            ogrencihareketbilgisi.odenenborc =bakiye.OgrenciHareket.odenenborc+bakiye.odenentutar;
            ogrencihareketbilgisi.OgrenciId = bakiye.Ogrenci.Id;
             _ogrencihareketservice.Update(ogrencihareketbilgisi);
            var taksitbilgileri = _taksitodemeturuservice.Get((int)bakiye.Ogrenci.TaksitOdemeId);
            taksitbilgileri.TaksitSayisi =Convert.ToInt32(bakiye.kalantaksitsayisi);
            if (taksitbilgileri.TaksitSayisi > 0)
            {
                taksitbilgileri.aylikodenecekmiktar = ogrencihareketbilgisi.kalanborc / taksitbilgileri.TaksitSayisi;
                taksitbilgileri.taksitodenecegitarihi = bakiye.TaksitOdeme.taksitodenecegitarihi;
                _taksitodemeturuservice.Update(taksitbilgileri);
                TempData["bakiye"] = bakiye;
                TempData.Keep();
                return RedirectToAction("FaturaOlustur");
            }
            if (taksitbilgileri.TaksitSayisi==0)
            {
                taksitbilgileri.aylikodenecekmiktar = 0;
                taksitbilgileri.taksitodenecegitarihi = bakiye.TaksitOdeme.taksitodenecegitarihi;
                _taksitodemeturuservice.Update(taksitbilgileri);
                return RedirectToAction("Index", "Anasayfa");
            }

            return RedirectToAction("Index","Anasayfa"); 
           
           
           
        }
        public ActionResult FaturaOlustur()
        {
            OgrenciModel veri =(OgrenciModel)TempData["bakiye"];
            return View(veri);
        }

        public ActionResult BakiyeListesi(string search)
        {
           
            var ogrenci = _ogrenciservice.GetAll();
            OgrenciViewModel model = new OgrenciViewModel();

            var oda = _odabilgileriservice.GetAll();
            var taksit = _taksitodemeturuservice.GetAll();
            var veli = _velibilgileriservice.GetAll();
            model.OgrenciListesi = new List<OgrenciModel>();
            if (!String.IsNullOrEmpty(search))
            {
                ogrenci = ogrenci.Where(s => s.ogrenciadisoyadi.Contains(search)).ToList();

            }
           
            model.OgrenciListesi = new List<OgrenciModel>();
            foreach (var item in ogrenci)
            {
               
                    OgrenciModel o = new OgrenciModel();
                    o.Ogrenci = item;

                    TaksitOdeme taksitbil = new TaksitOdeme();
                    OgrenciHareket ogrencihareket = new OgrenciHareket();
                    taksitbil = _taksitodemeturuservice.Get((int)item.TaksitOdemeId);
                    ogrencihareket = _ogrencihareketservice.GetirOgrenciID(item.Id);
                    o.TaksitOdeme = taksitbil;
                    o.OgrenciHareket = ogrencihareket;

                    model.OgrenciListesi.Add(o);
                
            }
                return View(model);
        }
        public ActionResult Mailgonder()
        {
            return View();
        }
        public ActionResult Duzenle(int id)
        {
            var bilgiler = _ogrenciservice.Get(id);
           // OgrenciModelVerileri model = new OgrenciModelVerileri();
            //var ogrenci = _ogrenciservice.GetAll();
            //model.Ogrenciliste = new OgrenciModel();
            OgrenciModel o = new OgrenciModel();
            o.Ogrenci = bilgiler;
            OdaBilgileri odabil = new OdaBilgileri();
            TaksitOdeme taksitbil = new TaksitOdeme();
            OgrenciHareket ogrencihareketbil = new OgrenciHareket();
            VeliBilgileri velibil = new VeliBilgileri();
            odabil = _odabilgileriservice.Get((int)bilgiler.OdaBilgileriId);
            o.OdaBilgisi = odabil;
            taksitbil = _taksitodemeturuservice.Get((int)bilgiler.TaksitOdemeId);
            o.TaksitOdeme = taksitbil;
            ogrencihareketbil = _ogrencihareketservice.GetirOgrenciID(bilgiler.Id);
            o.OgrenciHareket = ogrencihareketbil;
            velibil = _velibilgileriservice.Get((int)bilgiler.VeliBilgileriId);
            o.VeliBilgileri = velibil;
            return View(o);
        }
        [HttpPost]
        public ActionResult Duzenle(OgrenciModel model)
        {
            _odabilgileriservice.Update(model.OdaBilgisi);
            _ogrencihareketservice.Update(model.OgrenciHareket);
            _ogrenciservice.Update(model.Ogrenci);
            _velibilgileriservice.Update(model.VeliBilgileri);
            _taksitodemeturuservice.Update(model.TaksitOdeme);
            return RedirectToAction("OgrenciListele");
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

        public ActionResult Silme(int id)
        {
            var bilgiler = _ogrenciservice.Get(id);
            // OgrenciModelVerileri model = new OgrenciModelVerileri();
            //var ogrenci = _ogrenciservice.GetAll();
            //model.Ogrenciliste = new OgrenciModel();
         
           
            OdaBilgileri odabil = new OdaBilgileri();
            TaksitOdeme taksitbil = new TaksitOdeme();
            OgrenciHareket ogrencihareketbil = new OgrenciHareket();
            VeliBilgileri velibil = new VeliBilgileri();
            odabil = _odabilgileriservice.Get((int)bilgiler.OdaBilgileriId);
            _odabilgileriservice.Delete(odabil);
            taksitbil = _taksitodemeturuservice.Get((int)bilgiler.TaksitOdemeId);
            _taksitodemeturuservice.Delete(taksitbil);
            
            ogrencihareketbil = _ogrencihareketservice.GetirOgrenciID(bilgiler.Id);
            _ogrencihareketservice.Delete(ogrencihareketbil);
           
            velibil = _velibilgileriservice.Get(bilgiler.Id);
            _velibilgileriservice.Delete(velibil);
            _ogrenciservice.Delete(bilgiler);
            return RedirectToAction("OgrenciListele");
        }
        
        public void OgrenciSil(int id)
        {
            
            var ogrenci = _ogrenciservice.Get(id);  
            OdaBilgileri odabil = new OdaBilgileri();
            TaksitOdeme taksitbil = new TaksitOdeme();
            OgrenciHareket ogrencihareketbil = new OgrenciHareket();
            VeliBilgileri velibil = new VeliBilgileri();
            odabil = _odabilgileriservice.Get((int)ogrenci.OdaBilgileriId);
            taksitbil = _taksitodemeturuservice.Get((int)ogrenci.TaksitOdemeId);
            ogrencihareketbil = _ogrencihareketservice.GetirOgrenciID(ogrenci.Id);
            velibil = _velibilgileriservice.Get((int)ogrenci.VeliBilgileriId);
            _ogrencihareketservice.Delete(ogrencihareketbil);
            _ogrenciservice.Delete(ogrenci);
            _taksitodemeturuservice.Delete(taksitbil);
            _odabilgileriservice.Delete(odabil);
            _velibilgileriservice.Delete(velibil);
    
        }
        public ActionResult Delete(int id)
        {
            var ogrenci = _ogrenciservice.Get(id);
            return View(ogrenci);

        }

     
        public ActionResult ExcelBelgesi()
        {
            var ogrenci = _ogrenciservice.GetAll();
            OgrenciViewModel model = new OgrenciViewModel();

            var oda = _odabilgileriservice.GetAll();
            var veli = _velibilgileriservice.GetAll();
            model.OgrenciListesi = new List<OgrenciModel>();

            foreach (var item in ogrenci)
            {

                OgrenciModel o = new OgrenciModel();

                o.Ogrenci = item;


                OdaBilgileri odabil = new OdaBilgileri();
                VeliBilgileri velibil = new VeliBilgileri();
                odabil = _odabilgileriservice.Get((int)item.OdaBilgileriId);
                velibil = _velibilgileriservice.Get((int)item.VeliBilgileriId);
                o.VeliBilgileri = velibil;
                o.OdaBilgisi = odabil;
                model.OgrenciListesi.Add(o);
            }
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage ExcelPkg = new ExcelPackage();
            ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets.Add("Sheet1");
            wsSheet1.Column(3).Width = 15;
            wsSheet1.Column(4).Width = 15;
            wsSheet1.Column(5).Width = 15;
            wsSheet1.Column(8).Width = 15;
            wsSheet1.Column(9).Width = 15;
            wsSheet1.Column(10).Width = 15;
           

            int sutun = 1;
            int satir = 1;
            ExcelRange baslik = wsSheet1.Cells[satir, sutun ];
            baslik.Value = "SIRA NO";
            baslik.Style.Font.Color.SetColor(Color.Red);
            baslik.Style.Fill.PatternType = ExcelFillStyle.Solid;
            baslik.Style.Fill.BackgroundColor.SetColor(Color.LightGray);


            sutun = sutun + 1;
            ExcelRange baslik2 = wsSheet1.Cells[satir, sutun];
            baslik2.Value = "ODA NO";
            baslik2.Style.Font.Color.SetColor(Color.Red);
            baslik2.Style.Fill.PatternType = ExcelFillStyle.Solid;
            baslik2.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            

            sutun = sutun + 1;
            ExcelRange baslik3 = wsSheet1.Cells[satir, sutun];
            baslik3.Value = "İSİM SOYİSİM";
            baslik3.Style.Font.Color.SetColor(Color.Red);
            baslik3.Style.Fill.PatternType = ExcelFillStyle.Solid;
            baslik3.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
           


            sutun = sutun + 1;
            ExcelRange baslik4 = wsSheet1.Cells[satir, sutun];
            baslik4.Value = "T.C. NUMARASI";
            baslik4.Style.Font.Color.SetColor(Color.Red);
            baslik4.Style.Fill.PatternType = ExcelFillStyle.Solid;
            baslik4.Style.Fill.BackgroundColor.SetColor(Color.LightGray);


            sutun = sutun + 1;
            ExcelRange baslik5 = wsSheet1.Cells[satir, sutun];
            baslik5.Value = "BÖLÜM";
            baslik5.Style.Font.Color.SetColor(Color.Red);
            baslik5.Style.Fill.PatternType = ExcelFillStyle.Solid;
            baslik5.Style.Fill.BackgroundColor.SetColor(Color.LightGray);


            sutun = sutun + 1;
            ExcelRange baslik6 = wsSheet1.Cells[satir, sutun];
            baslik6.Value = "SINIF";
            baslik6.Style.Font.Color.SetColor(Color.Red);
            baslik6.Style.Fill.PatternType = ExcelFillStyle.Solid;
            baslik6.Style.Fill.BackgroundColor.SetColor(Color.LightGray);


            sutun = sutun + 1;
            ExcelRange baslik7 = wsSheet1.Cells[satir, sutun];
            baslik7.Value = "1.Ö/2.Ö";
            baslik7.Style.Font.Color.SetColor(Color.Red);
            baslik7.Style.Fill.PatternType = ExcelFillStyle.Solid;
            baslik7.Style.Fill.BackgroundColor.SetColor(Color.LightGray);


            sutun = sutun + 1;
            ExcelRange baslik8 = wsSheet1.Cells[satir, sutun];
            baslik8.Value = "CEP TELEFONU";
            baslik8.Style.Font.Color.SetColor(Color.Red);
            baslik8.Style.Fill.PatternType = ExcelFillStyle.Solid;
            baslik8.Style.Fill.BackgroundColor.SetColor(Color.LightGray);


            sutun = sutun + 1;
            ExcelRange baslik9 = wsSheet1.Cells[satir, sutun];
            baslik9.Value = "VELİ İSİM";
            baslik9.Style.Font.Color.SetColor(Color.Red);
            baslik9.Style.Fill.PatternType = ExcelFillStyle.Solid;
            baslik9.Style.Fill.BackgroundColor.SetColor(Color.LightGray);


            sutun = sutun + 1;
            ExcelRange baslik10 = wsSheet1.Cells[satir, sutun];
            baslik10.Value = "VELİ CEP";
            baslik10.Style.Font.Color.SetColor(Color.Red);
            baslik10.Style.Fill.PatternType = ExcelFillStyle.Solid;
            baslik10.Style.Fill.BackgroundColor.SetColor(Color.LightGray);


            sutun = 1;
            satir = satir + 1;
            int sayac = 1;
            for(var k=0;k< model.OgrenciListesi.Count();k++)
            {

                //excel.Range sirano = (excel.Range)sheet.Cells[satir + k, sutun];
                ExcelRange sirano = wsSheet1.Cells[satir+k, sutun];
                sirano.Style.Fill.PatternType = ExcelFillStyle.Solid;
                sirano.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                sirano.Value = k + 1;

                sutun = sutun + 1;
                ExcelRange odano = wsSheet1.Cells[satir + k, sutun];
                //excel.Range odano = (excel.Range)sheet.Cells[satir + k, sutun];
                odano.Value = model.OgrenciListesi[k].OdaBilgisi.OdaNo;
                odano.Style.Fill.PatternType = ExcelFillStyle.Solid;
                odano.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                sutun = sutun + 1;

                ExcelRange isimsoyisim = wsSheet1.Cells[satir + k, sutun];
                //excel.Range isimsoyisim = (excel.Range)sheet.Cells[satir+k, sutun];
                isimsoyisim.Value = model.OgrenciListesi[k].Ogrenci.ogrenciadisoyadi;
                isimsoyisim.Style.Fill.PatternType = ExcelFillStyle.Solid;
                isimsoyisim.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                sutun = sutun + 1;

                ExcelRange tckimlikno = wsSheet1.Cells[satir + k, sutun];
                //excel.Range tckimlikno = (excel.Range)sheet.Cells[satir+k, sutun];
                tckimlikno.Value = model.OgrenciListesi[k].Ogrenci.Ogrencitckimlikno;
                tckimlikno.Style.Fill.PatternType = ExcelFillStyle.Solid;
                tckimlikno.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                sutun = sutun + 1;

                ExcelRange bolum = wsSheet1.Cells[satir + k, sutun];
                // excel.Range bolum = (excel.Range)sheet.Cells[satir+k, sutun];
                bolum.Style.Fill.PatternType = ExcelFillStyle.Solid;
                bolum.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                bolum.Value = model.OgrenciListesi[k].Ogrenci.bolumadi;
                sutun = sutun + 1;

                ExcelRange sinifadi = wsSheet1.Cells[satir + k, sutun];
                //excel.Range sinifadi = (excel.Range)sheet.Cells[satir+k, sutun];
                sinifadi.Value = model.OgrenciListesi[k].Ogrenci.Sinifadi;
                sinifadi.Style.Fill.PatternType = ExcelFillStyle.Solid;
                sinifadi.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                sutun = sutun + 1;

                ExcelRange birikiogretim = wsSheet1.Cells[satir + k, sutun];
                //excel.Range birikiogretim = (excel.Range)sheet.Cells[satir+k, sutun];
                birikiogretim.Value = model.OgrenciListesi[k].Ogrenci.Ogrenimturu;
                birikiogretim.Style.Fill.PatternType = ExcelFillStyle.Solid;
                birikiogretim.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                sutun = sutun + 1;

                ExcelRange ogrencinumara = wsSheet1.Cells[satir + k, sutun];
                //excel.Range ogrencinumara = (excel.Range)sheet.Cells[satir+k, sutun];
                ogrencinumara.Value = model.OgrenciListesi[k].Ogrenci.Ceptelefonu;
                ogrencinumara.Style.Fill.PatternType = ExcelFillStyle.Solid;
                ogrencinumara.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                sutun = sutun + 1;

                ExcelRange veliisim = wsSheet1.Cells[satir + k, sutun];
                //excel.Range veliisim = (excel.Range)sheet.Cells[satir+k, sutun];
                veliisim.Value = model.OgrenciListesi[k].VeliBilgileri.VeliAdiSoyadi;
                veliisim.Style.Fill.PatternType = ExcelFillStyle.Solid;
                veliisim.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                sutun = sutun + 1;

                ExcelRange velinumara = wsSheet1.Cells[satir + k, sutun];
                //excel.Range velinumara = (excel.Range)sheet.Cells[satir+k, sutun];
                velinumara.Value = model.OgrenciListesi[k].VeliBilgileri.telefonno;
                velinumara.Style.Fill.PatternType = ExcelFillStyle.Solid;
                velinumara.Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                sutun = 1;

            }
            wsSheet1.Protection.IsProtected = false;
            wsSheet1.Protection.AllowSelectLockedCells = false;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ExcelPkg.SaveAs(new FileInfo(path + "\\OgrenciListesi.xlsx"));
            TempData["yoklamalistesi"] = "Yoklama Listeniz Masaüstünde YoklamaListesi Adındaki Excel Dosyasıdır.";
            return RedirectToAction("OgrenciListele");
        }
 
    }
}