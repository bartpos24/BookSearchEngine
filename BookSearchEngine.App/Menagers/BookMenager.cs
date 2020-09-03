using BookSearchEngine.App.Abstract;
using BookSearchEngine.App.Concrete;
using BookSearchEngine.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSearchEngine.App.Menagers
{
    public class BookMenager
    {
        private readonly MenuServices _menuService;
        private IService<Book> _bookService;
        public BookMenager(MenuServices menuService, IService<Book> bookService)
        {
            _bookService = bookService;
            _menuService = menuService;
        }
        public void AddNewBook()
        {
            Console.WriteLine("\nPlease enter title, author, grade and describtion.\n");
            Console.Write("Title: ");
            string bookTitle = Console.ReadLine();
            Console.Write("Author: ");
            string bookAuthor = Console.ReadLine();
            Console.Write("Grade: ");
            string bookGrade = Console.ReadLine();
            Console.Write("Description: ");
            string bookDescribtion = Console.ReadLine();

            var lastId = _bookService.GetLastId();

            Book newBook = new Book(lastId+1, bookTitle, bookAuthor, bookGrade, bookDescribtion);
            _bookService.AddBook(newBook);
            

        }

        public void ShowBookList()
        {
            var showListMenu = _menuService.GetMenuByMenuName("AllBooks");
            Console.WriteLine("\nPlease choose sort method.\n");
            foreach(var menu in showListMenu)
            {
                Console.WriteLine($"{menu.Id}. {menu.Name}");
            }
            
            var operation = Console.ReadKey();

            Console.WriteLine();

            var bookList = _bookService.GetAllBooks();
            
            if (operation.KeyChar == '1')
            {
                bookList = bookList.OrderBy(p => p.Id).ToList();
                foreach (var book in bookList)
                {
                    Console.WriteLine($"{book.Id}. {book.Title}     {book.Author}     {book.Grade}");
                }
            }
            else if (operation.KeyChar == '2')
            {
                bookList = bookList.OrderBy(p => p.Title).ToList();
                foreach (var book in bookList)
                {
                    Console.WriteLine($"{book.Id}. {book.Title}     {book.Author}     {book.Grade}");
                }
            }
            else if (operation.KeyChar == '3')
            {
                bookList = bookList.OrderBy(p => p.Author).ToList();
                foreach (var book in bookList)
                {
                    Console.WriteLine($"{book.Id}. {book.Title}     {book.Author}     {book.Grade}");
                }
            }
            else if (operation.KeyChar == '4')
            {
                bookList = bookList.OrderBy(p => p.Grade).ToList();
                foreach (var book in bookList)
                {
                    Console.WriteLine($"{book.Id}. {book.Title}     {book.Author}     {book.Grade}");
                }
            }
            else
            {
                Console.WriteLine("You entered invalid operation.");
            }
            

        }
        public void RemoveBookView()
        {
            int idToRemove;
            Console.WriteLine("\nPlease enter book id: ");
            idToRemove = Int32.Parse(Console.ReadLine());
            var bookRemoved = _bookService.RemoveBookById(idToRemove);
            if (bookRemoved != null)
            {
                Console.WriteLine("\nBook with this data has been removed: ");
                Console.WriteLine("\nId: " + bookRemoved.Id);
                Console.WriteLine("Title: " + bookRemoved.Title);
                Console.WriteLine("Author: " + bookRemoved.Author);
                Console.WriteLine("Grade: " + bookRemoved.Grade);
                Console.WriteLine("Description: " + bookRemoved.Description);
            }
            else
                Console.WriteLine("You enter invalid id.");
            /*var menu = _menuService.GetMenuByMenuName("Remove");
            Console.WriteLine("\nPlease choose operation. \n");
            foreach(var menuItem in menu)
            {
                Console.WriteLine($"{menuItem.Id}. {menuItem.Name}");
            }
            var operation = Console.ReadKey();
            Console.WriteLine();
            
            if(operation.KeyChar == '1')
            {
                int idToRemove;
                Console.WriteLine("\nPlease enter book id: ");
                idToRemove = Int32.Parse(Console.ReadLine());
                var bookRemoved = _bookService.RemoveBookById(idToRemove);
                if (bookRemoved != null)
                {
                    Console.WriteLine("\nBook with this data has been removed: ");
                    Console.WriteLine("\nId: " + bookRemoved.Id);
                    Console.WriteLine("Title: " + bookRemoved.Title);
                    Console.WriteLine("Author: " + bookRemoved.Author);
                    Console.WriteLine("Grade: " + bookRemoved.Grade);
                    Console.WriteLine("Description: " + bookRemoved.Description);
                }
                else
                    Console.WriteLine("You enter invalid id.");
            }
            else if(operation.KeyChar == '2')
            {
                string titleToRemove;
                Console.WriteLine("\nPlease enter book title: ");
                titleToRemove = Console.ReadLine();
                var bookRemoved = _bookService.RemoveBookByTitle(titleToRemove);
                if (bookRemoved != null)
                {
                    Console.WriteLine("\nBook with this data has been removed: ");
                    Console.WriteLine("\nId: " + bookRemoved.Id);
                    Console.WriteLine("Title: " + bookRemoved.Title);
                    Console.WriteLine("Author: " + bookRemoved.Author);
                    Console.WriteLine("Grade: " + bookRemoved.Grade);
                    Console.WriteLine("Description: " + bookRemoved.Description);
                }
                else
                    Console.WriteLine("You enter invalid title.");
            }
            else
            {
                Console.WriteLine("You entered invalid operation.");
                RemoveBookView();
            }*/
        }

        public void ShowDetails()
        {
            int idToDetails;
            Console.WriteLine("\nPlease enter book id: ");
            idToDetails = Int32.Parse(Console.ReadLine());
            var bookDetails = _bookService.GetBookById(idToDetails);
            if(bookDetails == null)
            {
                Console.WriteLine("\nDoesn't have book with this id.\n");
            }
            else
            {
                Console.WriteLine("\nYou chose book with following data: ");
                Console.WriteLine("\nId: " + bookDetails.Id);
                Console.WriteLine("Title: " + bookDetails.Title);
                Console.WriteLine("Author: " + bookDetails.Author);
                Console.WriteLine("Grade: " + bookDetails.Grade);
                Console.WriteLine("Description: " + bookDetails.Description);
            }
            

            /*var menu = _menuService.GetMenuByMenuName("Details");
            Console.WriteLine("\nPlease choose operation. \n");
            foreach (var menuItem in menu)
            {
                Console.WriteLine($"{menuItem.Id}. {menuItem.Name}");
            }
            var operation = Console.ReadKey();
            Console.WriteLine();
            if(operation.KeyChar == '1')
            {
                int idToDetails;
                Console.WriteLine("\nPlease enter book id: ");
                idToDetails = Int32.Parse(Console.ReadLine());
                _bookService.ShowDetailsById(idToDetails);
            }
            else if (operation.KeyChar == '2')
            {
                string titleToDetails;
                Console.WriteLine("\nPlease enter book title: ");
                titleToDetails = Console.ReadLine();
                _bookService.ShowDetailsByTitle(titleToDetails);
            }
            else
            {
                Console.WriteLine("You entered invalid operation.");
                ShowDetails();
            }*/

        }
        public void UpdateBook()
        {
            Console.WriteLine("\nPlease enter book id: ");
            int idToUpdate = Int32.Parse(Console.ReadLine());
            var bookToReplece = _bookService.GetBookById(idToUpdate);
            Console.WriteLine("Please update book.");

            Console.WriteLine("Old title: " + bookToReplece.Title);
            Console.Write("New Title: ");
            string newTitle = Console.ReadLine();
            bookToReplece.Title = newTitle;

            Console.WriteLine("Old Author: " + bookToReplece.Author);
            Console.Write("New Author: ");
            string newAuthor = Console.ReadLine();
            bookToReplece.Author = newAuthor;

            Console.WriteLine("Old Grade: " + bookToReplece.Grade);
            Console.Write("New Grade: ");
            string newGrade = Console.ReadLine();
            bookToReplece.Grade = newGrade;

            Console.WriteLine("Old Description: " + bookToReplece.Description);
            Console.Write("New Description: ");
            string newDescription = Console.ReadLine();
            bookToReplece.Description = newDescription;

            _bookService.UpdateBook(bookToReplece);


        }
    }
}
