using System;
using DDDCinema.Common;
using Newtonsoft.Json;

namespace DDDCinema.DataAccess.Sheduling
{
	public class SagaTimeoutSheduler : ISheduler
	{
		private readonly InfrastructureContext _context;

		public SagaTimeoutSheduler(InfrastructureContext context)
		{
			_context = context;
		}

		public void RequestTimeout<T>(T approvalProcessTimeout, TimeSpan afterTime)
		{
			_context.RequestedTimeouts.Add(new RequestedTimeout
			{
				Id = Guid.NewGuid(),
				TimeoutTime = DomainTime.Current.Now.Add(afterTime),
				TimeoutDataJson = JsonConvert.SerializeObject(approvalProcessTimeout),
				TimeoutType = typeof(T).AssemblyQualifiedName
			});

			_context.SaveChanges();
		}
	}
}
