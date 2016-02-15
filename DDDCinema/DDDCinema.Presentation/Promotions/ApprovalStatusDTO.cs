using System;

namespace DDDCinema.Presentation.Promotions
{
    public class ApprovalStatusDTO
    {
        public Guid PromotionId { get; set; }
        public string PromotionName { get; set; }
        public string PromotionStatus { get; set; }
    }
}