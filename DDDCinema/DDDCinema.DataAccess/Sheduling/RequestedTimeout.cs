using System;

namespace DDDCinema.DataAccess.Sheduling
{
	public class RequestedTimeout
	{
		public Guid Id { get; set; }
		public DateTime TimeoutTime { get; set; }
		public string TimeoutType { get; set; }
		public string TimeoutDataJson { get; set; }
	}
}
