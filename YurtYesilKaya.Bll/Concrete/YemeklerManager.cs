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
    public class YemeklerManager : IYemeklerService
    {
        private IYemeklerDal _YemeklerDal;
        public YemeklerManager(IYemeklerDal YemeklerDal)
        {
            _YemeklerDal = YemeklerDal;
        }


        public Yemekler Add(Yemekler entity)
        {
            return _YemeklerDal.Add(entity);
        }

        public void Delete(Yemekler entity)
        {
            _YemeklerDal.Delete(entity);
        }

        public Yemekler Get(int yemekid)
        {
           return  _YemeklerDal.Get(x=>x.Id==yemekid);
        }
       
        public List<Yemekler> GetAll()
        {
            return _YemeklerDal.GetAll();
        }

        public Yemekler Update(Yemekler entity)
        {
            throw new NotImplementedException();
        }
    }
}
