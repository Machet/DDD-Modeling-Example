using System.Data.Entity.ModelConfiguration;
using DDDCinema.Promotions.ReceiveConditions;

namespace DDDCinema.DataAccess.DbSetup.EntityMappings
{
	public class MovieToWatchMapping : EntityTypeConfiguration<MovieToWatch>
	{
		public MovieToWatchMapping()
		{
			ToTable("MoviesToWatch");
			HasKey(m => m.MovieId);
		}
	}
}
