using BookSearchEngine.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSearchEngine.App.Abstract
{
    interface IBookService : IService<Book>
    {
        Book RemoveBookByTitle(string titleBook);

        Book GetBookByTitle(string titleBook);
    }
}
