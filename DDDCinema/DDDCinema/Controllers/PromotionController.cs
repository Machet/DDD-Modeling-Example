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
		private readonly ICommandHandler<SetBenefitCommand> _changeBenefitHandler;
		private readonly ICommandHandler<SetConditionCommand> _changeConditionHandler;
		private readonly ICommandHandler<MarkPromotionAsReadyCommand> _markAsReadyHandler;

        public PromotionController(
			IPromotionsViewRepository repository,
			ICurrentUserProvider userProvider,
			ICommandHandler<CreatePromotionCommand> createPromotionHandler,
			ICommandHandler<RenamePromotionCommand> renamePromotionHandler,
			ICommandHandler<SetValidityDatesCommand> changeDatesHandler,
			ICommandHandler<SetBenefitCommand> changeBenefitHandler,
			ICommandHandler<SetConditionCommand> changeConditionHandler,
			ICommandHandler<MarkPromotionAsReadyCommand> markAsReadyHandler)
		{
			_repository = repository;
			_userProvider = userProvider;
			_createPromotionHandler = createPromotionHandler;
			_renamePromotionHandler = renamePromotionHandler;
			_changeDatesHandler = changeDatesHandler;
			_changeBenefitHandler = changeBenefitHandler;
			_changeConditionHandler = changeConditionHandler;
			_markAsReadyHandler = markAsReadyHandler;
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
			PromotionDetailsDTO details = _repository.GetPromotionDetails(id, _userProvider.GetUserId().Value);
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

		[HttpGet]
		public ActionResult SetBenefit(Guid id)
		{
			return View(_repository.GetSetBenefitView(id));
		}

		[HttpPost]
		public ActionResult SetBenefit([Bind(Prefix = "Command")]SetBenefitCommand command)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			_changeBenefitHandler.Handle(command);

			return RedirectToAction("Details", new { id = command.PromotionId });
		}

		[HttpGet]
		public ActionResult SetCondition(Guid id)
		{
			return View(_repository.GetSetConditionView(id));
		}

		[HttpPost]
		public ActionResult SetCondition([Bind(Prefix = "Command")]SetConditionCommand command)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			_changeConditionHandler.Handle(command);

			return RedirectToAction("Details", new { id = command.PromotionId });
		}

		[HttpGet]
		public ActionResult MarkAsComplete(Guid id)
		{
			return View(_repository.GetPromotionName(id));
		}

		[HttpPost]
		public ActionResult MarkAsComplete(MarkPromotionAsReadyCommand command)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			_markAsReadyHandler.Handle(command);
			return RedirectToAction("Index");
		}
	}
}