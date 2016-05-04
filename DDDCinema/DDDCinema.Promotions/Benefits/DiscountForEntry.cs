using DDDCinema.Common;
using DDDCinema.Promotions.Granting;

namespace DDDCinema.Promotions.Benefits
{
	public class DiscountForEntry : Benefit
	{
		public Percentage Discount { get; private set; }

		protected DiscountForEntry() { }

		public DiscountForEntry(Percentage discount)
		{
			Require.NotNull(discount, "discount");
			Discount = discount;
			Description = "Get " + Discount.Value + " percent of discount for next entry";
		}

		public override void ApplyFor(Visitor visitor, IPromotionCodeGenerator generator)
		{
			generator.GenerateDiscountFor(visitor, Discount);
		}
	}
}
