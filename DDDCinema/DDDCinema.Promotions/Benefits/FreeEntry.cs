using DDDCinema.Common;
using DDDCinema.Promotions.Granting;

namespace DDDCinema.Promotions.Benefits
{
    public class FreeEntry : Benefit
    {
        public Movie Movie { get; private set; }

		protected FreeEntry() { }

		public FreeEntry(Movie movie)
        {
            Require.NotNull(movie, nameof(movie));
            Movie = movie;
        }

        public override void ApplyFor(Visitor visitor, IPromotionCodeGenerator generator)
        {
            generator.GenerateFreeEntryPromoCodeForVisitor(visitor, Movie);
        }
    }
}
