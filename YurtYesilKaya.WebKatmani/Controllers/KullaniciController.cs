using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using YurtYesilKaya.Bll;
using YurtYesilKaya.Bll.Abstract;
using YurtYesilKaya.Entity.Entity;
using YurtYesilKaya.WebKatmani.Models;

namespace YurtYesilKaya.WebKatmani.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        IKullanicilarService _kullanicilarService;
        IillerService _illerService;
        IilcelerService _ilcelerService;
        ISifreDegisiklikService _sifredegisiklikservice;
        public KullaniciController(ISifreDegisiklikService sifredegisiklikservice, IKullanicilarService kullanicilarService, IillerService illerService, IilcelerService ilcelerService)
        {
            this._kullanicilarService = kullanicilarService;
            this._illerService = illerService;
            this._ilcelerService = ilcelerService;
            this._sifredegisiklikservice = sifredegisiklikservice;
        }
        // GET: Kullanici
        [HttpGet]
        public ActionResult KullaniciGiris()
        {
            var veri = TempData["giris"];
            TempData["yanlisgiris"] = veri;
            return View();
        }
        [HttpPost]
        public ActionResult KullaniciGiris(string KullaniciAdi, string Parola)
        {

            var kullanicilar = _kullanicilarService.KullaniciGiris(KullaniciAdi, Parola);
            if (kullanicilar == null)
            {
                TempData["giris"] = "Kullanıcı Adı Veya Şifre Hatalı";
                return RedirectToAction("KullaniciGiris");
            }
            Session["KullaniciId"] = kullanicilar.KullaniciAdi;
            Session["KullaniciAdi"] = kullanicilar.AdiSoyadi;
            return RedirectToAction("Index", "Anasayfa");

        }
  
        [HttpGet]
        public ActionResult UyeOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeOl(Kullanici kullanici)
        {
            var sifre = new ToPasswordRepository().Md5(kullanici.Parola);
            Kullanici db = new Kullanici();
            db.AdiSoyadi = kullanici.AdiSoyadi;
            db.telefonno = kullanici.telefonno;
            db.KullaniciAdi = kullanici.KullaniciAdi;
            db.Parola = sifre;
           
            _kullanicilarService.Add(db);
            return RedirectToAction("KullaniciGiris");
        }
        public ActionResult KullaniciCikis()
        {
            Session["KullaniciId"] = null;
            Session["KullaniciAdi"] = null;
            return RedirectToAction("KullaniciGiris");

        }
        public ActionResult BeniHatirla()
        {
            return View();
        }
        public ActionResult SifreResetle(string guid)
        {
            
            var kisimiz = _sifredegisiklikservice.Get(guid);
            var kullaniciadi = kisimiz.KullaniciAdi;
          
           if(kisimiz.gecerliliksuresi>DateTime.Now)
           {
                if (kisimiz.Active == true)
                {
                    SifreDegisiklik yenidurum = new SifreDegisiklik();

                    yenidurum.songuncellemetarihi = DateTime.Now;
                    yenidurum.KullaniciAdi = kisimiz.KullaniciAdi;
                    yenidurum.ilkkayittarihi = kisimiz.ilkkayittarihi;
                    yenidurum.Active = false;
                    yenidurum.guidimiz = kisimiz.guidimiz;
                    yenidurum.Id = kisimiz.Id;
                    _sifredegisiklikservice.Update(yenidurum);
                    var kullaniciadimiz = kullaniciadi;
                    var kidi = _kullanicilarService.GetKullaniciKullaniciName(kullaniciadimiz);
                    KullaniciModel model = new KullaniciModel();
                    model.Kullanici = kidi;
                    return View(model);
                }
                else
                {
                    TempData["guidgecersiz"] = "Linkiniz Artık Geçerli Değildir...";
                    return RedirectToAction("SifremiUnuttum");
                }
                
            }
            else
            {
                ViewBag.gecersizguid = "Bu Kullanıcı Link Geçersiz Şuan!!!";
                TempData["guidsuresidoldu"] = "Malesef Kullanım süresi Doldu...";
                return RedirectToAction("SifremiUnuttum");
            }
        }
        [HttpPost]
        public ActionResult SifreSifirlama(KullaniciModel model)
        {
            var sifre = new ToPasswordRepository().Md5(model.Yenisifre);
            Kullanici verim = new Kullanici();
            verim.KullaniciAdi = model.Kullanici.KullaniciAdi;
            verim.AdiSoyadi = model.Kullanici.AdiSoyadi;
            verim.Parola = model.Yenisifre;
            var kullan = _kullanicilarService.GetKullaniciKullaniciName(model.Kullanici.KullaniciAdi);
            kullan.KullaniciAdi = model.Kullanici.KullaniciAdi;
            kullan.Parola = sifre;
            kullan.AdiSoyadi = model.Kullanici.AdiSoyadi;
            kullan.telefonno = model.Kullanici.telefonno;
            _kullanicilarService.Update(kullan);
            
            TempData["sifresifirla"] = "  Şifre sıfırlama işlemi gerçekleşmiştir...";
            return RedirectToAction("KullaniciGiris");
        }
        public ActionResult SifremiUnuttum()
        {  
          
            return View();
        }
        [HttpPost]
        public ActionResult SifreOlustur(string KullaniciAdi, string telefonno)
        {
           
                var kisi = _kullanicilarService.KullaniciveEmail(KullaniciAdi, telefonno);
                if(kisi==null)
                {
                TempData["mailyanlis"] = "  Böyle bir kullanıcı yok...";
                }
                else
                {
                 Mailgonderecek(kisi);
                TempData["mailgitti"] = "  Mail Adresinize Gelen Linki Tıklayınız...";
                }
                

             
               
            return RedirectToAction("SifremiUnuttum");
        }
      
        public void Mailgonderecek(Kullanici kisi)
        {
            string serinumara = Guid.NewGuid().ToString();
            MailMessage mailim = new MailMessage();
            mailim.To.Add(kisi.telefonno);
            var tarih = DateTime.Now;
            var gecerliolduguzmn = DateTime.Now.AddHours(1);
            _sifredegisiklikservice.Add(new SifreDegisiklik { guidimiz = serinumara, Active = true, KullaniciAdi = kisi.KullaniciAdi, ilkkayittarihi = DateTime.Now, gecerliliksuresi=gecerliolduguzmn });
            mailim.To.Add("zehrakarahan1995@hotmail.com");
            mailim.From = new MailAddress("zehrakarahan95@gmail.com");
            var url = "http://" + Request.Url.Authority + "/Kullanici/SifreResetle?guid=" + serinumara;
            mailim.Subject = "YEŞİLKAYA ERKEK ÖĞRENCİ YURDU";
            /* mailim.Body = "Merhaba Sayın Kullanıcımız Giriş Bilgileriniz<br>" + "  "+
                           "Adınız Soyadınız=>"+"  "+kisi.AdiSoyadi+"<br>"+
                           "Kullanıcı Adınız=>"+"  "+kisi.KullaniciAdi+"<br>"+
                           "Şifreniz=>"+"  "+kullanici.Parola+"<br>"+
                           "İyi Günler Dileriz...";*/
            mailim.Body = "Merhaba  Şifre Bilginizi Sıfırlamak için Linke Tıklayınız....<br><br>" +
                  url;


            mailim.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
          smtp.Credentials = new NetworkCredential("zehrakarahan95@gmail.com", "141220034.6928");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mailim);
              
            }
            catch (Exception ex)
            {
              

            }



        }
    }
}