using System.Data.Entity.ModelConfiguration;
using DDDCinema.Promotions;

namespace DDDCinema.DataAccess.DbSetup.EntityMappings
{
	public class PercentageMapping : ComplexTypeConfiguration<Percentage>
	{
		public PercentageMapping()
		{
			Property(m => m.Value);
		}
	}
}
