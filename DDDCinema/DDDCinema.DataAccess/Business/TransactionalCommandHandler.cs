using System.Data.Entity;
using DDDCinema.Common;

namespace DDDCinema.DataAccess.Movies
{
	public abstract class TransactionalCommandHandler<TCommand, TContext> : ICommandHandler<TCommand>
		where TCommand : ICommand
		where TContext : DbContext
	{
		private ICommandHandler<TCommand> _innerHandler;
		private TContext _context;

		public TransactionalCommandHandler(ICommandHandler<TCommand> handler, TContext context)
		{
			_context = context;
			_innerHandler = handler;
		}

		public void Handle(TCommand command)
		{
			_innerHandler.Handle(command);
			_context.SaveChanges();
		}
	}

	public class CinemaTransactionalCommandHandler<T> : TransactionalCommandHandler<T, CinemaContext> where T : ICommand
	{
		public CinemaTransactionalCommandHandler(ICommandHandler<T> handler, CinemaContext context) : base(handler, context) { }
	}

	public class PromotionTransactionalCommandHandler<T> : TransactionalCommandHandler<T, PromotionsContext> where T : ICommand
	{
		public PromotionTransactionalCommandHandler(ICommandHandler<T> handler, PromotionsContext context) : base(handler, context) { }
	}
}
