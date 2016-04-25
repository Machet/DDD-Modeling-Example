using System;
using DDDCinema.Common;
using DDDCinema.Promotions;
using DDDCinema.Promotions.Approving;

namespace DDDCinema.Application.Promotions
{
	public class RejectPromotionDraftCommand : ICommand
	{
		public Guid ApprovalProcessId { get; set; }
		public string Reason { get; internal set; }
	}

	public class RejectDraftCommandHandler : ICommandHandler<RejectPromotionDraftCommand>
	{
		private readonly IApprovalRepository _approvalRepository;
		private readonly IUserInRoleRepository _userInRoleRepository;
		private readonly ICurrentUserProvider _currentUserProvider;

		public RejectDraftCommandHandler(
			IApprovalRepository approvalRepository,
			IUserInRoleRepository userInRoleRepository,
			ICurrentUserProvider currentUserProvider)
		{
			_approvalRepository = approvalRepository;
			_userInRoleRepository = userInRoleRepository;
			_currentUserProvider = currentUserProvider;
		}

		public void Handle(RejectPromotionDraftCommand command)
		{
			Editor editor = _userInRoleRepository.GetEditor(_currentUserProvider.GetUserId().Value);
			ApprovalProcess process = _approvalRepository.GetApprovalProcess(command.ApprovalProcessId);
			process.RejectFor(editor, command.Reason);
		}
	}

}
