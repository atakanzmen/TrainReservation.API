using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainReservation.BusinessLayer.Abstract;
using TrainReservation.BusinessLayer.Concrete;
using TrainReservation.Entities.Request;
using TrainReservation.Entities.Response;

namespace TrainReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public ReservationResponse Post([FromBody] ReservationRequest request)
        {
            return _reservationService.Reservation(request);
        }
    }
}
