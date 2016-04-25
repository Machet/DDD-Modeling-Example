using System;

namespace DDDCinema.Application.Presentation.Promotions
{
	public interface IApprovalsViewRepository
	{
		ApprovalsView GetApprovalsView(Guid userId);
		PromotionDraftNameDTO GetDraftNameForApprovalProcess(Guid processId);
	}
}
