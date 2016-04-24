using System.Collections.Generic;
using DDDCinema.Application.Promotions;

namespace DDDCinema.Application.Presentation.Promotions
{
	public class SetBenefitView
	{
		public SetBenefitCommand Command { get; set; }
		public List<MovieDTO> AvailableMovies { get; set; }
	}
}
