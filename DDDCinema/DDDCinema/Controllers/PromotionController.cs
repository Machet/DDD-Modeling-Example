using System;
using System.Web.Mvc;
using DDDCinema.Application.Presentation.Promotions;
using DDDCinema.Application.Promotions;
using DDDCinema.Common;

namespace DDDCinema.Controllers
{
	[Authorize]
	public class PromotionController : Controller
	{
		private readonly IPromotionsViewRepository _repository;
		private readonly ICurrentUserProvider _userProvider;
		private readonly ICommandHandler<CreatePromotionCommand> _createPromotionHandler;
		private readonly ICommandHandler<RenamePromotionCommand> _renamePromotionHandler;
		private readonly ICommandHandler<SetValidityDatesCommand> _changeDatesHandler;

		public PromotionController(
			IPromotionsViewRepository repository, 
			ICurrentUserProvider userProvider, 
			ICommandHandler<CreatePromotionCommand> createPromotionHandler,
			ICommandHandler<RenamePromotionCommand> renamePromotionHandler,
			ICommandHandler<SetValidityDatesCommand> changeDatesHandler)
		{
			_repository = repository;
			_userProvider = userProvider;
			_createPromotionHandler = createPromotionHandler;
			_renamePromotionHandler = renamePromotionHandler;
			_changeDatesHandler = changeDatesHandler;
		}

		[HttpGet]
		public ActionResult Index()
		{
			return View(_repository.GetPromotions(_userProvider.GetUserId().Value));
		}

		[HttpGet]
		public ActionResult New()
		{
			return View(new CreatePromotionCommand());
		}

		[HttpPost]
		public ActionResult New(CreatePromotionCommand command)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			command.PromotionId = Guid.NewGuid();
			_createPromotionHandler.Handle(command);

			return RedirectToAction("Details", new { id = command.PromotionId });
		}

		[HttpGet]
		public ActionResult Details(Guid id)
		{
			PromotionDetailsDTO details = _repository.GetPromotionDetails(id);
			return View(details);
		}

		[HttpGet]
		public ActionResult Rename(Guid id)
		{
			return View(new RenamePromotionCommand() { PromotionId = id });
		}

		[HttpPost]
		public ActionResult Rename(RenamePromotionCommand command)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			_renamePromotionHandler.Handle(command);

			return RedirectToAction("Details", new { id = command.PromotionId });
		}

		[HttpGet]
		public ActionResult SetValidityDates(Guid id)
		{
			return View(new SetValidityDatesCommand() { PromotionId = id });
		}

		[HttpPost]
		public ActionResult SetValidityDates(SetValidityDatesCommand command)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			_changeDatesHandler.Handle(command);

			return RedirectToAction("Details", new { id = command.PromotionId });
		}
	}
}