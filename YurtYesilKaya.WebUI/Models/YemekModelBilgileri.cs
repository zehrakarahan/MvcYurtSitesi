using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.WebUI.Models
{
    public class YemekModelBilgileri
    {
        public Yemekler Yemeklersonveyailkintumbilgisi{ get; set; }
        public string yemekogunu { get; set; }
        public int gunbilgisi { get; set; }
        public int aybilgisi { get; set; }
        public int yilbilgisi { get; set; }
        public DateTime ilkmisonmutarih { get; set; }
        public string kisatarih { get; set; }
        public DateTime baslangictarihi { get; set; }

    }
}