using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskB
{
    internal class Book : IComparable
    {
        // Class members
        public string Title { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public int Publication_Year { get; set; }

        public Book(string title, string author, int isbn, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Publication_Year = publicationYear;
        }

        //CompareTo method required by IComparable
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Book otherBook = obj as Book;
            if (otherBook != null)
            {
                // change this line to sort by Title, Author, ISBN, or Publication_Year as well as add a new case in program class
                return this.Title.CompareTo(otherBook.Title);
            }
            else
            {
                throw new ArgumentException("Object is not a Book");
            }
        }
    }
}
