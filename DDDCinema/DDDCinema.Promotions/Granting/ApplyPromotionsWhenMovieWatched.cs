using DDDCinema.Common;
using System.Collections.Generic;

namespace DDDCinema.Promotions.Granting
{
    public class ApplyPromotionsWhenMovieWatched : IDomainEventHandler<MovieWatched>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IVisitorHistoryRepository _historyRepository;
        private readonly IPromotionCodeGenerator _promotionCodeGenerator;

        public ApplyPromotionsWhenMovieWatched(
            IPromotionRepository promotionRepository,
            IVisitorHistoryRepository historyRepository,
            IPromotionCodeGenerator promotionCodeGenerator)
        {
            _promotionRepository = promotionRepository;
            _historyRepository = historyRepository;
            _promotionCodeGenerator = promotionCodeGenerator;
        }

        public void Handle(MovieWatched @event)
        {
            _historyRepository.AddNewEntry(@event);
            List<Promotion> activePromotions = _promotionRepository.GetActivePromotions();
            foreach (var promotion in activePromotions)
            {
                promotion.GrantBenefit(new Visitor(@event.UserId), _historyRepository, _promotionCodeGenerator);
            }
        }
    }
}
