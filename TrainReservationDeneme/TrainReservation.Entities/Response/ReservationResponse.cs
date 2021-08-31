using System;
using System.Collections.Generic;
using System.Text;

namespace TrainReservation.Entities.Response
{
    public class ReservationResponse
    {
        public bool AvailableToBook { get; set; }
        public List<SittingDetail> SittingDetails { get; set; }
    }
}
