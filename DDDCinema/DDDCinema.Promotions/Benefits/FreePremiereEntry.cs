using DDDCinema.Promotions.Granting;

namespace DDDCinema.Promotions.Benefits
{
    public class FreePremiereEntry : Benefit
    {
		public FreePremiereEntry()
		{
			Description = "Get a free entrance for premiere movie";
		}

		public override void ApplyFor(Visitor visitor, IPromotionCodeGenerator generator)
        {
            generator.GeneratePremierePromoCodeFor(visitor);
        }
    }
}
