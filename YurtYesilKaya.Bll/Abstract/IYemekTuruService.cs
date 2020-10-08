using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;


namespace YurtYesilKaya.Bll.Abstract
{
    public interface IYemekTuruService
    {
        List<YemekTuru> GetAll();
        YemekTuru Get(int yemekid);
        YemekTuru Getkarsilastir(int birgundeikitanedurumu);
        YemekTuru Update(YemekTuru entity);
        void Delete(YemekTuru entity);
        YemekTuru Add(YemekTuru entity);
    }
}
