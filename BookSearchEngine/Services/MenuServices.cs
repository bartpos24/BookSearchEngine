using BookSearchEngine.Model;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace BookSearchEngine.Services
{
    public class MenuServices
    {
        private List<Menu> menuActions = new List<Menu>();

        public void AddNewAction(int id, string name, string menuName)
        {
            Menu menuAction = new Menu() { Id = id, Name = name, MenuName = menuName };

            menuActions.Add(menuAction);
        }

        public List<Menu> GetMenuByMenuName(string menuName)
        {
            
            List<Menu> result = new List<Menu>();
            foreach(var menuAction in menuActions)
            {
                if(menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }
    }
}
