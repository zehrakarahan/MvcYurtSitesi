using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YurtYesilKaya.WebKatmani.Models
{
    public class YoklamaModelView
    {
        public List<OgrenciModel> OgrenciListesi { get; set; }
        public List<int> OdaNumaralari { get; set; }
        public List<YoklamaModel> YoklamaModel { get; set; }
        public List<DateTime> tarihler { get; set; }
    }

}