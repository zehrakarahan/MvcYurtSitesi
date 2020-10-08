using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Core.Entities;

namespace YurtYesilKaya.Entity.Entity
{
    public class Yemekler : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? bugununtarihi { get; set; }
        public string sabahkahvaltisimiaksamyemegimi { get; set; }
        public string birinciyemekadi { get; set; }
        public string ikinciyemekadi { get; set; }
        public string ucuncuyemekadi { get; set; }
        public string dorduncuyemekadi { get; set; }
        public string besinciyemekadi { get; set; }
        public string altinciyemekadi { get; set; }
        public string yedinciyemekadi { get; set; }
        public virtual IEnumerable<YemekTuru> YemekTuru { get; set; }

    }
}
