using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurtYesilKaya.Bll.Abstract;
using YurtYesilKaya.WebKatmani.Models;

namespace YurtYesilKaya.WebKatmani.Controllers
{
    public class FaturavetaslaklarController : Controller
    {
        // GET: Faturavetaslaklar
        IOgrenciService _ogrenciservice;
        IOgrenciHareketleriService _ogrencihareketservice;
        IOdaBilgileriService _odabilgileriservice;
        IVeliBilgilerService _velibilgileriservice;
        ITaksitOdemeTuruService _taksitodemeturuservice;
        public FaturavetaslaklarController( IOgrenciService ogrenciservice, IOgrenciHareketleriService ogrencihareketservice,
            IVeliBilgilerService velibilgileriservice, IOdaBilgileriService odabilgileriservice, 
            ITaksitOdemeTuruService taksitodemeturuservice)
        {
        

            this._ogrenciservice = ogrenciservice;
            this._ogrencihareketservice = ogrencihareketservice;
            this._odabilgileriservice = odabilgileriservice;
            this._velibilgileriservice = velibilgileriservice;
            this._taksitodemeturuservice = taksitodemeturuservice;
          
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SenetOlustur()
        {
            return View();
        }
    }
}