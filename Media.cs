using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject
{
    //Base class to derive other media from
    public enum RentalStatus { Out, In };

    abstract class Media
    {
        public RentalStatus Status { get; set; }
        public DateTime DueDate { get; set; }

        public Media()
        {
            Status = RentalStatus.In;
        }
        public abstract void CheckOut();

        public void Return()
        {
            DueDate = DateTime.MaxValue;
            Status = RentalStatus.In;
        }
    }
}
