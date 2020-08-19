using BookSearchEngine.Services;
using System;

namespace BookSearchEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. dodawanie ksiazki
            //2. usuwanie ksiazki
            //3. lista ksiazek 
            //4. szczegoly ksiazki
            ////1.1 dodawanie ksiazki(id(autoincrement), tytul, autor, rodzaj, opis)
            ////2.1 usuwanie ksiazki po id
            ////2.2 usuwanie ksiazki po tytule
            ////3.1 lista wszystkich ksiazek sortowana po id
            ////3.2 lista wszystkich ksiazek sortowana po tytule
            ////3.3 lista wszystkich ksiazek sortowana po autorze
            ////3.4 lista wszystkich ksiazek sortowana po gatunku
            ////4.1 szczegoly ksiazki po wpisaniu albo id
            ////4.2 szczegoly ksiazki po wpisaniu albo tytulu

            MenuServices actionService = new MenuServices();
            actionService = Initialize(actionService);
            BookServices bookService = new BookServices();

            Console.WriteLine("\n ----- Welcome in my Book Search Engine ----- \n");

            var menu = actionService.GetMenuByMenuName("Main");

            while(true)
            {
                Console.WriteLine("");
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{menu[i].Id}. {menu[i].Name}");
                }
                Console.WriteLine("\nPlease enter number of action. \n");
                var operation = Console.ReadKey();

                switch (operation.KeyChar)
                {
                    case '1':
                        bookService.AddNewBook();
                        break;
                    case '2':
                        var keyInfo = bookService.RemoveBookView(actionService);
                        bookService.RemoveBook(keyInfo.KeyChar);
                        break;
                    case '3':
                        var listInfo = bookService.SortBooksView(actionService);
                        bookService.SortBooks(listInfo.KeyChar);
                        break;
                    case '4':
                        var detailsInfo = bookService.ShowBookDetailsView(actionService);
                        bookService.ShowBookDetails(detailsInfo.KeyChar);
                        break;
                    default:
                        Console.WriteLine("\nYou have entered incorrect operation!\n");
                        break;
                }

            }
            
        }

        private static MenuServices Initialize(MenuServices actionService)
        {
            actionService.AddNewAction(1, "Add book", "Main");
            actionService.AddNewAction(2, "Remove book", "Main");
            actionService.AddNewAction(3, "List of books", "Main");
            actionService.AddNewAction(4, "Show details", "Main");

            actionService.AddNewAction(1, "Remove by id", "Remove");
            actionService.AddNewAction(2, "Remove by title", "Remove");

            actionService.AddNewAction(1, "Sort books by id.", "AllBooks");
            actionService.AddNewAction(2, "Sort books by title.", "AllBooks");
            actionService.AddNewAction(3, "Sort books by author.", "AllBooks");
            actionService.AddNewAction(4, "Sort books by grade.", "AllBooks");

            actionService.AddNewAction(1, "Show details by id.", "Details");
            actionService.AddNewAction(2, "Show details by title.", "Details");

            return actionService;
        }
    }
}
