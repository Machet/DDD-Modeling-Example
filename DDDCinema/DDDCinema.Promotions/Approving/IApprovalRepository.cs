using System;

namespace DDDCinema.Promotions.Approving
{
    public interface IApprovalRepository
    {
        ApprovalProcess GetProcess(Guid approvalProcessId);
        void Store(ApprovalProcess approvalProcess);
        ApprovalProcess GetProcessByRequest(object approvalRequestId);
    }
}