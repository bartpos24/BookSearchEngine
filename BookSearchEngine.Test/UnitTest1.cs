using BookSearchEngine.App.Abstract;
using BookSearchEngine.App.Concrete;
using BookSearchEngine.App.Menagers;
using BookSearchEngine.Domain.Entity;
using System;
using Xunit;

namespace BookSearchEngine.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
        
        [Fact]
        public void CanAddNewBook()
        {
            //Arrange
            Book book = new Book(1, "Title", "Author", "Grade", "Description");
            IService<Book> bookService = new BookServices();

            //var menager = new BookMenager(new MenuServices(), bookService);
            //Act
            bookService.AddBook(book);
            //Assert

            
        }
    }
}
