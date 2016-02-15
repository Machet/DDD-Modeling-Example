using DDDCinema.Movies;
using System;
using System.Linq;

namespace DDDCinema.DataAccess.DbSetup
{
	public class MovieTimeSeed 
	{
		public static void Seed(CinemaContext context)
		{
            var movies = context.Movies.ToArray();
            context.Seanses.Add(new Seanse { RoomId = 1, MovieId = movies[1].MovieId, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(11, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 1, MovieId = movies[1].MovieId, StartTime = new TimeSpan(12, 0, 0), EndTime = new TimeSpan(15, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 1, MovieId = movies[1].MovieId, StartTime = new TimeSpan(16, 0, 0), EndTime = new TimeSpan(17, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 1, MovieId = movies[1].MovieId, StartTime = new TimeSpan(21, 0, 0), EndTime = new TimeSpan(23, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 3, MovieId = movies[1].MovieId, StartTime = new TimeSpan(23, 30, 0), EndTime = new TimeSpan(1, 30, 0) });
                                                                   
            context.Seanses.Add(new Seanse { RoomId = 2, MovieId = movies[2].MovieId, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(12, 0, 0) });
            context.Seanses.Add(new Seanse { RoomId = 2, MovieId = movies[2].MovieId, StartTime = new TimeSpan(12, 30, 0), EndTime = new TimeSpan(15, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 2, MovieId = movies[2].MovieId, StartTime = new TimeSpan(16, 0, 0), EndTime = new TimeSpan(18, 0, 0) });
            context.Seanses.Add(new Seanse { RoomId = 2, MovieId = movies[2].MovieId, StartTime = new TimeSpan(21, 00, 0), EndTime = new TimeSpan(23, 00, 0) });
                                                                   
            context.Seanses.Add(new Seanse { RoomId = 3, MovieId = movies[3].MovieId, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(12, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 3, MovieId = movies[3].MovieId, StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(16, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 3, MovieId = movies[3].MovieId, StartTime = new TimeSpan(17, 0, 0), EndTime = new TimeSpan(20, 30, 0) });
                                                                   
            context.Seanses.Add(new Seanse { RoomId = 4, MovieId = movies[4].MovieId, StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(12, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 4, MovieId = movies[4].MovieId, StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(15, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 4, MovieId = movies[4].MovieId, StartTime = new TimeSpan(16, 0, 0), EndTime = new TimeSpan(18, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 4, MovieId = movies[4].MovieId, StartTime = new TimeSpan(20, 0, 0), EndTime = new TimeSpan(21, 30, 0) });
                                                                   
            context.Seanses.Add(new Seanse { RoomId = 5, MovieId = movies[5].MovieId, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 40, 0) });
            context.Seanses.Add(new Seanse { RoomId = 5, MovieId = movies[5].MovieId, StartTime = new TimeSpan(12, 0, 0), EndTime = new TimeSpan(13, 40, 0) });
            context.Seanses.Add(new Seanse { RoomId = 5, MovieId = movies[5].MovieId, StartTime = new TimeSpan(14, 0, 0), EndTime = new TimeSpan(15, 40, 0) });
            context.Seanses.Add(new Seanse { RoomId = 5, MovieId = movies[5].MovieId, StartTime = new TimeSpan(16, 0, 0), EndTime = new TimeSpan(16, 40, 0) });
            context.Seanses.Add(new Seanse { RoomId = 5, MovieId = movies[5].MovieId, StartTime = new TimeSpan(18, 0, 0), EndTime = new TimeSpan(18, 40, 0) });
                                                                   
            context.Seanses.Add(new Seanse { RoomId = 6, MovieId = movies[6].MovieId, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(12, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 6, MovieId = movies[6].MovieId, StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(16, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 6, MovieId = movies[6].MovieId, StartTime = new TimeSpan(17, 0, 0), EndTime = new TimeSpan(20, 30, 0) });
                                                                   
            context.Seanses.Add(new Seanse { RoomId = 7, MovieId = movies[7].MovieId, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(11, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 7, MovieId = movies[7].MovieId, StartTime = new TimeSpan(12, 0, 0), EndTime = new TimeSpan(15, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 7, MovieId = movies[7].MovieId, StartTime = new TimeSpan(16, 0, 0), EndTime = new TimeSpan(17, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 7, MovieId = movies[7].MovieId, StartTime = new TimeSpan(21, 0, 0), EndTime = new TimeSpan(23, 30, 0) });
                                                                   
            context.Seanses.Add(new Seanse { RoomId = 8, MovieId = movies[8].MovieId, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(11, 40, 0) });
            context.Seanses.Add(new Seanse { RoomId = 8, MovieId = movies[8].MovieId, StartTime = new TimeSpan(12, 0, 0), EndTime = new TimeSpan(15, 40, 0) });
            context.Seanses.Add(new Seanse { RoomId = 8, MovieId = movies[8].MovieId, StartTime = new TimeSpan(16, 0, 0), EndTime = new TimeSpan(17, 40, 0) });
            context.Seanses.Add(new Seanse { RoomId = 8, MovieId = movies[8].MovieId, StartTime = new TimeSpan(21, 0, 0), EndTime = new TimeSpan(23, 40, 0) });
                                                                   
            context.Seanses.Add(new Seanse { RoomId = 1, MovieId = movies[9].MovieId, StartTime = new TimeSpan(18, 0, 0), EndTime = new TimeSpan(20, 30, 0) });
            context.Seanses.Add(new Seanse { RoomId = 3, MovieId = movies[9].MovieId, StartTime = new TimeSpan(21, 0, 0), EndTime = new TimeSpan(23, 30, 0) });
                                                                   
            context.Seanses.Add(new Seanse { RoomId = 2, MovieId = movies[0].MovieId, StartTime = new TimeSpan(22, 0, 0), EndTime = new TimeSpan(23, 40, 0) });
            context.Seanses.Add(new Seanse { RoomId = 1, MovieId = movies[0].MovieId, StartTime = new TimeSpan(18, 20, 0), EndTime = new TimeSpan(22, 00, 0) });

            context.SaveChanges();
		}
	}
}
