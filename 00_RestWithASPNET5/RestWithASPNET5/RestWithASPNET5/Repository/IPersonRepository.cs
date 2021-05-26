using RestWithASPNET5.Models;
using System.Collections.Generic;

namespace RestWithASPNET5.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person Update(Person person);
        Person FindById(long id);
        void Delete(long id);
        List<Person> FindAll();
        bool Exists(long id);
    }
}
