using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibraryProject
{
    class Catalog
    {
        List<Book> Books { get; set; }

        public Catalog()
        {
            //Initialize Book objects and place them into a list here
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
    }
}
