using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.Entities.Request;
using TrainReservation.Entities.Response;

namespace TrainReservation.BusinessLayer.Abstract
{
    public interface IReservationService
    {
        ReservationResponse Reservation(ReservationRequest request);
    }
}
