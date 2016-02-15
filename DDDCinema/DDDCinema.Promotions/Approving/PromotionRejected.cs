using DDDCinema.Common;
using System;

namespace DDDCinema.Promotions.Approving
{
    public class PromotionRejected : IDomainEvent
    {
        public Guid PromotionId { get; private set; }

        public PromotionRejected(Guid promotionId)
        {
            PromotionId = promotionId;
        }
    }
}