﻿namespace DDDCinema.Movies.Notifications
{
    public interface ITemplateRepository
    {
        string GetReservationPlainTextMessage(Seanse seanse, Seat seat);
        string GetReservationHtmlMessage(Seanse seanse, Seat seat);
        string GetFreeTicketPlainTextMessage(int freeTicketCount);
        string GetFreeTicketHtmlMessage(int freeTicketCount);
    }
}
