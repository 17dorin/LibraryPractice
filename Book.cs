﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject
{
    class Book : Media
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string Title, string Author) : base()
        {
            this.Title = Title;
            this.Author = Author;
        }
    }
}
