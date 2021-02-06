using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            catalog.DisplayMenu();
        }

        private static void SaveAndExitApp(string fileName, Catalog catalog)
        {
            using (var writer = File.AppendText($"{fileName}.txt"))
            {
                foreach (var book in catalog.Pieces)
                {
                    writer.WriteLine(book.ToString());
                }
            }
        }

        //public static List<Book> GenerateBookListFromDisk()
        //{
        //    List<Book> diskBooks = new List<Book>();

        //    string fileName = "LibraryCatalog.txt";
        //    string path = Path.Combine(Environment.CurrentDirectory, fileName);

        //    List<string> booksData = File.ReadAllLines(path).ToList();

        //    foreach (string line in booksData)
        //    {
        //        // Create an array of each value separated by delimiter (comma)
        //        string[] data = line.Split(',');

        //        // For each value in the array, trim out in extra space, just in case!
        //        for (int i = 0; i < data.Length; i++)
        //        {
        //            data[i] = data[i].Trim();
        //        }

        //        diskBooks.Add(new Book(data[0], data[1], data[2], data[3]));
        //    }

        //    // Order Alphabetically
        //    diskBooks.Sort((x, y) => x.Title.CompareTo(y.Title));

        //    return diskBooks;
        //}
    }
}