using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssignment02
{
    internal abstract class Shipment
    {
        private string trackingCode;
        private string description;
        private double weight;
        private double deliveryFee;

        //read-only
        public string TrackingCode
        {
            get { return trackingCode; }
        }

        //read/write property with validation
        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    description = value;
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                    weight = value;
            }
        }

        //private setter
        public double DeliveryFee
        {
            get { return deliveryFee; }
            private set
            {
                if (value > 0)
                    deliveryFee = value;
            }
        }
        public DeliveryAddress Destination { get; set; }

        public abstract decimal EstimatedCost
        {
            get;
        }

        public Shipment(string trackingCode)
        {
            this.trackingCode = trackingCode;
            description = "Unknown";
            weight = 1;
            deliveryFee = 50;

            Destination = new DeliveryAddress(
                "Unknown",
                "Unknown",
                0
            );
        }
        public Shipment(string trackingCode, string description, double weight, double deliveryFee, DeliveryAddress destination)
        {
            this.trackingCode = trackingCode;     //belonging to current shipment
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }
        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                deliveryFee = (double)newFee;
            }
        }
        public abstract void PrintShipment();
        public void UpdateWeight(double newWeight)
        {
            if (newWeight > 0)
            {
                Weight = newWeight;
            }
        }

        //updates weign after adding packing weight
        public void UpdateWeight(double newWeight, double packingWeight)
        {
            if (newWeight > 0 && packingWeight >= 0)
            {
                Weight = newWeight + packingWeight;
            }
        }
    }
}
