using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftFX_Task.EntityFramework.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        T Get(int id);
        T Get(Func<T, bool> where);
        ICollection<T> GetList();
        ICollection<T> GetList(Func<T, bool> where);
        void Add(T model);
        void AddList(ICollection<T> models);
        void Update(T model);
        void Update(ICollection<T> models);
        void Delete(int id);
        void Delete(ICollection<int> ids);
        void Delete(T model);
        void Delete(ICollection<T> models);
        void Save();
    }
}
