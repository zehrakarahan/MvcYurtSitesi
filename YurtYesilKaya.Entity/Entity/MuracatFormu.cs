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
    public class MuracatFormu: IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string birincialan { get; set; }

        public string ikincialan { get; set; }

        public string ucuncualan { get; set; }

        public string ikikisilik { get; set; }

        public string dortkisilik { get; set; }

        public string dortkisibanyosuz { get; set; }

        public string beskisilik { get; set; }
    }
}
