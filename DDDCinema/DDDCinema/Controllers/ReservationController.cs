using System;
using System.Web.Mvc;
using DDDCinema.Application.Movies;
using DDDCinema.Common;

namespace DDDCinema.Controllers
{
	[Authorize]
	public class ReservationController : Controller
	{
		private readonly ICommandHandler<ReserveSeatCommand> _movieService;
		private readonly ICurrentUserProvider _userProvider;

		public ReservationController(ICurrentUserProvider userProvider, ICommandHandler<ReserveSeatCommand> service)
		{
			_movieService = service;
			_userProvider = userProvider;
		}

		[HttpPost]
		public ActionResult ChooseSeat(int seanseId, string seat)
		{
			var seatPosition = seat.Split('_');
			_movieService.Handle(new ReserveSeatCommand
			{
				UserId = _userProvider.GetUserId().Value,
				SeanseId = seanseId,
				SeatNumber = int.Parse(seatPosition[1]),
				SeatRow = int.Parse(seatPosition[0])
			});

			return RedirectToAction("SeatTaken");
		}

		[HttpGet]
		public ActionResult SeatTaken()
		{
			return View();
		}
	}
}