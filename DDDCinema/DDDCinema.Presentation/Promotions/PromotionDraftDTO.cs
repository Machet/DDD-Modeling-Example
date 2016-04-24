using System;

namespace DDDCinema.Presentation.Promotions
{
    public class PromotionDraftDTO
    {
        public Guid PromotionId { get; set; }
        public string Name { get; set; }
		public string State { get; set; }
        public DateTime CreationDate { get; set; }
    }
}