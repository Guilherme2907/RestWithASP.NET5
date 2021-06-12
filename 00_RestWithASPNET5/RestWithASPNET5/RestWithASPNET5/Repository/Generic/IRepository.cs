using RestWithASPNET5.Models;
using System.Collections.Generic;

namespace RestWithASPNET5.Repository
{
    public interface IRepository<T> where T : BaseEntity
    { 
        T Create(T t);
        T Update(T t);
        T FindById(long id);
        void Delete(long id);
        List<T> FindAll();
        bool Exists(long id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
