using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YurtYesilKaya.Bll.Abstract;
using YurtYesilKaya.Bll.Concrete;
using YurtYesilKaya.Dal.Abstract;
using YurtYesilKaya.Dal.Concrete.EntityFramework.Repository;

namespace YurtYesilKaya.Bll.DepencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IArsivService>().To<ArsivManager>().InSingletonScope();
            Bind<IArsivDal>().To<ArsivDal>().InSingletonScope();
            Bind<ISifreDegisiklikService>().To<SifreDegisiklikManager>().InSingletonScope();
            Bind<ISifreDegisiklikDal>().To<SifreDegisiklikDal>().InSingletonScope();

            Bind<IYemekTuruService>().To<YemekTuruManager>().InSingletonScope();
            Bind<IYemekTuruDal>().To<YemekTuruDal>().InSingletonScope();

            Bind<IKullanicilarService>().To<KullanicilarManager>().InSingletonScope();
            Bind<IKullanicilarDal>().To<KullanicilarDal>().InSingletonScope();

            Bind<IMuracatFormuService>().To<MuracatFormuManager>().InSingletonScope();
            Bind<IMuracatFormuDal>().To<MuracatFormuDal>().InSingletonScope();


            Bind<IYemeklerService>().To<YemeklerManager>().InSingletonScope();
            Bind<IYemeklerDal>().To<YemeklerDal>().InSingletonScope();

            Bind<ITaksitOdemeTuruService>().To<TaksitOdemeTuruManager>().InSingletonScope();
            Bind<ITaksitOdemeTuruDal>().To<TaksitOdemeTuruDal>().InSingletonScope();


            

            Bind<IDevamsizlikService>().To<DevamsizlikManager>().InSingletonScope();
            Bind<IDevamsilikBilgisiDal>().To<DevamsizlikBilgisiDal>().InSingletonScope();

            Bind<IFaturaService>().To<FaturaManager>().InSingletonScope();
            Bind<IFaturaDal>().To<FaturaDal>().InSingletonScope();

            Bind<IilcelerService>().To<ilcelerManager>().InSingletonScope();
            Bind<IilcelerDal>().To<ilcelerDal>().InSingletonScope();

            Bind<IillerService>().To<illerManager>().InSingletonScope();
            Bind<IillerDal>().To<illerDal>().InSingletonScope();



            Bind<IOdaBilgileriService>().To<OdaBilgileriManager>().InSingletonScope();
            Bind<IOdaBilgileriDal>().To<OdaBilgileriDal>().InSingletonScope();

            Bind<IKurumBilgileriService>().To<KurumBilgileriManager>().InSingletonScope();
            Bind<IKurumBilgileriDal>().To<KurumBilgileriDal>().InSingletonScope();


            Bind<IOgrenciHareketleriService>().To<OgrenciHareketleriManager>().InSingletonScope();
            Bind<IOgrenciHareketleriDal>().To<OgrenciHareketleriDal>().InSingletonScope();

            Bind<IOgrenciService>().To<OgrenciManager>().InSingletonScope();
            Bind<IOgrenciDal>().To<OgrenciDal>().InSingletonScope();



            Bind<IOzelDurumIndirimService>().To<OzelDurumIndirimManager>().InSingletonScope();
            Bind<IOzelDurumIndirimDal>().To<OzelDurumIndirimListesiDal>().InSingletonScope();

            Bind<ISenetService>().To<SenetManager>().InSingletonScope();
            Bind<ISenetDal>().To<SenetDal>().InSingletonScope();

           




            Bind<IVeliBilgilerService>().To<VeliBilgilerManager>().InSingletonScope();
            Bind<IVeliBilgilerDal>().To<VeliBilgileriDal>().InSingletonScope();

            Bind<IYetkiService>().To<YetkiManager>().InSingletonScope();
            Bind<IYetkiDal>().To<YetkiDal>().InSingletonScope();

   


        }
    }
}
