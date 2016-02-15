using System;

namespace DDDCinema.Presentation
{
    public interface ILoginViewRepository
    {
        LoginAttemptDTO GetLoginAttemptById(Guid id);
    }
}
