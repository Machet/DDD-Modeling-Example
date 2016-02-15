using System.Data.Entity;

using DDDCinema.Movies;
using DDDCinema.Movies.Notifications;
using DDDCinema.DataAccess.AuditLogging;
using DDDCinema.Movies.Authentication;

namespace DDDCinema.DataAccess
{
    public class PromotionsContext : DbContext
    {
        public DbSet<LoginAttempt> LoginAttempts { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
