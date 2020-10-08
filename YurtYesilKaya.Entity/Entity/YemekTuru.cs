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
    public class YemekTuru : IEntity
    {
        //sabah kahvaltisimi aksam yemegimi
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string yemekturu { get; set; }
        public int? birgundeikitaneid{ get; set; }
        public int? yemeklerId { get; set; }
        public Yemekler Yemekler { get; set; }


    }
}
