using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Hypermedia.Utils;
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
        List<PersonVO> FindByName(string firstName,string lastName);
        PersonVO Disable(long id);
        PagedSearchVO<PersonVO> FindWithPagedSearch(string name,string sortDirection,int pageSize,int page);
    }
}
