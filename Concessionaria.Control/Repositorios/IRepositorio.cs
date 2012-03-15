using System.Collections.Generic;

namespace Concessionaria.Control.Repositorios
{
    public interface IRepositorio<T>
    {
        void SaveOrUpdateAndFlush(T entity);
        T GetOne(int id);
        IList<T> GetAll();
        void Delete(int id);
        void Delete(T entity);
    }
}
