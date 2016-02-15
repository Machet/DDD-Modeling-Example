using DDDCinema.Common;
using DDDCinema.Promotions.Granting;
using System;

namespace DDDCinema.Promotions
{
    public class Promotion
    {
        public Guid Id { get; private set; }
        public ValidityRange ValidityRange { get; private set; }
        public Benefit Benefit { get; private set; }
        public ReceiveCondition ReceiveCondition { get; private set; }

        public Promotion(ValidityRange validityRange, ReceiveCondition receiveCondition, Benefit benefit)
        {
            ValidityRange = validityRange;
            ReceiveCondition = receiveCondition;
            Benefit = benefit;
        }

        public void GrantBenefit(Visitor visitor, IVisitorHistoryRepository historyService, IPromotionCodeGenerator generator)
        {
            Require.IsTrue(IsActive, "Promotion is not active");
            if (ReceiveCondition.IsSatisfiedFor(visitor, historyService))
            {
                Benefit.ApplyFor(visitor, generator);
                DomainEventBus.Current.Raise(new PromotionGrantedForVisitor(Id, visitor.Id));
            }
        }

        public bool IsActive()
        {
            return ValidityRange.Contains(DomainTime.Current.Now);
        }
    }
}
