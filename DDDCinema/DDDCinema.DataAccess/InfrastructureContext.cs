using System.Data.Entity;
using DDDCinema.DataAccess.Sheduling;

namespace DDDCinema.DataAccess
{
	public class InfrastructureContext : DbContext
	{
		public DbSet<RequestedTimeout> RequestedTimeouts { get; set; }

		public InfrastructureContext(string connectionString) : base(connectionString)
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("Infrastructure");
		}
	}
}
