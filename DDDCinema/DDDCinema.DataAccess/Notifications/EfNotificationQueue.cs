﻿using System.Collections.Generic;
using System.Linq;
using DDDCinema.Common.Notifications;

namespace DDDCinema.DataAccess.Movies
{
	public class EfNotificationRepository : INotificationQueue
	{
		private readonly InfrastructureContext _context;

		public EfNotificationRepository(InfrastructureContext context)
		{
			_context = context;
		}

		public List<MailToSend> GetUnsentMails()
		{
			return _context.MailsToSend.Where(m => !m.HasBeenSent).ToList();
		}

		public List<SmsToSend> GetUnsentSmses()
		{
			return _context.SmsesToSend.Where(s => !s.HasBeenSent).ToList();
		}

		public void QueueMail(MailToSend mailToSend)
		{
			_context.MailsToSend.Add(mailToSend);
		}

		public void QueueSms(SmsToSend smsToSend)
		{
			_context.SmsesToSend.Add(smsToSend);
		}
	}
}
