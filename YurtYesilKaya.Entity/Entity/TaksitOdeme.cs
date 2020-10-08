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
    public class TaksitOdeme : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string OdemeTuru { get; set; }
        public int? TaksitSayisi { get; set; }
        public DateTime? taksitodenecegitarihi { get; set; }
        public decimal? aylikodenecekmiktar { get; set; }
        public virtual IEnumerable<Fatura> Fatura { get; set; }
        public virtual IEnumerable<Senet> Senet { get; set; }
        public virtual IEnumerable<Ogrenci> Ogrenci { get; set; }
        public virtual IEnumerable<OgrenciHareket> OgrenciHareket { get; set; }
    }
}
