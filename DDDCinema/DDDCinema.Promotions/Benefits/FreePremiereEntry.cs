using DDDCinema.Promotions.Granting;

namespace DDDCinema.Promotions.Benefits
{
    public class FreePremiereEntry : Benefit
    {
		protected FreePremiereEntry() { }

		public override void ApplyFor(Visitor visitor, IPromotionCodeGenerator generator)
        {
            generator.GeneratePremierePromoCodeFor(visitor);
        }
    }
}
