using System;
using System.IO;

namespace LibraryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            //catalog.DisplayMenu();

            SaveAndExitApp("disk-catalog-test", catalog);

        }

        private static void SaveAndExitApp(string fileName, Catalog catalog)
        {
            using (var writer = File.AppendText($"{fileName}.txt"))
            {
                foreach (var book in catalog.Books)
                {
                    writer.WriteLine(book.ToString());
                }
            }
            

        }
    }
}