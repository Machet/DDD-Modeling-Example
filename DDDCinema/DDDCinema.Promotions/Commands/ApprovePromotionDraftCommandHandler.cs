using System;
using DDDCinema.Common;
using DDDCinema.Promotions.Approving;

namespace DDDCinema.Promotions.Commands
{
	public class ApproveDraft : ICommand
	{
		public Guid ApprovalProcessId { get; set; }
	}

	public class ApproveDraftCommandHandler : ICommandHandler<ApproveDraft>
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

		public void Handle(ApproveDraft command)
		{
			Editor editor = _userInRoleRepository.GetEditor(_currentUserProvider.GetUserId().Value);
			ApprovalProcess process = _approvalRepository.GetApprovalProcess(command.ApprovalProcessId);
			process.ApproveFor(editor);
		}
	}

}
