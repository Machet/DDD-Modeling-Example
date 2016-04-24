using System;
using System.Collections.Generic;
using System.Linq;
using DDDCinema.Application.Presentation.Promotions;
using DDDCinema.Application.Promotions;
using DDDCinema.Common;

namespace DDDCinema.DataAccess.Presentation
{
	public class EfPromotionsViewRepository : IPromotionsViewRepository
	{
		private readonly DDDCinemaReadonly _context;
		private readonly ICurrentUserProvider _provider;

		public EfPromotionsViewRepository(DDDCinemaReadonly context, ICurrentUserProvider provider)
		{
			_context = context;
			_provider = provider;
		}

		public PromotionDetailsDTO GetPromotionDetails(Guid promotionId)
		{
			return _context.PromotionDrafts
				.Where(pd => pd.Id == promotionId)
				.Select(pd => new PromotionDetailsDTO
				{
					Id = pd.Id,
					Name = pd.Name,
					StartDate = pd.ValidityRange_StartDate,
					EndDate = pd.ValidityRange_EndDate,
					Condition = pd.ReceiveCondition.Description,
					Benefit = pd.Benefit.Description
				})
				.FirstOrDefault();
		}

		public List<PromotionDraftDTO> GetPromotions(Guid userId)
		{
			return _context.PromotionDrafts
				.Where(p => p.Owner_Id == userId)
				.Select(p => new PromotionDraftDTO
				{
					PromotionId = p.Id,
					Name = p.Name,
					State = p.State.ToString(),
					CreationDate = p.CreationDate
				}).ToList();
		}

		public SetBenefitView GetSetBenefitView(Guid promotionId)
		{
			var command = _context.PromotionDrafts
				.Where(pd => pd.Id == promotionId)
				.Select(pd => new SetBenefitCommand
				{
					PromotionId = pd.Id,
					BenefitType = pd.Benefit.Type,
					DiscountPercentage = pd.Benefit.Discount_Value,
					MovieId = pd.Benefit.Movie_Id
				})
				.FirstOrDefault();

			var movies = _context.Movies2.Select(m => new MovieDTO
			{
				Id = m.MovieId,
				Name = m.Title
			}).ToList();

			return new SetBenefitView
			{
				Command = command,
				AvailableMovies = movies
			};
		}

		public SetConditionView GetSetConditionView(Guid promotionId)
		{
			var command = _context.PromotionDrafts
				.Where(pd => pd.Id == promotionId)
				.Select(pd => new SetConditionCommand
				{
					PromotionId = pd.Id,
					ConditionType = pd.ReceiveCondition.Type,
					DayToWatch = pd.ReceiveCondition.DayToWatch,
					PremierePeriodStart = pd.ReceiveCondition.ValidityRange_StartDate,
					PremierePeriodEnd = pd.ReceiveCondition.ValidityRange_EndDate,
					PremireWatchCount = pd.ReceiveCondition.RequiredCount,
					MoviesToWatch = pd.ReceiveCondition.Movies1.Select(m => m.Id).ToList()
				})
				.FirstOrDefault();

			var movies = _context.Movies2
				.Select(m => new MovieDTO
				{
					Id = m.MovieId,
					Name = m.Title
				}).ToList();

			return new SetConditionView
			{
				Command = command,
				AvailableMovies = movies
			};
		}
	}
}
