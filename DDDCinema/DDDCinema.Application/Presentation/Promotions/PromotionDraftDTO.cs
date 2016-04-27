using System;
using DDDCinema.Promotions;

namespace DDDCinema.Application.Presentation.Promotions
{
    public class PromotionDraftDTO
    {
        public Guid PromotionId { get; set; }
        public string Name { get; set; }
		public DraftState State { get; set; }
        public DateTime CreationDate { get; set; }
		public bool IsComplete { get; set; }
	}
}