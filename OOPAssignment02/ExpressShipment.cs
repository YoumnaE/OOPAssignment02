using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssignment02
{
    internal class ExpressShipment : Shipment, ITrackable, IInsurable
    {
        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.08m;
        }
        public string GetTrackingStatus()
        {
            return "Shipment " + TrackingCode + " is Out for Delivery.";
        }
        private decimal extraFee;

        public decimal ExtraFee
        {
            get { return extraFee; }
            set
            {
                if (value >= 0)
                    extraFee = value;
            }
        }


        public ExpressShipment(string trackingCode, string description, decimal weight,decimal deliveryFee,DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }
        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + ExtraFee;
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
            Console.WriteLine("Extra Fee: " + ExtraFee);
        }
    }
}
