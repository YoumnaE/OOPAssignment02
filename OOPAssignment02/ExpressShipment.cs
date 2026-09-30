using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssignment02
{
    internal class ExpressShipment : Shipment
    {
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

        public new double EstimatedCost     //overrides estimatedcost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + (double)ExtraFee;
            }
        }

        public ExpressShipment(string trackingCode, string description, double weight,double deliveryFee,DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }
    }
}
