using System;

namespace DDDCinema.Presentation
{
    public interface INotificationViewRepository
    {
        NotificationsDTO GetNotificationsForUser(Guid userId);
    }
}
