using System;

namespace DDDCinema.Movies.Notifications
{
    public class SmsToSend
    {
        public int SmsToSendId { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
        public bool HasBeenSent { get; set; }
        public DateTime CreationTime { get; set; }
    }
}