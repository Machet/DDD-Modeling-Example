using System;
using System.Collections.Generic;
using System.Linq;
using DDDCinema.Common;
using DDDCinema.Presentation.Promotions;

namespace DDDCinema.DataAccess.Presentation
{
	public class EfPromotionsViewRepository : IPromotionsViewRepository
	{
		private readonly PromotionsContext _context;
		private readonly ICurrentUserProvider _provider;

		public EfPromotionsViewRepository(PromotionsContext context, ICurrentUserProvider provider)
		{
			_context = context;
			_provider = provider;
		}

		public List<PromotionDraftDTO> GetPromotions(Guid userId)
		{
			return _context.PromotionDrafts
				.Where(p => p.Owner.Id == userId)
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
