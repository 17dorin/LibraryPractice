using System;

namespace LibraryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            //catalog.DisplayMenu();
            catalog.ReserveBook();
            Console.WriteLine("Book reserved");
            catalog.ReturnBook();
            Console.WriteLine("Book returned");

          

        }
    }
}