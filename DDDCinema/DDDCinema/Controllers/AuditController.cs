using System;
using System.Web.Mvc;
using DDDCinema.Application.Presentation.Audit;
using DDDCinema.Common;

namespace DDDCinema.Controllers
{
	[Authorize]
    public class AuditController : Controller
    {
        private readonly IAuditViewRepository _auditRepository;
        private readonly ICurrentUserProvider _currentUserProvider;

		public AuditController(IAuditViewRepository auditRepository, ICurrentUserProvider currentUserProvider)
        {
            _auditRepository = auditRepository;
			_currentUserProvider = currentUserProvider;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var data = _auditRepository.GetAuditEntriesForUser(_currentUserProvider.GetUserId().Value);
            return View(data);
        }
    }
}