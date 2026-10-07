using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssignment02
{
    internal class PriorityInternationalShipment : InternationalShipment
    {
        public PriorityInternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee,DeliveryAddress destination,string destinationCountry,decimal customsFee)
            : base(trackingCode, description, weight,deliveryFee,destination, destinationCountry, customsFee)
        {
        }

        // public sealed override void GenerateCustomsReport()  // cannot inherit after this
        //{
           // Console.WriteLine("Priority Customs Report");
            //Console.WriteLine("Destination Country: " + DestinationCountry);
           // Console.WriteLine("Customs Fee: " + CustomsFee);
        //}
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
    }
}
