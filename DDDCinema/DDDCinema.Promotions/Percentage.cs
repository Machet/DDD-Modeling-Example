using DDDCinema.Common;

namespace DDDCinema.Promotions
{
	public class Percentage
	{
		public decimal Value { get; private set; }
		protected Percentage() { }

		public Percentage(decimal value)
		{
			Require.IsTrue(() => value <= 100 && value >= 0, "incorrect value for percentage");
			Value = value;
		}
	}
}