using System;
using System.Collections.Generic;
using DDDCinema.Common;
using DDDCinema.Promotions.ReceiveConditions;

namespace DDDCinema.Promotions.Granting
{
	public interface IVisitorHistoryRepository
	{
		bool HasAttendedPremiere(Visitor visitor, ValidityRange validityRange, int requiredCount);
		bool HasWatchedAnyMovie(Visitor visitor, DateTime dayToWatch);
		bool HasWatchedMovies(Visitor visitor, List<MovieToWatch> moviesToWatch);
		void AddNewEntry(MovieWatched @event);
	}
}
