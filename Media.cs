using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject
{
    public enum RentalStatus { Out, In };

    class Media
    {
        private RentalStatus _status;
        private DateTime _dueDate;

        public RentalStatus Status
        {
            get { return _status;  }
            set
            {
                if (value == RentalStatus.Out)
                {
                    _dueDate = UpdateDueDate();
                }
            }
        }

        public DateTime DueDate { get; set; }

        public Media()
        {
            _status = RentalStatus.In;
        }
        public DateTime UpdateDueDate()
        {
            DateTime timeOfCheckOut = DateTime.Now;
            DateTime dueDate = new DateTime(timeOfCheckOut.Year, timeOfCheckOut.Month, timeOfCheckOut.Day + 14);

            return dueDate;
        }
    }
}
