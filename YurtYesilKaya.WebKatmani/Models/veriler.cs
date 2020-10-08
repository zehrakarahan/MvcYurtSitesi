using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YurtYesilKaya.Entity.Entity;
namespace YurtYesilKaya.WebKatmani.Models
{
    public class veriler
    {
        public string OgrenciAdiSoyadi { get; set; }  
    }
    public class DevamsizlikModel
    {
        public Ogrenci Ogrenci { get; set; }
        public DevamsizlikSayisi DevamsizlikSayisi { get; set; }
    }
    public class DevamsizlikViewModel
    {
        public List<DevamsizlikModel> DevamsizlikListesi { get; set; }
    }
}