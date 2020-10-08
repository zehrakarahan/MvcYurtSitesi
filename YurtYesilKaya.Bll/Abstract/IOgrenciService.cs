using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Abstract
{
    public interface IOgrenciService
    {
        List<Ogrenci> GetAll();
        Ogrenci Get(int OgrenciId);
        Ogrenci Getadsoyad(string adsoyad);
        List<Ogrenci> Getkisiler(int odaid);
        Ogrenci Update(Ogrenci entity);
        void Delete(Ogrenci entity);
        Ogrenci Add(Ogrenci entity);
    }
}
