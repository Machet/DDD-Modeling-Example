using DDDCinema.Presentation;
using System;
using System.Web.Mvc;

namespace DDDCinema.Controllers
{
    public class AuditController : Controller
    {
        private readonly IAuditViewRepository _auditRepository;

        public AuditController(IAuditViewRepository auditRepository)
        {
            _auditRepository = auditRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var data = _auditRepository.GetAuditEntriesForUser(Guid.Parse(User.Identity.Name));
            return View(data);
        }
    }
}