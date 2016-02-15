using DDDCinema.Movies.Authentication;
using DDDCinema.Presentation.Promotions;
using System;
using System.Collections.Generic;

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

        public List<PromotionRowDTO> GetPromotions()
        {
            throw new NotImplementedException();
        }
    }
}
