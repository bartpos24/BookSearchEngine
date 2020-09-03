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

        void UpdateBook(T book);

        T RemoveBookById(int idBook);

        T GetBookById(int idBook);

        int GetLastId();
    }
}
