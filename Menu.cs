//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace LibraryProject
//{
//    class Menu
//    {
//        public Catalog Library { get; set; }

//        public void DisplayMenu()
//        {
//            while (true)
//            {
//                Console.Clear();

//                Console.WriteLine("\n\n\n\t\t\t=====EIDMAR=LIBRARY=====");
//                Console.WriteLine("\t\t\t/--x-/--x-/--x-/--x-/--x");
//                Console.WriteLine("\t\t\t====WHY=ARE=YOU=HERE====");
//                Console.WriteLine("\t\t\t[1] Our collection");
//                Console.WriteLine("\t\t\t[2] Who wrote it?");
//                Console.WriteLine("\t\t\t[3] What's it called?");
//                Console.WriteLine("\t\t\t[4] Give it back");
//                Console.WriteLine("\t\t\t[5] Let me out");
//                Console.WriteLine("\t\t\t========================");
//                Console.WriteLine("\t\t\tx--/-x--/-x--/-x--/-x--/");
//                Console.WriteLine("\t\t\t========================");

//                ConsoleKeyInfo keyInput = Console.ReadKey();

//                if (keyInput.Key == ConsoleKey.D1 || keyInput.Key == ConsoleKey.NumPad1)
//                {
//                    Console.Clear();
//                    Console.WriteLine("\t\t==========OUR=COLLECTION==========");
//                    Library.ReserveBook();
//                    Console.ReadKey();
//                }
//                else if (keyInput.Key == ConsoleKey.D2 || keyInput.Key == ConsoleKey.NumPad2)
//                {
//                    Console.Clear();
//                    Console.WriteLine("\n\n\t\t\t========================");
//                    Console.WriteLine("\t\t\t====Search=by=Author====\n");
//                    Console.Write("\n\t\t\tAuthor Name: ");
//                    string input = Console.ReadLine().ToLower().Trim();
//                    LibraryDisplayBooks(FindAuthor(input));
//                    Console.ReadKey();


//                }
//                else if (keyInput.Key == ConsoleKey.D3 || keyInput.Key == ConsoleKey.NumPad3)
//                {
//                    Console.Clear();

//                    Console.WriteLine("\n\n\t\t\t=======================");
//                    Console.WriteLine("\t\t\t====Search=by=Title====\n");
//                    Console.Write("\n\t\t\tBook Title: ");

//                    string input = Console.ReadLine().ToLower().Trim();
//                    DisplayBooks(FindTitle(input));

//                    Console.ReadKey();
//                }
//                else if (keyInput.Key == ConsoleKey.D4 || keyInput.Key == ConsoleKey.NumPad4)
//                {
//                    Console.Clear();
//                    Console.WriteLine("\t\t\t==========BORROWED=ITEMS==========");
//                    ReturnBook();
//                    Console.ReadKey();
//                }
//                else if (keyInput.Key == ConsoleKey.D5 || keyInput.Key == ConsoleKey.NumPad5)
//                {
//                    Console.Clear();
//                    Console.WriteLine("\n\n\n\t\t\tLater.\n\n\n\n\n\n");

//                    // Save before exiting
//                    CatalogToDisk.SaveBooksStateToDisk(this);
//                    CatalogToDisk.SaveCdStateToDisk(this);
//                    CatalogToDisk.SaveMagazinesStateToDisk(this);

//                    break;
//                }
//                else
//                {
//                    Console.Clear();
//                    continue;
//                }
//            }
//        }
//    }

//}

