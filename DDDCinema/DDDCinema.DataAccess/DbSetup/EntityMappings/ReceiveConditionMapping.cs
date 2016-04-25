using System.Data.Entity.ModelConfiguration;
using DDDCinema.Promotions;
using DDDCinema.Promotions.ReceiveConditions;

namespace DDDCinema.DataAccess.DbSetup.EntityMappings
{
	public class ReceiveConditionMapping : EntityTypeConfiguration<ReceiveCondition>
	{
		public ReceiveConditionMapping()
		{
			Map<GoToPremiere>(m => m.Requires("Type").HasValue("GoToPremiere"));
			Map<WatchAtSpecificDay>(m => m.Requires("Type").HasValue("WatchAtSpecificDay"));
			Map<WatchSpecificMovies>(m => m.Requires("Type").HasValue("WatchSpecificMovies"));
		}
	}

	public class WatchSpecificMoviesReceiveConditionMapping : EntityTypeConfiguration<WatchSpecificMovies>
	{
		public WatchSpecificMoviesReceiveConditionMapping()
		{
			HasMany(m => m.MoviesToWatch).WithRequired();
		}
	}
}
