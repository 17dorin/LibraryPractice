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

        /// <summary>
        /// Overload Method intended for use by the FILE IO 
        /// </summary>
        public Book(string Title, string Author, string Status, string DueDate )
        {
            this.Title = Title;
            this.Author = Author;
            this.Status = (RentalStatus)Enum.Parse(typeof(RentalStatus), Status);
            DateTime dueDate = DateTime.Parse(DueDate);
            this.DueDate = dueDate;
        }

        //Both CheckOut and Return are called within Catalog
        public override void CheckOut()
        {
            DateTime timeOfCheckOut = DateTime.Now;
            DateTime dueDate = new DateTime(timeOfCheckOut.Year, timeOfCheckOut.Month, timeOfCheckOut.Day + 14);


            DueDate = dueDate;
            Status = RentalStatus.Out;
        }

        public override string ToString()
        {
            return $"{Title}, {Author}, {Status}, {DueDate}";
        }

        public override string PrintInfo()
        {
            return $"\"{Title}\" \n\t\t\tAuthor: {Author} \n\t\t\tStatus: {Status}";
        }
    }
}
