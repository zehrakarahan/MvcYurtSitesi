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
    public class Arsiv : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; }
    }
}
