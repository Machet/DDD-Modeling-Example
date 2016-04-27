using System;

namespace DDDCinema.Movies.Notifications
{
    public class MailToSend
    {
        public int MailToSendId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public bool HasBeenSent { get; set; }
        public DateTime CreationTime { get; set; }
    }
}