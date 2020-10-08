using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.WebUI.Models
{
    public class Veritabanisiniflari
    {
        public Ogrenci Ogrenci { get; set; }
        
        public HttpPostedFileBase Foto { get; set; }
        public TaksitOdeme TaksitOdeme { get; set; }
        public VeliBilgileri VeliBilgileri { get; set; }
        public OdaBilgileri OdaBilgileri { get; set; }
    }
}