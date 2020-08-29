using BookSearchEngine.App.Concrete;
using BookSearchEngine.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSearchEngine.App.Menagers
{
    public class BookMenager
    {
        private readonly MenuServices _menuService;
        private BookServices _bookService;
        public BookMenager(MenuServices menuService)
        {
            _bookService = new BookServices();
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

            var booksAfterSort = _bookService.SortBooks(operation.KeyChar, bookList);
            foreach(var book in booksAfterSort)
            {
                Console.WriteLine($"{book.Id}. {book.Title}     {book.Author}     {book.Grade}");
            }

        }
        public void RemoveBookView()
        {
            var menu = _menuService.GetMenuByMenuName("Remove");
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
                _bookService.RemoveBookById(idToRemove);
            }
            else if(operation.KeyChar == '2')
            {
                string titleToRemove;
                Console.WriteLine("\nPlease enter book title: ");
                titleToRemove = Console.ReadLine();
                _bookService.RemoveBookByTitle(titleToRemove);
            }
            else
            {
                Console.WriteLine("You entered invalid operation.");
                RemoveBookView();
            }
        }

        public void ShowDetails()
        {
            var menu = _menuService.GetMenuByMenuName("Details");
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
            }

        }
        /*public void UpdateBook()
        {
            Console.WriteLine("\nPlease enter book id: ");
            int idToUpdate = Int32.Parse(Console.ReadLine());
            Console.WriteLine();


        }*/
    }
}
