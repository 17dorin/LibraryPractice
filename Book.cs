using System;
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
            this.Status = RentalStatus.In;
            this.DueDate = new DateTime(DateTime.MaxValue.Ticks);
        }
        //Both CheckOut and Return are called within Catalog
        public void CheckOut()
        {
            DateTime timeOfCheckOut = DateTime.Now;
            DateTime dueDate = new DateTime(timeOfCheckOut.Year, timeOfCheckOut.Month, timeOfCheckOut.Day + 14);


            DueDate = dueDate;
            Status = RentalStatus.Out;
        }

        public void Return()
        {
            DueDate = DateTime.MaxValue;
            Status = RentalStatus.In;
        }
    }
}
