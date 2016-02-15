using System;
using System.Linq;

namespace DDDCinema.Common
{
    public class Require
    {
        public static void NotNull(object argument, string name)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void IsEqual<T>(T argument, T desireValue, string message)
        {
            IsTrue(() => argument.Equals(desireValue), message);
        }

        public static void IsNotEqual<T>(T argument, T desireValue, string message)
        {
            IsTrue(() => !argument.Equals(desireValue), message);
        }

        public static void IsLowerThan(DateTime startDate, DateTime endDate, string message)
        {
            IsTrue(() => startDate < endDate, message);
        }

        public static void IsNotIn<T>(T argument, params T[] excludedValues)
        {
            if(excludedValues.Any(ev => ev.Equals(argument)))
            {
                throw new ArgumentException(string.Format("{0} should not be in {1}", argument, string.Join(", ", excludedValues)));
            }
        }

        public static void IsIn<T>(T argument, params T[] excludedValues)
        {
            if (excludedValues.All(ev => !ev.Equals(argument)))
            {
                throw new ArgumentException(string.Format("{0} should be in {1}", argument, string.Join(", ", excludedValues)));
            }
        }

        public static void IsTrue(Func<bool> predicate, string message)
        {
            if (!predicate())
            {
                throw new ArgumentException(message);
            }
        }
    }
}
