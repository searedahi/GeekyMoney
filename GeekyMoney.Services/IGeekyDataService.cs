using System.Collections.Generic;

namespace GeekyMoney.Services
{
    public interface IGeekyDataService<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        T Create(T domainModel);
        T Update(T domainModel);
        bool Delete(int id);
        //T FromDb(object databaseAnalog);
    }
}
