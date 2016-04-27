using System.Configuration;
using System.Data.Entity;
using DDDCinema.DataAccess;
using DDDCinema.DataAccess.DbSetup;

namespace DDDCinema
{
	public class DatabaseConfig
	{
		public static void Setup()
		{
			var connectionString = ConfigurationManager.ConnectionStrings["DDDCinema"].ConnectionString;

			using (var movieContext = new CinemaContext(connectionString))
			using (var promotionsContext = new PromotionsContext(connectionString))
			using (var infrastructureContext = new InfrastructureContext(connectionString))
			{
				Database.SetInitializer(new MoviesDbInitializer());
				movieContext.Database.Initialize(true);

				Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PromotionsContext>());
				promotionsContext.Database.Initialize(true);

				Database.SetInitializer(new DropCreateDatabaseIfModelChanges<InfrastructureContext>());
				infrastructureContext.Database.Initialize(true);
			}
		}
	}
}