using DDDCinema.Common;
using System;

namespace DDDCinema.Promotions.Granting
{
    public class PromotionGrantedForVisitor : IDomainEvent
    {
        public Guid PromotionId { get; private set; }
        public Guid VisitorId { get; private set; }

        public PromotionGrantedForVisitor(Guid promotionId, Guid visitorId)
        {
            PromotionId = promotionId;
            VisitorId = visitorId;
        }
    }
}