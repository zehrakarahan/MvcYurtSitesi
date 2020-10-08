using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YurtYesilKaya.Entity.Entity;
namespace YurtYesilKaya.WebKatmani.Models
{
    public class KullaniciModel
    {
        public Kullanici Kullanici { get; set; }
        public string Yenisifre { get; set; }
        public string Şifretekrar { get; set; }

    }
}