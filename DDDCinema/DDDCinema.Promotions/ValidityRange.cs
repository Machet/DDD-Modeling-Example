using DDDCinema.Common;
using System;

namespace DDDCinema.Promotions
{
    public class ValidityRange
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public ValidityRange(DateTime startDate, DateTime endDate)
        {
            Require.IsLowerThan(startDate, endDate, "Start date should be before end date");
        }

        public bool StartsAfter(DateTime date)
        {
            return StartDate > date;
        }

        public bool Contains(DateTime date)
        {
            return StartDate < date && EndDate > date;
        }
    }
}