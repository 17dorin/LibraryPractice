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

            //catalog.DisplayMenu();
            catalog.DisplayMediaOptions();
        }
    }
}