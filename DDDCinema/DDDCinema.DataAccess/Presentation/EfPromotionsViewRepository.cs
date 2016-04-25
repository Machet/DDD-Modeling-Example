using System;
using System.Collections.Generic;
using System.Linq;
using DDDCinema.Application.Presentation.Promotions;
using DDDCinema.Application.Promotions;
using DDDCinema.Common;
using DDDCinema.Promotions;

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

		public PromotionDraftNameDTO GetPromotionName(Guid promotionDraftId)
		{
			return _context.PromotionDrafts
				.Select(d => new PromotionDraftNameDTO
				{
					Name = d.Name,
					PromotionId = d.Id
				}).FirstOrDefault(d => d.PromotionId == promotionDraftId);
		}

		public PromotionDetailsDTO GetPromotionDetails(Guid promotionId, Guid userId)
		{
			return _context.PromotionDrafts
				.Where(pd => pd.Id == promotionId)
				.Select(pd => new PromotionDetailsDTO
				{
					Id = pd.Id,
					Name = pd.Name,
					State = (DraftState)pd.State,
					OwnerName = pd.Owner_Name,
					StartDate = pd.ValidityRange_StartDate,
					EndDate = pd.ValidityRange_EndDate,
					Condition = pd.ReceiveCondition.Description,
					Benefit = pd.Benefit.Description,
					IsComplete = pd.IsComplete,
					IsOwner = pd.Owner_Id == userId
				})
				.FirstOrDefault();
		}

		public PromotionLimitDTO GetPromotionLimit(Guid promotionId)
		{
			return _context.PromotionDrafts
				.Where(pd => pd.Id == promotionId)
				.Select(pd => new PromotionLimitDTO
				{
					PromotionId = promotionId,
					Limit = null
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
					State = (DraftState)p.State,
					CreationDate = p.CreationDate,
					IsComplete = p.IsComplete
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
					MoviesToWatch = pd.ReceiveCondition.MoviesToWatches.Select(m => m.MovieId).ToList()
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
