using BookSearchEngine.App.Concrete;
using BookSearchEngine.Domain.Entity;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookSearchEngine.Test
{
    public class BookServiceTest
    {
        [Fact]
        public void Should_GetLastId()
        {
            //Arrange
            var bookService = new BookServices();
            //Act
            var lastId = bookService.GetLastId();
            //Assert
            lastId.Should().Be(0);
            lastId.Should().BeOfType(typeof(int));
        }
        [Fact]
        public void Should_AddBook()
        {
            //Arrange
            var bookService = new BookServices();
            int lastId = bookService.GetLastId();

            Book book1 = new Book(lastId + 1, "Title", "Author", "Grade", "Description");
           
            //Act
            bookService.AddBook(book1);
            var book = bookService.GetBookById(1);

            //Assert
            book.Id.Should().Be(book.Id);
            book.Title.Should().Be("Title");
            book.Description.Should().Be("Description");
            book.Should().BeOfType(typeof(Book));

            //Clear
            bookService.RemoveBookById(book1.Id);

        }
        [Fact]
        public void Should_RemoveBook()
        {
            //Arrange
            var bookService = new BookServices();
            int lastId = bookService.GetLastId();

            Book book1 = new Book(lastId + 1, "Title", "Author", "Grade", "Description");
            Book book2 = new Book(lastId + 2, "t", "a", "g", "d");
            bookService.AddBook(book1);
            bookService.AddBook(book2);

            //Act
            bookService.RemoveBookById(book1.Id);
            bookService.RemoveBookByTitle(book2.Title);
            var books = bookService.GetAllBooks();

            //Assert
            books.Should().BeEmpty();

        }
        [Fact]
        public void Should_GetAllBooks()
        {
            //Arrange
            var bookService = new BookServices();
            int lastId = bookService.GetLastId();

            Book book1 = new Book(lastId + 1, "Title", "Author", "Grade", "Description");
            Book book2 = new Book(lastId + 2, "t", "a", "g", "d");
            bookService.AddBook(book1);
            bookService.AddBook(book2);

            //Act
            var books = bookService.GetAllBooks();

            //Assert
            books.Should().HaveCount(2);
            books[0].Id.Should().Be(1);
            books.Should().BeOfType(typeof(List<Book>));

            //Clear
            bookService.RemoveBookById(book1.Id);
            bookService.RemoveBookById(book2.Id);

        }
        [Fact]
        public void Should_GetBookById_And_GetBookByTitle()
        {
            //Arrange
            var bookService = new BookServices();
            int lastId = bookService.GetLastId();

            Book book1 = new Book(lastId + 1, "Title", "Author", "Grade", "Description");
            Book book2 = new Book(lastId + 2, "t", "a", "g", "d");
            bookService.AddBook(book1);
            bookService.AddBook(book2);

            //Act
            var bookDetails1 = bookService.GetBookById(1);
            var bookDetails2 = bookService.GetBookByTitle("t");

            //Assert
            bookDetails1.Should().BeSameAs(book1);
            bookDetails2.Id.Should().Equals(book2.Id);

            //Clear
            bookService.RemoveBookById(book1.Id);
            bookService.RemoveBookById(book2.Id);

        }
        [Fact]
        public void Should_UpdateBook()
        {
            //Arrange
            var bookService = new BookServices();
            int lastId = bookService.GetLastId();

            Book book1 = new Book(lastId + 1, "Title", "Author", "Grade", "Description");
            bookService.AddBook(book1);
            //Act
            var bookToReplace = bookService.GetBookById(1);
            bookToReplace.Title = "ChangeTitle";
            bookService.UpdateBook(bookToReplace);
            var changeBook = bookService.GetAllBooks();

            //Assert
            changeBook[0].Title.Should().Be("ChangeTitle");
            changeBook.Should().HaveCount(1);

            //Clear
            bookService.RemoveBookById(1);
        }
    }
}
