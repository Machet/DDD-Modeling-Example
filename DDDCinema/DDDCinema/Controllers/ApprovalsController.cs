using System.Web.Mvc;
using DDDCinema.Application.Presentation.Promotions;

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