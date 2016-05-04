using System.Collections.Generic;
using DDDCinema.Common.Notifications;
using Quartz;

namespace DDDCinema.Background.Jobs
{
	public class EmailSendingJob : IJob
	{
		private readonly INotificationQueue _notificationQueue;
		private readonly IMailSender _mailSender;

		public EmailSendingJob(INotificationQueue notificationQueue, IMailSender mailSender)
		{
			_notificationQueue = notificationQueue;
			_mailSender = mailSender;
		}

		public void Execute(IJobExecutionContext context)
		{
			List<MailToSend> mailsToSend = _notificationQueue.GetUnsentMails();
			foreach (var mail in mailsToSend)
			{
				_mailSender.SendMail(mail);
				mail.HasBeenSent = true;
			}
		}
	}
}
