using System;
using DDDCinema.Common;
using Newtonsoft.Json;

namespace DDDCinema.DataAccess.AuditLogging
{
	public class AuditingCommandHandler<T> : ICommandHandler<T> where T : ICommand
	{
		private readonly AuditLogger _logger;
		private readonly ICommandHandler<T> _innerHandler;

		public AuditingCommandHandler(ICommandHandler<T> innerHandler, AuditLogger logger)
		{
			_innerHandler = innerHandler;
			_logger = logger;
		}

		public void Handle(T command)
		{
			string serializedEvent = JsonConvert.SerializeObject(command);
			_innerHandler.Handle(command);
			_logger.LogAction("User performed " + typeof(T).Name + Environment.NewLine + serializedEvent);
		}
	}
}
