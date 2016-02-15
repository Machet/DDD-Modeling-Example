using System;

namespace DDDCinema.Promotions.Approving
{
    public class ApprovalProcessTimeout
    {
        public Guid ApprovalProcessId { get; private set; }

        public ApprovalProcessTimeout(Guid id)
        {
            ApprovalProcessId = id;
        }
    }
}