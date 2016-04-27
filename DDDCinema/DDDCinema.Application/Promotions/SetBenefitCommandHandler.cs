using System;
using DDDCinema.Common;
using DDDCinema.Promotions;
using DDDCinema.Promotions.Benefits;

namespace DDDCinema.Application.Promotions
{
	public class SetBenefitCommand : ICommand
	{
		public Guid PromotionId { get; set; }
		public string BenefitType { get; set; }
		public decimal? DiscountPercentage { get; set; }
		public Guid? MovieId { get; set; }
	}

	public class SetBenefitCommandHandler : ICommandHandler<SetBenefitCommand>
	{
		private readonly IPromotionRepository _promotionRepository;
		private readonly IMovieRepository _movieRepository;

		public SetBenefitCommandHandler(IPromotionRepository promotionRepository, IMovieRepository movieRepository)
		{
			_promotionRepository = promotionRepository;
			_movieRepository = movieRepository;
		}

		public void Handle(SetBenefitCommand command)
		{
			PromotionDraft draft = _promotionRepository.GetDraftById(command.PromotionId);
			if (@command.BenefitType == "FreePremiereEntry")
			{
				draft.SetBenefit(new FreePremiereEntry());
			}

			if (@command.BenefitType == "FreeEntry")
			{
				Movie movie = _movieRepository.GetMoviesWithId(command.MovieId.Value);
				draft.SetBenefit(new FreeEntry(movie));
			}

			if (@command.BenefitType == "DiscountForEntry")
			{
				draft.SetBenefit(new DiscountForEntry(new Percentage(command.DiscountPercentage.Value)));
			}
		}
	}
}
