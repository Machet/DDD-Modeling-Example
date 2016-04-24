using System;
using DDDCinema.Promotions.Granting;

namespace DDDCinema.Promotions.ReceiveConditions
{
    public class WatchAtSpecificDay : ReceiveCondition
    {
        public DateTime DayToWatch { get; private set; }

		protected WatchAtSpecificDay() { }

		public WatchAtSpecificDay(DateTime dayToWatch)
        {
            DayToWatch = dayToWatch;
        }

        public override bool IsSatisfiedFor(Visitor visitor, IVisitorHistoryRepository historyService)
        {
            return historyService.HasWatchedAnyMovie(visitor, DayToWatch);
        }
    }
}
