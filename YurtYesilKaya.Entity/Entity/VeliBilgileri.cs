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
    public class VeliBilgileri : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  Id { get; set; }
        public string VeliAdiSoyadi { get; set; }
        public string TckimlikNo { get; set; }
        public string SosyalGuvencesi { get; set; }
        public string telefonno { get; set; }
        public string mailadresi { get; set; }
        public string velimeslegi { get; set; }
        public virtual IEnumerable<Ogrenci> Ogrenci { get; set; }
        public virtual IEnumerable<Fatura> Fatura { get; set; }
        public virtual IEnumerable<Senet> Senet { get; set; }
    }
}
