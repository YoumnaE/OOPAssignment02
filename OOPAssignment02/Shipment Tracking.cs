using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssignment02
{
    internal partial class Shipment
    {
        private string trackingStatus = "In Transit";

        public string GetTrackingStatus()
        {
            return trackingStatus;
        }

        public void UpdateTrackingStatus(string newStatus)
        {
            if (!string.IsNullOrWhiteSpace(newStatus))
            {
                trackingStatus = newStatus;
            }
        }
    }
}
