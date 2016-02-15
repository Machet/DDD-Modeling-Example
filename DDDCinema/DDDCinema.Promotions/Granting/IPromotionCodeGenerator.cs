namespace DDDCinema.Promotions.Granting
{
    public interface IPromotionCodeGenerator
    {
        void GeneratePremierePromoCodeFor(Visitor visitor);
        void GenerateDiscountFor(Visitor visitor, Percentage discount);
        void GenerateFreeEntryPromoCodeForVisitor(Visitor visitor, Movie movie);
    }
}
