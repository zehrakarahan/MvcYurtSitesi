using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.WebKatmani.Models
{
    public class YoklamaModel
    {
        public Ogrenci Ogrenci { get; set; }
        public OdaBilgileri OdaBilgileri { get; set; }
        public List<string> geldigelmedi { get; set; }
        public List<string> ayingunleri { get; set; }
    }
}