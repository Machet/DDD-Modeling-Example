using DDDCinema.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDDCinema.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly INotificationViewRepository _notificationRepository;

        public NotificationController(INotificationViewRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var data = _notificationRepository.GetNotificationsForUser(Guid.Parse(User.Identity.Name));
            return View(data);
        }
    }
}