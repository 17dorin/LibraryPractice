using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibraryProject
{
    class Catalog
    {
<<<<<<< HEAD
        List<Book> Books { get; set; }
=======
        public List<Book> Books { get; set; }
>>>>>>> main

        public Catalog()
        {
            //Initialize Book objects and place them into a list here
<<<<<<< HEAD
=======
            Books = new List<Book>();
            Books.Add(new Book("The Pants that Couldn't", "Timmy Dilly"));
            Books.Add(new Book("Unless You Don't Mind", "Sarah Pessica Jarker"));
>>>>>>> main
        }

        public void DisplayBooks(List<Book> books)
        {
            if(books.Count != 0)
            {
                foreach (Book book in books)
                {
                    Console.WriteLine($"\"{book.Title}\", Written by {book.Author}. The book is currently {book.Status}");
                }
            }
            else
            {
                throw new Exception("No books were found");
            }

        }

        public List<Book> FindAuthor(string search)
        {
            List<Book> SearchedBooks = new List<Book>();
            //TODO Fix Lambda expression to find partial string
            //SearchedBooks = Books.Where(b => b.Author.Any(x => x.Author.ToUpper().Contains(search.ToUpper())));

            foreach(Book book in Books)
            {
                if(String.Equals(search, book.Author))
                {
                    SearchedBooks.Add(book);
                }
            }

            return SearchedBooks;

        }

        public List<Book> FindTitle(string search)
        {
            List<Book> SearchedBooks = new List<Book>();
            //TODO Fix Lambda expression to find partial string
            //SearchedBooks = Books.Where(b => b.Author.Any(x => x.Author.ToUpper().Contains(search.ToUpper())));

            foreach (Book book in Books)
            {
                if (String.Equals(search, book.Title))
                {
                    SearchedBooks.Add(book);
                }
            }

            return SearchedBooks;

        }
<<<<<<< HEAD
=======

        public void UpdateDueDate(Book book)
        {
            DateTime timeOfCheckOut = DateTime.Now;
            DateTime dueDate = new DateTime(timeOfCheckOut.Year, timeOfCheckOut.Month, timeOfCheckOut.Day + 14);

            book.DueDate = dueDate;
        }
>>>>>>> main
    }
}
