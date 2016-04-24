using System;
using System.Collections.Generic;

namespace DDDCinema.Promotions
{
	public interface IPromotionRepository
	{
		Promotion GetById(Guid promotionId);
		List<Promotion> GetActivePromotions();
		PromotionDraft GetDraftById(Guid promotionDraftId);
		void Store(Promotion promotion);
		void Store(PromotionDraft draft);
	}
}