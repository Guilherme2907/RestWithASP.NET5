using RestWithASPNET5.Models;
using System;
using System.Collections.Generic;

namespace RestWithASPNET5.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        public T Create(T t)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(long id)
        {
            throw new NotImplementedException();
        }

        public List<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public T FindById(long id)
        {
            throw new NotImplementedException();
        }

        public T Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
