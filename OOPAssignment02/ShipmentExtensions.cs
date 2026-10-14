using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssignment02
{
    internal static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            ITrackable trackable = (ITrackable)shipment;
            return $"{shipment.TrackingCode} | " + $"{shipment.GetType().Name.Replace("Shipment", "")} | " + $"{shipment.Weight} KG | " + $"{trackable.GetTrackingStatus()}";
        }

        public static bool IsDelivered(this Shipment shipment)
        {
            ITrackable trackable = (ITrackable)shipment;
            return trackable.GetTrackingStatus() == "Delivered";
        }
    }
}
