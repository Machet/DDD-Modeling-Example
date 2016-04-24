using System;
using DDDCinema.Common;

namespace DDDCinema.Promotions
{
	public class ValidityRange
	{
		public DateTime? StartDate { get; protected set; }
		public DateTime? EndDate { get; protected set; }

		protected ValidityRange()
		{
		}

		public bool StartsAfter(DateTime date)
		{
			return StartDate > date;
		}

		public bool Contains(DateTime date)
		{
			return StartDate < date && EndDate > date;
		}

		public bool IsDefined()
		{
			return StartDate.HasValue && EndDate.HasValue;
		}

		public static ValidityRange LimitedValidityRange(DateTime startDate, DateTime endDate)
		{
			Require.IsLowerThan(startDate, endDate, "Start date should be before end date");
			return new ValidityRange
			{
				StartDate = startDate,
				EndDate = endDate
			};
        }

		public static ValidityRange NotSpecified()
		{
			return new ValidityRange
			{
				StartDate = null,
				EndDate = null
			};
		}
	}
}