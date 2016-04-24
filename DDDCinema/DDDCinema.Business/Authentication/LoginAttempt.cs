using System;

namespace DDDCinema.Movies.Authentication
{
    public class LoginAttempt
    {
        public Guid LoginAttemptId { get; set; }
        public bool Succeeded { get; set; }
        public Guid? UserId { get; set; }
        public string UserRole { get; set; }
		public string Message { get; set; }
        public DateTime Time { get; set; }

        internal static LoginAttempt Failed(Guid id, string message)
        {
            return new LoginAttempt
            {
                LoginAttemptId = id,
                Succeeded = false,
                Message = message,
                Time = DateTime.Now,
                UserId = null
            };
        }

        internal static LoginAttempt Failed(Guid id, string message, User user)
        {
            return new LoginAttempt
            {
                LoginAttemptId = id,
                Succeeded = false,
                Message = message,
                Time = DateTime.Now,
                UserId = user.Id,
				UserRole = user.Role
            };
        }

        internal static LoginAttempt Successful(Guid id, User user)
        {
            return new LoginAttempt
            {
                LoginAttemptId = id,
                Succeeded = true,
                Message = "Successfull",
                Time = DateTime.Now,
                UserId = user.Id,
				UserRole = user.Role
            };
		}
    }
}
