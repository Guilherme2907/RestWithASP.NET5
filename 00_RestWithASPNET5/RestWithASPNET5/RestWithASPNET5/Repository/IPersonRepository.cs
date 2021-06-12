using RestWithASPNET5.Models;
using System.Collections.Generic;

namespace RestWithASPNET5.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
        List<Person> FindByName(string firstName,string lastName);
    }
}
