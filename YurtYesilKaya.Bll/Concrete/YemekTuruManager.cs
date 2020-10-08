
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Bll.Abstract;
using YurtYesilKaya.Dal.Abstract;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Concrete
{
    public class YemekTuruManager : IYemekTuruService
    {
        private IYemekTuruDal _YemekTuruDal;
        public YemekTuruManager(IYemekTuruDal YemekTuruDal)
        {
            _YemekTuruDal = YemekTuruDal;
        }

       
        public void Delete(YemekTuru entity)
        {
            _YemekTuruDal.Delete(entity);
        }

        public YemekTuru Get(int yemekid)
        {
            return _YemekTuruDal.Get(x => x.Id == yemekid);
        }

        public List<YemekTuru> GetAll()
        {
            return _YemekTuruDal.GetAll();
        }

        public YemekTuru Getkarsilastir(int birgundeikitanedurumu)
        {
            return _YemekTuruDal.Get(x => x.birgundeikitaneid == birgundeikitanedurumu);
        }

        YemekTuru IYemekTuruService.Add(YemekTuru entity)
        {
           return _YemekTuruDal.Add(entity);
        }

      

        YemekTuru IYemekTuruService.Update(YemekTuru entity)
        {
            return _YemekTuruDal.Update(entity);
        }
    }
}
