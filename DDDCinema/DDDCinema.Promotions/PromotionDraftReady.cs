using System;
using DDDCinema.Common;

namespace DDDCinema.Promotions
{
    public class PromotionDraftReady : IDomainEvent
    {
        public Guid OwnerId { get; private set; }
        public Guid PromotionId { get; private set; }

        public PromotionDraftReady(Guid promotionId, Guid ownerId)
        {
            PromotionId = promotionId;
            OwnerId = ownerId;
        }
    }
}