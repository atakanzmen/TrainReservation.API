using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.BusinessLayer.Abstract;
using TrainReservation.Entities.Request;
using TrainReservation.Entities.Response;

namespace TrainReservation.BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        public ReservationResponse Reservation(ReservationRequest request)
        {
            ReservationResponse response = new ReservationResponse();
            Dictionary<string, int> vagonInfs = new Dictionary<string, int>();
            List<SittingDetail> sittingDet = new List<SittingDetail>();
            int peopleNum = request.ReservationNum;
            bool diffSittingPlan = request.DifferentVagon;

            foreach (Vagon vagon in request.Train.Vagons)
            {
                int emptySeats = 0;
                if (vagon.Capacity * 0.7 - vagon.FullSeatsNum > 0)
                {
                    emptySeats = Convert.ToInt32(vagon.Capacity * 0.7 - vagon.FullSeatsNum);
                }

                vagonInfs.Add(vagon.Name, emptySeats);
            }

            foreach (var vagonInf in vagonInfs)
            {
                if (peopleNum > 0)
                {
                    if (vagonInf.Value != 0)
                    {
                        if (peopleNum > vagonInf.Value && diffSittingPlan)
                        {
                            sittingDet.Add(new SittingDetail()
                            {
                                PassengerNum = vagonInf.Value,
                                VagonName = vagonInf.Key
                            });

                            peopleNum -= vagonInf.Value;
                        }
                        else if (peopleNum <= vagonInf.Value)
                        {
                            sittingDet.Add(new SittingDetail()
                            {
                                PassengerNum = peopleNum,
                                VagonName = vagonInf.Key
                            });

                            peopleNum = 0;
                        }
                    }

                    if (peopleNum == 0)
                    {
                        response.SittingDetails = sittingDet;
                        response.AvailableToBook = true;
                        return response;
                    }
                }
            }
            response.AvailableToBook = false;
            response.SittingDetails = new List<SittingDetail>();
            return response;
        }
    }
}
