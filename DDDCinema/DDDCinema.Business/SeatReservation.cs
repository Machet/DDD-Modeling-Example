using System;

namespace DDDCinema.Movies
{
    public class SeatAssignment
    {
        public int SeatAssignmentId { get; set; }
        public int SeanseId { get; set; }
        public Guid UserId { get; set; }
        public int Row { get; set; }
        public int SeatNumber { get; set; }
    }
}
