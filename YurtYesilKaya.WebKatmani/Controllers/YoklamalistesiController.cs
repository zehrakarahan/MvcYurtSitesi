using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurtYesilKaya.Bll.Abstract;
using YurtYesilKaya.WebKatmani.Models;
using System.Web.Mvc.Html;
using YurtYesilKaya.Entity.Entity;
using excel = Microsoft.Office.Interop.Excel;
using System.Net;
using System.Text;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
namespace YurtYesilKaya.WebKatmani.Controllers
{
    public class YoklamalistesiController : Controller
    {
        IOgrenciService _ogrenciservis;

        IVeliBilgilerService _velibilgilerservice;
        IOdaBilgileriService _odabilgileriservice;
        IDevamsizlikService _devamsizlikservice;
        public YoklamalistesiController(IOgrenciService ogrenciservis, IVeliBilgilerService velibilgileriservice, IOdaBilgileriService odabilgilerservice, IDevamsizlikService devamsizlikservice)
        {
            _ogrenciservis = ogrenciservis;

            _velibilgilerservice = velibilgileriservice;
            _odabilgileriservice = odabilgilerservice;
            _devamsizlikservice = devamsizlikservice;
        }
        [HttpPost]
        public ActionResult Index(DateTime tarih)
        {

            YoklamaModelView yoklamaviewmodel = new YoklamaModelView();
            DateTime ayinilkgunu = new DateTime(tarih.Year, tarih.Month, 1);
            DateTime aysonu = new DateTime(tarih.Year, tarih.Month + 1, 1).AddDays(-1);
            TempData["ilkgun"] = ayinilkgunu;
            TempData["songun"] = aysonu;
            var ogrenciliste = _ogrenciservis.GetAll();
            List<OdaBilgileri> odanolar = _odabilgileriservice.GetAll().OrderBy(x => x.OdaNo).ToList();
            var odan = _odabilgileriservice.GetAll();
            List<int> odanumarasi = new List<int>();
            List<int> elemanlar = new List<int>();

            int n = 0, sayac = 0, i = 0, j, k, l;
            foreach (OdaBilgileri item in odan)
            {
                elemanlar.Add(item.OdaNo);
            }
            for (j = 0; j < elemanlar.Count; j++)
            {
                for (k = 0; k < elemanlar.Count - 1; k++)
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
            for (int m = 0; m <= odanumarasi.Count; m++)
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
            TempData["odabilgisi"] = odanumarasi;
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
            var ogrenci = _ogrenciservis.GetAll();
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
        public ActionResult ExcelBelgesi()
        {
            var aybasi = TempData["ilkgun"];
            var aysonu = TempData["songun"];
            List<int> odanumara = new List<int>();
            List<int> modelData = TempData["odabilgisi"] as List<int>;
            TempData.Keep();

            DateTime ilkgun = DateTime.Parse(aybasi.ToString());
            DateTime songun = DateTime.Parse(aysonu.ToString());
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage ExcelPkg = new ExcelPackage();

            ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets.Add("Sheet1");
            var ogrenciler = _ogrenciservis.GetAll();
            List<int> liste = new List<int>();
            OgrenciViewModel modelbilgi = new OgrenciViewModel();

            var oda = _odabilgileriservice.GetAll();

            modelbilgi.OgrenciListesi = new List<OgrenciModel>();
            foreach (var ve in ogrenciler)
            {

                OgrenciModel oo = new OgrenciModel();

                oo.Ogrenci = ve;


                OdaBilgileri odabilgil = new OdaBilgileri();

                odabilgil = _odabilgileriservice.Get((int)ve.OdaBilgileriId);

                oo.OdaBilgisi = odabilgil;

                modelbilgi.OgrenciListesi.Add(oo);
            }
            int sutun = 1;
            int satir = 1;
            int sayac = 1;
            int sayac2 = 2;
            for (int i = 0; i < 2; i = i + 2)
            {
                ExcelRange basliklar = wsSheet1.Cells[satir, sutun + i];
                ExcelRange baslikla = wsSheet1.Cells[satir, sutun + 1];
                baslikla.Style.Border.Top.Style = ExcelBorderStyle.Thin;
              
                baslikla.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                baslikla.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                basliklar.Value = "";
                basliklar.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                basliklar.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                basliklar.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                basliklar.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                // excel.Range basliklar = (excel.Range)wsSheet1.Cells[satir, sutun + i];



            }
            for (DateTime j = ilkgun; j <= songun; j = j.AddDays(1))
            {
                wsSheet1.Column(sutun + sayac).Width = 3;
                sayac = sayac + 1;
                ExcelRange baslik = wsSheet1.Cells[satir, sutun + sayac];
                // excel.Range baslik = (excel.Range)wsSheet1.Cells[satir, sutun + sayac];

                baslik.Value = j.ToShortDateString();
                 
                baslik.Merge = true;
                baslik.Style.Font.Color.SetColor(Color.Black);
                baslik.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                baslik.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                baslik.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                baslik.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;


                baslik.Style.Font.Size = 10;
                wsSheet1.Column(sutun + sayac).Width = 3;
                wsSheet1.Cells[satir, sutun + sayac].Style.TextRotation = 180;
                
                wsSheet1.Row(satir).Height = 70;
                // baslik.Font.Color = ColorTranslator.ToOle(Color.Black);


            }

            sayac = 2;
            satir = satir + 1;
            foreach (int item in modelData)
            {

                for (int j = 0; j < 33; j++)
                {
                    ExcelRange bas = wsSheet1.Cells[satir, sutun + j];
                    // excel.Range bas = (excel.Range)wsSheet1.Cells[satir, sutun + j];
                    bas.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    bas.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    bas.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    bas.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    bas.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    bas.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                    // bas.Interior.Color = ColorTranslator.ToOle(Color.LightGray);

                }
                for (int i = 0; i < 34; i = i + 20)
                {
                    ExcelRange odanuma = wsSheet1.Cells[satir, sutun + i];
                    // excel.Range odanuma = (excel.Range)wsSheet1.Cells[satir, sutun + i];
                    odanuma.Value = "ODA NO :" + item;
                    odanuma.Style.Font.Color.SetColor(Color.Red);
                    odanuma.Style.Font.Size = 10;
                   

                }
                satir = satir + 1;
                foreach (var item2 in modelbilgi.OgrenciListesi)
                {
                    if (item2.OdaBilgisi.OdaNo == item)
                    {
                        for (int j = 0; j < 2; j = j + 3)
                        {
                            ExcelRange odanum = wsSheet1.Cells[satir, sutun + j];
                            ExcelRange odanumarasi = wsSheet1.Cells[satir, sutun+1];
                            odanumarasi.Style.Font.Color.SetColor(Color.Black);
                            odanumarasi.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            odanumarasi.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                            odanumarasi.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            odanumarasi.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                            // excel.Range odanum = (excel.Range)wsSheet1.Cells[satir, sutun + j];
                            odanum.Value = item2.Ogrenci.ogrenciadisoyadi;
                            odanum.Style.Font.Size = 10;
                            odanum.Style.Font.Color.SetColor(Color.Black);
                            odanum.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            odanum.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                            odanum.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            odanum.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;

                        }

                        for (DateTime j = ilkgun; j <= songun; j = j.AddDays(1))
                        {
                            sayac2 = sayac2 + 1;
                            ExcelRange baslik = wsSheet1.Cells[satir, sutun + sayac2];
                            ExcelRange baslik2 = wsSheet1.Cells[satir, sutun + sayac2-1];
                            baslik2.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            baslik2.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                            baslik2.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            baslik2.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                            // excel.Range baslik = (excel.Range)wsSheet1.Cells[satir, sutun + sayac2];
                            baslik.Value = "";
                            if (j < songun.AddDays(-1))
                            {
                                baslik.Style.Font.Color.SetColor(Color.Black);
                                baslik.Style.Font.Size = 10;
                                baslik.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                baslik.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                                baslik.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                baslik.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                                wsSheet1.Column(sutun + sayac).Width = 10;
                            }
                        }

                        sayac2 = 2;
                        satir++;
                    }

                }
            }
            wsSheet1.Protection.IsProtected = false;
            wsSheet1.Protection.AllowSelectLockedCells = false;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ExcelPkg.SaveAs(new FileInfo(path + "\\YoklamaListesi.xlsx"));
            TempData["yoklamalistesi"] = "Yoklama Listeniz Masaüstünde YoklamaListesi Adındaki Excel Dosyasıdır.";
            return RedirectToAction("Index", "Anasayfa");
        }
        public ActionResult YoklamaListesi()
        {
            DevamsizlikViewModel modelliste = new DevamsizlikViewModel();
            var ogrencibilgi = _ogrenciservis.GetAll();
            modelliste.DevamsizlikListesi = new List<DevamsizlikModel>();
            foreach (var item in ogrencibilgi)
            {
                DevamsizlikModel o = new DevamsizlikModel();
                o.Ogrenci = item;
                DevamsizlikSayisi devambil = new DevamsizlikSayisi();
                devambil = _devamsizlikservice.Get((int)item.DevamsizlikId);
                o.DevamsizlikSayisi = devambil;
                modelliste.DevamsizlikListesi.Add(o);
            }

            return View(modelliste);
        }
        [HttpPost]
        public ActionResult YoklamaKaydet(YoklamaModelView veriler)
        {
            var ogrenci = _ogrenciservis.GetAll();
            int geldi = 0;
            int gelmedi = 0;
           
            for (int i = 0; i < ogrenci.Count(); i++)
            {
               
                var id = veriler.YoklamaModel[i].Ogrenci.Id;
                var ogren = _ogrenciservis.Get(id);
                for (int k = 0; k < veriler.YoklamaModel[i].geldigelmedi.Count(); k++)
                {
                   

                    if (veriler.YoklamaModel[i].geldigelmedi[k] == "+")
                    {
                        geldi = geldi + 1;
                    }
                    if (veriler.YoklamaModel[i].geldigelmedi[k] == "-")
                    {
                        gelmedi = gelmedi + 1;
                    }
                }
                        if (veriler.YoklamaModel[i].Ogrenci.ogrenciadisoyadi == ogrenci[i].ogrenciadisoyadi)
                        {
                            if (ogrenci[i].DevamsizlikId == null)
                            {
                                _devamsizlikservice.Add(new DevamsizlikSayisi { Devamsizliksayi = gelmedi });
                                Ogrenci veri = new Ogrenci();
                                veri = ogren;
                                var soneleman = _devamsizlikservice.GetAll().Last();
                                veri.DevamsizlikId = soneleman.Id;
                                veri = ogren;
                                _ogrenciservis.Update(veri);
                            }
                            else
                            {
                                var devamgirilecek = _devamsizlikservice.Get((int)ogren.DevamsizlikId);
                                devamgirilecek.Devamsizliksayi = devamgirilecek.Devamsizliksayi + gelmedi;
                                _devamsizlikservice.Update(devamgirilecek);
                            }
                        }
                geldi = 0;
                gelmedi = 0;
              SmsGonder();

            }
            return RedirectToAction("YoklamaListesi");
        }
        public void SmsGonder()
        {

            var devamsizliksayisi = _devamsizlikservice.GetAll();
            var ogrencilistesi = _ogrenciservis.GetAll();
            var velilistesi = _velibilgilerservice.GetAll();
            List<DevamsizlikSayisi> devamsizligifazla = new List<DevamsizlikSayisi>();
            List<Ogrenci> devamsizogrenciler = new List<Ogrenci>();
            List<VeliBilgileri> velitelefonlar = new List<VeliBilgileri>();
            foreach (var item in devamsizliksayisi)
            {
                if (item.Devamsizliksayi > 7)
                {
                    devamsizligifazla.Add(item);
                }
            }
            for (int i = 0; i < devamsizligifazla.Count(); i++)
            {
                foreach (var item in ogrencilistesi)
                {
                    if (item.DevamsizlikId == devamsizligifazla[i].Id)
                    {
                        devamsizogrenciler.Add(item);
                    }
                }
            }
            for (int i = 0; i < devamsizogrenciler.Count(); i++)
            {
                foreach (var item in velilistesi)
                {
                    if (item.Id == devamsizogrenciler[i].VeliBilgileriId)
                    {
                        velitelefonlar.Add(item);
                    }
                }
            }
        }
      
    }

}