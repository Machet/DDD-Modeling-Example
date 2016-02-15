using System;
using System.Collections.Generic;

namespace DDDCinema.Promotions
{
    public interface IPromotionRepository
    {
        Promotion GetById(Guid promotionId);
        PromotionDraft GetDraftById(Guid promotionDraftId);
        void Store(Promotion promotion);
        List<Promotion> GetActivePromotions();
    }
}