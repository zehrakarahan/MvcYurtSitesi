using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YurtYesilKaya.Entity.Entity
{
    public class YesilKayaContext : DbContext
    {
       
        public YesilKayaContext()
            : base(@"Data Source=LAPTOP-AOAGCN36;Initial Catalog=YesilKayaErkekYurduBiligileri2020;Integrated Security=True")
        {
            Database.SetInitializer<YesilKayaContext>(new DropCreateDatabaseIfModelChanges<YesilKayaContext>());
        }
        public DbSet<Arsiv> Arsiv { get; set; }
        
        public DbSet<DevamsizlikSayisi> DevamsizlikSayisi { get; set; }
        public DbSet<Fatura> Fatura { get; set; }
        public DbSet<il> il { get; set; }
        public DbSet<ilceler> ilceler { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<KurumBilgileri> KurumBilgileri { get; set; }
        public DbSet<OdaBilgileri> OdaBilgileri { get; set; }
        public DbSet<Ogrenci> Ogrenci { get; set; }
        public DbSet<OgrenciHareket> OgrenciHareket { get; set; }
        public DbSet<OzelDurum> OzelDurum { get; set; }
        public DbSet<Senet> Senet { get; set; }
        public DbSet<SifreDegisiklik> SifreDegisiklik { get; set; }
        public DbSet<TaksitOdeme> TaksitOdeme { get; set; }
        public DbSet<VeliBilgileri> VeliBilgileri { get; set; }
        public DbSet<YemekTuru> YemekTuru { get; set; }
        public DbSet<Yemekler> Yemekler { get; set; }
        public DbSet<MuracatFormu> MuracatFormu { get; set; }
        public DbSet<Yetki> Yetki { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
