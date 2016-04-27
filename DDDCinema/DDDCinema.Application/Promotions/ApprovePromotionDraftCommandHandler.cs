using System;
using DDDCinema.Common;
using DDDCinema.Promotions;
using DDDCinema.Promotions.Approving;

namespace DDDCinema.Application.Promotions
{
	public class ApprovePromotionDraftCommand : ICommand
	{
		public Guid ApprovalProcessId { get; set; }
	}

	public class ApproveDraftCommandHandler : ICommandHandler<ApprovePromotionDraftCommand>
	{
		private readonly IApprovalRepository _approvalRepository;
		private readonly IUserInRoleRepository _userInRoleRepository;
		private readonly ICurrentUserProvider _currentUserProvider;

		public ApproveDraftCommandHandler(
			IApprovalRepository approvalRepository,
			IUserInRoleRepository userInRoleRepository,
			ICurrentUserProvider currentUserProvider)
		{
			_approvalRepository = approvalRepository;
			_userInRoleRepository = userInRoleRepository;
			_currentUserProvider = currentUserProvider;
		}

		public void Handle(ApprovePromotionDraftCommand command)
		{
			Editor editor = _userInRoleRepository.GetEditor(_currentUserProvider.GetUserId().Value);
			ApprovalProcess process = _approvalRepository.GetApprovalProcess(command.ApprovalProcessId);
			process.ApproveFor(editor);
		}
	}

}
