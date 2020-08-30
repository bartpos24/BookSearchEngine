using BookSearchEngine.App.Common;
using BookSearchEngine.Domain;
using BookSearchEngine.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSearchEngine.App.Concrete
{
    public class BookServices : BaseService<Book>
    {
        public List<Book> AllBooks { get; set; }
        public BookServices()
        {
            AllBooks = new List<Book>();
        }
        
        /*public Book RemoveBookByTitle(string titleToRemove)
        {
            var entity = Books.FirstOrDefault(p => p.Title == titleToRemove);
            Books.Remove(entity);
            return entity;
        }*/
        public void ShowDetailsById(int idDetails)
        {
            var entity = Books.FirstOrDefault(predicate => predicate.Id == idDetails);
            if(entity != null)
            {
                Console.WriteLine("\nId: " + entity.Id);
                Console.WriteLine("Title: " + entity.Title);
                Console.WriteLine("Author: " + entity.Author);
                Console.WriteLine("Grade: " + entity.Grade);
                Console.WriteLine("Description: " + entity.Description);
            }
            else
            {
                Console.WriteLine("\nYou etered invalid id.");
            }
            
        }

        public void ShowDetailsByTitle(string titleDetails)
        {
            var entity = Books.FirstOrDefault(predicate => predicate.Title == titleDetails);
            if (entity != null)
            {
                Console.WriteLine("\nId: " + entity.Id);
                Console.WriteLine("Title: " + entity.Title);
                Console.WriteLine("Author: " + entity.Author);
                Console.WriteLine("Grade: " + entity.Grade);
                Console.WriteLine("Description: " + entity.Description);
            }
            else
            {
                Console.WriteLine("\nYou etered invalid title.");
            }

        }

    }
}
