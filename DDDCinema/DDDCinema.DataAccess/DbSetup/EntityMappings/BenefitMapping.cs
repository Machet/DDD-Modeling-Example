using System.Data.Entity.ModelConfiguration;
using DDDCinema.Promotions;
using DDDCinema.Promotions.Benefits;

namespace DDDCinema.DataAccess.DbSetup.EntityMappings
{
	public class BenefitMapping : EntityTypeConfiguration<Benefit>
	{
		public BenefitMapping()
		{
			Map<DiscountForEntry>(m => m.Requires("Type").HasValue("DiscountForEntry"));
			Map<FreeEntry>(m => m.Requires("Type").HasValue("FreeEntry"));
			Map<FreePremiereEntry>(m => m.Requires("Type").HasValue("FreePremiereEntry"));
		}
	}
}
