using System;
using System.Collections.Generic;
using System.Linq;
using DDDCinema.Common;
using DDDCinema.Promotions;
using System.Data.Entity;

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
				.Include(x => x.ReceiveCondition)
				.Include(x => x.Benefit)
				.Where(p => p.ValidityRange.StartDate < DomainTime.Current.Now && p.ValidityRange.EndDate > DomainTime.Current.Now)
				.ToList();
		}

		public Promotion GetById(Guid promotionId)
		{
			return _context.Promotions
				.Include(x => x.ReceiveCondition)
				.Include(x => x.Benefit)
				.SingleOrDefault(p => p.Id == promotionId);
		}

		public PromotionDraft GetDraftById(Guid promotionDraftId)
		{
			return _context.PromotionDrafts
				.Include(x => x.ReceiveCondition)
				.Include(x => x.Benefit)
				.SingleOrDefault(p => p.Id == promotionDraftId);
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
