using RestWithASPNET5.Data.Converter.Implementations;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Hypermedia.Utils;
using RestWithASPNET5.Models;
using RestWithASPNET5.Repository;
using System.Collections.Generic;

namespace RestWithASPNET5.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        private readonly PersonConverter _converter;

        public PersonServiceImplementation(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            _converter = new PersonConverter();
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_personRepository.FindAll());
        }

        public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            var offset = page > 0 ? (page - 1) * pageSize : 0;
            var sort = !string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = pageSize < 1 ? 10 : pageSize;

            string query = @"select * from person p where 1 = 1";
            if (!string.IsNullOrWhiteSpace(name)) query += $" and p.first_name like '%{name}%'";
             query += $" order by p.first_name {sort} limit {size} offset {offset}";

            var countQuery = @"select count(*) from person p where 1 = 1";
            if (!string.IsNullOrWhiteSpace(name)) countQuery += $" and p.first_name like '%{name}%'";

            var persons = _personRepository.FindWithPagedSearch(query);

            int totalResults = _personRepository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO> {
                CurrentPage = page,
                List = _converter.Parse(persons),
                PageSize = size,
                SorteDirections = sort,
                TotalResults = totalResults
            };
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_personRepository.FindById(id));
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            return _converter.Parse(_personRepository.Create(personEntity));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            return _converter.Parse(_personRepository.Update(personEntity));
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }

        public List<PersonVO> FindByName(string firsName,string lasName)
        {
            return _converter.Parse(_personRepository.FindByName(firsName, lasName));
        }

        public PersonVO Disable(long id)
        {
            return _converter.Parse(_personRepository.Disable(id));
        }
    }
}
