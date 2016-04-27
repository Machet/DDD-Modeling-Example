using System;
using DDDCinema.Promotions;

namespace DDDCinema.Application.Presentation.Promotions
{
	public class PromotionDetailsDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string OwnerName { get; set; }
		public DraftState State { get; set; }
		public DateTime? EndDate { get; set; }
		public DateTime? StartDate { get; set; }
		public string Benefit { get; set; }
		public string Condition { get; set; }
		public int? Limit { get; set; }
		public bool IsComplete { get; set; }
		public bool IsOwner { get; set; }
	}
}