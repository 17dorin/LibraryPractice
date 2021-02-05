using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject
{
    public enum RentalStatus { Out, In };
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public RentalStatus Status { get; set; }
        public DateTime DueDate { get; set; }

        public Book(string Title, string Author)
        {
            this.Title = Title;
            this.Author = Author;
            this.Status = RentalStatus.In;
        }

        //public override string ToString()
        //{
        //}
        }


    
}