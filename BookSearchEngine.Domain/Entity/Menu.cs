using BookSearchEngine.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSearchEngine.Domain.Entity
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }

        public string MenuName { get; set; }

        public Menu(int id, string name, string menuName)
        {
            Id = id;
            Name = name;
            MenuName = menuName;

        }
    }
}
