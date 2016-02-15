using DDDCinema.Movies;
using System;
using System.Linq;

namespace DDDCinema.DataAccess.Movies
{
    public class EfUserRepository : IUserRepository
    {
        private readonly CinemaContext _context;

        public EfUserRepository(CinemaContext context)
        {
            _context = context;
        }

        public int GetReservationsCountForUser(Guid userId)
        {
            return _context.SeatAssignments.Count(s => s.UserId == userId);
        }

        public User GetUser(Guid userId)
        {
            return _context.Users.Find(userId);
        }
    }
}
