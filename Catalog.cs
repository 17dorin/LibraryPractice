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
                    Console.WriteLine($"[{books.IndexOf(book) + 1}] \"{book.Title}\", Written by {book.Author}. The book is currently {book.Status}");
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

            search = search.ToLower();

            foreach(Book book in Books)
            {
                if(book.Author.ToLower().Contains(search))
                {
                    SearchedBooks.Add(book);
                }
            }

            return SearchedBooks;

        }

        public List<Book> FindTitle(string search)
        {

            List<Book> SearchedBooks = new List<Book>();

            search = search.ToLower();

            foreach (Book book in Books)
            {
                if (book.Title.ToLower().Contains(search))
                {
                    SearchedBooks.Add(book);
                }
            }

            return SearchedBooks;

        }

        public void ReserveBook()
        {
            Console.WriteLine("Which book do you want to check out?");
            DisplayBooks(this.Books);

            ConsoleKeyInfo selection = Console.ReadKey();
            double option = Char.GetNumericValue(selection.KeyChar);

            Console.Clear();

            if (option - 1 >= 0 && option - 1 < Books.Count)
            {
                foreach (Book book in Books)
                {
                    if (Char.GetNumericValue(selection.KeyChar) - 1 == Books.IndexOf(book))
                    {
                        Console.WriteLine("Do you want to check out this book? Y/N");
                        Console.WriteLine($"{book.Title}");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            book.CheckOut();
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid option");
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
            List<Book> outBooks = new List<Book>();
            Console.WriteLine("Which book do you want to return?");

            foreach(Book book in Books)
            {
                if(book.Status == RentalStatus.Out)
                {
                    outBooks.Add(book);
                }
            }

            DisplayBooks(outBooks);

            ConsoleKeyInfo selection = Console.ReadKey();
            double option = Char.GetNumericValue(selection.KeyChar);

            Console.Clear();

            if(option - 1 >= 0 && option - 1 < outBooks.Count)
            {
                foreach (Book book in outBooks)
                {
                    if(option - 1 == outBooks.IndexOf(book))
                    {
                        Console.WriteLine("Do you want to return this book? Y/N");
                        Console.WriteLine($"{book.Title}");
                        if(Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            if(book.DueDate <= DateTime.Now)
                            {
                                Console.WriteLine("This book is past due! You'll owe a fine");
                            }
                            book.Return();
                            Console.WriteLine("Book returned");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid option");
            }
        }
    }
}
