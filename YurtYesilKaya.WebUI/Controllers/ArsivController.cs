using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurtYesilKaya.Bll.Abstract;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.WebUI.Controllers
{
    public class ArsivController : Controller
    {
        IOgrenciService _ogrenciservice;
        
        public ArsivController(IOgrenciService ogrenciservice)
        {


            this._ogrenciservice = ogrenciservice;
            
        }
        public ActionResult Index(int sayfa=1)
        {
           var veriler=_ogrenciservice.GetAll();
           List<Ogrenci> veri = new List<Ogrenci>();
            foreach (var deger in veriler)
            {
                DateTime sonuc =Convert.ToDateTime(deger.kayittarihi);
                if(DateTime.Now.Year>sonuc.Year)
                {
                   
                    veri.Add(deger);
                }
               
            }
            var liste = veri.ToPagedList(sayfa, 5);
            
            return View(liste);
        }
    }
}