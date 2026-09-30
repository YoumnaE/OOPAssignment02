namespace OOPAssignment02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part One

            #region Q1

            //a) What is the difference between a class and a struct?
            // Struct: 1. Value Type,stored in stack, non-nullable
            //         2. paramterless or custom constructor
            //         3. better performance with smaller data

            // Class: 1. Reference Type, stored in heap, nullable
            //        2. paramterless or custom constructor
            //        3. suitable with complex data



            //b) while struct has better performance with smaller data, class has more complex feature such as inheritance suitable with more complex data

            #endregion

            #region Q2

            //a) Which class is the parent class? Shipment
            //b) Which class is the child class? ExpressShipment
            //c) What members are inherited by ExpressShipment? TrackingCode
            //d) Why is inheritance better than duplicating the same code in multiple classes?
            //      less code, easier to maintain and extend

            #endregion

            #endregion

            #region Part Two
            Console.Write("Enter center name: ");
            string centerName = Console.ReadLine();
            DeliveryCenter deliveryCenter = new DeliveryCenter(centerName);
            Console.WriteLine("Delivery center created: " + deliveryCenter.CenterName);

            #region Standard Shipment

            Console.WriteLine("\n Standard Shipment");

            Console.Write("Tracking Code: ");
            string trackingCode = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Weight: ");
            double weight = double.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            double deliveryFee = double.Parse(Console.ReadLine());

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("Country: ");
            string country = Console.ReadLine();

            Console.Write("Postal Code: ");
            int postalCode = int.Parse(Console.ReadLine());

            DeliveryAddress address = new DeliveryAddress(city,country,postalCode);
            StandardShipment standard = new StandardShipment(trackingCode,description,weight,deliveryFee,address);

            #endregion


            #region Express Shipment

            Console.WriteLine("\n--- Express Shipment ---");

            Console.Write("Tracking Code: ");
            trackingCode = Console.ReadLine();

            Console.Write("Description: ");
            description = Console.ReadLine();

            Console.Write("Weight: ");
            weight = double.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            deliveryFee = double.Parse(Console.ReadLine());

            Console.Write("Extra Fee: ");
            decimal extraFee = decimal.Parse(Console.ReadLine());

            Console.Write("City: ");
            city = Console.ReadLine();

            Console.Write("Country: ");
            country = Console.ReadLine();

            Console.Write("Postal Code: ");
            postalCode = int.Parse(Console.ReadLine());

            address = new DeliveryAddress(city,country,postalCode);

            ExpressShipment express = new ExpressShipment(trackingCode,description,weight,deliveryFee,address,extraFee);

            #endregion

            #region International Shipment

            Console.WriteLine("\n International Shipment");

            Console.Write("Tracking Code: ");
            trackingCode = Console.ReadLine();

            Console.Write("Description: ");
            description = Console.ReadLine();

            Console.Write("Weight: ");
            weight = double.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            deliveryFee = double.Parse(Console.ReadLine());

            Console.Write("Destination Country: ");
            string destinationCountry = Console.ReadLine();

            Console.Write("Customs Fee: ");
            decimal customsFee = decimal.Parse(Console.ReadLine());

            Console.Write("City: ");
            city = Console.ReadLine();

            Console.Write("Country: ");
            country = Console.ReadLine();

            Console.Write("Postal Code: ");
            postalCode = int.Parse(Console.ReadLine());

            address = new DeliveryAddress(city,country,postalCode);

            InternationalShipment international = new InternationalShipment(trackingCode,description,weight,deliveryFee,address,destinationCountry,customsFee);

            #endregion

            deliveryCenter.AddShipment(standard);
            deliveryCenter.AddShipment(express);
            deliveryCenter.AddShipment(international);

            Console.WriteLine("\n ALL SHIPMENTS");
            deliveryCenter.PrintAllShipments();

            //search using string indexer
            #region Search

            Console.Write("\nEnter tracking code to search: ");
            string searchCode = Console.ReadLine();

            Shipment foundShipment = deliveryCenter[searchCode];

            if (foundShipment != null){
                Console.WriteLine("\nShipment found:");
                foundShipment.PrintShipment();
            }else{
                Console.WriteLine("Shipment not found.");
            }

            #endregion


            #region remove

            Console.Write("Enter tracking code to remove: ");
            string userTrackingCode = Console.ReadLine();

            bool removed = deliveryCenter.RemoveShipment(userTrackingCode);

            if (removed){
                Console.WriteLine("removed successfully.");
                Console.WriteLine("\n ALL SHIPMENTS");
                deliveryCenter.PrintAllShipments();
            }
            else{
                Console.WriteLine("not found.");
            }

            #endregion
            Console.ReadLine();
            #endregion
        }
    }
}
