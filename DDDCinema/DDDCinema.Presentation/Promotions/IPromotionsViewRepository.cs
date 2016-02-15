using System.Collections.Generic;

namespace DDDCinema.Presentation.Promotions
{
    public interface IPromotionsViewRepository
    {
        List<PromotionRowDTO> GetPromotions();
    }
}
