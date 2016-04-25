using System;

namespace DDDCinema.Promotions.ReceiveConditions
{
	public class MovieToWatch
	{
		public Guid MovieId { get; private set; }

		protected MovieToWatch() { }

		public MovieToWatch(Movie movie)
		{
			MovieId = movie.Id;
		}
	}
}
