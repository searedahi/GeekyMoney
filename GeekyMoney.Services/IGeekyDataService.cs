using System.Collections.Generic;

namespace GeekyMoney.Services
{
    public interface IGeekyDataService<T>
    {
        T Get(string id);
        IEnumerable<T> GetAll();
        T Save(T domainModel);
        T Update(T domainModel);
        bool Delete(int id);
        //T FromDb(object databaseAnalog);
    }
}
