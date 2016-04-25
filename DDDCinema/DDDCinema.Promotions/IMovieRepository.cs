using System;
using System.Collections.Generic;

namespace DDDCinema.Promotions
{
	public interface IMovieRepository
	{
		Movie GetMoviesWithId(Guid value);
		List<Movie> GetMoviesWithIds(List<Guid> moviesToWatch);
	}
}