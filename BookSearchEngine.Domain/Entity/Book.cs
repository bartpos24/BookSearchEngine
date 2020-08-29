using BookSearchEngine.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSearchEngine.Domain.Entity
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Grade { get; set; }

        public string Description { get; set; }

        public Book(int id, string title, string author, string grade, string description)
        {
            Id = id;
            Title = title;
            Author = author;
            Grade = grade;
            Description = description;
        }
    }
}
