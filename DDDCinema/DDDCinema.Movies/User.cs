using System;

namespace DDDCinema.Movies
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get;  set; }
        public string MobilePhone { get; set; }
        public bool ContactByEmailAllowed { get; set; }
        public bool ContactBySmslAllowed { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public UserType UserType { get; set; }
        public int FreeTicketsCount { get; set; }
    }
}
