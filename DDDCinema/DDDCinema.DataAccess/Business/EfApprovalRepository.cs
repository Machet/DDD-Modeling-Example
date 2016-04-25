using System;
using System.Data.Entity;
using System.Linq;
using DDDCinema.Promotions.Approving;

namespace DDDCinema.DataAccess.Business
{
	public class EfApprovalRepository : IApprovalRepository
	{
		private readonly PromotionsContext _context;

		public EfApprovalRepository(PromotionsContext context)
		{
			_context = context;
		}

		public ApprovalProcess GetApprovalProcess(Guid approvalProcessId)
		{
			return _context.ApprovalProcesses
				.Include(a => a.ApprovalRequests)
				.FirstOrDefault(a => a.Id == approvalProcessId);
		}

		public void Store(ApprovalProcess approvalProcess)
		{
			_context.ApprovalProcesses.Add(approvalProcess);
		}
	}
}
