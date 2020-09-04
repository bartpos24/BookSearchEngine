using BookSearchEngine.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSearchEngine.App.Abstract
{
    public interface IBookService 
    {
        List<Book> Books { get; set; }

        List<Book> GetAllBooks();

        void AddBook(Book book);

        void UpdateBook(Book book);
        //void UpdateBookByTitle(Book book);

        Book RemoveBookById(int idBook);

        Book GetBookById(int idBook);

        int GetLastId();
        Book RemoveBookByTitle(string titleBook);

        Book GetBookByTitle(string titleBook);
    }
}
