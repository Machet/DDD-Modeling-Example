using System;
using System.Collections.Generic;
using System.Linq;
using DDDCinema.Promotions;

namespace DDDCinema.DataAccess.Business
{
	public class EfMovieRepository : IMovieRepository
	{
		private readonly CinemaContext _context;

		public EfMovieRepository(CinemaContext context)
		{
			_context = context;
		}

		public Movie GetMoviesWithId(Guid movieId)
		{
			var movie = _context.Movies
				.Select(m => new { m.MovieId, m.Title })
				.FirstOrDefault(m => m.MovieId == movieId);

			return new Movie(movie.MovieId, movie.Title);
		}

		public List<Movie> GetMoviesWithIds(List<Guid> moviesToWatch)
		{
			return _context.Movies
				.Where(m => moviesToWatch.Contains(m.MovieId))
				.Select(m => new { m.MovieId, m.Title })
				.ToList()
				.Select(m => new Movie(m.MovieId, m.Title))
				.ToList();
		}
	}
}
