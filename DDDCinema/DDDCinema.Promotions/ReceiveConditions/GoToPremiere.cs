using DDDCinema.Common;
using DDDCinema.Promotions.Granting;
using System;

namespace DDDCinema.Promotions.ReceiveConditions
{
    public class GoToPremiere : ReceiveCondition
    {
        public ValidityRange ValidityRange { get; private set; }
        public int RequiredCount { get; private set; }

		protected GoToPremiere() { }

		public GoToPremiere(ValidityRange range, int requiredCount)
        {
            Require.NotNull(range, "range");
            Require.IsTrue(() => requiredCount > 0, "required count should be positive");
            Require.IsTrue(() => range.IsDefined(), "range must have definied dates");
            ValidityRange = range;
            RequiredCount = requiredCount;
			Description = "Go to premiere movies " + requiredCount + " times between " + range.StartDate.Value.ToShortDateString() + " and " + range.EndDate.Value.ToShortDateString();
        }

        public override bool IsSatisfiedFor(Visitor visitor, IVisitorHistoryRepository historyService)
        {
            return historyService.HasAttendedPremiere(visitor, ValidityRange, RequiredCount);
        }
    }
}
