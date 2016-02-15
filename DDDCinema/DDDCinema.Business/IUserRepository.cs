using System;

namespace DDDCinema.Movies
{
    public interface IUserRepository
    {
        User GetUser(Guid userId);
        int GetReservationsCountForUser(Guid userId);
    }
}
