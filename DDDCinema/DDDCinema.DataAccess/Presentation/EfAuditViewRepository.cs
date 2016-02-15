using DDDCinema.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDCinema.DataAccess.Presentation
{
    public class EfAuditViewRepository : IAuditViewRepository
    {
        private readonly CinemaContext _context;

        public EfAuditViewRepository(CinemaContext context)
        {
            _context = context;
        }

        public List<AuditDTO> GetAuditEntriesForUser(Guid userId)
        {
            return _context.AuditLogs
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.ChangeTime)
                .ThenByDescending(a => a.Id)
                .Select(a => new AuditDTO
                {
                    AuditTime = a.ChangeTime,
                    AuditText = a.Changes
                }).Take(30).ToList();
        }
    }
}
