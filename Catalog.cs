﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace LibraryProject
{
    class Catalog
    {
        public List<Book> Books { get; set; }

        //All instances of books/other media are instantiated within the Catalog constructor
        public Catalog()
        {
           Books = GenerateBookListFromDisk();
        }

        //Displays all books/other media with index and related info
        public void DisplayBooks(List<Book> books)
        {

            Console.WriteLine("Book list");

            if(books.Count != 0)
            {
                foreach (Book book in books)
                {
                    Console.WriteLine($"\n\t\t[{books.IndexOf(book) + 1}]-----Title: \"{book.Title}\" \n\t\t\tAuthor: {book.Author} \n\t\t\tStatus: {book.Status}");
                }
            }
            else
            {
                Console.WriteLine("\n\n\n\t\t\tNo books were found");
            }

        }

        //Finds books based on Author property with a given string, can find partial matches
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

        //Same as FindAuthor but with Title property
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

        public static int GetNumber()
        {
            int option;
            string unparsed = Console.ReadLine();

            if(!int.TryParse(unparsed, out option))
            {
                throw new Exception("Input must be a number of the given options");
            }

            return option;
        }

        //Checks out a book/other media
        public void ReserveBook()
        {
            Console.WriteLine("Which book do you want to check out?");
            try
            {
                DisplayBooks(this.Books);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            //Gets the pressed key from user and converts to a number, itended to be a number 1 - size of list
            int option = -1;
            try
            {
                option = GetNumber();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }



            Console.Clear();

            //Makes sure input is within bounds of the list
            if (option - 1 >= 0 && option - 1 < Books.Count)
            {
                foreach (Book book in Books)
                {
                    //Matches input with correct book
                    if (option - 1 == Books.IndexOf(book))
                    {
                        //Checks if selected book is currently out
                        if(book.Status == RentalStatus.In)
                        {
                            Console.WriteLine("\n\n\t\tDo you want to check out this book? Y/N");
                            Console.WriteLine($"\n\t\t\tTitle: \"{book.Title}\" \n\t\t\tAuthor: {book.Author}");
                            if (Console.ReadKey(false).Key == ConsoleKey.Y)
                            {
                                book.CheckOut();
                                Console.Clear();
                                Console.WriteLine("\n\n\t\tYou have checked out: ");
                                
                                Console.WriteLine($"\n\t\t\tTitle: \"{book.Title}\" \n\t\t\tAuthor: {book.Author}\n\n\t\t\t\tDue: {book.DueDate}");


                            }
                        }
                        else
                        {
                            Console.WriteLine("That book is currently out");
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

                Console.WriteLine("\n\n\n\t\t\t=====EIDMAR=LIBRARY=====");
                Console.WriteLine("\t\t\t/--x-/--x-/--x-/--x-/--x");
                Console.WriteLine("\t\t\t====WHY=ARE=YOU=HERE====");
                Console.WriteLine("\t\t\t[1] Show me the books");
                Console.WriteLine("\t\t\t[2] Who wrote it?");
                Console.WriteLine("\t\t\t[3] What's it called?");
                Console.WriteLine("\t\t\t[4] Borrow a book");
                Console.WriteLine("\t\t\t[5] Give it back");
                Console.WriteLine("\t\t\t[6] Let me out");
                Console.WriteLine("\t\t\t========================");
                Console.WriteLine("\t\t\tx--/-x--/-x--/-x--/-x--/");
                Console.WriteLine("\t\t\t========================");

                ConsoleKeyInfo keyInput = Console.ReadKey();

                if (keyInput.Key == ConsoleKey.D1 || keyInput.Key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t==========OUR=COLLECTION==========");
                    DisplayBooks(Books);
                    Console.ReadKey();
                }
                else if (keyInput.Key == ConsoleKey.D2 || keyInput.Key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\t========================");
                    Console.WriteLine("\t\t\t====Search=by=Author====");
                    Console.Write("\n\t\t\tAuthor Name: ");
                    string input = Console.ReadLine().ToLower().Trim();
                    DisplayBooks(FindAuthor(input));
                    Console.ReadKey();


                }
                else if (keyInput.Key == ConsoleKey.D3 || keyInput.Key == ConsoleKey.NumPad3)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\t========================");
                    Console.WriteLine("\t\t\t====Search=by=Title====");
                    Console.Write("\n\t\t\tTitle: ");
                    string input = Console.ReadLine().ToLower().Trim();
                    DisplayBooks(FindTitle(input));

                    Console.ReadKey();
                }
                else if (keyInput.Key == ConsoleKey.D4 || keyInput.Key == ConsoleKey.NumPad4)
                {
                    Console.Clear();
                    ReserveBook();
                    Console.ReadKey();
                }
                else if (keyInput.Key == ConsoleKey.D5 || keyInput.Key == ConsoleKey.NumPad5)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t==========BORROWED=BOOKS==========");
                    ReturnBook();
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

        //Returns a checked out book
        public void ReturnBook()
        {
            List<Book> outBooks = new List<Book>();
            Console.WriteLine("Which book do you want to return?");

            //Adds books in our catalog that are currently out to a different list
            foreach(Book book in Books)
            {
                if(book.Status == RentalStatus.Out)
                {
                    outBooks.Add(book);
                }
            }

            //Tries to print list of out books, throws and handles exception if list is empty
            try
            {
                DisplayBooks(outBooks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Gets user key press and converts to a number, intended to be 1 - the size of the list
            int option = -1;
            try
            {
                option = GetNumber();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


            Console.Clear();
            
            //Checks to make sure input is within bounds
            if(option - 1 >= 0 && option - 1 < outBooks.Count)
            {
                foreach (Book book in outBooks)
                {
                    //Matches selectes book with the correct book in the list
                    if(option - 1 == outBooks.IndexOf(book))
                    {
                        Console.WriteLine("Do you want to return this book? Y/N");
                        Console.WriteLine($"{book.Title}");

                        if(Console.ReadKey(false).Key == ConsoleKey.Y)
                        {
                            //Checks to see if book is overdue
                            if(book.DueDate <= DateTime.Now)
                            {
                                Console.WriteLine("This book is past due! You'll owe a fine");
                            }
                            book.Return();
                            Console.Clear();

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

        // FILE IO
        public static List<Book> GenerateBookListFromDisk()
        {
            List<Book> diskBooks = new List<Book>();
            string fileName = "LibraryCatalog.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            List<string> booksData = File.ReadAllLines(path).ToList();

            foreach (string line in booksData)
            {
                // Create an array of each value separated by delimiter (comma)
                string[] data = line.Split(',');

                // For each value in the array, trim out in extra space, just in case!
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = data[i].Trim();
                }

                diskBooks.Add(new Book(data[0], data[1], data[2], data[3]));
            }

            // Order Alphabetically
            diskBooks.Sort((x, y) => x.Title.CompareTo(y.Title));

            return diskBooks;
        }
    }
}
