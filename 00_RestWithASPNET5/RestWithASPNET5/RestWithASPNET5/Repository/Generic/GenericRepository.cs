using Microsoft.EntityFrameworkCore;
using RestWithASPNET5.Models;
using RestWithASPNET5.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected MySqlContext _context;

        protected DbSet<T> dataset;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }
        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(t => t.Id.Equals(id));
        }

        public T Create(T t)
        {
            try
            {
                dataset.Add(t);
                _context.SaveChanges();
                return t;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public T Update(T t)
        {
            if (!Exists(t.Id)) return null;

            var result = dataset.SingleOrDefault(o => o.Id.Equals(t.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(t);
                    _context.SaveChanges();

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(t => t.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return dataset.Any(t => t.Id.Equals(id));
        }

        public List<T> FindWithPagedSearch(string query)
        {
            return dataset.FromSqlRaw<T>(query).ToList();
        }

        public int GetCount(string query)
        {
            var result = "";
            using(var connection = _context.Database.GetDbConnection())
            {
                connection.Open();

                using(var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    result = command.ExecuteScalar().ToString();
                }
            }
            return int.Parse(result);
        }
    }
}
