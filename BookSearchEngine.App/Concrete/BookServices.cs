using BookSearchEngine.App.Abstract;
using BookSearchEngine.Domain;
using BookSearchEngine.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSearchEngine.App.Concrete
{
    public class BookServices : IBookService
    {
        public List<Book> Books { get; set; }

        public BookServices()
        {
            Books = new List<Book>();
        }

        public List<Book> GetAllBooks()
        {
            return Books;
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var entity = Books.FirstOrDefault(predicate => (predicate.Id == book.Id) || (predicate.Title == book.Title));
            if (entity != null)
            {
                entity = book;
            }
        }

        public Book RemoveBookById(int idBook)
        {
            var entity = Books.FirstOrDefault(p => p.Id == idBook);
            Books.Remove(entity);
            return entity;
        }
        public Book RemoveBookByTitle(string titleBook)
        {
            var entity = Books.FirstOrDefault(p => p.Title == titleBook);
            Books.Remove(entity);
            return entity;
        }

        public Book GetBookById(int idBook)
        {
            var entity = Books.FirstOrDefault(predicate => predicate.Id == idBook);
            return entity;
        }

        public int GetLastId()
        {
            int lastId;
            if (Books.Any())
            {
                lastId = Books.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        

        public Book GetBookByTitle(string titleBook)
        {
            var entity = Books.FirstOrDefault(predicate => predicate.Title == titleBook);
            return entity;
        }
    }
}
