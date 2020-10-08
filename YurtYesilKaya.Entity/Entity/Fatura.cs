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
    public class Fatura : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; }
        public int? kdvorani { get; set; }
        public int? OgrenciHareketId { get; set; }
        public OgrenciHareket OgrenciHareket { get; set; }
        public DateTime islemtarihi { get; set; }
        public int? TaksitOdemeId { get; set; }
        public TaksitOdeme TaksitOdeme { get; set; }
        public int? VeliId { get; set; }
        public VeliBilgileri VeliBilgileri { get; set; }


    }
}
