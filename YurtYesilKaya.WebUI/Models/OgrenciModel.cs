using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YurtYesilKaya.Entity.Entity;
namespace YurtYesilKaya.WebUI.Models
{
    
    public class OgrenciModel
    {
        public OdaBilgileri OdaBilgisi { get; set; }
        public Ogrenci Ogrenci { get; set; }
        public TaksitOdeme TaksitOdeme { get; set; }
        public VeliBilgileri VeliBilgileri { get; set; }
        public OgrenciHareket OgrenciHareket { get; set; }
    }
}