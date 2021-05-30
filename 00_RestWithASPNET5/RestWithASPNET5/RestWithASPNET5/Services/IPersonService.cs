using RestWithASPNET5.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNET5.Services
{
    public interface IPersonService
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        PersonVO FindById(long id);
        void Delete(long id);
        List<PersonVO> FindAll();
        PersonVO FindByName(string name);
    }
}
