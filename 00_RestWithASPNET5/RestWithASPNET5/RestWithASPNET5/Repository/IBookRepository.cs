using RestWithASPNET5.Models;
using System.Collections.Generic;

namespace RestWithASPNET5.Repository
{
    public interface IBookRepository
    {
        Book Create(Book Book);
        Book Update(Book Book);
        Book FindById(long id);
        void Delete(long id);
        List<Book> FindAll();
        bool Exists(long id);
    }
}
