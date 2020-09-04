using BookSearchEngine.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSearchEngine.App.Abstract
{
    public interface IMenuService
    {
        List<Menu> Items { get; set; }

        void AddItem(Menu item);

        void RemoveItem(Menu item);

        List<Menu> GetMenuByMenuName(string menuName);
    }
}
