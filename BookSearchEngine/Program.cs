using BookSearchEngine.App.Abstract;
using BookSearchEngine.App.Concrete;
using BookSearchEngine.App.Menagers;
using BookSearchEngine.Domain.Entity;
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
            BookMenager bookMenager = new BookMenager(actionService);


            Console.WriteLine("\n ----- Welcome in my Book Search Engine ----- \n");

            var menu = actionService.GetMenuByMenuName("Main");

            while (true)
            {
                Console.WriteLine("");
                foreach(var menuItem in menu)
                {
                    Console.WriteLine($"{menuItem.Id}. {menuItem.Name}");
                }
                
                Console.WriteLine("\nPlease enter number of action. \n");
                var operation = Console.ReadKey();

                switch (operation.KeyChar)
                {
                    case '1':
                        bookMenager.AddNewBook();
                        break;
                    case '2':
                        bookMenager.RemoveBookView();
                        break;
                    case '3':
                        bookMenager.ShowBookList();
                        break;
                    case '4':
                        bookMenager.ShowDetails();
                        break;
                    /*case '5':
                        bookMenager.UpdateBook();
                        break;*/
                    default:
                        Console.WriteLine("\nYou have entered incorrect operation!\n");
                        break;
                }

            }

        }
    }
}
