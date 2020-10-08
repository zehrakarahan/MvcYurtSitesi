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
    public class Ogrenci : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ogrenciadisoyadi { get; set; }
        public string Ogrencitckimlikno { get; set; }
        public string OgrenciResmi { get; set; }
        public string OgrenciAdress { get; set; }
        public string banyovarmi { get; set; }
        public string DogumYeri { get; set; }
        public int dogumyili { get; set; }
        public DateTime? kayittarihi { get; set; }
        public string OkuduguOkul { get; set; }
        public DateTime? Yurttakalmayabasladigitarih { get; set; }
        public DateTime? YurtAyrildigiTarih { get; set; }
        public decimal? pesinatmiktari { get; set; }
        public string Ogrenimturu { get; set; }
        public string Katbilgisi { get; set; }
        public string Ceptelefonu { get; set; }
        public string AcilDurumCep { get; set; }
        public decimal? depozitomiktari { get; set; }
        public decimal? Ozeldurumindirimmiktari { get; set; }
        public string BabaAdi { get; set; }
        public string AnneAdi { get; set; }
        public decimal? ilanedilenyillikmiktar { get; set; }
        public string ilandabelirtilenYaziileTutar { get; set; }
        public decimal? Ogrencininkayitedildigimiktar { get; set; }
        public string ogrencikayitedildigiyaziletutar { get; set; }
        public string BarinmaTuru { get; set; }
        public string OdemeSekli { get; set; }
        public virtual IEnumerable<Arsiv> Arsiv { get; set; }
        public int? DevamsizlikId { get; set; }
        public DevamsizlikSayisi DevamsizlikSayisi { get; set; }
        public virtual IEnumerable<Fatura> Fatura { get; set; }
        public virtual IEnumerable<Senet> Senet { get; set; }
        public string Sinifadi { get; set; }
        public int? VeliBilgileriId { get; set; }
        public VeliBilgileri VeliBilgileri { get; set; }
        public int? TaksitOdemeId { get; set; }
        public TaksitOdeme TaksitOdeme { get; set; }
        public int? OdaBilgileriId { get; set; }
        public OdaBilgileri OdaBilgileri { get; set; }
        public int? OzelDurumId { get; set; }
        public OzelDurum OzelDurum { get; set; }
        public string bolumadi { get; set; }
        public virtual IEnumerable<OgrenciHareket> OgrenciHareket { get; set; }

    }
}
