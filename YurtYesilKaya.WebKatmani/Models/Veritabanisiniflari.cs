using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.WebKatmani.Models
{
    public class Veritabanisiniflari
    {
        public Ogrenci Ogrenci { get; set; }
        
        public HttpPostedFileBase Foto { get; set; }
        public TaksitOdeme TaksitOdeme { get; set; }
        public VeliBilgileri VeliBilgileri { get; set; }
        public OdaBilgileri OdaBilgileri { get; set; }
        public string ozeldurumnedeni { get; set; }
    }
}