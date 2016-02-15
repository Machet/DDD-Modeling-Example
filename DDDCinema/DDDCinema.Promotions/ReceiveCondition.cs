using DDDCinema.Promotions.Granting;

namespace DDDCinema.Promotions
{
    public abstract class ReceiveCondition
    {
        public abstract bool IsSatisfiedFor(Visitor visitor, IVisitorHistoryRepository historyService);
    }
}
