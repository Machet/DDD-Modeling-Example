using System.Data.Entity;
using DDDCinema.DataAccess.Sheduling;

namespace DDDCinema.DataAccess
{
	public class InfrastructureContext : DbContext
	{
		public DbSet<RequestedTimeout> RequestedTimeouts { get; set; }

		static InfrastructureContext()
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<InfrastructureContext>());
		}

		public InfrastructureContext(string connectionString) : base(connectionString)
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("Infrastructure");
		}
	}
}
