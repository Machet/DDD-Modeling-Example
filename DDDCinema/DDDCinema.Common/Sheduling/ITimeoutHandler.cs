namespace DDDCinema.Common
{
    public interface ITimeoutHandler<T>
    {
        void HandleTimeout(T timeoutData);
    }
}