using BookSearchEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSearchEngine.Services
{
    public class BookServices
    {
        public List<Book> AllBooks { get; set; }
        public BookServices()
        {
            AllBooks = new List<Book>();
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
            int listSize = AllBooks.Count + 1;
            
            Book newBook = new Book();
            newBook.Id = listSize;
            newBook.Title = bookTitle;
            newBook.Author = bookAuthor;
            newBook.Grade = bookGrade;
            newBook.Description = bookDescribtion;

            AllBooks.Add(newBook);

        }

        public void GetAllBooks()
        {
            Console.WriteLine();
            foreach(var book in AllBooks)
            {
                Console.WriteLine($"{book.Id}. {book.Title}     {book.Author}     {book.Grade}");
            }

        }

        public ConsoleKeyInfo RemoveBookView(MenuServices menuService)
        {
            var removeMenu = menuService.GetMenuByMenuName("Remove");
            Console.WriteLine();
            for(int i = 0; i< removeMenu.Count; i++)
            {
                Console.WriteLine($"{removeMenu[i].Id}. {removeMenu[i].Name}");
            }
            var operationRemove = Console.ReadKey();
            return operationRemove;
        }
        public void RemoveBook(char operation)
        {
            if(operation == '1')
            {
                Console.WriteLine("\nPlease enter id to remove book.\n");
                Console.Write("Id: ");
                int idToRemove = Int32.Parse(Console.ReadLine());
                //Book bookToBring = new Book();
                foreach(var bookToRemove in AllBooks)
                {
                    if(bookToRemove.Id == idToRemove)
                    {
                        Console.WriteLine("\nThe book with following data has been removed.\n");
                        Console.WriteLine("Id: " + bookToRemove.Id);
                        Console.WriteLine("Title: " + bookToRemove.Title);
                        Console.WriteLine("Author: " + bookToRemove.Author);
                        Console.WriteLine("Grade: " + bookToRemove.Grade);
                        Console.WriteLine("Description: " + bookToRemove.Description);
                        AllBooks.Remove(bookToRemove);
                        for(int i = idToRemove; i <= AllBooks.Count; i++)
                        {
                            AllBooks[i-1].Id = i;
                        }
                        break;
                    }
                }
            }
            else if(operation == '2')
            {
                Console.WriteLine("\nPlease enter title to remove book.");
                Console.Write("Title: ");
                string titleToRemove = Console.ReadLine();
                foreach(var bookToRemove in AllBooks)
                {
                    if(bookToRemove.Title == titleToRemove)
                    {
                        int idBook = bookToRemove.Id;
                        Console.WriteLine("\nThe book with following data has been removed.\n");
                        Console.WriteLine("Id: " + bookToRemove.Id);
                        Console.WriteLine("\nTitle: " + bookToRemove.Title);
                        Console.WriteLine("\nAuthor: " + bookToRemove.Author);
                        Console.WriteLine("\nGrade: " + bookToRemove.Grade);
                        Console.WriteLine("\nDescription: " + bookToRemove.Description);
                        AllBooks.Remove(bookToRemove);
                        for(int i = idBook; i <= AllBooks.Count; i++)
                        {
                            AllBooks[i-1].Id = i;
                        }
                        break;
                    }
                }

            }
            else
            {
                Console.WriteLine("\nYou have entered incorrect operation.");
            }

        }
        public ConsoleKeyInfo ShowBookDetailsView(MenuServices menuServices)
        {
            var menuDetails = menuServices.GetMenuByMenuName("Details");
            Console.WriteLine("\nPlease enter operation.");
            foreach(var i in menuDetails)
            {
                Console.WriteLine(i.Id + " " + i.Name);
            }
            var operation = Console.ReadKey();
            return operation;

        }

        public void ShowBookDetails(char operation)
        {
            if(operation == '1')
            {
                Console.WriteLine("\nPlease enter id to show book details.\n");
                Console.Write("Id: ");
                int idToDetails = Int32.Parse(Console.ReadLine());

                foreach(var bookDetails in AllBooks)
                {
                    if(bookDetails.Id == idToDetails)
                    {
                        Console.WriteLine("\nBook details:\n");
                        Console.WriteLine($"Id: {bookDetails.Id}.");
                        Console.WriteLine("Title: " + bookDetails.Title);
                        Console.WriteLine("Author: " + bookDetails.Author);
                        Console.WriteLine("Grade: " + bookDetails.Grade);
                        Console.WriteLine("Describtion: " + bookDetails.Description);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nYou have entered incorrect data.");
                    }
                }

            }
            else if(operation == '2')
            {
                Console.WriteLine("\nPlease enter title to show book details.");
                Console.Write("Title: ");
                string titleToDetails = Console.ReadLine();
                
                foreach(var bookDetails in AllBooks)
                {
                    if(bookDetails.Title == titleToDetails)
                    {
                        Console.WriteLine("\nBook details:\n");
                        Console.WriteLine($"Id: {bookDetails.Id}.");
                        Console.WriteLine("Title: " + bookDetails.Title);
                        Console.WriteLine("Author: " + bookDetails.Author);
                        Console.WriteLine("Grade: " + bookDetails.Grade);
                        Console.WriteLine("Describtion: " + bookDetails.Description);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nYou have entered incorrect data.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nYou have entered incorrect data.");
            }

        }

        public ConsoleKeyInfo SortBooksView(MenuServices menuServices)
        {
            var listOperation = menuServices.GetMenuByMenuName("AllBooks");
            Console.WriteLine("\nPlease enter number of sort method.\n");
            foreach (var book in listOperation)
            {
                Console.WriteLine($"{book.Id}. {book.Name}");
            }
            
            var operation = Console.ReadKey();
            Console.WriteLine();
            return operation;
        } 

        public void SortBooks(char operation)
        {
            if(operation == '1')
            {
                GetAllBooks();
            }
            else if (operation == '2')
            {
                var titleSortList = AllBooks.OrderBy(t => t.Title).ToList();
                SortBookDisplay(titleSortList);
            }
            else if(operation == '3')
            {
                var authorSortList = AllBooks.OrderBy(a => a.Author).ToList();
                SortBookDisplay(authorSortList);
            }
            else if(operation == '4')
            {
                var gradeSortList = AllBooks.OrderBy(g => g.Grade).ToList();
                SortBookDisplay(gradeSortList);
            }
            else
                Console.WriteLine("\nYou have entered incorrect operation.");
        }

        public void SortBookDisplay(List<Book> list)
        {
            foreach(var book in list)
            {
                Console.WriteLine($"{book.Id}. {book.Title}     {book.Author}     {book.Grade}");
            }
        }
    }
}
