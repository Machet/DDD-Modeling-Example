using System;

namespace DDDCinema.Application.Presentation.Audit
{
    public interface INotificationViewRepository
    {
        NotificationsDTO GetNotificationsForUser(Guid userId);
    }
}
