using System.Data.Entity;
using DDDCinema.DataAccess.AuditLogging;
using DDDCinema.Movies;
using DDDCinema.Movies.Authentication;
using DDDCinema.Movies.Notifications;

namespace DDDCinema.DataAccess
{
	public class CinemaContext : DbContext
	{
		public DbSet<LoginAttempt> LoginAttempts { get; set; }
		public DbSet<AuditLog> AuditLogs { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Seanse> Seanses { get; set; }
		public DbSet<SeatAssignment> SeatAssignments { get; set; }
		public DbSet<MailToSend> MailsToSend { get; set; }
		public DbSet<SmsToSend> SmsesToSend { get; set; }

		public CinemaContext(string connectionString) : base(connectionString)
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("Movies");
		}
	}
}
