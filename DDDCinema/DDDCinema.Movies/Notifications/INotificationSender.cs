namespace DDDCinema.Movies.Notifications
{
    public interface INotificationSender
    {
        void NotifyThatReservationIsReady(User user, Seanse seanse, Seat seat);
        void NotifyThatFreeTicketGranted(User user, int freeTicketCount);
    }
}