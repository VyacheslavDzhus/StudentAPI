using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
