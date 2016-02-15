using DDDCinema.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDCinema.Movies
{
    public class Seanse
    {
        public int SeanseId { get; set; }
        public Guid MovieId { get; set; }
        public int RoomId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public virtual Room Room { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual List<SeatAssignment> SeatAssignments { get; set; }

        public bool HasEnded
        {
            get { return StartTime < DomainTime.Current.Now.TimeOfDay; }
        }

        internal void ReserveSeatForUser(Guid userId, Seat seat)
        {
            if (HasEnded)
            {
                throw new InvalidOperationException("Seanse already ended");
            }

            if (Room.HasSeat(seat))
            {
                throw new InvalidOperationException("This room doesn't have such seat");
            }

            var existingSeat = SeatAssignments
                .FirstOrDefault(a => a.Row == seat.Row && a.SeatNumber == seat.SeatNumber);

            if (existingSeat != null)
            {
                throw new InvalidOperationException("Seat already taken");
            }

            SeatAssignments.Add(new SeatAssignment
            {
                SeanseId = SeanseId,
                Row = seat.Row,
                SeatNumber = seat.SeatNumber,
                UserId = userId
            });

            DomainEventBus.Current.Raise(new SeatAssignedToUser
            {
                SeanseId = SeanseId,
                UserId = userId,
                Seat = seat
            });

            DomainEventBus.Current.Raise(
                new MovieWatched(userId, Movie.MovieId, Movie.IsPremiere, DomainTime.Current.Now));
        }
    }
}
