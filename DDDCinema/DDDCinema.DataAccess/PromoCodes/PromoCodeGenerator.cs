using System;
using DDDCinema.Promotions;
using DDDCinema.Promotions.Granting;

namespace DDDCinema.DataAccess.PromoCodes
{
	public class PromoCodeGenerator : IPromotionCodeGenerator
	{
		public void GenerateDiscountFor(Visitor visitor, Percentage discount)
		{
		}

		public void GenerateFreeEntryPromoCodeForVisitor(Visitor visitor, Movie movie)
		{
		}

		public void GeneratePremierePromoCodeFor(Visitor visitor)
		{
		}
	}
}
