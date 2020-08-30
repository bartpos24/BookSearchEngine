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
        public T GetBookById(int idBook)
        {
            var entity = Books.FirstOrDefault(predicate => predicate.Id == idBook);
            return entity;
        }

        public T RemoveBookById(int idBook)
        {
            var entity = Books.FirstOrDefault(p => p.Id == idBook);
            Books.Remove(entity);
            return entity;
        }
        /*public void RemoveBookByTitle(string titleBook)
        {
            var entity = Books.FirstOrDefault(p => p. == idBook);
            Books.Remove(entity);
        }*/

        public void UpdateBook(T book)
        {
            var entity = Books.FirstOrDefault(predicate => predicate.Id == book.Id);
            if (entity != null)
            {
                entity = book;
            }
        }
        
    }
}
