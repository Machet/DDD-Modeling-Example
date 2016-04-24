using System.Web.Mvc;
using DDDCinema.Common;

namespace DDDCinema.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		private readonly ICurrentUserProvider _currentUserProvider;

		public HomeController(ICurrentUserProvider currentUserProvider)
		{
			_currentUserProvider = currentUserProvider;
		}

		[HttpGet]
		public ActionResult Index()
		{
			if (_currentUserProvider.GetRole() == "User")
			{
				return RedirectToAction("Index", "Movie");
			}

			if (_currentUserProvider.GetRole() == "Editor")
			{
				return RedirectToAction("Index", "Promotion");
			}

			return RedirectToAction("Index", "Login");
		}
	}
}