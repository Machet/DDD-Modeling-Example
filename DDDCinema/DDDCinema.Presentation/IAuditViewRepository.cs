using System;
using System.Collections.Generic;

namespace DDDCinema.Presentation
{
    public interface IAuditViewRepository
    {
        List<AuditDTO> GetAuditEntriesForUser(Guid userId);
    }
}
