using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssignment02
{
    internal class PriorityInternationalShipment : InternationalShipment
    {
        public PriorityInternationalShipment(string trackingCode, string description, double weight, double deliveryFee,DeliveryAddress destination,string destinationCountry,decimal customsFee)
            : base(trackingCode, description, weight,deliveryFee,destination, destinationCountry, customsFee)
        {
        }

        public sealed override void GenerateCustomsReport()  // cannot inherit after this
        {
            Console.WriteLine("Priority Customs Report");
            Console.WriteLine("Destination Country: " + DestinationCountry);
            Console.WriteLine("Customs Fee: " + CustomsFee);
        }
    }
}
