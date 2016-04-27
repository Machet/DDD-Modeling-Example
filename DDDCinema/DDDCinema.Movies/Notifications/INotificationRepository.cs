using System.Collections.Generic;

namespace DDDCinema.Movies.Notifications
{
    public interface INotificationRepository
    {
        void QueueMail(MailToSend mailToSend);
        void QueueSms(SmsToSend smsSettings);
        List<MailToSend> GetUnsentMails();
        List<SmsToSend> GetUnsentSmses();
    }
}
