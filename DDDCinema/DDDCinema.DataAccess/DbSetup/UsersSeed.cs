using DDDCinema.Movies;
using DDDCinema.Movies.Authentication;
using System;

namespace DDDCinema.DataAccess.DbSetup
{
    public class UsersSeed
    {
        public static void Seed(CinemaContext context)
        {
            var hasher = new StringHasher();
            for (int i = 1; i <= 10; i++)
            {
                context.Users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Name = "User" + i,
                    Email = i + "@movie.com",
                    ContactByEmailAllowed = true,
                    MobilePhone = "" + i + i + i + i + i,
                    ContactBySmslAllowed = true,
                    Password = hasher.GetHash("123", "user" + i),
                    PasswordSalt = "user" + i,
                    Role = "User",
                    UserType = (UserType)(i % 3)
                });
            }

            for (int i = 1; i <= 5; i++)
            {
                context.Users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Editor" + i,
                    Email = "editor" + i + "@movie.com",
                    ContactByEmailAllowed = true,
                    MobilePhone = "" + i + i + i + i + i,
                    ContactBySmslAllowed = true,
                    Password = hasher.GetHash("123", "editor" + i),
                    PasswordSalt = "editor" + i,
                    Role = "Editor",
                    UserType = (UserType)(i % 3)
                });
            }

            context.SaveChanges();
        }
    }
}