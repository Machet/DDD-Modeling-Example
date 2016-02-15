using DDDCinema.Common;
using System;
using System.Collections.Generic;

namespace DDDCinema.Promotions.Granting
{
    public interface IVisitorHistoryRepository
    {
        bool HasAttendedPremiere(Visitor visitor, ValidityRange validityRange, int requiredCount);
        bool HasWatchedAnyMovie(Visitor visitor, DateTime dayToWatch);
        bool HasWatchedMovies(Visitor visitor, List<Movie> moviesToWatch);
        void AddNewEntry(MovieWatched @event);
    }
}
