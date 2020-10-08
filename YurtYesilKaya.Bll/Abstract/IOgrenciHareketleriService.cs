using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Abstract
{
    public interface IOgrenciHareketleriService
    {
        List<OgrenciHareket> GetAll();
        OgrenciHareket Get(int id);
        OgrenciHareket GetirOgrenciID(int ogrenciId);
        OgrenciHareket Update(OgrenciHareket entity);
        void Delete(OgrenciHareket entity);
        OgrenciHareket Add(OgrenciHareket entity);
    }
}
