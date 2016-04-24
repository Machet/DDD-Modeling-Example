using DDDCinema.Common;
using DDDCinema.Promotions.Granting;

namespace DDDCinema.Promotions
{
	public abstract class Benefit : IdentifiedValueObject
	{
		public string Description { get; protected set; }
		public abstract void ApplyFor(Visitor visitor, IPromotionCodeGenerator generator);
	}
}
