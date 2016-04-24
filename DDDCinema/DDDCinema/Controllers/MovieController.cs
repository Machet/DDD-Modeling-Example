using System;
using System.Web.Mvc;
using DDDCinema.Application.Presentation.Movies;

namespace DDDCinema.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly IMovieViewRepository _repository;

        public MovieController(IMovieViewRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_repository.GetMovies(DateTime.Now));
        }

        [HttpGet]
        [Authorize]
        public ActionResult ChooseSeat(int seanseId)
        {
            return View(_repository.GetRoomBySeanse(seanseId));
        }
    }
}