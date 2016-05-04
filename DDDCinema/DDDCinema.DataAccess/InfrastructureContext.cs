using System.Data.Entity;
using DDDCinema.Common.Notifications;
using DDDCinema.DataAccess.Sheduling;

namespace DDDCinema.DataAccess
{
	public class InfrastructureContext : DbContext
	{
		public DbSet<RequestedTimeout> RequestedTimeouts { get; set; }
		public DbSet<MailToSend> MailsToSend { get; set; }
		public DbSet<SmsToSend> SmsesToSend { get; set; }

		public InfrastructureContext(string connectionString) : base(connectionString)
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("Infrastructure");
		}
	}
}
