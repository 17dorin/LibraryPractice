using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibraryProject
{
    class CatalogToDisk
    {
        // There are txt files that contain data for various Media types.
        // These files are in the main project directory.
        // Visual Studio will COPY these text files to the BIN directory when the project builds.
        // Then the methods below will access those files in the BIN directory, and create Lists of Media based on the text file data.
        // Changes made to the Media Lists during runtime will be saved when the app closes.
        // The methods in below in the WRITE region will again access the BIN directory, and write to it.

        #region READ
        public static List<Book> GenerateBookListFromDisk()
        {
            List<Book> diskBooks = new List<Book>();
            string fileName = "Data\\LibraryCatalog.txt";
            string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
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

        public static List<MusicCD> GenerateMusicCdListFromDisk()
        {
            List<MusicCD> diskMusicCDs = new List<MusicCD>();

            string fileName = "Data\\CdCatalog.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);

            List<string> cdsData = File.ReadAllLines(path).ToList();

            foreach (string line in cdsData)
            {
                // Create an array of each value separated by delimiter (comma)
                string[] data = line.Split(',');

                // For each value in the array, trim out in extra space, just in case!
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = data[i].Trim();
                }

                diskMusicCDs.Add(new MusicCD(data[0], data[1], data[2], data[3]));
            }

            // Order Alphabetically
            diskMusicCDs.Sort((x, y) => x.Artist.CompareTo(y.Artist));

            return diskMusicCDs;
        }

        public static List<Magazine> GenerateMagazineListFromDisk()
        {
            List<Magazine> diskMagazines = new List<Magazine>();

            string fileName = "Data\\MagazineCatalog.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);

            List<string> cdsData = File.ReadAllLines(path).ToList();

            foreach (string line in cdsData)
            {
                // Create an array of each value separated by delimiter (comma)
                string[] data = line.Split(',');

                // For each value in the array, trim out in extra space, just in case!
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = data[i].Trim();
                }

                diskMagazines.Add(new Magazine(data[0], data[1], data[2], data[3]));
            }

            // Order Alphabetically
            diskMagazines.Sort((x, y) => x.Title.CompareTo(y.Title));

            return diskMagazines;
        }

        #endregion

        #region WRITE

        public static void SaveBooksStateToDisk(Catalog catalog)
        {
            string fileName = "Data\\LibraryCatalog.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);

            using (var writer = File.CreateText(path))
            {
                foreach (var book in catalog.Books)
                {
                    writer.WriteLine(book.ToString());
                }
            }
        }

        public static void SaveCdStateToDisk(Catalog catalog)
        {
            string fileName = "Data\\CdCatalog.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);

            using (var writer = File.CreateText(path))
            {
                foreach (var cd in catalog.CDs)
                {
                    writer.WriteLine(cd.ToString());
                }
            }
        }

        public static void SaveMagazinesStateToDisk(Catalog catalog)
        {
            string fileName = "Data\\MagazineCatalog.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);

            using (var writer = File.CreateText(path))
            {
                foreach (var magazine in catalog.Magazines)
                {
                    writer.WriteLine(magazine.ToString());
                }
            }
        }

        #endregion
    }
}
