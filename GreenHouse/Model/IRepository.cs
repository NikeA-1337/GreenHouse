using System.Collections.Generic;

namespace Model
{
    public interface IRepository<T>
    {
        int Add(T obj);
        void Update(T obj);
        void Remove(int id);
        List<T> GetAll();
    }
}
