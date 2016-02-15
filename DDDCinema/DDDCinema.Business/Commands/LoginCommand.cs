using System;

namespace DDDCinema.Movies.Commands
{
    public class LoginCommand : ICommand
    {
        public Guid AttemptId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
