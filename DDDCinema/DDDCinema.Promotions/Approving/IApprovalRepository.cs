using System;

namespace DDDCinema.Promotions.Approving
{
    public interface IApprovalRepository
    {
		ApprovalProcess GetApprovalProcess(Guid approvalProcessId);
		void Store(ApprovalProcess approvalProcess);
	}
}