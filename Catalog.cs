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
        public List<MusicCD> CDs { get; set; }
        public List<Magazine> Magazines { get; set; }

        public List<Media> Medias { get; set; }


        //All instances of books/other media are instantiated within the Catalog constructor
        public Catalog()
        {
            Books = CatalogToDisk.GenerateBookListFromDisk();
            CDs = CatalogToDisk.GenerateMusicCdListFromDisk();
            Magazines = CatalogToDisk.GenerateMagazineListFromDisk();
            Medias = new List<Media>();
            Medias.AddRange(Books);
            Medias.AddRange(Magazines);
            Medias.AddRange(CDs);
        }

        //Displays all books/other media with index and related info
        public void DisplayBooks()
        {
            if(Books.Count != 0)
            {
                foreach (Book book in Books)
                {
                    Console.WriteLine($"\n\t\t[{Books.IndexOf(book) + 1}]-----Title: \"{book.Title}\" \n\t\t\tAuthor: {book.Author} \n\t\t\tStatus: {book.Status}");
                }
            }
            else
            {
                Console.WriteLine("\n\n\n\t\t\tNo items in our collection match your query");
            }

        }
        public void DisplayMagazines()
        {
            if (Magazines.Count != 0)
            {
                foreach (Magazine magazine in Magazines)
                {
                    Console.WriteLine($"\n\t\t[{Magazines.IndexOf(magazine) + 1}]-----Title: \"{magazine.Title}\" \n\t\t\tIssue: {magazine.Issue} \n\t\t\tStatus: {magazine.Status}");
                }
            }
            else
            {
                Console.WriteLine("\n\n\n\t\t\tNo items in our collection match your query");
            }

        }
        public void DisplayMusic()
        {
            if (CDs.Count != 0)
            {
                foreach (MusicCD music in CDs)
                {
                    Console.WriteLine($"\n\t\t[{CDs.IndexOf(music) + 1}]-----Album: \"{music.Album}\" \n\t\t\tArtist: {music.Artist} \n\t\t\tStatus: {music.Status}");
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

        public void ReserveMedia(List<Media> media)
        {
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

            if (option - 1 >= 0 && option - 1 < media.Count)
            {
                foreach(Media piece in media)
                {
                    if (option - 1 == media.IndexOf(piece))
                    {
                        if (piece.Status == RentalStatus.In)
                        {
                            Console.WriteLine("\n\n\t\tDo you want to check out this item? Y/N");
                            if (Console.ReadKey(false).Key == ConsoleKey.Y)
                            {
                                piece.CheckOut();
                                Console.Clear();
                                Console.WriteLine($"\n\n\t\tYou have checked out: {piece} ");


                            }
                        }
                        else
                        {
                            Console.WriteLine($"\n\n\t\tThat item is currently checked out until {piece.DueDate}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\n\n\t\tPlease enter a valid option\n\n\t\tPress [ENTER] to return to main menu");
            }
        }

        ////Checks out a book/other media
        //public void ReserveBook()
        //{
        //    //Console.WriteLine("\n\n\t\t--Choose-a-[#]-to-borrow--\n\t\t------------or------------\n\t\t-------LEAVE--[ESC]-------\n");
        //    try
        //    {
        //        DisplayMediaOptions();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }


        //    //Gets the pressed key from user and converts to a number, itended to be a number 1 - size of list
        //    int option = -1;
        //    try
        //    {
        //        option = GetNumber();
        //    }
        //    catch (Exception e)
        //    {

        //        Console.WriteLine(e.Message);
        //    }



        //    Console.Clear();

        //    //Makes sure input is within bounds of the list
        //    if (option - 1 >= 0 && option - 1 < Books.Count)
        //    {
        //        foreach (Book book in Books)
        //        {
        //            //Matches input with correct book
        //            if (option - 1 == Books.IndexOf(book))
        //            {
        //                //Checks if selected book is currently out
        //                if(book.Status == RentalStatus.In)
        //                {
        //                    Console.WriteLine("\n\n\t\tDo you want to check out this item? Y/N");
        //                    Console.WriteLine($"\n\t\t\tTitle: \"{book.Title}\" \n\t\t\tAuthor: {book.Author}");
        //                    if (Console.ReadKey(false).Key == ConsoleKey.Y)
        //                    {
        //                        book.CheckOut();
        //                        Console.Clear();
        //                        Console.WriteLine("\n\n\t\tYou have checked out: ");
                                
        //                        Console.WriteLine($"\n\t\t\tTitle: \"{book.Title}\" \n\t\t\tAuthor: {book.Author}\n\n\t\t\t\tDue: {book.DueDate}");


        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine($"\n\n\t\tThat item is currently checked out until {book.DueDate}");
        //                }

        //            }
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("\n\n\t\tPlease enter a valid option\n\n\t\tPress [ENTER] to return to main menu");
        //    }
        //}

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
                    DisplayMediaOptions();
                    Console.ReadKey();
                }
                else if (keyInput.Key == ConsoleKey.D2 || keyInput.Key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\t========================");
                    Console.WriteLine("\t\t\t====Search=by=Author====\n");
                    Console.Write("\n\t\t\tAuthor Name: ");
                    string input = Console.ReadLine().ToLower().Trim();
                    DisplayBooks();
                    Console.ReadKey();


                }
                else if (keyInput.Key == ConsoleKey.D3 || keyInput.Key == ConsoleKey.NumPad3)
                {
                    Console.Clear();

                    Console.WriteLine("\n\n\t\t\t=======================");
                    Console.WriteLine("\t\t\t====Search=by=Title====\n");
                    Console.Write("\n\t\t\tBook Title: ");

                    string input = Console.ReadLine().ToLower().Trim();
                    DisplayBooks();

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
            List<Media> outMedia = new List<Media>();
            Console.WriteLine("\n\n\t\tWhat do you want to return?");

            //Adds books in our catalog that are currently out to a different list
            foreach(Media piece in Medias)
            {
                if(piece.Status == RentalStatus.Out)
                {
                    outMedia.Add(piece);
                }
            }

            //Tries to print list of out books, throws and handles exception if list is empty
            try
            {
                //Add logic to print all out books
                foreach(Media piece in outMedia)
                {
                    Console.WriteLine($"[{outMedia.IndexOf(piece) + 1}]{piece.ToString()}");
                }
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
            if(option - 1 >= 0 && option - 1 < outMedia.Count)
            {
                foreach (Media piece in outMedia)
                {
                    //Matches selectes book with the correct book in the list
                    if(option - 1 == outMedia.IndexOf(piece))
                    {
                        Console.WriteLine("\n\nDo you want to return this item? Y/N");
                        Console.WriteLine($" [{outMedia.IndexOf(piece) + 1}]{piece.ToString()}");

                        if(Console.ReadKey(false).Key == ConsoleKey.Y)
                        {
                            //Checks to see if book is overdue
                            if(piece.DueDate <= DateTime.Now)
                            {
                                Console.WriteLine("\n\n\t\tThis item is past due! \n\n\t\tOpen your wallet, miscreant.");
                            }
                            piece.Return();
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

        public void DisplayAllMedia()
        {
            int i = 1;

            if (Books.Count != 0)
            {
                foreach (Book book in Books)
                {
                    Console.WriteLine($"\n\t\t[{i}]-----Title: \"{book.Title}\" \n\t\t\tAuthor: {book.Author} \n\t\t\tStatus: {book.Status}");
                    i++;
                }


            }
            if (Magazines.Count != 0)
            {
                foreach (Magazine magazine in Magazines)
                {
                    Console.WriteLine($"\n\t\t[{i}]-----Title: \"{magazine.Title}\" \n\t\t\tIssue: {magazine.Issue} \n\t\t\tStatus: {magazine.Status}");
                    i++;
                }
            }
            if (CDs.Count != 0)
            {
                foreach (MusicCD music in CDs)
                {
                    Console.WriteLine($"\n\t\t[{i}]-----Album: \"{music.Album}\" \n\t\t\tArtist: {music.Artist} \n\t\t\tStatus: {music.Status}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("\n\n\n\t\t\tNo items in our collection match your query");
            }
        }
            public void DisplayMediaOptions()
            {
            List<Media> toDisplay;
               
                Console.WriteLine("\n\n\t\tWhich format would you like to browse?");
                Console.WriteLine("\n\t\t\t[1] Books");
                Console.WriteLine("\n\t\t\t[2] Magazines");
                Console.WriteLine("\n\t\t\t[3] Music");
                Console.WriteLine("\n\t\t\t[4] Browse All");

                ConsoleKeyInfo keyInput = Console.ReadKey();

                if (keyInput.Key == ConsoleKey.D1 || keyInput.Key == ConsoleKey.NumPad1)
                {
                    toDisplay = Books.Cast<Media>().ToList();    

                    Console.Clear();
                    Console.WriteLine("\t\t==========BOOKS==========");
                    DisplayBooks();
                    ReserveMedia(toDisplay);
                    Console.ReadKey();
                    Console.Clear();
                    DisplayMediaOptions();
                }
                else if (keyInput.Key == ConsoleKey.D2 || keyInput.Key == ConsoleKey.NumPad2)
                {
                    toDisplay = Magazines.Cast<Media>().ToList();

                    Console.Clear();
                    Console.WriteLine("\t\t========MAGAZINES========");
                    DisplayMagazines();
                    ReserveMedia(toDisplay);
                    Console.ReadKey();
                    Console.Clear();
                    DisplayMediaOptions();
                }
                else if (keyInput.Key == ConsoleKey.D3 || keyInput.Key == ConsoleKey.NumPad3)
                {
                    toDisplay = CDs.Cast<Media>().ToList();

                    Console.Clear();
                    Console.WriteLine("\t\t==========MUSIC==========");
                    DisplayMusic();
                    ReserveMedia(toDisplay);
                    Console.ReadKey();
                    Console.Clear();
                    DisplayMediaOptions();
                }
                else if (keyInput.Key == ConsoleKey.D4 || keyInput.Key == ConsoleKey.NumPad4)
                {                  
                    Console.Clear();
                    Console.WriteLine("\t\t===========ALL===========");
                    DisplayAllMedia();
                    ReserveMedia(Medias);
                    Console.ReadKey();
                    Console.Clear();
                    DisplayMediaOptions();

            }
                else
                {
                    Console.Clear();
                }
            
            }


    }
}
