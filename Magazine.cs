using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject
{
    class Magazine : Media
    {
        public string Title { get; set; }
        public string Issue { get; set; }

        public Magazine(string Title, string Issue) : base()
        {
            this.Title = Title;
            this.Issue = Issue;
        }

        /// <summary>
        /// Overload Method intended for use by the FILE IO 
        /// </summary>
        public Magazine(string Title, string Issue, string Status, string DueDate)
        {
            this.Title = Title;
            this.Issue = Issue;
            this.Status = (RentalStatus)Enum.Parse(typeof(RentalStatus), Status);
            DateTime dueDate = DateTime.Parse(DueDate);
            this.DueDate = dueDate;
        }

        //Both CheckOut and Return are called within Catalog
        public override void CheckOut()
        {
            DateTime timeOfCheckOut = DateTime.Now;
            DateTime dueDate = new DateTime(timeOfCheckOut.Year, timeOfCheckOut.Month, timeOfCheckOut.Day + 2);


            DueDate = dueDate;
            Status = RentalStatus.Out;
        }

        public override string ToString()
        {
            return $"{Title}, {Issue}, {Status}, {DueDate}";
        }

        public override string PrintInfo()
        {
            return $"Title: \"{Title}\" \n\t\t\tIssue: {Issue} \n\t\t\tStatus: {Status}";
        }
    }
}
