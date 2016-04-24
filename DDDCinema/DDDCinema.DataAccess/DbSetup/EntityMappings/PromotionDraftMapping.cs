using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DDDCinema.Promotions;

namespace DDDCinema.DataAccess.DbSetup.EntityMappings
{
	public class PromotionDraftMapping : EntityTypeConfiguration<PromotionDraft>
	{
		public PromotionDraftMapping()
		{
			HasKey(m => m.Id);
			Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
		}
	}
}
