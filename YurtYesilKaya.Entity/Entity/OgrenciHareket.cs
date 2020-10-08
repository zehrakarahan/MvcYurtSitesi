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
    public class OgrenciHareket : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal odenenborc { get; set; }
        public decimal kalanborc { get; set; }
        public DateTime islemtarihi { get; set; }
        public int? TaksitOdemeId { get; set; }
        public TaksitOdeme TaksitOdeme { get; set; }
        public int? OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; }
        public virtual IEnumerable<Fatura> Fatura { get; set; }
        public virtual IEnumerable<Senet> Senet { get; set; }
       

    }
}
