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
    public class Kullanici : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AdiSoyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
        public string adres { get; set; }
        public string telefonno { get; set; }
        public string tckimlikno { get; set; }
        public int? ilId { get; set; }
        public il il { get; set; }
        public int? ilceId { get; set; }
        public ilceler ilceler { get; set; }
        public int? YetkiId { get; set; }
        public Yetki Yetki { get; set; }
    }
}
