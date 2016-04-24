using System;

namespace DDDCinema.Presentation.Promotions
{
	public class PromotionDetailsDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public DateTime? EndDate { get; set; }
		public DateTime? StartDate { get; set; }
	}
}