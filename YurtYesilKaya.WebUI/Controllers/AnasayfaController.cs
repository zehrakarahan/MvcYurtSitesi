using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurtYesilKaya.Bll.Abstract;
using YurtYesilKaya.WebUI.Models;

namespace YurtYesilKaya.WebUI.Controllers
{
    public class AnasayfaController : Controller
    {
        IYemeklerService _yemeklerservice;
        IYemekTuruService _yemekturuservice;
        IilcelerService _ilcelerService;
        public AnasayfaController(IYemeklerService yemeklerservice,IYemekTuruService yemekturuservice,IilcelerService ilcelerService)
        {
            this._yemeklerservice = yemeklerservice;
            this._yemekturuservice = yemekturuservice;
            this._ilcelerService = ilcelerService;
        }
        SayiDegeri durum = new SayiDegeri();
        public ActionResult Index()
        {
            var yemekturu = _yemekturuservice.GetAll();
            var yemek = _yemeklerservice.GetAll();
            var yemektursayisi = yemekturu.Count();
            var sayi = yemek.Count();
            ViewBag.sayimiz = sayi;
            ViewBag.yemekturu = yemekturu;
            ViewBag.yemek = yemek;
            ViewBag.yemekturusayisi = yemektursayisi;
         

            
            return View();

        }
        public ActionResult liste()
        {
            return View();
        }
    }
}