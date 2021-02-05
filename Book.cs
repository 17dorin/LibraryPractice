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
            this.DueDate = new DateTime(DateTime.MaxValue.Ticks);
        }


        public void CheckOut()
        {
            DateTime timeOfCheckOut = DateTime.Now;
            DateTime dueDate = new DateTime(timeOfCheckOut.Year, timeOfCheckOut.Month, timeOfCheckOut.Day + 14);

            this.DueDate = dueDate;
            this.Status = RentalStatus.Out;
        }
    }
}
