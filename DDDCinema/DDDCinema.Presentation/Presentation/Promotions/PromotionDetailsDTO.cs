using System;

namespace DDDCinema.Application.Presentation.Promotions
{
	public class PromotionDetailsDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public DateTime? EndDate { get; set; }
		public DateTime? StartDate { get; set; }
		public string Benefit { get; set; }
		public string Condition { get; set; }
	}
}