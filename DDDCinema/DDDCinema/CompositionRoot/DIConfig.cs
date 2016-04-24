using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using DDDCinema.Common;
using DDDCinema.DataAccess;
using DDDCinema.DataAccess.AuditLogging;
using DDDCinema.DataAccess.Movies;
using DDDCinema.Movies;
using DDDCinema.Movies.Authentication;
using DDDCinema.Movies.Commands;
using DDDCinema.Movies.Lotery;
using DDDCinema.Movies.Notifications;
using DDDCinema.Promotions;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace DDDCinema.CompositionRoot
{
	public class DIConfig
	{
		public static void Setup()
		{
			var container = new Container();
			var perRequest = new WebRequestLifestyle();
			var dataAccessAssembly = typeof(CinemaContext).Assembly;
			var moviesAssembly = typeof(Seat).Assembly;
			var promotionsAssembly = typeof(PromotionDraft).Assembly;
			var connectionString = ConfigurationManager.ConnectionStrings["DDDCinema"].ConnectionString;

			container.Register(() => new CinemaContext(connectionString), perRequest);
			container.Register(() => new PromotionsContext(connectionString), perRequest);
			var userProviderRegistration = Lifestyle.Singleton.CreateRegistration<ContextUserProvider>(container);
			container.AddRegistration(typeof(ICurrentUserProvider), userProviderRegistration);
			container.AddRegistration(typeof(ContextUserProvider), userProviderRegistration);
			container.Register<IWinChanceCalculatorFactory, SimpleInjectorWinChanceCalculatorFactory>(Lifestyle.Singleton);

			foreach (var repositorType in dataAccessAssembly.GetExportedTypes()
				.Where(t => t.Name.Contains("Repository")))
			{
				container.Register(repositorType.GetInterfaces().Single(), repositorType, perRequest);
			}

			container.RegisterDecorator(typeof(ICommandHandler<LoginCommand>), typeof(AuditingLoginCommandHandler));
			container.RegisterDecorator(typeof(ICommandHandler<>), typeof(AuditingCommandHandler<>),
				p => !p.AppliedDecorators.Any(t => t.Name.Contains("Auditing")));
			container.RegisterDecorator(typeof(ICommandHandler<>), typeof(CinemaTransactionalCommandHandler<>), p => p.ImplementationType.Namespace.Contains("Movies"));
			container.RegisterDecorator(typeof(ICommandHandler<>), typeof(PromotionTransactionalCommandHandler<>), p => p.ImplementationType.Namespace.Contains("Promotions"));
			container.Register(typeof(ICommandHandler<>), new[] { moviesAssembly, promotionsAssembly });

			container.RegisterCollection(typeof(INotificationSender), new[] { moviesAssembly });
			var registration = perRequest.CreateRegistration<SendNotificationWhenSeatTaken>(container);
			container.AppendToCollection(typeof(IDomainEventHandler<>), typeof(AuditOccurrenceEventHandler<>));
			container.RegisterCollection(typeof(IDomainEventHandler<>), new[] { registration });
			container.RegisterDecorator(typeof(IDomainEventHandler<>), typeof(AuditingEventHandler<>),
				p => !p.ImplementationType.Name.Contains("Audit"));


			container.Register<List<INotificationSender>>(() => container.GetAllInstances<INotificationSender>().ToList(), perRequest);
			DomainEventBus.Current = new SimpleInjectorEventBus(container);
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
		}
	}
}