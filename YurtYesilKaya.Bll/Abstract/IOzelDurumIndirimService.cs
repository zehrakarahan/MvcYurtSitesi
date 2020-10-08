using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.Abstract
{
    public interface IOzelDurumIndirimService
    {
        List<OzelDurum> GetAll();
        OzelDurum Get(int id);
        OzelDurum GetString(string ozeldurum);
        List<OzelDurum> GetOzelDurumİndirimListesiByOzelDurumName(string OzelDurumName);
        OzelDurum Update(OzelDurum entity);
        void Delete(OzelDurum entity);
        OzelDurum Add(OzelDurum entity);
    }
}
