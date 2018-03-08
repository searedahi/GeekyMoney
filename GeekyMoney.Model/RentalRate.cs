using System;
using GeekyMoney.Enums;

namespace GeekyMoney.Model
{
    public class RentalRate : IRentalRate
    {
        // Data Persisted Properties
        public decimal RentalAmount { get; set; }
        public ScheduleType Schedule { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        // Calculated Properties
        private int DaysInYear = 365;
        public int DaysApplied
        {
            get
            {
                return (BeginDate - EndDate).Days;
            }
        }
        public decimal AnnualWeight
        {
            get
            {
                return DaysApplied / DaysInYear;
            }
        }
    }
}
