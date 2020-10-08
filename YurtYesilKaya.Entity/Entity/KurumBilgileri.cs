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
    public class KurumBilgileri : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string KurumCode { get; set; }
        public string KurumAdi { get; set; }
        public string kurucuadi { get; set; }
        public string KurucuTemsilciAdi { get; set; }
        public string MudurAdi { get; set; }
        public string KurumAdresi { get; set; }
        public string KurumTelefon { get; set; }
        public DateTime? kayittarihi { get; set; }
   
    }
}
