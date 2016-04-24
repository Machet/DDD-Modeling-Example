using System;

namespace DDDCinema.Promotions
{
	public class Movie
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }

		protected Movie() { }

		public Movie(Guid id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}