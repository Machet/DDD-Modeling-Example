using System;

namespace DDDCinema.Common
{
    public interface ISheduler
    {
        void RequestTimeout<T>(T timeout, TimeSpan afterTime);
    }
}