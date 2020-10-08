using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurtYesilKaya.Bll.Abstract;
using YurtYesilKaya.Entity.Entity;
using YurtYesilKaya.WebKatmani.Models;

namespace YurtYesilKaya.WebKatmani.Controllers
{
    public class AnasayfaController : Controller
    {
        IYemeklerService _yemeklerservice;
        IYemekTuruService _yemekturuservice;
        IilcelerService _ilcelerService;
        IOgrenciService _ogrenciservice;
        IOdaBilgileriService _odabilgileriservice;
        IOgrenciHareketleriService _ogrencihareketservice;
        ITaksitOdemeTuruService _taksitodemeturuservice;
        IVeliBilgilerService _velibilgileriservice;
        public AnasayfaController(IYemeklerService yemeklerservice,IYemekTuruService yemekturuservice,IilcelerService ilcelerService,IOgrenciService ogrenciservice,IOdaBilgileriService odabilgileriservice,IOgrenciHareketleriService ogrencihareketservice,ITaksitOdemeTuruService taksitodemeservice,IVeliBilgilerService velibilgileriservice)
       {
            this._yemeklerservice = yemeklerservice;
            this._yemekturuservice = yemekturuservice;
            this._ilcelerService = ilcelerService;
            this._ogrenciservice = ogrenciservice;
            this._odabilgileriservice = odabilgileriservice;
            this._ogrencihareketservice = ogrencihareketservice;
            this._taksitodemeturuservice = taksitodemeservice;
            this._velibilgileriservice = velibilgileriservice;
        }
        SayiDegeri durum = new SayiDegeri();
        public ActionResult Index()
        {
            var yemekturu = _yemekturuservice.GetAll();
            var yemeklistesi = _yemeklerservice.GetAll();
            var yemektursayisi = yemekturu.Count();
            var yemeklistesisayi = yemeklistesi.Count();
            ViewBag.sayimiz = yemeklistesisayi;
            ViewBag.yemekturu = yemekturu;
            ViewBag.yemeklistesi = yemeklistesi;
            ViewBag.yemekturusayisi = yemektursayisi;
            var yemekturulistesi = _yemekturuservice.GetAll();
            var sonyemekturu = yemekturulistesi.Count();
          



         

            
            return View();

        }
        int pagesize = 10;
        public ActionResult liste(int? page)
        {
            YesilKayaContext context = new YesilKayaContext();
            OgrenciViewModel model = new OgrenciViewModel();
            OgrenciModel model2 = new OgrenciModel();
            IEnumerable<Ogrenci> ogrenci = null;
            if(!page.HasValue)
            {
                ogrenci = context.Ogrenci.OrderByDescending(f=>f.Id).Take(pagesize);
            }
            else
            {
                int pageindex = pagesize * page.Value;
                ogrenci = context.Ogrenci.OrderByDescending(f=>f.Id).Skip(pageindex).Take(pagesize);
            }
            if (Request.IsAjaxRequest())
            {
               return PartialView("_Ogrenci", ogrenci);
            }
           
                return View(ogrenci);
         
        }
        public ActionResult veriler()
        {
            YoklamaModelView yoklamaviewmodel = new YoklamaModelView();
            DateTime ayinilkgunu = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime aysonu = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1);
            var ogrenciliste = _ogrenciservice.GetAll();
            List<OdaBilgileri> odanolar = _odabilgileriservice.GetAll().OrderBy(x => x.OdaNo).ToList();
            var odan = _odabilgileriservice.GetAll();
            List<int> odanumarasi = new List<int>();
            List<int> elemanlar = new List<int>();
          
            int n = 0, sayac = 0, i = 0, j, k, l;
            foreach (OdaBilgileri item in odan)
            {
                elemanlar.Add(item.OdaNo);
            }
            for (j = 0; j < elemanlar.Count - 1; j++)
            {
                for (k = j; k < elemanlar.Count - 1; k++)
                {
                    if (elemanlar[j] == elemanlar[k + 1])
                    {
                        sayac++;
                    }
                }
                if (odanumarasi.Count == 0)
                {
                    odanumarasi.Add(elemanlar[j]);
                }
                else
                {
                    if (sayac >= 1)
                    {

                        for (l = 0; l < odanumarasi.Count; l++)
                        {
                            if (odanumarasi[l] == elemanlar[j])
                            {
                                n++;
                            }
                        }
                    }
                    if (sayac >= 1)
                    {
                        for (l = 0; l < odanumarasi.Count; l++)
                        {
                            if (odanumarasi[l] != elemanlar[j])
                            {
                                if (n == 0)
                                {
                                    odanumarasi.Add(elemanlar[j]);
                                    n++;
                                }
                            }
                        }
                    }
                }
                sayac = 0;
                n = 0;

            }
            int gecici;
            for (int m = 0; m <= odanumarasi.Count - 1; m++)
            {
                for (int h = 1; h <= odanumarasi.Count - 1; h++)
                {
                    if (odanumarasi[h - 1] > odanumarasi[h])
                    {
                        gecici = odanumarasi[h - 1];
                        odanumarasi[h - 1] = odanumarasi[h];
                        odanumarasi[h] = gecici;
                    }
                }

            }
            yoklamaviewmodel.OdaNumaralari = odanumarasi;
          
            List<string> tarihler = new List<string>();
            List<string> geldigelmedi = new List<string>();
            List<DateTime> tari = new List<DateTime>();
            for (DateTime dtmTarih = ayinilkgunu; dtmTarih <= aysonu; dtmTarih = dtmTarih.AddDays(1))
            {

                string strGunKisaltmali = dtmTarih.ToShortDateString();
                tari.Add(dtmTarih);
                tarihler.Add(strGunKisaltmali);
                geldigelmedi.Add("");

            }
            yoklamaviewmodel.tarihler = tari;
            DateTime dtmBaslangicTarihi = Convert.ToDateTime(ayinilkgunu);
            var ogrenci = _ogrenciservice.GetAll();
            //OgrenciViewModel ogrenciviewmodel = new OgrenciViewModel();
            var oda = _odabilgileriservice.GetAll();
            yoklamaviewmodel.OgrenciListesi = new List<OgrenciModel>();
            yoklamaviewmodel.YoklamaModel = new List<YoklamaModel>();
            foreach (var item in ogrenci)
            {
               
                OgrenciModel o = new OgrenciModel();
                YoklamaModel yoklamamodel = new YoklamaModel();
                yoklamamodel.Ogrenci = item;
                yoklamamodel.ayingunleri = tarihler;
                yoklamamodel.geldigelmedi = geldigelmedi;
                o.Ogrenci = item;
               
                OdaBilgileri odabil = new OdaBilgileri();
                odabil = _odabilgileriservice.Get((int)item.OdaBilgileriId);
                yoklamamodel.OdaBilgileri = odabil;
                o.OdaBilgisi = odabil;
               // ogrenciviewmodel.OgrenciListesi.Add(o);
                yoklamaviewmodel.OgrenciListesi.Add(o);
                yoklamaviewmodel.YoklamaModel.Add(yoklamamodel);
               
            }
           
            return View(yoklamaviewmodel);

           
        }
        [HttpPost]
        public ActionResult Gelenler(YoklamaModelView veriler)
        {

            return View();
        }
        public ActionResult deneme()
        {
            var ogrenci = _ogrenciservice.GetAll();
            return View(ogrenci);
        }
       
        public ActionResult ikikisilik(string veril)
        {
            string[] parcalar;
         
            parcalar = veril.Split(',');
            List<int> oglistesi = new List<int>();
            foreach (var i in parcalar)
             {
                oglistesi.Add(Convert.ToInt32(i));

             }
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            Ogrenci ilk = new Ogrenci();
            Ogrenci ikinci = new Ogrenci();
            for (int i=0;i<oglistesi.Count;i++)
            {
                var liste = _ogrenciservice.Get(oglistesi[i]);
                if (oglistesi.Count == 1)
                {
                    ilk = _ogrenciservice.Get(oglistesi[0]);

                }
                if (oglistesi.Count == 2)
                {
                    ilk = _ogrenciservice.Get(oglistesi[0]);
                    ikinci = _ogrenciservice.Get(oglistesi[1]);

                }
                ogrenciler.Add(liste);
            }
            ViewBag.ilkeleman = ilk;
            ViewBag.ikinicieleman = ikinci;
            return View(ogrenciler);
        }
        public ActionResult beskisilik(string veril)
        {
            string[] parcalar;

            parcalar = veril.Split(',');
            List<int> oglistesi = new List<int>();

            foreach (var i in parcalar)
            {
                oglistesi.Add(Convert.ToInt32(i));

            }
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            Ogrenci ilk = new Ogrenci();
            Ogrenci ikinci = new Ogrenci();
            Ogrenci uc = new Ogrenci();
            Ogrenci dort = new Ogrenci();
            Ogrenci bes = new Ogrenci();
          
            for (int i = 0; i < oglistesi.Count ; i++)
            {
                
                var liste = _ogrenciservice.Get(oglistesi[i]);
                if (oglistesi.Count == 1)
                {
                    ilk = _ogrenciservice.Get(oglistesi[0]);

                }
                if (oglistesi.Count==2)
                {
                    ilk = _ogrenciservice.Get(oglistesi[0]);
                    ikinci = _ogrenciservice.Get(oglistesi[1]);

                }
                if(oglistesi.Count==3)
                {
                    ilk = _ogrenciservice.Get(oglistesi[0]);
                    ikinci = _ogrenciservice.Get(oglistesi[1]);
                    uc = _ogrenciservice.Get(oglistesi[2]);
                }
                if(oglistesi.Count==4)
                {
                    ilk = _ogrenciservice.Get(oglistesi[0]);
                    ikinci = _ogrenciservice.Get(oglistesi[1]);
                    uc = _ogrenciservice.Get(oglistesi[2]);
                    dort = _ogrenciservice.Get(oglistesi[3]);
                }
                if(oglistesi.Count==5)
                {
                    ilk = _ogrenciservice.Get(oglistesi[0]);
                    ikinci = _ogrenciservice.Get(oglistesi[1]);
                    uc = _ogrenciservice.Get(oglistesi[2]);
                    dort = _ogrenciservice.Get(oglistesi[3]);
                    bes = _ogrenciservice.Get(oglistesi[4]);

                }
              
                
                ogrenciler.Add(liste);
            }
            ViewBag.ilkeleman = ilk;
            ViewBag.ikinicieleman = ikinci;
            ViewBag.ucuncueleman = uc;
            ViewBag.dortduncueleman = dort;
            ViewBag.besincieleman = bes;  
            return View(ogrenciler);
        }
        public ActionResult dortkisibanyolu(string veril)
        {
            string[] parcalar;

            parcalar = veril.Split(',');



            List<int> oglistesi = new List<int>();

            foreach (var i in parcalar)
            {
                oglistesi.Add(Convert.ToInt32(i));

            }
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            Ogrenci ilk = new Ogrenci();
            Ogrenci ikinci = new Ogrenci();
            Ogrenci uc = new Ogrenci();
            Ogrenci dort = new Ogrenci();
            for (int i = 0; i < oglistesi.Count ; i++)
            {
                var liste = _ogrenciservice.Get(oglistesi[i]);
                if (oglistesi.Count == 1)
                {
                    ilk = _ogrenciservice.Get(oglistesi[0]);
                    

                }
                if (oglistesi.Count == 2)
                {
                    ilk = _ogrenciservice.Get(oglistesi[0]);
                    ikinci = _ogrenciservice.Get(oglistesi[1]);

                }
                if (oglistesi.Count == 3)
                {
                    ilk = _ogrenciservice.Get(oglistesi[0]);
                    ikinci = _ogrenciservice.Get(oglistesi[1]);
                    uc = _ogrenciservice.Get(oglistesi[2]);
                }
                if (oglistesi.Count == 4)
                {
                    ilk = _ogrenciservice.Get(oglistesi[0]);
                    ikinci = _ogrenciservice.Get(oglistesi[1]);
                    uc = _ogrenciservice.Get(oglistesi[2]);
                    dort = _ogrenciservice.Get(oglistesi[3]);
                }
              
                ogrenciler.Add(liste);
            }
            ViewBag.ilkeleman = ilk;
            ViewBag.ikinicieleman = ikinci;
            ViewBag.ucuncueleman = uc;
            ViewBag.dortduncueleman = dort;
            return View(ogrenciler);
        }
        public ActionResult dortkisibanyosuz(string veril)
        {
            string[] parcalar;

            parcalar = veril.Split(',');



            List<int> oglistesi = new List<int>();

            foreach (var i in parcalar)
            {
                oglistesi.Add(Convert.ToInt32(i));

            }
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            Ogrenci ilk = new Ogrenci();
            Ogrenci ikinci = new Ogrenci();
            Ogrenci uc = new Ogrenci();
            Ogrenci dort = new Ogrenci();
            for (int i = 0; i < oglistesi.Count; i++)
            {
                var liste = _ogrenciservice.Get(oglistesi[i]);
                if (oglistesi.Count == 1)
                {
                    ilk = _ogrenciservice.Get(oglistesi[0]);
                   

                }
                if (oglistesi.Count == 2)
                {
                    ilk = _ogrenciservice.Get(oglistesi[0]);
                    ikinci = _ogrenciservice.Get(oglistesi[1]);

                }
                if (oglistesi.Count == 3)
                {
                    ilk = _ogrenciservice.Get(oglistesi[0]);
                    ikinci = _ogrenciservice.Get(oglistesi[1]);
                    uc = _ogrenciservice.Get(oglistesi[2]);
                }
                if (oglistesi.Count == 4)
                {
                    ilk = _ogrenciservice.Get(oglistesi[0]);
                    ikinci = _ogrenciservice.Get(oglistesi[1]);
                    uc = _ogrenciservice.Get(oglistesi[2]);
                    dort = _ogrenciservice.Get(oglistesi[3]);
                }

                ogrenciler.Add(liste);
            }
            ViewBag.ilkeleman = ilk;
            ViewBag.ikinicieleman = ikinci;
            ViewBag.ucuncueleman = uc;
            ViewBag.dortduncueleman = dort;
            return View(ogrenciler);
        }
    }
}