using System;
using System.Web.Mvc;
using DDDCinema.Application.Presentation.Audit;
using DDDCinema.Common;

namespace DDDCinema.Controllers
{
	[Authorize]
	public class NotificationController : Controller
	{
		private readonly INotificationViewRepository _notificationRepository;
		private readonly ICurrentUserProvider _userProvider;

		public NotificationController(INotificationViewRepository notificationRepository, ICurrentUserProvider userProvider)
		{
			_notificationRepository = notificationRepository;
			_userProvider = userProvider;
		}

		[HttpGet]
		public ActionResult Index()
		{
			var data = _notificationRepository.GetNotificationsForUser(_userProvider.GetUserId().Value);
			return View(data);
		}
	}
}