using DDDCinema.Common;
using DDDCinema.Promotions.Granting;

namespace DDDCinema.Promotions
{
	public abstract class Benefit : IdentifiedValueObject
	{
		public abstract void ApplyFor(Visitor visitor, IPromotionCodeGenerator generator);
	}
}
