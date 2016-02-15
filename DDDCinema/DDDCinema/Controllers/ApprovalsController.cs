using DDDCinema.Presentation;
using DDDCinema.Presentation.Promotions;
using System;
using System.Web.Mvc;

namespace DDDCinema.Controllers
{
    public class ApprovalsController : Controller
    {
        private readonly IApprovalsViewRepository _repository;

        public ApprovalsController(IApprovalsViewRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_repository.GetApprovals());
        }
    }
}