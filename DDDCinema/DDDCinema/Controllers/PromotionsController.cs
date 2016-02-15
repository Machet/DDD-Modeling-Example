using DDDCinema.Presentation.Promotions;
using System.Web.Mvc;

namespace DDDCinema.Controllers
{
    [Authorize]
    public class PromotionsController : Controller
    {
        private readonly IPromotionsViewRepository _repository;

        public PromotionsController(IPromotionsViewRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_repository.GetPromotions());
        }
    }
}