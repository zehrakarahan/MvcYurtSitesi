using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using YurtYesilKaya.Bll.Abstract;
using YurtYesilKaya.Entity.Entity;
using YurtYesilKaya.WebUI.Models;

namespace YurtYesilKaya.WebUI.Controllers
{
    public class YemekController : Controller
    {
        // GET: Yemek
        IYemeklerService _yemeklerservice;
        IYemekTuruService _yemekturuservice;
        IilcelerService _ilcelerService;
        public YemekController(IYemeklerService yemeklerservice, IYemekTuruService yemekturuservice, IilcelerService ilcelerService)
        {
            this._yemeklerservice = yemeklerservice;
            this._yemekturuservice = yemekturuservice;
            this._ilcelerService = ilcelerService;
        }
        // GET: Yemek
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Liste()
        {

            return View();
        }
       
        public ActionResult Taslak30gunluk()
        {
            return View();
        }



        [HttpPost]
        public ActionResult YemekListesi(DateTime tarih)
        {

            DateTime dd = tarih;
            var deger = tarih.Day.ToString();
            DateTime aysonu2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
            DateTime aysonu = new DateTime(tarih.Year, tarih.Month, 1);
            List<Yemekler> yemekler = _yemeklerservice.GetAll();
      

            if (yemekler.Count == 0)
            {
                if (tarih.Year % 4 == 0 && tarih.Year % 100 != 0)
                {
                    if (tarih.Month < 8)
                    {
                        if (tarih.Month % 2 != 0)
                        {
                            return RedirectToAction("Taslak30gunluk", "Yemek", new { tarih = tarih });
                        }

                        else
                        {
                            if (tarih.Month == 2)
                            {
                                return RedirectToAction("Taslak30gunluk", "Yemek", new { tarih = tarih });
                            }
                            else
                            {
                                //return new RedirectToRouteResult(
                                //      new RouteValueDictionary {
                                //            { "action", "Taslak30gunluk" },
                                //            { "controller", "Yemek" },
                                //            { "tarih", tarih }
                                //      }
                                //  );
                                // return RedirectToAction("Taslak30gunluk", "Yemek", new { tarih = tarih });
                               
                            }
                        }
                    }
                }
                else
                {
                    if (tarih.Month < 8)
                    {
                        if (tarih.Month % 2 != 0)
                        {
                            return RedirectToAction("Taslak30gunluk", "Yemek", new { tarih = tarih });
                        }

                        else
                        {
                            if (tarih.Month == 2)
                            {
                                return RedirectToAction("Taslak30gunluk", "Yemek", new { tarih = tarih });
                            }
                            else
                            {
                                return RedirectToAction("Taslak30gunluk", "Yemek", new { tarih = tarih });
                            }
                        }
                    }
                }
            }
            else
            {
                if (tarih.Year % 4 == 0 && tarih.Year % 100 != 0)
                {
                    if (tarih.Month < 8)
                    {
                        if (tarih.Month % 2 != 0)
                        {
                            return RedirectToAction("Taslak31gunluk", "Yemek", new { tarih = tarih });
                        }

                        else
                        {
                            if (tarih.Month == 2)
                            {
                                return RedirectToAction("Taslak31gunluk", "Yemek", new { tarih = tarih });
                            }
                            else
                            {
                                return RedirectToAction("Taslak31gunluk", "Yemek", new { tarih = tarih });
                            }
                        }
                    }
                }
                else
                {
                    if (tarih.Month < 8)
                    {
                        if (tarih.Month % 2 != 0)
                        {
                            return RedirectToAction("Taslak31gunluk", "Yemek", new { tarih = tarih });
                        }

                        else
                        {
                            if (tarih.Month == 2)
                            {
                                return RedirectToAction("Taslak31gunluk", "Yemek", new { tarih = tarih });
                            }
                            else
                            {
                                return RedirectToAction("Taslak31gunluk", "Yemek", new { tarih = tarih });
                            }
                        }
                    }
                }

            }

            return RedirectToAction("Index", "Yemek");
        }
        public ActionResult Taslak()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Taslak31gunluk(YemekModel yemekmodel)
        {
             var yemekturu=_yemekturuservice.GetAll();
             var ogun = yemekturu.Last();
            var dene = ogun.yemekturu;
            List<Yemekler> deger = _yemeklerservice.GetAll();
            var veri = deger.Last();
            var ilkdeger = deger.FirstOrDefault();

            DateTime tarihibilgisi,baslangictarihi;
            string kisatarihbilgisi;

            int aybilgisi; int gunbilgisi; int yilbilgisi;
            var yemekbilgileri=Yemektarihleri.tarihbilgileri(_yemeklerservice.GetAll(),yemekmodel);
            tarihibilgisi = yemekbilgileri.ilkmisonmutarih;
            kisatarihbilgisi = yemekbilgileri.kisatarih;
            aybilgisi = yemekbilgileri.aybilgisi;
            yilbilgisi = yemekbilgileri.yilbilgisi;
            gunbilgisi = yemekbilgileri.gunbilgisi;
            baslangictarihi= yemekbilgileri.baslangictarihi;
            TempData["ogun"] = yemekmodel.YemekTuru.yemekturu;
            var yemekturusayisi = _yemekturuservice.GetAll().Count();
            List<YemekTuru> yemekturleri = _yemekturuservice.GetAll();
            if (deger.Count > 28)
            {
                for (int i = 0; i < 28; i++)
                {

                    if (yemekturusayisi == 30)
                    {
                        _yemekturuservice.Delete(yemekturleri[i]);
                        _yemeklerservice.Delete(deger[i]);
                    }
                    else
                    {
                        _yemeklerservice.Delete(deger[i]);
                       
                    }
                }
            }
            ViewBag.yilbigisi31 =yemekmodel.Tarih.Year;
            ViewBag.aybilgisi31 =yemekmodel.Tarih.Month;
            ViewBag.gunbilgisi31 =yemekmodel.Tarih.Day;
            ViewBag.ayadi =yemekmodel.Tarih.ToString("MMMM");
            string strHTML = string.Empty;


            strHTML += "<table class='table table-bordered' id='sayfa' margin-top:-4px; margin-bottom:-4px; padding:0px; >";
            DateTime dtmBaslangicTarihi = Convert.ToDateTime(baslangictarihi);
            DateTime dtmBitisTarihi = dtmBaslangicTarihi.AddDays(27);

            int intSayac = 1;
            for (DateTime dtmTarih = dtmBaslangicTarihi; dtmTarih <= dtmBitisTarihi; dtmTarih = dtmTarih.AddDays(1))
            {
                string strGun_Adi = fnTarih(dtmTarih, false);
                string strGun = dtmTarih.ToShortDateString();

                if (intSayac == 1)
                    strHTML += "<tr style='margin-bottom:-2px;'>";
                strHTML += "<td style='margin:0px;'>";
                strHTML += strGun_Adi;
                // Başlangıç
                strHTML += "<table class='table'>";

                strHTML += "<tr style='margin-bottom:-8px;'>";
                strHTML += "<td>";
                strHTML += strGun;
                strHTML += "<input class='form-control' style='width:145px;' type='hidden' name='gun_" + intSayac + "' value='" + strGun + "' />";
                strHTML += "</td>";
                strHTML += "</tr>";

                strHTML += "<tr style='margin:0px;'>";
                strHTML += "<td><input class='form-control' style='width:145px; '  type='text' name='gun_" + intSayac + "_yemek_1' /></td>";
                strHTML += "</tr>";

                strHTML += "<tr style='margin:0px;'>";
                strHTML += "<td><input class='form-control' style='width:145px;' type='text' name='gun_" + intSayac + "_yemek_2' /></td>";
                strHTML += "</tr>";

                strHTML += "<tr style='margin:0px;'>";
                strHTML += "<td><input class='form-control' style='width:145px;' type='text' name='gun_" + intSayac + "_yemek_3' /></td>";
                strHTML += "</tr>";

                strHTML += "<tr style='margin:0px;'>";
                strHTML += "<td><input class='form-control' style='width:145px;' type='text' name='gun_" + intSayac + "_yemek_4' /></td>";
                strHTML += "</tr>";

                strHTML += "<tr style='margin:0px;'>";
                strHTML += "<td><input class='form-control' style='width:145px; ' type='text' name='gun_" + intSayac + "_yemek_5' /></td>";
                strHTML += "</tr>";

                strHTML += "<tr style='margin:0px;'>";
                strHTML += "<td><input class='form-control' style='width:145px;' type='text' name='gun_" + intSayac + "_yemek_6' /></td>";
                strHTML += "</tr>";

                strHTML += "</table>";
                // Bitiş
                strHTML += "</td>";

                if (intSayac == 7 || intSayac == 14 || intSayac == 21)
                    strHTML += "</tr><tr>";

                if (intSayac == 28)
                    strHTML += "</tr>";

                intSayac += 1;
            }

            strHTML += "</table>";

            //  }
            ViewBag.tarihler_html = strHTML;
            return View();


        }
        public bool fnTarih_Mi(object objVeri)
        {
            bool blnSonuc = false;
            if (objVeri != null)
            {
                if (!string.IsNullOrEmpty(objVeri.ToString()))
                {
                    Regex desen = new Regex(@"(\d{4})[\-](0?[1-9]|1[012])[\-](0?[1-9]|[12][0-9]|3[01])?$");
                    blnSonuc = desen.IsMatch(objVeri.ToString());
                }
            }
            return blnSonuc;
        }
        public string fnTarih(object objTarih, bool blnSaat)
        {
            string strDonen_Deger = "";
            try
            {
                if (objTarih != null)
                {
                    string parTarih = objTarih.ToString();
                    string[] arrAylar = { "", "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };
                    string[] arrGunler = { "Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi" };
                    DateTime dtmTarih = DateTime.Parse(parTarih);
                    string strTarih = dtmTarih.ToString("yyyy-MM-dd HH:mm");
                    int intYil = dtmTarih.Year;
                    string strYil = intYil.ToString();
                    int intAy = dtmTarih.Month;
                    string strAy = arrAylar[intAy];
                    int intGun = dtmTarih.Day;
                    string strGun = intGun.ToString();
                    string strZaman = dtmTarih.ToShortTimeString();
                    int intHaftanin_Gunu = (int)dtmTarih.Date.DayOfWeek;
                    string strGun_Adi = arrGunler[intHaftanin_Gunu];
                    //strDonen_Deger = strGun + " " + strAy + " " + strYil + " " + strGun_Adi;
                    strDonen_Deger = strGun_Adi;
                    if (blnSaat == true)
                        strDonen_Deger = strDonen_Deger + ", " + strZaman;
                }
            }
            catch
            {

            }
            return strDonen_Deger;
        }


        [HttpPost]
        public ActionResult Taslak30gunluk(YemekModel yemekmodel)
        {
            var yemeklistesi = _yemeklerservice.GetAll();
            ViewBag.yilbigisi30 = yemekmodel.Tarih.Year;
            ViewBag.aybilgisi30 =yemekmodel.Tarih.Month;
            ViewBag.gunbilgisi30 = yemekmodel.Tarih.Day;
            ViewBag.ayadi = yemekmodel.Tarih.ToString("MMMM");
            List<Yemekler> deger = _yemeklerservice.GetAll();
            DateTime tarihibilgisi, baslangictarihi;
            string kisatarihbilgisi;
            int aybilgisi; int gunbilgisi; int yilbilgisi;
            var yemekbilgileri=Yemektarihleri.tarihbilgileri(_yemeklerservice.GetAll(),yemekmodel);
            string strHTML = string.Empty;
            tarihibilgisi = yemekbilgileri.ilkmisonmutarih;
            kisatarihbilgisi = yemekbilgileri.kisatarih;
            aybilgisi = yemekbilgileri.aybilgisi;
            yilbilgisi = yemekbilgileri.yilbilgisi;
            gunbilgisi = yemekbilgileri.gunbilgisi;
            baslangictarihi = yemekbilgileri.baslangictarihi;
            TempData["ogun"] = yemekmodel.YemekTuru.yemekturu;
        
          
            strHTML += "<table class='table table-bordered' id='sayfa' margin-top:-4px; margin-bottom:-4px; padding:0px; >";
            DateTime dtmBaslangicTarihi = Convert.ToDateTime(baslangictarihi);
            DateTime dtmBitisTarihi = dtmBaslangicTarihi.AddDays(27);

            int intSayac = 1;
            for (DateTime dtmTarih = dtmBaslangicTarihi; dtmTarih <= dtmBitisTarihi; dtmTarih = dtmTarih.AddDays(1))
            {
                string strGun_Adi = fnTarih(dtmTarih, false);
                string strGun = dtmTarih.ToShortDateString();

                if (intSayac == 1)
                    strHTML += "<tr style='margin-bottom:-2px;'>";
                strHTML += "<td style='margin:0px;'>";
                strHTML += strGun_Adi;
                // Başlangıç
                strHTML += "<table class='table'>";

                strHTML += "<tr style='margin-bottom:-8px;'>";
                strHTML += "<td>";
                strHTML += strGun;
                strHTML += "<input class='form-control' style='width:145px;' type='hidden' name='gun_" + intSayac + "' value='" + strGun + "' />";
                strHTML += "</td>";
                strHTML += "</tr>";

                strHTML += "<tr style='margin:0px;'>";
                strHTML += "<td><input class='form-control' style='width:145px; '  type='text' name='gun_" + intSayac + "_yemek_1' /></td>";
                strHTML += "</tr>";

                strHTML += "<tr style='margin:0px;'>";
                strHTML += "<td><input class='form-control' style='width:145px;' type='text' name='gun_" + intSayac + "_yemek_2' /></td>";
                strHTML += "</tr>";

                strHTML += "<tr style='margin:0px;'>";
                strHTML += "<td><input class='form-control' style='width:145px;' type='text' name='gun_" + intSayac + "_yemek_3' /></td>";
                strHTML += "</tr>";

                strHTML += "<tr style='margin:0px;'>";
                strHTML += "<td><input class='form-control' style='width:145px;' type='text' name='gun_" + intSayac + "_yemek_4' /></td>";
                strHTML += "</tr>";

                strHTML += "<tr style='margin:0px;'>";
                strHTML += "<td><input class='form-control' style='width:145px; ' type='text' name='gun_" + intSayac + "_yemek_5' /></td>";
                strHTML += "</tr>";

                strHTML += "<tr style='margin:0px;'>";
                strHTML += "<td><input class='form-control' style='width:145px;' type='text' name='gun_" + intSayac + "_yemek_6' /></td>";
                strHTML += "</tr>";

                strHTML += "</table>";
                // Bitiş
                strHTML += "</td>";

                if (intSayac == 7 || intSayac == 14 || intSayac == 21)
                    strHTML += "</tr><tr>";

                if (intSayac == 28)
                    strHTML += "</tr>";
               
                intSayac += 1;
            }

            strHTML += "</table>";

            //  }
            ViewBag.tarihler_html = strHTML;
            return View();


        }
        [HttpPost]
        public ActionResult AylikListeFormuKaydet()
        {
            string ogun;
            ogun = TempData["ogun"].ToString() ;
            _yemekturuservice.Add(new YemekTuru { yemekturu=ogun });
            string stFormVerileri = string.Empty;
            string strGun = string.Empty;
            string strGun_Yemek_1 = string.Empty;
            string strGun_Yemek_2 = string.Empty;
            string strGun_Yemek_3 = string.Empty;
            string strGun_Yemek_4 = string.Empty;
            string strGun_Yemek_5 = string.Empty;
            string strGun_Yemek_6 = string.Empty;
            for (int i = 1; i < 29; i++)
            {
                strGun = Request.Form["gun_" + i];
                strGun_Yemek_1 = Request.Form["gun_" + i + "_yemek_1"];
                strGun_Yemek_2 = Request.Form["gun_" + i + "_yemek_2"];
                strGun_Yemek_3 = Request.Form["gun_" + i + "_yemek_3"];
                strGun_Yemek_4 = Request.Form["gun_" + i + "_yemek_4"];
                strGun_Yemek_5 = Request.Form["gun_" + i + "_yemek_5"];
                strGun_Yemek_6 = Request.Form["gun_" + i + "_yemek_6"];

                _yemeklerservice.Add(new Yemekler
                {
                    birinciyemekadi = strGun_Yemek_1,
                    ikinciyemekadi = strGun_Yemek_2,
                    ucuncuyemekadi = strGun_Yemek_3,
                    dorduncuyemekadi = strGun_Yemek_4,
                    besinciyemekadi=strGun_Yemek_5,
                    altinciyemekadi = strGun_Yemek_6,
                    yedinciyemekadi = "",
                    bugununtarihi = DateTime.Parse(strGun),
                    sabahkahvaltisimiaksamyemegimi=ogun

                });

            }

            return RedirectToAction("Index", "AnaSayfa");
        }

        [HttpGet]
        public ActionResult Taslak28gunluk(DateTime tarih)
        {
            ViewBag.tarih = tarih;
            ViewBag.yilbigisi28 = tarih.Year;
            ViewBag.aybilgisi28 = tarih.Month;
            ViewBag.gunbilgisi28 = tarih.Day;
            ViewBag.ayadi = tarih.ToString("MMMM");
            DateTime y_IlkTarih = new DateTime(tarih.Year, tarih.Month, 1);
            ViewBag.gunadi28 = y_IlkTarih.DayOfWeek;

            string gunu = y_IlkTarih.DayOfWeek.ToString();
            for (int i = 1; i < 7; i++)
            {
                y_IlkTarih = new DateTime(tarih.Year, tarih.Month, i);
                gunu = y_IlkTarih.DayOfWeek.ToString();
                if (gunu == "Monday")
                {
                    int deger = i;
                    ViewBag.ilkpazartesigunu = deger;
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Taslak29gunluk(DateTime tarih)
        {
            ViewBag.yilbigisi29 = tarih.Year;
            ViewBag.aybilgisi29 = tarih.Month;
            ViewBag.gunbilgisi29 = tarih.Day;
            ViewBag.ayadi = tarih.ToString("MMMM");
            DateTime y_IlkTarih = new DateTime(tarih.Year, tarih.Month, 1);
            ViewBag.gunadi29 = y_IlkTarih.DayOfWeek;
            string gunu = y_IlkTarih.DayOfWeek.ToString();
            for (int i = 1; i < 7; i++)
            {
                y_IlkTarih = new DateTime(tarih.Year, tarih.Month, i);
                gunu = y_IlkTarih.DayOfWeek.ToString();
                if (gunu == "Monday")
                {
                    int deger = i;
                    ViewBag.ilkpazartesigunu = deger;
                }
            }
            return View();
        }


        private static string RenderRazorViewToString(ControllerContext controllerContext, string viewName)
        {

            using (var sw = new StringWriter())
            {
                var ViewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                var ViewContext = new ViewContext(controllerContext, ViewResult.View, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, sw);
                ViewResult.View.Render(ViewContext, sw);
                ViewResult.ViewEngine.ReleaseView(controllerContext, ViewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        public ActionResult PrintAll()
        {
            // var q = new ActionAsPdf("Index");
            return View();
        }
    }
}