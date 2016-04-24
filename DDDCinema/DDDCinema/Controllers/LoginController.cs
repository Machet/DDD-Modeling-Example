using System;
using System.Web.Mvc;
using DDDCinema.Common;
using DDDCinema.CompositionRoot;
using DDDCinema.Movies.Commands;
using DDDCinema.Presentation;

namespace DDDCinema.Controllers
{
	public class LoginController : Controller
	{
		private readonly ILoginViewRepository _loginRepository;
		private readonly ICommandHandler<LoginCommand> _loginHandler;
		private readonly ContextUserProvider _userProvider;

		public LoginController(ILoginViewRepository loginRepository, ContextUserProvider userProvider, ICommandHandler<LoginCommand> loginHandler)
		{
			_loginHandler = loginHandler;
			_loginRepository = loginRepository;
			_userProvider = userProvider;
		}

		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Logout()
		{
			_userProvider.Clear();
			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public ActionResult Index(string userName, string password, string returnUrl)
		{
			Guid attemptId = Guid.NewGuid();

			_loginHandler.Handle(new LoginCommand
			{
				AttemptId = attemptId,
				Username = userName,
				Password = password
			});

			LoginAttemptDTO result = _loginRepository.GetLoginAttemptById(attemptId);
			if (result.Succeeded)
			{
				_userProvider.SetUser(result.UserId.Value, result.UserRole);
				return !string.IsNullOrEmpty(returnUrl)
					? (ActionResult)Redirect(returnUrl)
					: RedirectToAction("Index", "Home");
			}

			ModelState.AddModelError("LoginFailed", result.Message);
			return View();
		}
	}
}