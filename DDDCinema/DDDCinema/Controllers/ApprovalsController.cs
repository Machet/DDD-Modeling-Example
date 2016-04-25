using System;
using System.Web.Mvc;
using DDDCinema.Application.Presentation.Promotions;
using DDDCinema.Application.Promotions;
using DDDCinema.Common;

namespace DDDCinema.Controllers
{
	[Authorize]
    public class ApprovalsController : Controller
    {
        private readonly IApprovalsViewRepository _repository;
		private readonly ICurrentUserProvider _userProvider;
		private readonly ICommandHandler<ApprovePromotionDraftCommand> _approveHandler;
        private readonly ICommandHandler<RejectPromotionDraftCommand> _rejectHandler;

		public ApprovalsController(
			IApprovalsViewRepository repository,
			ICurrentUserProvider userProvider,
			ICommandHandler<ApprovePromotionDraftCommand> approveHandler,
            ICommandHandler<RejectPromotionDraftCommand> rejectHandler)
        { 
            _repository = repository;
			_userProvider = userProvider;
			_approveHandler = approveHandler;
			_rejectHandler = rejectHandler;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_repository.GetApprovalsView(_userProvider.GetUserId().Value));
        }

		[HttpGet]
		public ActionResult Approve(Guid id)
		{
			return View(_repository.GetDraftNameForApprovalProcess(id));
		}

		[HttpPost]
		public ActionResult Approve(ApprovePromotionDraftCommand command)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			_approveHandler.Handle(command);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Reject(Guid id)
		{
			return View(_repository.GetDraftNameForApprovalProcess(id));
		}

		[HttpPost]
		public ActionResult Reject(RejectPromotionDraftCommand command)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			_rejectHandler.Handle(command);
			return RedirectToAction("Index");
		}
	}
}