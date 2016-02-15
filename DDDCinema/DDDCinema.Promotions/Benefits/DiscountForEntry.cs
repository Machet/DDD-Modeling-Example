using DDDCinema.Common;
using DDDCinema.Promotions.Granting;

namespace DDDCinema.Promotions.Benefits
{
    public class DiscountForEntry : Benefit
    {
        public Percentage Discount { get; private set; }

        public DiscountForEntry(Percentage discount)
        {
            Require.NotNull(discount, nameof(discount));
        }

        public override void ApplyFor(Visitor visitor, IPromotionCodeGenerator generator)
        {
            generator.GenerateDiscountFor(visitor, Discount);
        }
    }
}
