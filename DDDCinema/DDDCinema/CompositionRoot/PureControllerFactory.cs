using DDDCinema.Movies.Authentication;
using DDDCinema.Movies.Commands;
using DDDCinema.Controllers;
using DDDCinema.DataAccess.AuditLogging;
using DDDCinema.DataAccess.Movies;
using DDDCinema.DataAccess.Presentation;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace DDDCinema.CompositionRoot
{
    public class PureControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type controllerType = GetControllerType(requestContext, controllerName);
            var perRequestStore = PerRequestStore.Current;

            if (controllerType == typeof(HomeController))
            {
                var movieRepository = new EfMovieViewRepository(perRequestStore.Context.Value);
                return new HomeController(movieRepository);
            }

            if (controllerType == typeof(ReservationController))
            {
                var handler = new ReserveSeatCommandHandler(
                    perRequestStore.UserRepository.Value,
                    perRequestStore.RoomRepository.Value,
                    new PureWinChanceCalculatorFactory(perRequestStore.UserRepository.Value));
                var auditingHandler = new AuditingCommandHandler<ReserveSeatCommand>(
                    handler,
                    perRequestStore.AuditLogger.Value);
                var transactionalHandler = new TransactionalCommandHandler<ReserveSeatCommand>(
                    auditingHandler,
                    perRequestStore.Context.Value);
                return new ReservationController(transactionalHandler);
            }

            if (controllerType == typeof(LoginController))
            {
                var handler = new LoginCommandHandler(new EfAuthenticationRepository(perRequestStore.Context.Value), perRequestStore.CurrentUserProvider.Value, new StringHasher());
                var auditingHandler = new AuditingLoginCommandHandler(handler, perRequestStore.AuditLogger.Value);
                var transactionalHandler = new TransactionalCommandHandler<LoginCommand>(auditingHandler, perRequestStore.Context.Value);
                return new LoginController(new EfLoginRepository(perRequestStore.Context.Value), transactionalHandler);
            }

            if (controllerType == typeof(AuditController))
            {
                return new AuditController(new EfAuditViewRepository(perRequestStore.Context.Value));
            }

            if (controllerType == typeof(NotificationController))
            {
                return new NotificationController(new EfNotificationViewRepository(perRequestStore.Context.Value));
            }

            return base.CreateController(requestContext, controllerName);
        }
    }
}