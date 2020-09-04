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
        private IBookService _bookService;
        public BookMenager(MenuServices menuService, IBookService bookService)
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
            var menu = _menuService.GetMenuByMenuName("Details");
            Console.WriteLine();
            foreach (var item in menu)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
            Console.WriteLine("\nPlease choose operation: ");
            var operation = Console.ReadKey();


            if (operation.KeyChar == '1')
            {
                int idToDetails;
                Console.WriteLine("\nPlease enter book id: ");
                idToDetails = Int32.Parse(Console.ReadLine());
                var bookDetails = _bookService.GetBookById(idToDetails);
                if (bookDetails == null)
                {
                    Console.WriteLine("\nBook with this id doesn't exists.\n");
                }
                else
                {
                    ShowDetailsView(bookDetails);
                }

            }
            else if (operation.KeyChar == '2')
            {
                Console.WriteLine("\nPlease enter book title: ");
                string titleToDetails = Console.ReadLine();
                var bookDetails = _bookService.GetBookByTitle(titleToDetails);
                if (bookDetails == null)
                {
                    Console.WriteLine("\nBook with this title doesn't exists.\n");
                }
                else
                {
                    ShowDetailsView(bookDetails);
                }
            }
            else
                Console.WriteLine("\nYou entered invalid operation.\n");

        }
        private void ShowDetailsView(Book bookDetails)
        {
            Console.WriteLine("\nYou chose book with following data: ");
            Console.WriteLine("\nId: " + bookDetails.Id);
            Console.WriteLine("Title: " + bookDetails.Title);
            Console.WriteLine("Author: " + bookDetails.Author);
            Console.WriteLine("Grade: " + bookDetails.Grade);
            Console.WriteLine("Description: " + bookDetails.Description + "\n");
        }
        public void UpdateBook()
        {
            var menu = _menuService.GetMenuByMenuName("Update");
            Console.WriteLine();
            foreach(var item in menu)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
            Console.WriteLine("\nPlease choose operation: ");
            var operation = Console.ReadKey();
            

            if (operation.KeyChar == '1')
            {
                Console.WriteLine("\nPlease enter book id: ");
                int idToUpdate = Int32.Parse(Console.ReadLine());
                var bookToReplece = _bookService.GetBookById(idToUpdate);
                if(bookToReplece == null)
                {
                    Console.WriteLine("\nBook with this id doesn't exists");
                }
                else
                {
                    UpdateBookView(bookToReplece);
                }

            }
            else if (operation.KeyChar == '2')
            {
                Console.WriteLine("\nPlease enter book title: ");
                string titleToUpdate = Console.ReadLine();
                var bookToReplece = _bookService.GetBookByTitle(titleToUpdate);
                if (bookToReplece == null)
                {
                    Console.WriteLine("\nBook with this title doesn't exists");
                }
                else
                {
                    UpdateBookView(bookToReplece);
                }
            }
            else
                Console.WriteLine("\nYou entered invalid operation.\n");
            
        }

        private void UpdateBookView(Book bookToReplace)
        {
            Console.WriteLine("Please update book.");

            Console.WriteLine("Old title: " + bookToReplace.Title);
            Console.Write("New Title: ");
            string newTitle = Console.ReadLine();
            bookToReplace.Title = newTitle;

            Console.WriteLine("Old Author: " + bookToReplace.Author);
            Console.Write("New Author: ");
            string newAuthor = Console.ReadLine();
            bookToReplace.Author = newAuthor;

            Console.WriteLine("Old Grade: " + bookToReplace.Grade);
            Console.Write("New Grade: ");
            string newGrade = Console.ReadLine();
            bookToReplace.Grade = newGrade;

            Console.WriteLine("Old Description: " + bookToReplace.Description);
            Console.Write("New Description: ");
            string newDescription = Console.ReadLine();
            bookToReplace.Description = newDescription;
            _bookService.UpdateBook(bookToReplace);
        }
    }
}
