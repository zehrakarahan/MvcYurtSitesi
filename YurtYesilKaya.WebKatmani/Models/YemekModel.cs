using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.WebKatmani.Models
{
    public class YemekModel
    {
        public DateTime Tarih { get; set; }
        public YemekTuru YemekTuru { get; set; }
    }
}