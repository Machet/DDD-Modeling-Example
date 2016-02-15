using DDDCinema.Common;
using System;

namespace DDDCinema.Promotions.Approving
{
    public class PromotionApproved : IDomainEvent
    {
        public Guid PromotionId { get; private set; }

        public PromotionApproved(Guid promotionId)
        {
            PromotionId = promotionId;
        }
    }
}