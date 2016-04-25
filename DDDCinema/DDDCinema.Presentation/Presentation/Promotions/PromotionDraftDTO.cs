using System;

namespace DDDCinema.Application.Presentation.Promotions
{
    public class PromotionDraftDTO
    {
        public Guid PromotionId { get; set; }
        public string Name { get; set; }
		public string State { get; set; }
        public DateTime CreationDate { get; set; }
		public bool IsComplete { get; set; }
	}
}