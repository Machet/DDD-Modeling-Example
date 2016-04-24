using System;
using System.Collections.Generic;

namespace DDDCinema.Presentation.Promotions
{
	public interface IPromotionsViewRepository
	{
		List<PromotionDraftDTO> GetPromotions(Guid userId);
	}
}
