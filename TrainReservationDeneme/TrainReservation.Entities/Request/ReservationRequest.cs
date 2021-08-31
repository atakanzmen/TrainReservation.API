using System;
using System.Collections.Generic;
using System.Text;

namespace TrainReservation.Entities.Request
{
    public class ReservationRequest
    {
        public Train Train { get; set; }
        public int ReservationNum { get; set; }
        public bool DifferentVagon { get; set; }
    }
}
