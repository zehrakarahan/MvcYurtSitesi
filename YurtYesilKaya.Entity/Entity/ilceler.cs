﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Core.Entities;

namespace YurtYesilKaya.Entity.Entity
{
    public class ilceler : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ilceadi { get; set; }
        public int ilId { get; set; }
        public il iller { get; set; }
        public virtual IEnumerable<Kullanici> Kullanici { get; set; }
    }
}
