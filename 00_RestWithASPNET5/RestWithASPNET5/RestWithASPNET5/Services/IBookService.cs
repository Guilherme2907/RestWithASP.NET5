using RestWithASPNET5.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNET5.Services
{
    public interface IBookService
    {
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        BookVO FindById(long id);
        void Delete(long id);
        List<BookVO> FindAll();
    }
}
