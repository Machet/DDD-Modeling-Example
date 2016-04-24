using System;

namespace DDDCinema.Application.Presentation.Promotions
{
    public class ApprovalRequestsDTO
    {
        public Guid RequestId { get; set; }
        public Guid PromotionId { get; set; }
        public string PromotionName { get; set; }
    }
}