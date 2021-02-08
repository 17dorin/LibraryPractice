using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject
{
    class MusicCD : Media
    {
        public string Artist { get; set; }
        public string Album { get; set; }

        public MusicCD(string Artist, string Album) : base()
        {
            this.Artist = Artist;
            this.Album = Album;
        }

        /// <summary>
        /// Overload Method intended for use by the FILE IO 
        /// </summary>
        public MusicCD(string Artist, string Album, string Status, string DueDate)
        {
            this.Artist = Artist;
            this.Album = Album;
            this.Status = (RentalStatus)Enum.Parse(typeof(RentalStatus), Status);
            DateTime dueDate = DateTime.Parse(DueDate);
            this.DueDate = dueDate;
        }

        //Both CheckOut and Return are called within Catalog
        public override void CheckOut()
        {
            DateTime timeOfCheckOut = DateTime.Now;
            DateTime dueDate = new DateTime(timeOfCheckOut.Year, timeOfCheckOut.Month, timeOfCheckOut.Day + 7);


            DueDate = dueDate;
            Status = RentalStatus.Out;
        }

        public override string ToString()
        {
            return $"{Artist}, {Album}, {Status}, {DueDate}";
        }

        public override string PrintSearchInfo()
        {
            return $"Artist: \"{Artist}\" \n\t\t\tAlbum: {Album} \n\t\t\tStatus: {Status}";
        }

        public override string PrintCheckOutInfo()
        {
            return $"\n\n\t\t\tYou checked out {Album}.\n\t\t\tIt's due by {DueDate}";
        }
    }
}
