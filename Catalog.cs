using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibraryProject
{
    class Catalog
    {
        List<Media> Pieces { get; set; }

        //All instances of books/other media are instantiated within the Catalog constructor
        public Catalog()
        {
            Pieces = new List<Media>();
            Pieces.Add(new Book("The Pants that Couldn't", "Timmy Dilly"));
            Pieces.Add(new Book("Unless You Don't Mind", "Sarah Pessica Jarker"));
            Pieces.Add(new Book("bbok 3", "anon"));
            Pieces.Add(new Book("We as a society have progressed past the need for git", "Me"));
            Pieces.Add(new Book("The Pants that Didn't event try", "Timmy Dilly Jr."));
            Pieces.Add(new Book("Turn 3", "Dale Earnheardt"));
            Pieces.Add(new Book("23 Stab Wounds", "Julius Ceasar"));
            Pieces.Add(new Book("Back to nature", "Carlos Mark"));
            Pieces.Add(new Book("Everyday is a winding road", "Sheryl Crowe"));
            Pieces.Add(new Book("book4", "steve jobs"));
            Pieces.Add(new Book("almost time for lunch", "Me"));
            Pieces.Add(new Book("time for lunch", "Me Jr."));
        }

        //Displays all books/other media with index and related info
        public void DisplayBooks(List<Media> pieces)
        {

            Console.WriteLine("\t\t==========OUR=COLLECTION==========");

            if(pieces.Count != 0)
            {
                foreach (Book book in pieces)
                {
                    Console.WriteLine($"\n\t\t[{pieces.IndexOf(book) + 1}]-----Title: \"{book.Title}\" \n\t\t\tAuthor: {book.Author} \n\t\t\tStatus: {book.Status}");
                }
            }
            else
            {
                throw new Exception("\n\n\n\t\t\tNo books were found");
            }

        }

        //Finds books based on Author property with a given string, can find partial matches
        public List<Media> FindAuthor(string search)
        {
            List<Media> searchedMedia = new List<Media>();

            search = search.ToLower();

            foreach(Media piece in Pieces)
            {
                if(piece.Author.ToLower().Contains(search))
                {
                    searchedMedia.Add(piece);
                }
            }

            return searchedMedia;

        }

        //Same as FindAuthor but with Title property
        public List<Media> FindTitle(string search)
        {

            List<Media> searchedMedia = new List<Media>();

            search = search.ToLower();

            foreach (Media piece in Pieces)
            {
                if (piece.Title.ToLower().Contains(search))
                {
                    searchedMedia.Add(piece);
                }
            }

            return searchedMedia;

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
                DisplayBooks(this.Pieces);
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
            if (option - 1 >= 0 && option - 1 < Pieces.Count)
            {
                foreach (Book book in Pieces)
                {
                    //Matches input with correct book
                    if (option - 1 == Pieces.IndexOf(book))
                    {
                        //Checks if selected book is currently out
                        if(book.Status == RentalStatus.In)
                        {
                            Console.WriteLine("Do you want to check out this book? Y/N");
                            Console.WriteLine($"{book.Title}");
                            if (Console.ReadKey(false).Key == ConsoleKey.Y)
                            {
                                book.CheckOut();
                                Console.Clear();
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
                    DisplayBooks(this.Pieces);
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
                    Console.Write("\n\t\t\tAuthor Name: ");
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
            foreach(Book book in Pieces)
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
    }
}
