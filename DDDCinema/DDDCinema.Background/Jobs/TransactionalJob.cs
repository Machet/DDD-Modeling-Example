using DDDCinema.DataAccess;
using Quartz;

namespace DDDCinema.Background.Jobs
{
    public class TransactionalJob : IJob
    {
        private readonly IJob _innerJob;
        private readonly InfrastructureContext _context;

        public TransactionalJob(IJob job, InfrastructureContext context)
        {
            _innerJob = job;
            _context = context;
        }

        public void Execute(IJobExecutionContext context)
        {
            _innerJob.Execute(context);
            _context.SaveChanges();
        }
    }
}
