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
    public class SifreDegisiklik: IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  Id{ get; set; }
        public string  guidimiz{ get; set; }
        public DateTime? songuncellemetarihi { get; set; }
        public bool Active { get; set; }
        public DateTime? gecerliliksuresi { get; set; }
        public DateTime? ilkkayittarihi { get; set; }
        public string KullaniciAdi { get; set; }

    }
}
