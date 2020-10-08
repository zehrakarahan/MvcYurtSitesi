using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.WebKatmani.Models
{
  
    public class YoklamaBilgileri
    {
        public OgrenciModel ogrencimodel { get; set; }
        public List<string> kisatarih { get; set; }
        public List<bool> Geldigigunler { get; set; }
  
  
      
    }
   
}