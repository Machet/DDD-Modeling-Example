using System;
using System.Collections.Generic;
using System.Linq;
using DDDCinema.Application.Presentation.Promotions;
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
					EndDate = pd.ValidityRange_EndDate
				})
				.FirstOrDefault();
		}

		public BenefitDTO GetBenefit(Guid promotionId)
		{
			return _context.PromotionDrafts
				.Where(pd => pd.Id == promotionId)
				.Select(pd => new BenefitDTO
				{
					//Id = pd.Benefit.,
					//Name = pd.Name,
					//StartDate = pd.ValidityRange_StartDate,
					//EndDate = pd.ValidityRange_EndDate
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
	}
}
