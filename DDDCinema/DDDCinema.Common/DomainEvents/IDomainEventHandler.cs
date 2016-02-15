namespace DDDCinema.Common
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        void Handle(T @event);
    }
}