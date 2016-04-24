using System;

namespace DDDCinema.Common
{
	public class IdentifiedValueObject
	{
		public Guid Id { get; private set; }

		public IdentifiedValueObject()
		{
			Id = Guid.NewGuid();
		}
	}
}
