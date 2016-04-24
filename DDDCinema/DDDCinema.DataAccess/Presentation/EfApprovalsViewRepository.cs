using System;
using DDDCinema.Application.Presentation.Promotions;
using DDDCinema.Common;

namespace DDDCinema.DataAccess.Presentation
{
	public class EfApprovalsViewRepository : IApprovalsViewRepository
	{
		private readonly PromotionsContext _context;
		private readonly ICurrentUserProvider _provider;

		public EfApprovalsViewRepository(PromotionsContext context, ICurrentUserProvider provider)
		{
			_context = context;
			_provider = provider;
		}

		public ApprovalsView GetApprovals()
		{
			throw new NotImplementedException();
		}
	}
}
