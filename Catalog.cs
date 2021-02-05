using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibraryProject
{
    class Catalog
    {

        public List<Book> Books { get; set; }

        public Catalog()
        {
            //Initialize Book objects and place them into a list here
            Books = new List<Book>();
            Books.Add(new Book("The Pants that Couldn't", "Timmy Dilly"));
            Books.Add(new Book("Unless You Don't Mind", "Sarah Pessica Jarker"));
        }

        public void DisplayBooks(List<Book> books)
        {
            if(books.Count != 0)
            {
                foreach (Book book in books)
                {
                    Console.WriteLine($"1) \"{book.Title}\", Written by {book.Author}. The book is currently {book.Status}");
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

        public void ReserveBook()
        {
            Console.WriteLine("Enter the title of the book you want to check out");
            DisplayBooks(this.Books);
            string input = Console.ReadLine().Trim().ToLower();

            foreach(Book book in this.Books)
            {
                if(String.Equals(input, book.Title.ToLower()))
                {
                    Console.WriteLine("Do you want to check out this book? Y/N");
                    if (Console.ReadKey(false).Key == ConsoleKey.Y)
                    {
                        book.CheckOut();
                    }
                }
            }

        }

        public void ReturnBook()
        {
            Console.WriteLine("Which book do you want to return?");
        }

    }
}
