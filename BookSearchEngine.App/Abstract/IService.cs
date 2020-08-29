using System;
using System.Collections.Generic;
using System.Text;

namespace BookSearchEngine.App.Abstract
{
    public interface IService<T>
    {
        List<T> Books { get; set; }

        List<T> GetAllBooks();

        void AddBook(T book);

        int UpdateBook(T book);

        void RemoveBook(T book);
    }
}
