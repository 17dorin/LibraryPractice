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
            Books = new List<Book>();
            Books.Add(new Book("The Pants that Couldn't", "Timmy Dilly"));
            Books.Add(new Book("Unless You Don't Mind", "Sarah Pessica Jarker"));
        }

        public void DisplayBooks(List<Book> books)
        {

            Console.WriteLine("Book list");

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

        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("\n\n\n\t\t\t==== EIDMAR==LIBRARY====");
                Console.WriteLine("\t\t\t/--x-/--x-/--x-/--x-/--x");
                Console.WriteLine("\t\t\t====WHY=ARE=YOU=HERE====");
                Console.WriteLine("\t\t\t[1] Show me the books");
                Console.WriteLine("\t\t\t[2] Who wrote it?");
                Console.WriteLine("\t\t\t[3] What's it called?");
                Console.WriteLine("\t\t\t[4] Book status");
                Console.WriteLine("\t\t\t[5] Give it back");
                Console.WriteLine("\t\t\t[6] Let me out");
                Console.WriteLine("\t\t\t========================");
                Console.WriteLine("\t\t\tx--/-x--/-x--/-x--/-x--/");
                Console.WriteLine("\t\t\t========================");

                ConsoleKeyInfo keyInput = Console.ReadKey();

                if (keyInput.Key == ConsoleKey.D1 || keyInput.Key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    DisplayBooks(Books);
                    Console.ReadKey();
                }
                else if (keyInput.Key == ConsoleKey.D2 || keyInput.Key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    Console.WriteLine("find author");
                    Console.ReadKey();

                }
                else if (keyInput.Key == ConsoleKey.D3 || keyInput.Key == ConsoleKey.NumPad3)
                {
                    Console.Clear();
                    Console.WriteLine("search by title");
                    Console.ReadKey();
                }
                else if (keyInput.Key == ConsoleKey.D4 || keyInput.Key == ConsoleKey.NumPad4)
                {
                    Console.Clear();
                    Console.WriteLine("select book");
                    Console.ReadKey();
                }
                else if (keyInput.Key == ConsoleKey.D5 || keyInput.Key == ConsoleKey.NumPad5)
                {
                    Console.Clear();
                    Console.WriteLine("return");
                    Console.ReadKey();
                }
                else if (keyInput.Key == ConsoleKey.D6 || keyInput.Key == ConsoleKey.NumPad6)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\t\t\tLater.\n\n\n\n\n\n");
                    break;
                }
                else
                {
                    Console.Clear();
                    continue;
                }
            }
        }

        public void ReturnBook()
        {
            Console.WriteLine("Which book do you want to return?");
        }
    }
}
