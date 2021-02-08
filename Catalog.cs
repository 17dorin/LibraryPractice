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

        #region CATALOG FUNCTIONS

        static int GetNumber()
        {
            int option;
            string unparsed = Console.ReadLine();

            if (!int.TryParse(unparsed, out option))
            {
                throw new Exception("\n\n\t\tInput must be a number of the given options");
            }
            Console.WriteLine("\n\n\t\tWhich [#] would you like to checkout?\n\t\tDouble-tap [ENTER] to return to collection menu");

            return option;
        }

        public void SearchMedia(string input)
        {
            bool foundMedia = false;
            string search = input.Trim().ToLower();
            int index = 1;

            if (!String.IsNullOrEmpty(search) && !String.IsNullOrWhiteSpace(search))
            {
                foreach (Media piece in Medias)
                {
                    if (piece.ToString().ToLower().Contains(search))
                    {
                        Console.WriteLine($"\n\t\t\t[{index}] {piece.PrintInfo()}");
                        foundMedia = true;
                        index++;
                    }
                }

                if (!foundMedia)
                {
                    Console.WriteLine("\n\t\tNo results were found for your search");
                }
            }
            else
            {
                Console.WriteLine("\n\t\tSearch string cannot be blank");
            }

            AnyKeyToMainMenuPrompt();
        }

        public void SearchMusic(string input)
        {
            bool foundMedia = false;
            string search = input.Trim().ToLower();
            int index = 1;

            if (!String.IsNullOrEmpty(search) && !String.IsNullOrWhiteSpace(search))
            {
                foreach (MusicCD cd in Medias.OfType<MusicCD>())
                {
                    if (cd.ToString().ToLower().Contains(search))
                    {
                        Console.WriteLine($"\n\t\t\t[{index}]-----{cd.PrintInfo()}");
                        foundMedia = true;
                        index++;
                    }
                }

                if (!foundMedia)
                {
                    Console.WriteLine("\n\t\tNo results were found for your search");
                }
            }
            else
            {
                Console.WriteLine("Search string cannot be blank");
            }

            AnyKeyToMainMenuPrompt();
        }

        public void SearchMagazines(string input)
        {
            bool foundMedia = false;
            string search = input.Trim().ToLower();
            int index = 1;

            if (!String.IsNullOrEmpty(search) && !String.IsNullOrWhiteSpace(search))
            {
                foreach (Magazine mag in Medias.OfType<Magazine>())
                {
                    if (mag.ToString().ToLower().Contains(search))
                    {
                        Console.WriteLine($"\n\t\t\t[{index}] {mag.PrintInfo()}");
                        foundMedia = true;
                        index++;
                    }
                }

                if (!foundMedia)
                {
                    Console.WriteLine("\n\t\tNo results were found for your search");
                }
            }
            else
            {
                Console.WriteLine("Search string cannot be blank");
            }

            AnyKeyToMainMenuPrompt();
        }

        public void SearchBookByTitle(string input)
        {
            bool foundMedia = false;
            string search = input.Trim().ToLower();
            int index = 1;

            if (!String.IsNullOrEmpty(search) && !String.IsNullOrWhiteSpace(search))
            {
                foreach (Book b in Medias.OfType<Book>())
                {
                    if (b.Title.ToLower().Contains(search))
                    {
                        Console.WriteLine($"\n\t\t\t[{index}] {b.PrintInfo()}");
                        index++;
                        foundMedia = true;
                    }
                }

                if (!foundMedia)
                {
                    Console.WriteLine("\n\t\tNo results were found for your search");
                }
            }
            else
            {
                Console.WriteLine("Search string cannot be blank");
            }

            AnyKeyToMainMenuPrompt();
        }

        public void SearchBookByAuthor(string input)
        {
            bool foundMedia = false;
            string search = input.Trim().ToLower();
            int index = 1;

            if (!String.IsNullOrEmpty(search) && !String.IsNullOrWhiteSpace(search))
            {
                foreach (Book b in Medias.OfType<Book>())
                {
                    if (b.Author.ToLower().Contains(search))
                    {
                        Console.WriteLine($"\n\t\t\t[{index}] {b.PrintInfo()}");
                        index++;
                        foundMedia = true;
                    }
                }

                if(!foundMedia)
                {
                    Console.WriteLine("\n\t\tNo results were found for your search");
                }
            }
            else
            {
                Console.WriteLine("\n\t\tSearch string cannot be blank");
            }

            AnyKeyToMainMenuPrompt();
        }

        //Grabs a piece of media from a list, changes its rental status and due date
        public void ReserveMedia(List<Media> media)
        {
            //gets the index of the book you want to checkout, starting at 1 and changed to 0 indexed later
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

            //Checks to see 
            if (option - 1 >= 0 && option - 1 < media.Count)
            {
                foreach (Media piece in media)
                {
                    if (option - 1 == media.IndexOf(piece))
                    {
                        if (piece.Status == RentalStatus.In)
                        {
                            Console.WriteLine("\n\n\t\tDo you want to check out this item? Y/N");
                            Console.WriteLine($"\n\n\t\t{piece}");
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

        public void ReturnBook()
        {
            List<Media> outMedia = new List<Media>();
            Console.WriteLine("\n\n\t\tWhat do you want to return?");

            //Adds media in our catalog that are currently out to a different list
            foreach (Media piece in Medias)
            {
                if (piece.Status == RentalStatus.Out)
                {
                    outMedia.Add(piece);
                }
            }

            //Tries to print list of out media, throws and handles exception if list is empty
            try
            {
                //Add logic to print all out media
                foreach (Media piece in outMedia)
                {
                    Console.WriteLine($"\n\n\t\t[{outMedia.IndexOf(piece) + 1}]{piece.ToString()}");
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
            if (option - 1 >= 0 && option - 1 < outMedia.Count)
            {
                foreach (Media piece in outMedia)
                {
                    //Matches selected media with the correct media in the list
                    if (option - 1 == outMedia.IndexOf(piece))
                    {
                        Console.WriteLine("\n\nDo you want to return this item? Y/N");
                        Console.WriteLine($"\n\n\t\t[{outMedia.IndexOf(piece) + 1}] {piece.ToString()}");

                        if (Console.ReadKey(false).Key == ConsoleKey.Y)
                        {
                            //Checks to see if media is overdue
                            if (piece.DueDate <= DateTime.Now)
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
                Console.WriteLine("\n\n\t\tYou didn't select anything from our collection... That's fine.\n\n\t\tPress[ENTER] to return to collection menu");
            }
        }

        #endregion

        #region CATALOG MENU

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
                Console.WriteLine("\t\t\t[2] Search our collection");
                Console.WriteLine("\t\t\t[3] Give it back");
                Console.WriteLine("\t\t\t[4] Let me out");
                Console.WriteLine("\t\t\t========================");
                Console.WriteLine("\t\t\tx--/-x--/-x--/-x--/-x--/");
                Console.WriteLine("\t\t\t========================");

                ConsoleKeyInfo keyInput = Console.ReadKey();

                if (keyInput.Key == ConsoleKey.D1 || keyInput.Key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t==========OUR=COLLECTION==========");
                    DisplayMediaOptions();
                }
                else if (keyInput.Key == ConsoleKey.D2 || keyInput.Key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\t========================");
                    Console.WriteLine("\t\t\t=========Search=========\n");
                    DisplaySearchOptions();
                }
                else if (keyInput.Key == ConsoleKey.D3 || keyInput.Key == ConsoleKey.NumPad3)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t==========BORROWED=ITEMS==========");
                    ReturnBook();
                    //Console.ReadKey();
                }
                else if (keyInput.Key == ConsoleKey.D4 || keyInput.Key == ConsoleKey.NumPad4)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\t\t\tLater.\n\n\n\n\n\n");

                    // Save before exiting
                    CatalogToDisk.SaveBooksStateToDisk(this);
                    CatalogToDisk.SaveCdStateToDisk(this);
                    CatalogToDisk.SaveMagazinesStateToDisk(this);

                    break;
                }
                else if (keyInput.Key == ConsoleKey.D0 || keyInput.Key == ConsoleKey.NumPad0)
                {
                    Console.Clear();
                    Console.Write("\n\n\t\t\t...What is your name?: ");
                    string name = Console.ReadLine();
                    if (name.ToLower().Contains("julius") || name.ToLower().Contains("cesar"))
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\t\t\tThe senators will meet you at the exit\n\n\n\n");
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }
                else
                {
                    Console.Clear();
                    continue;
                }
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
               
                Console.WriteLine("\n\t\tWhich format would you like to browse?");
                Console.WriteLine("\n\t\t\t[1] Books");
                Console.WriteLine("\n\t\t\t[2] Magazines");
                Console.WriteLine("\n\t\t\t[3] Music");
                Console.WriteLine("\n\t\t\t[4] Browse All");
                Console.WriteLine("\n\t\t\t[5] Return to main menu");

                ConsoleKeyInfo keyInput = Console.ReadKey();

                if (keyInput.Key == ConsoleKey.D1 || keyInput.Key == ConsoleKey.NumPad1)
                {
                    toDisplay = Books.Cast<Media>().ToList();    

                    Console.Clear();
                    Console.WriteLine("\t\t==========BOOKS==========");
                    DisplayBooks();
                    ReserveMedia(toDisplay);
                    DisplayMediaOptions();
                }
                else if (keyInput.Key == ConsoleKey.D2 || keyInput.Key == ConsoleKey.NumPad2)
                {
                    toDisplay = Magazines.Cast<Media>().ToList();

                    Console.Clear();
                    Console.WriteLine("\t\t========MAGAZINES========");
                    DisplayMagazines();
                    ReserveMedia(toDisplay);
                    DisplayMediaOptions();
                }
                else if (keyInput.Key == ConsoleKey.D3 || keyInput.Key == ConsoleKey.NumPad3)
                {
                    toDisplay = CDs.Cast<Media>().ToList();

                    Console.Clear();
                    Console.WriteLine("\t\t==========MUSIC==========");
                    DisplayMusic();
                    ReserveMedia(toDisplay);
                    DisplayMediaOptions();
                }
                else if (keyInput.Key == ConsoleKey.D4 || keyInput.Key == ConsoleKey.NumPad4)
                {                  
                    Console.Clear();
                    Console.WriteLine("\t\t===========ALL===========");
                    DisplayAllMedia();
                    ReserveMedia(Medias);
                    DisplayMediaOptions();

                }
                else if (keyInput.Key == ConsoleKey.D5 || keyInput.Key == ConsoleKey.NumPad5)
                {
                    Console.Clear();
                    return;
                }
            
            }

        public void DisplaySearchOptions()
        {
            Console.WriteLine("\n\t\tWhat are you searching for?");
            Console.WriteLine("\n\t\t\t[1] Books");
            Console.WriteLine("\n\t\t\t[2] Magazines");
            Console.WriteLine("\n\t\t\t[3] Music");
            Console.WriteLine("\n\t\t\t[4] Return to main menu");

            ConsoleKeyInfo keyInput = Console.ReadKey();

            if (keyInput.Key == ConsoleKey.D1 || keyInput.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t========================");
                Console.WriteLine("\t\t\t=========Search=========\n");
                DisplayBookSearchOptions();
            }
            else if (keyInput.Key == ConsoleKey.D2 || keyInput.Key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t========================");
                Console.WriteLine("\t\t\t=========Search=========\n");
                Console.Write("\n\t\t\tSearch Magazines: ");
                string input = Console.ReadLine().ToLower().Trim();
                SearchMagazines(input);
            }
            else if (keyInput.Key == ConsoleKey.D3 || keyInput.Key == ConsoleKey.NumPad3)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t========================");
                Console.WriteLine("\t\t\t=========Search=========\n");
                Console.Write("\n\t\t\tSearch Music: ");
                string input = Console.ReadLine().ToLower().Trim();
                SearchMusic(input);
            }
            else if (keyInput.Key == ConsoleKey.D4 || keyInput.Key == ConsoleKey.NumPad4)
            {
                Console.Clear();
            }

        }

        public void DisplayBookSearchOptions()
        {
            Console.WriteLine("\n\t\tHow are you searching?");
            Console.WriteLine("\n\t\t\t[1] By Author");
            Console.WriteLine("\n\t\t\t[2] By Title");
            Console.WriteLine("\n\t\t\t[3] Return to main menu");

            ConsoleKeyInfo keyInput = Console.ReadKey();

            if (keyInput.Key == ConsoleKey.D1 || keyInput.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t========================");
                Console.WriteLine("\t\t\t=========Search=========\n");
                Console.Write("\n\t\t\tSearch Books by Author: ");
                string input = Console.ReadLine().ToLower().Trim();
                SearchBookByAuthor(input);
            }
            else if (keyInput.Key == ConsoleKey.D2 || keyInput.Key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t========================");
                Console.WriteLine("\t\t\t=========Search=========\n");
                Console.Write("\n\t\t\tSearch Books by Title: ");
                string input = Console.ReadLine().ToLower().Trim();
                SearchBookByTitle(input);
            }
            else if (keyInput.Key == ConsoleKey.D3 || keyInput.Key == ConsoleKey.NumPad3)
            {
                Console.Clear();
            }

        }

        private static void AnyKeyToMainMenuPrompt()
        {
            Console.WriteLine("\n\t\t\tPress any key to return to the main menu");
            Console.ReadKey();
        }

        #endregion

    }
}
