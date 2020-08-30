using BookSearchEngine.App.Common;
using BookSearchEngine.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace BookSearchEngine.App.Concrete
{
    public class MenuServices : BaseService<Menu>
    {
        //private List<Menu> menuActions = new List<Menu>();

        public MenuServices()
        {
            Initialize();
        }
        public List<Menu> GetMenuByMenuName(string menuName)
        {
            
            List<Menu> result = new List<Menu>();
            foreach(var menuAction in Books)
            {
                if(menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }
        public void Initialize()
        {
            AddBook(new Menu(1, "Add book", "Main"));
            AddBook(new Menu(2, "Remove book", "Main"));
            AddBook(new Menu(3, "List of books", "Main"));
            AddBook(new Menu(4, "Show details", "Main"));
            AddBook(new Menu(5, "Update book", "Main"));

            AddBook(new Menu(1, "Remove by id", "Remove"));
            AddBook(new Menu(2, "Remove by title", "Remove"));

            AddBook(new Menu(1, "Sort books by id.", "AllBooks"));
            AddBook(new Menu(2, "Sort books by title.", "AllBooks"));
            AddBook(new Menu(3, "Sort books by author.", "AllBooks"));
            AddBook(new Menu(4, "Sort books by grade.", "AllBooks"));

            AddBook(new Menu(1, "Show details by id.", "Details"));
            AddBook(new Menu(2, "Show details by title.", "Details"));
        }
    }
}
