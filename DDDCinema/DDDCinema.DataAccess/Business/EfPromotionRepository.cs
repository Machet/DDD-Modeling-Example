using System;
using System.Collections.Generic;
using System.Linq;
using DDDCinema.Common;
using DDDCinema.Promotions;

namespace DDDCinema.DataAccess.Business
{
	public class EfPromotionRepository : IPromotionRepository
	{
		private readonly PromotionsContext _context;

		public EfPromotionRepository(PromotionsContext context)
		{
			_context = context;
		}

		public List<Promotion> GetActivePromotions()
		{
			return _context.Promotions
				.Where(p => p.ValidityRange.StartDate > DomainTime.Current.Now && p.ValidityRange.EndDate < DomainTime.Current.Now)
				.ToList();
		}

		public Promotion GetById(Guid promotionId)
		{
			return _context.Promotions.Find(promotionId);
		}

		public PromotionDraft GetDraftById(Guid promotionDraftId)
		{
			return _context.PromotionDrafts.Find(promotionDraftId);
		}

		public void Store(PromotionDraft draft)
		{
			_context.PromotionDrafts.Add(draft);
		}

		public void Store(Promotion promotion)
		{
			_context.Promotions.Add(promotion);
		}
	}
}
