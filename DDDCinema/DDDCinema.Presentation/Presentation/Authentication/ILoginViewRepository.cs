using System;

namespace DDDCinema.Application.Presentation.Authentication
{
    public interface ILoginViewRepository
    {
        LoginAttemptDTO GetLoginAttemptById(Guid id);
    }
}
