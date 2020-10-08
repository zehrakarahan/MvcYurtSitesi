using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Dal.Mapping
{
    public class ArsivMap: EntityTypeConfiguration<Arsiv>
    {
        public ArsivMap()
        {
            this.HasKey(t => t.Id);
            this.ToTable("Arsiv");
            this.Property(t => t.Id).HasColumnName("ArsivId");
            
        }
        
    }
}
