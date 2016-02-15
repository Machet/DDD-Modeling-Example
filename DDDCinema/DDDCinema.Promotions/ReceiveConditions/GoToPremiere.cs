using DDDCinema.Common;
using DDDCinema.Promotions.Granting;
using System;

namespace DDDCinema.Promotions.ReceiveConditions
{
    public class GoToPremiere : ReceiveCondition
    {
        public ValidityRange ValidityRange { get; private set; }
        public int RequiredCount { get; private set; }

        public GoToPremiere(ValidityRange range, int requiredCount)
        {
            Require.NotNull(range, nameof(range));
            Require.IsTrue(() => requiredCount > 0, "required count should be positive");
            ValidityRange = range;
            RequiredCount = requiredCount;
        }

        public override bool IsSatisfiedFor(Visitor visitor, IVisitorHistoryRepository historyService)
        {
            return historyService.HasAttendedPremiere(visitor, ValidityRange, RequiredCount);
        }
    }
}
