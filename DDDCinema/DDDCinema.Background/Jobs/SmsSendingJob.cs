using DDDCinema.Movies.Notifications;
using Quartz;
using System.Collections.Generic;
using DDDCinema.Common.Notifications;

namespace DDDCinema.Background.Jobs
{
    public class SmsSendingJob : IJob
    {
        private readonly INotificationQueue _notificationQueue;
        private readonly ISmsSender _smsSender;

        public SmsSendingJob(INotificationQueue notificationQueue, ISmsSender smsSender)
        {
            _notificationQueue = notificationQueue;
            _smsSender = smsSender;
        }

        public void Execute(IJobExecutionContext context)
        {
            List<SmsToSend> smsTosend = _notificationQueue.GetUnsentSmses();
            foreach (var sms in smsTosend)
            {
                _smsSender.SendSms(sms);
                sms.HasBeenSent = true;
            }
        }
    }
}
