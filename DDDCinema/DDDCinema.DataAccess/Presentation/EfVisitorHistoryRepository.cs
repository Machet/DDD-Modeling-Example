using System;
using System.Collections.Generic;
using DDDCinema.Common;
using DDDCinema.Promotions;
using DDDCinema.Promotions.Granting;
using DDDCinema.Promotions.ReceiveConditions;

namespace DDDCinema.DataAccess.Presentation
{
	public class EfVisitorHistoryRepository : IVisitorHistoryRepository
	{
		public void AddNewEntry(MovieWatched @event)
		{
		}

		public bool HasAttendedPremiere(Visitor visitor, ValidityRange validityRange, int requiredCount)
		{
			return true;
		}

		public bool HasWatchedAnyMovie(Visitor visitor, DateTime dayToWatch)
		{
			return true;
		}

		public bool HasWatchedMovies(Visitor visitor, List<MovieToWatch> moviesToWatch)
		{
			return true;
		}
	}
}
