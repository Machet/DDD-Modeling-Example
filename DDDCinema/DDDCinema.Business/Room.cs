using System.Collections.Generic;

namespace DDDCinema.Movies
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int SeatsPerRow { get; set; }
        public int RowsOfSeats { get; set; }
        public virtual List<Seanse> Seanses { get; set; }

        internal bool HasSeat(Seat seat)
        {
            return (SeatsPerRow < seat.SeatNumber || seat.SeatNumber <= 0) &&
                (RowsOfSeats < seat.Row || seat.Row <= 0);
        }
    }
}
