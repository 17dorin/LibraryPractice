using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace LibraryProject
{
    class Catalog
    {
        public List<Book> Books { get; set; }
        public List<MusicCD> CDs { get; set; }
        public List<Magazine> Magazines { get; set; }

        //All instances of books/other media are instantiated within the Catalog constructor
        public Catalog()
        {
            Books = CatalogToDisk.GenerateBookListFromDisk();
            CDs = CatalogToDisk.GenerateMusicCdListFromDisk();
            Magazines = CatalogToDisk.GenerateMagazineListFromDisk();
        }

        //Displays all books/other media with index and related info
        public void DisplayBooks(List<Book> books)
        {

            if(books.Count != 0)
            {
                foreach (Book book in books)
                {
                    Console.WriteLine($"\n\t\t[{books.IndexOf(book) + 1}]-----Title: \"{book.Title}\" \n\t\t\tAuthor: {book.Author} \n\t\t\tStatus: {book.Status}");
                }
            }
            else
            {
                Console.WriteLine("\n\n\n\t\t\tNo items in our collection match your query");
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
                throw new Exception("\n\n\t\tInput must be a number of the given options");
            }

            return option;
        }

        //Checks out a book/other media
        public void ReserveBook()
        {
            Console.WriteLine("\n\n\t\t--Choose-a-[#]-to-borrow--\n\t\t------------or------------\n\t\t-------LEAVE--[ESC]-------\n");
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
                            Console.WriteLine("\n\n\t\tDo you want to check out this item? Y/N");
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
                            Console.WriteLine($"\n\n\t\tThat item is currently checked out until {book.DueDate}");
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("\n\n\t\tPlease enter a valid option\n\n\t\tPress [ENTER] to return to main menu");
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
                Console.WriteLine("\t\t\t[1] Our collection");
                Console.WriteLine("\t\t\t[2] Who wrote it?");
                Console.WriteLine("\t\t\t[3] What's it called?");
                Console.WriteLine("\t\t\t[4] Give it back");
                Console.WriteLine("\t\t\t[5] Let me out");
                Console.WriteLine("\t\t\t========================");
                Console.WriteLine("\t\t\tx--/-x--/-x--/-x--/-x--/");
                Console.WriteLine("\t\t\t========================");

                ConsoleKeyInfo keyInput = Console.ReadKey();

                if (keyInput.Key == ConsoleKey.D1 || keyInput.Key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t==========OUR=COLLECTION==========");
                    ReserveBook();
                    Console.ReadKey();
                }
                else if (keyInput.Key == ConsoleKey.D2 || keyInput.Key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\t========================");
                    Console.WriteLine("\t\t\t====Search=by=Author====\n");
                    Console.Write("\n\t\t\tAuthor Name: ");
                    string input = Console.ReadLine().ToLower().Trim();
                    DisplayBooks(FindAuthor(input));
                    Console.ReadKey();


                }
                else if (keyInput.Key == ConsoleKey.D3 || keyInput.Key == ConsoleKey.NumPad3)
                {
                    Console.Clear();

                    Console.WriteLine("\n\n\t\t\t=======================");
                    Console.WriteLine("\t\t\t====Search=by=Title====\n");
                    Console.Write("\n\t\t\tBook Title: ");

                    string input = Console.ReadLine().ToLower().Trim();
                    DisplayBooks(FindTitle(input));

                    Console.ReadKey();
                }
                else if (keyInput.Key == ConsoleKey.D4 || keyInput.Key == ConsoleKey.NumPad4)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t==========BORROWED=ITEMS==========");
                    ReturnBook();
                    Console.ReadKey();
                }
                else if (keyInput.Key == ConsoleKey.D5 || keyInput.Key == ConsoleKey.NumPad5)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\t\t\tLater.\n\n\n\n\n\n");

                    // Save before exiting
                    CatalogToDisk.SaveBooksStateToDisk(this);
                    CatalogToDisk.SaveCdStateToDisk(this);
                    CatalogToDisk.SaveMagazinesStateToDisk(this);

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
            Console.WriteLine("\n\n\t\tWhich book do you want to return?");

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
                        Console.WriteLine("\n\nDo you want to return this item? Y/N");
                        Console.WriteLine($"{book.Title}");

                        if(Console.ReadKey(false).Key == ConsoleKey.Y)
                        {
                            //Checks to see if book is overdue
                            if(book.DueDate <= DateTime.Now)
                            {
                                Console.WriteLine("\n\n\t\tThis item is past due! \n\n\t\tOpen your wallet, miscreant.");
                            }
                            book.Return();
                            Console.Clear();

                            Console.WriteLine("\n\n\t\tItem returned to inventory");
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
