using System;

namespace DDDCinema.Presentation
{
    public class LoginAttemptDTO
    {
        public Guid LoginAttemptId { get; set; }
        public bool Succeeded { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
