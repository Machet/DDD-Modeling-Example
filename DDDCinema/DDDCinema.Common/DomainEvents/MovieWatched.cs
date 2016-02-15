using DDDCinema.Common;
using System;

namespace DDDCinema.Common
{
    public class MovieWatched : IDomainEvent
    {
        public Guid MovieId { get; private set; }
        public Guid UserId { get; private set; }
        public bool IsPremiere { get; private set; }
        public DateTime WatchedAt { get; private set; }

        public MovieWatched(Guid userId, Guid movieId, bool isPremiere, DateTime watchedAt)
        {
            UserId = userId;
            MovieId = movieId;
            IsPremiere = isPremiere;
            WatchedAt = watchedAt;
        }
    }
}