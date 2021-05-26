using RestWithASPNET5.Models;
using RestWithASPNET5.Repository;
using System.Collections.Generic;

namespace RestWithASPNET5.Services.Implementations
{
    public class BookServiceImplementation : IBookService
    {
        private readonly IBookRepository _repository;

        public BookServiceImplementation(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Create(Book Book)
        {
            return _repository.Create(Book);
        }

        public Book Update(Book Book)
        {
            return _repository.Update(Book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
