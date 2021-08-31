using System;
using System.Collections.Generic;
using System.Text;

namespace TrainReservation.Entities.Request
{
    public class Vagon
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int FullSeatsNum { get; set; }
    }
}
