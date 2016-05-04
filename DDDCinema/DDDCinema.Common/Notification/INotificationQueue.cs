using System.Collections.Generic;

namespace DDDCinema.Common.Notifications
{
    public interface INotificationQueue
    {
        void QueueMail(MailToSend mailToSend);
        void QueueSms(SmsToSend smsSettings);
        List<MailToSend> GetUnsentMails();
        List<SmsToSend> GetUnsentSmses();
    }
}
