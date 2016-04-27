using System;
using System.Linq;
using System.Collections.Generic;
using DDDCinema.Common;
using DDDCinema.Promotions;
using DDDCinema.Promotions.ReceiveConditions;

namespace DDDCinema.Application.Promotions
{
	public class SetConditionCommand : ICommand
	{
		public Guid PromotionId { get; set; }
		public string ConditionType { get; set; }
		public List<Guid> MoviesToWatch { get; set; }
		public DateTime? DayToWatch { get; set; }
		public DateTime? PremierePeriodEnd { get; set; }
		public DateTime? PremierePeriodStart { get; set; }
		public int? PremireWatchCount { get; set; }
	}

	public class SetConditionCommandHandler : ICommandHandler<SetConditionCommand>
	{
		private readonly IPromotionRepository _promotionRepository;
		private readonly IMovieRepository _movieRepository;

		public SetConditionCommandHandler(IPromotionRepository promotionRepository, IMovieRepository movieRepository)
		{
			_promotionRepository = promotionRepository;
			_movieRepository = movieRepository;
		}

		public void Handle(SetConditionCommand command)
		{
			PromotionDraft draft = _promotionRepository.GetDraftById(command.PromotionId);
			if (@command.ConditionType == "GoToPremiere")
			{
				var range = ValidityRange.LimitedValidityRange(command.PremierePeriodStart.Value, command.PremierePeriodEnd.Value);
				draft.SetReceiveCondition(new GoToPremiere(range, command.PremireWatchCount.Value));
			}

			if (@command.ConditionType == "WatchAtSpecificDay")
			{
				draft.SetReceiveCondition(new WatchAtSpecificDay(@command.DayToWatch.Value));
            }

			if (@command.ConditionType == "WatchSpecificMovies")
			{
				List<Movie> movies = _movieRepository.GetMoviesWithIds(command.MoviesToWatch);
				draft.SetReceiveCondition(new WatchSpecificMovies(movies));
			}
		}
	}
}
