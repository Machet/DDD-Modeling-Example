using DDDCinema.Promotions.Granting;

namespace DDDCinema.Promotions
{
    public abstract class Benefit
    {
        public abstract void ApplyFor(Visitor visitor, IPromotionCodeGenerator generator);
    }
}
