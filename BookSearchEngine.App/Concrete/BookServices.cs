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

        public List<Book> SortBooks(char operation, List<Book> books)
        {
            var sortsBook = books;
            if (operation == '1')
            {
                sortsBook = books.OrderBy(p => p.Id).ToList();
            }
            else if (operation == '2')
            {
                sortsBook = books.OrderBy(p => p.Title).ToList();
            }
            else if (operation == '3')
            {
                sortsBook = books.OrderBy(p => p.Author).ToList();
            }
            else if (operation == '4')
            {
                sortsBook = books.OrderBy(p => p.Grade).ToList();
            }
            else
            {
                Console.WriteLine("You entered invalid operation.");
            }
            return sortsBook;
        }
        public void RemoveBookById(int idToRemove)
        {
            var allBooks = GetAllBooks();
            foreach(var book in allBooks)
            {
                if(book.Id == idToRemove)
                {
                    Console.WriteLine("\nThe book with following data has been removed.\n");
                    Console.WriteLine("Id: " + book.Id);
                    Console.WriteLine("Title: " + book.Title);
                    Console.WriteLine("Author: " + book.Author);
                    Console.WriteLine("Grade: " + book.Grade);
                    Console.WriteLine("Description: " + book.Description);
                    RemoveBook(book);
                    for (int i = idToRemove; i <= Books.Count; i++)
                    {
                        Books[i - 1].Id = i;
                    }
                    break;
                }
            }
        }
        public void RemoveBookByTitle(string titleToRemove)
        {
            var allBooks = GetAllBooks();
            foreach (var book in allBooks)
            {
                if (book.Title == titleToRemove)
                {
                    Console.WriteLine("\nThe book with following data has been removed.\n");
                    Console.WriteLine("Id: " + book.Id);
                    Console.WriteLine("Title: " + book.Title);
                    Console.WriteLine("Author: " + book.Author);
                    Console.WriteLine("Grade: " + book.Grade);
                    Console.WriteLine("Description: " + book.Description);
                    int idToRemove = book.Id;
                    RemoveBook(book);
                    for (int i = idToRemove; i <= Books.Count; i++)
                    {
                        Books[i - 1].Id = i;
                    }
                    break;
                }
            }
        }
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
