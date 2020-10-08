using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace YurtYesilKaya.WebKatmani.Models
{
    public class OgrenciBilgileri
    {
        public int OgrenciId { get; set; }

        [StringLength(50)]
        public string OgrenciAdi { get; set; }

        [StringLength(50)]
        public string OgrenciSoyadi { get; set; }
        [StringLength(11)]
        public string OgrenciTckimlik { get; set; }

        [StringLength(50)]
        public string OdemeSekli { get; set; }
        [StringLength(250)]
        public string OgrenciResim { get; set; }

      
        [StringLength(50)]
        public string BarinmaTuru { get; set; }
        public decimal? ilanedilenyillikmiktar { get; set; }

        public decimal? Ogrencininkayitedildigimiktar { get; set; }
        [StringLength(150)]
        public string ogrencikayitedildigiyaziletutar { get; set; }
        [StringLength(150)]
        public string ilandabelirtilenYaziileTutar { get; set; }
        [StringLength(250)]
        public string OgrenciAdres { get; set; }

        [StringLength(100)]
        public string BabaAdi { get; set; }

        [StringLength(100)]
        public string Anneadi { get; set; }

        [StringLength(50)]
        public string OgrenciDogumyeri { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OgrenciDogumYili { get; set; }

        public DateTime? OgrenciKayittarihi { get; set; }

        [StringLength(70)]
        public string OkuduguOkul { get; set; }

        public DateTime? Yurttakalmayabasladigitarih { get; set; }

        public DateTime? YurtAyrildigiTarih { get; set; }

        [StringLength(150)]
        public string YaziileTutar { get; set; }

        public decimal? PesinatMiktari { get; set; }

        [StringLength(50)]
        public string NevresimGunu { get; set; }

        [StringLength(50)]
        public string OgrenimTuru { get; set; }

        public int? FaturaId { get; set; }

        public int? SenetId { get; set; }

        public int? KatBilgisi { get; set; }

        [StringLength(50)]
        public string BolumAdi { get; set; }
        [StringLength(50)]
        public string SinifAdi { get; set; }



        [StringLength(11)]
        public string CepTelefonu { get; set; }
        [StringLength(11)]
        public string AcildurumTelefon { get; set; }

        [StringLength(10)]
        public string Pesin { get; set; }

        public decimal? DepozitoMiktari { get; set; }


    }
}