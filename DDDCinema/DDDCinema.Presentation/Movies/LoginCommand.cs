using System;
using DDDCinema.Common;

namespace DDDCinema.Application.Movies
{
	public class LoginCommand : ICommand
	{
		public Guid AttemptId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
