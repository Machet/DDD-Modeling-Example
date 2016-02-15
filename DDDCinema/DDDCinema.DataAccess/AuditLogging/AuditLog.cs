using System;

namespace DDDCinema.DataAccess.AuditLogging
{
	public class AuditLog
	{
		public int Id { get; set; }
		public Guid UserId { get; set; }
		public DateTime ChangeTime { get; set; }
		public string Changes { get; set; }
	}
}
