﻿using System;
using System.Web.Mvc;
using DDDCinema.Common;
using DDDCinema.Movies.Commands;

namespace DDDCinema.Controllers
{
	[Authorize]
	public class ReservationController : Controller
	{
		private readonly ICommandHandler<ReserveSeatCommand> _movieService;

		public ReservationController(ICommandHandler<ReserveSeatCommand> service)
		{
			_movieService = service;
		}

		[HttpPost]
		public ActionResult ChooseSeat(int seanseId, string seat)
		{
			var seatPosition = seat.Split('_');
			_movieService.Handle(new ReserveSeatCommand
			{
				UserId = Guid.Parse(User.Identity.Name),
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