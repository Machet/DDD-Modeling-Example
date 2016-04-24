using DDDCinema.Common;
using DDDCinema.Promotions.Granting;

namespace DDDCinema.Promotions
{
	public abstract class ReceiveCondition : IdentifiedValueObject
	{
		public string Description { get; protected set; }
		public abstract bool IsSatisfiedFor(Visitor visitor, IVisitorHistoryRepository historyService);
	}
}
