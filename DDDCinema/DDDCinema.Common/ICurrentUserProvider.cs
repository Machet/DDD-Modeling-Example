using System;

namespace DDDCinema.Common
{
	public interface ICurrentUserProvider
	{
		Guid? GetUserId();
		string GetRole();
	}
}