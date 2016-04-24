using System.Data.Entity;

namespace DDDCinema.DataAccess.DbSetup
{
    public class MoviesDbInitializer : DropCreateDatabaseIfModelChanges<CinemaContext>
    {
        protected override void Seed(CinemaContext context)
        {
            MovieSeed.Seed(context);
            UsersSeed.Seed(context);
            RoomSeed.Seed(context);
            MovieTimeSeed.Seed(context);
        }
    }

	public class PromotionsDbInitializer : DropCreateDatabaseIfModelChanges<PromotionsContext>
	{
	}
}
