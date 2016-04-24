using System;
using System.Collections.Generic;
using DDDCinema.Promotions;

namespace DDDCinema.Application.Promotions
{
	public interface IMovieRepository
	{
		Movie GetMoviesWithId(Guid value);
		List<Movie> GetMoviesWithIds(List<Guid> moviesToWatch);
	}
}