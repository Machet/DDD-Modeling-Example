using DDDCinema.Common;

namespace DDDCinema.Promotions
{
    public class Percentage
    {
        public Percentage(decimal value)
        {
            Require.IsTrue(() => value <= 100 && value >= 0, "incorrect value for percentage");
        }
    }
}