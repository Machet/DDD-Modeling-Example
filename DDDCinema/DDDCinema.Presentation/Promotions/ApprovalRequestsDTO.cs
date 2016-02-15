using System;

namespace DDDCinema.Presentation.Promotions
{
    public class ApprovalRequestsDTO
    {
        public Guid RequestId { get; set; }
        public Guid PromotionId { get; set; }
        public string PromotionName { get; set; }
    }
}