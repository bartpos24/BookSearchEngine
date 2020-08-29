using BookSearchEngine.App.Abstract;
using BookSearchEngine.Domain.Common;
using BookSearchEngine.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSearchEngine.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Books { get; set; }

        public BaseService()
        {
            Books = new List<T>();
        }

        public int GetLastId()
        {
            int lastId;
            if(Books.Any())
            {
                lastId = Books.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        public void AddBook(T book)
        {
            Books.Add(book);
        }

        public List<T> GetAllBooks()
        {
            return Books;
        }

        public void RemoveBook(T book)
        {
            Books.Remove(book);
        }

        public int UpdateBook(T book)
        {
            var entity = Books.FirstOrDefault(predicate => predicate.Id == book.Id);
            if (entity != null)
            {
                entity = book;
            }
            return entity.Id;
        }
        
    }
}
