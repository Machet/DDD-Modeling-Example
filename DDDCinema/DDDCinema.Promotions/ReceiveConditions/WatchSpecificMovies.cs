using DDDCinema.Common;
using DDDCinema.Promotions.Granting;
using System.Collections.Generic;
using System.Linq;

namespace DDDCinema.Promotions.ReceiveConditions
{
    public class WatchSpecificMovies : ReceiveCondition
    {
        public List<Movie> MoviesToWatch { get; private set; }

		protected WatchSpecificMovies() { }

		public WatchSpecificMovies(List<Movie> moviesToWatch)
        {
            Require.NotNull(moviesToWatch, nameof(moviesToWatch));
            Require.IsTrue(() => moviesToWatch.Count > 0, "At least one movie required");
            MoviesToWatch = moviesToWatch;
			Description = "Watch all movies: " + string.Join(" ,", moviesToWatch.Select(m => m.Name));
        }

        public override bool IsSatisfiedFor(Visitor visitor, IVisitorHistoryRepository historyService)
        {
            return historyService.HasWatchedMovies(visitor, MoviesToWatch);
        }
    }
}
