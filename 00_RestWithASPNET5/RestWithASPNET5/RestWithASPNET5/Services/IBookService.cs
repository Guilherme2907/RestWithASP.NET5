using RestWithASPNET5.Models;
using System.Collections.Generic;

namespace RestWithASPNET5.Services
{
    public interface IBookService
    {
        Book Create(Book Book);
        Book Update(Book Book);
        Book FindById(long id);
        void Delete(long id);
        List<Book> FindAll();
    }
}
