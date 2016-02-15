using DDDCinema.Movies.Authentication;
using DDDCinema.Presentation.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
