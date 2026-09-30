using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssignment02
{
    internal class StandardShipment : Shipment
    {
        public StandardShipment(string trackingCode,string description,double weight,double deliveryFee,DeliveryAddress destination)
        : base(trackingCode, description, weight, deliveryFee, destination)
        {

        }
    }
}
