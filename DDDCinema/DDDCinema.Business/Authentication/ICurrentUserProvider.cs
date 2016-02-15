using System;

namespace DDDCinema.Movies.Authentication
{
    public interface ICurrentUserProvider
    {
        string Role { get; }
        Guid? GetUserId();
        void SetUser(Guid id, string role);
    }
}