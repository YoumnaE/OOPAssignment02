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
            #region Q1

            DeliveryAddress address1 = new DeliveryAddress("Alex", "Smouha", 20);
            DeliveryAddress address2 = address1;

            address2.Street = "Sidi Gaber";
            address2.BuildingNumber = 1;
            //Because DeliveryAddress is a struct, address2 gets its own copy
            Console.WriteLine(address1.GetFullAddress());
            Console.WriteLine(address2.GetFullAddress());




            DeliveryCenter deliveryCenter = new DeliveryCenter();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"***Enter Shipment {i + 1}***");

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

                Console.Write("Street: ");
                string street = Console.ReadLine();

                Console.Write("Building Number: ");
                int buildingNumber = int.Parse(Console.ReadLine());

                DeliveryAddress address = new DeliveryAddress(city, street, buildingNumber);

                Shipment shipment = new Shipment(trackingCode, description, weight, deliveryFee, address);

                deliveryCenter.AddShipment(shipment);

            #endregion





            }

            //print all 3 shipments
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nShipment {i + 1}:");
                deliveryCenter[i].PrintShipment();
            }


            //search using string indexer
            Console.Write("\nEnter tracking code to search: ");
            string searchCode = Console.ReadLine();

            Shipment foundShipment = deliveryCenter[searchCode];

            // Check if shipment was found
            if (!string.IsNullOrEmpty(foundShipment.TrackingCode))
            {
                Console.WriteLine("\nShipment found:");
                foundShipment.PrintShipment();
            }
            else
            {
                Console.WriteLine("Shipment not found.");
            }

            Console.ReadLine();
            #endregion
        }
    }
}
