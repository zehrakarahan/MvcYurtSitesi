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
    public class Yetki : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string yetkiadi { get; set; }
        public virtual IEnumerable<Kullanici> Kullanici { get; set; }
    }
}
