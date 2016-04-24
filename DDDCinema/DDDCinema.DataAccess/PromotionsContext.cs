using System.Data.Entity;
using DDDCinema.DataAccess.DbSetup;
using DDDCinema.Promotions;
using DDDCinema.Promotions.Approving;

namespace DDDCinema.DataAccess
{
	public class PromotionsContext : DbContext
	{
		public DbSet<PromotionDraft> PromotionDrafts { get; set; }
		public DbSet<Promotion> Promotions { get; set; }
		public DbSet<ApprovalProcess> ApprovalProcesses { get; set; }

		static PromotionsContext()
		{
			Database.SetInitializer(new PromotionsDbInitializer());
		}

		public PromotionsContext(string connectionString) : base(connectionString)
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("Promotions");
			modelBuilder.Configurations.AddFromAssembly(typeof(PromotionsContext).Assembly);
		}
	}
}
