using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssignment02
{
    internal class InternationalShipment : Shipment
    {
        private string destinationCountry;
        private decimal customsFee;

        public string DestinationCountry
        {
            get { return destinationCountry; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    destinationCountry = value;
            }
        }

        public decimal CustomsFee
        {
            get { return customsFee; }
            set
            {
                if (value >= 0)
                    customsFee = value;
            }
        }

        public override double EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + (double)CustomsFee;
            }
        }

        public InternationalShipment(string trackingCode, string description, double weight, double deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }
        public override void PrintShipment()
        {
            base.PrintShipment();
            Console.WriteLine("Destination Country: " + DestinationCountry);
            Console.WriteLine("Customs Fee: " + CustomsFee);
        }
    }
}
