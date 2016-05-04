using System;
using System.Collections.Generic;
using DDDCinema.Common;
using DDDCinema.Common.Notifications;

namespace DDDCinema.Movies.Notifications
{
	public class SmsNotificationSender : INotificationSender
	{
		private readonly INotificationQueue _notificationQueue;
		private readonly ITemplateRepository _templateRepository;
		private readonly Dictionary<Guid, SmsToSend> _currentSmsesToSend;

		public SmsNotificationSender(INotificationQueue notificationQueue, ITemplateRepository templateRepository)
		{
			_notificationQueue = notificationQueue;
			_templateRepository = templateRepository;
			_currentSmsesToSend = new Dictionary<Guid, SmsToSend>();
		}

		public void NotifyThatReservationIsReady(User user, Seanse seanse, Seat seat)
		{
			string message = _templateRepository.GetReservationPlainTextMessage(seanse, seat);
			if (!CanSendSmsNotification(user))
			{
				return;
			}

			SmsToSend queuedSms = GetSmsFromQueue(user.Id);
			if (queuedSms != null)
			{
				queuedSms.Message = message + " " + queuedSms.Message;
			}
			else
			{
				QueueSms(user, message);
			}
		}

		public void NotifyThatFreeTicketGranted(User user, int freeTicketCount)
		{
			string message = _templateRepository.GetFreeTicketPlainTextMessage(freeTicketCount);
			if (!CanSendSmsNotification(user))
			{
				return;
			}

			SmsToSend queuedSms = GetSmsFromQueue(user.Id);
			if (queuedSms != null)
			{
				queuedSms.Message = queuedSms.Message + " " + message;
			}
			else
			{
				QueueSms(user, message);
			}
		}

		private static bool CanSendSmsNotification(User user)
		{
			return !string.IsNullOrEmpty(user.MobilePhone) && user.ContactBySmslAllowed;
		}

		private SmsToSend GetSmsFromQueue(Guid userId)
		{
			return _currentSmsesToSend.ContainsKey(userId)
				? _currentSmsesToSend[userId]
				: null;
		}

		private void QueueSms(User user, string message)
		{
			var smsToSend = new SmsToSend
			{
				UserId = user.Id,
				PhoneNumber = user.MobilePhone,
				Message = message,
				CreationTime = DomainTime.Current.Now
			};

			_currentSmsesToSend[user.Id] = smsToSend;
			_notificationQueue.QueueSms(smsToSend);
		}
	}
}