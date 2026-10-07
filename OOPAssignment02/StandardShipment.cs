using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssignment02
{
    internal class StandardShipment : Shipment, ITrackable,IInsurable
    {
        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.05m;
        }
        public StandardShipment(string trackingCode,string description, decimal weight, decimal deliveryFee,DeliveryAddress destination)
        : base(trackingCode, description, weight, deliveryFee, destination)
        {

        }
        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5);
            }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Tracking Code: " + TrackingCode);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Weight: " + Weight);
            Console.WriteLine("Delivery Fee: " + DeliveryFee);
            Console.WriteLine("Destination: " + Destination.GetFullAddress());
            Console.WriteLine("Estimated Cost: " + EstimatedCost);
        }
        public string GetTrackingStatus()
        {
            return "Shipment " + TrackingCode + " is Ready.";
        }
    }
}
