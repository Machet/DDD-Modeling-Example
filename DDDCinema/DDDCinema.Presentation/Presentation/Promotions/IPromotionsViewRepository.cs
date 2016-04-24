using System;
using System.Collections.Generic;

namespace DDDCinema.Application.Presentation.Promotions
{
	public interface IPromotionsViewRepository
	{
		List<PromotionDraftDTO> GetPromotions(Guid userId);
		PromotionDetailsDTO GetPromotionDetails(Guid promotionId);
		SetBenefitView GetSetBenefitView(Guid promotionId);
		SetConditionView GetSetConditionView(Guid promotionId);
	}
}
