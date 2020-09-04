using BookSearchEngine.App.Abstract;
using BookSearchEngine.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace BookSearchEngine.App.Concrete
{
    public class MenuServices : IMenuService
    {
        public List<Menu> Items { get; set; }

        public MenuServices()
        {
            Items = new List<Menu>();
            Initialize();
        }

        public void AddItem(Menu item)
        {
            Items.Add(item);
        }

        public List<Menu> GetMenuByMenuName(string menuName)
        {
            
            List<Menu> result = new List<Menu>();
            foreach(var menuAction in Items)
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
            AddItem(new Menu(1, "Add book", "Main"));
            AddItem(new Menu(2, "Remove book", "Main"));
            AddItem(new Menu(3, "List of books", "Main"));
            AddItem(new Menu(4, "Show details", "Main"));
            AddItem(new Menu(5, "Update book", "Main"));

            AddItem(new Menu(1, "Remove by id", "Remove"));
            AddItem(new Menu(2, "Remove by title", "Remove"));

            AddItem(new Menu(1, "Sort books by id.", "AllBooks"));
            AddItem(new Menu(2, "Sort books by title.", "AllBooks"));
            AddItem(new Menu(3, "Sort books by author.", "AllBooks"));
            AddItem(new Menu(4, "Sort books by grade.", "AllBooks"));

            AddItem(new Menu(1, "Show details by id.", "Details"));
            AddItem(new Menu(2, "Show details by title.", "Details"));

            AddItem(new Menu(1, "Find book to update by id.", "Update"));
            AddItem(new Menu(2, "Find book to update by title.", "Update"));
        }

        public void RemoveItem(Menu item)
        {
            Items.Remove(item);
        }
    }
}
