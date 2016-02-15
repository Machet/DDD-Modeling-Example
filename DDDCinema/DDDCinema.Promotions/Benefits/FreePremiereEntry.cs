using DDDCinema.Promotions.Granting;

namespace DDDCinema.Promotions.Benefits
{
    public class FreePremiereEntry : Benefit
    {
        public override void ApplyFor(Visitor visitor, IPromotionCodeGenerator generator)
        {
            generator.GeneratePremierePromoCodeFor(visitor);
        }
    }
}
