using BookSearchEngine.App.Common;
using BookSearchEngine.Domain;
using BookSearchEngine.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSearchEngine.App.Concrete
{
    public class BookServices : BaseService<Book>
    {
        public List<Book> AllBooks { get; set; }
        public BookServices()
        {
            AllBooks = new List<Book>();
        }
        
        
    }
}
