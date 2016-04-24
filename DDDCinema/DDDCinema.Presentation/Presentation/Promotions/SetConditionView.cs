using System.Collections.Generic;
using System.Linq;
using DDDCinema.Application.Promotions;

namespace DDDCinema.Application.Presentation.Promotions
{
	public class SetConditionView
	{
		public SetConditionCommand Command { get; set; }
		public List<MovieDTO> AvailableMovies { get; set; }

		public List<MovieDTO> GetSelectedMovies()
		{
			return AvailableMovies.Where(m => Command.MoviesToWatch.Contains(m.Id)).ToList();
		}
	}
}
