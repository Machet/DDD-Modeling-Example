using System;

namespace DDDCinema.Application.Presentation.Promotions
{
    public class ApprovalRequestsDTO
    {
        public Guid ProcessId { get; set; }
        public Guid RequestId { get; set; }
        public Guid PromotionId { get; set; }
        public string PromotionName { get; set; }
		public string OwnerName { get; set; }
    }
}