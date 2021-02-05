using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject
{
    public enum RentalStatus { Out, In };

    class Media
    {
        public RentalStatus Status { get; set; }
        public DateTime DueDate { get; set; }

        public Media()
        {
            Status = RentalStatus.In;
        }
    }
}
