using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrentBas.DomainModels;


namespace TrentBas.ServiceContracts
{
    public interface IService<T>
    {
        List<T> GetT();
        List<T> SearchT(string tName);
        T GetTByTID(long tID);
        void InsertT(T t);
        void UpdateT(T t);
        void Delete(long tID);
    }
}
