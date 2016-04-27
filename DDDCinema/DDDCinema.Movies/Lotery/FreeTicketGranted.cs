using DDDCinema.Common;
using System;

namespace DDDCinema.Movies.Lotery
{
    public class FreeTicketGranted : IDomainEvent
    {
        public Guid UserId { get; private set; }
        public int CurrentFreeTicketsCount { get; private set; }

        public FreeTicketGranted(Guid userId, int currentFreeTicketsCount)
        {
            UserId = userId;
            CurrentFreeTicketsCount = currentFreeTicketsCount;
        }
    }
}
