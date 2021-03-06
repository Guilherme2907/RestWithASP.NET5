using RestWithASPNET5.Models;
using RestWithASPNET5.Models.Context;
using RestWithASPNET5.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Repository.Implementations
{
    public class PersonRepositoryImplementation : GenericRepository<Person>,IPersonRepository
    {
        public PersonRepositoryImplementation(MySqlContext context) : base(context) { }

        public Person Disable(long id)
        {
            if (!_context.Persons.Any(p => p.Id.Equals(id))) return null;

            var user = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if(user != null)
            {
                user.Enabled = false;

                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                } catch (Exception)
                {
                    throw;
                }
            }
            return user;
        }

        public List<Person> FindByName(string firstName,string lastName)
        {
            if(!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return dataset.Where(p => p.FirstName
                                        .Contains(firstName) &&
                                        p.LastName.Contains(lastName)).ToList();
            }
            else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return dataset.Where(p => p.LastName.Contains(lastName)).ToList();
            }
            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return dataset.Where(p => p.FirstName
                                        .Contains(firstName)).ToList();
            }

            return null;
        }
    }
}
