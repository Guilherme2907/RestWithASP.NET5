using RestWithASPNET5.Models;

namespace RestWithASPNET5.Repository
{
    public interface IPersonRepository
    {
        Person FindByName(string name);
    }
}
