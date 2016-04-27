using System;
using System.Collections.Generic;

namespace DDDCinema.Application.Presentation.Promotions
{
	public interface IPromotionsViewRepository
	{
		List<PromotionDraftDTO> GetPromotions(Guid userId);
		PromotionDraftNameDTO GetPromotionName(Guid id);
		PromotionDetailsDTO GetPromotionDetails(Guid promotionId, Guid userId);
		PromotionLimitDTO GetPromotionLimit(Guid promotionId);
		SetBenefitView GetSetBenefitView(Guid promotionId);
		SetConditionView GetSetConditionView(Guid promotionId);
	}
}
