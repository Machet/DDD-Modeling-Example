using System.Collections.Generic;

namespace DDDCinema.Application.Presentation.Promotions
{
    public class ApprovalsView
    {
        public List<ApprovalStatusDTO> Approvals { get; set; }
        public List<ApprovalRequestsDTO> Requests { get; set; }
    }
}