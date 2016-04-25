using System;
using System.Linq;
using DDDCinema.Application.Presentation.Promotions;
using DDDCinema.Common;
using DDDCinema.Promotions.Approving;

namespace DDDCinema.DataAccess.Presentation
{
	public class EfApprovalsViewRepository : IApprovalsViewRepository
	{
		private readonly DDDCinemaReadonly _context;
		private readonly ICurrentUserProvider _provider;

		public EfApprovalsViewRepository(DDDCinemaReadonly context, ICurrentUserProvider provider)
		{
			_context = context;
			_provider = provider;
		}

		public ApprovalsView GetApprovalsView(Guid userId)
		{
			var requests = _context.ApprovalRequests
				.Where(r => r.Editor_Id == userId && r.Status == (int)ApprovalStatus.Pending)
				.Select(r => new ApprovalRequestsDTO
				{
					ProcessId = r.ApprovalProcess.Id,
					PromotionId = r.ApprovalProcess.PromotionId,
					PromotionName = _context.PromotionDrafts.Where(p => p.Id == r.ApprovalProcess.PromotionId).Select(p => p.Name).FirstOrDefault(),
					OwnerName = _context.PromotionDrafts.Where(p => p.Id == r.ApprovalProcess.PromotionId).Select(p => p.Owner_Name).FirstOrDefault(),
					RequestId = r.Id
				}).ToList();

			return new ApprovalsView
			{
				Requests = requests
			};
		}

		public PromotionDraftNameDTO GetDraftNameForApprovalProcess(Guid processId)
		{
			return _context.ApprovalProcesses
				.Where(r => r.Id == processId)
				.Select(r => new PromotionDraftNameDTO
				{
					PromotionId = r.PromotionId,
					Name = _context.PromotionDrafts.Where(p => p.Id == r.PromotionId).Select(p => p.Name).FirstOrDefault(),
				}).FirstOrDefault();
		}
	}
}
