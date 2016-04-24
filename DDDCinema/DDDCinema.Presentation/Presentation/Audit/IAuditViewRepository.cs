using System;
using System.Collections.Generic;

namespace DDDCinema.Application.Presentation.Audit
{
    public interface IAuditViewRepository
    {
        List<AuditDTO> GetAuditEntriesForUser(Guid userId);
    }
}
