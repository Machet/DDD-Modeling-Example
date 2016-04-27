using DDDCinema.Common;
using System;

namespace DDDCinema.Movies
{
    public class SeatAssignedToUser : IDomainEvent
    {
        public int SeanseId { get; internal set; }
        public Guid UserId { get; internal set; }
        public Seat Seat { get; internal set; }
    }
}