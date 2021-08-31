using System;
using System.Collections.Generic;
using System.Text;

namespace TrainReservation.Entities.Request
{
    public class Train
    {
        public string Name { get; set; }
        public List<Vagon> Vagons { get; set; }
    }
}
