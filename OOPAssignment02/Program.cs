namespace OOPAssignment02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part One

            #region Assignment 03 Q2

            // a)  What is the purpose of the sealed keyword when applied to a class? 
            //     cannot be inherited by another class 

            // b)  What is the difference between a sealed class and a sealed method?
            //     sealed class: prevents the class from being inherited
            //     Sealed method: prevents a method from being overridden in inheritance class

            // c)  Can a sealed method be overridden? Why?
            //     sealeed keyword prevents overriding 

            #endregion

            #region Assignment 04

            #region Q1

            // a)  What is Abstraction in Object - Oriented Programming?
            //     hiding unimportant implementtation and only showing key features

            // b)  Why is abstraction considered one of the four pillars of OOP?
            // makes code easier to understand, use, maintain and hides complexity 

            #endregion

            #region Q2

            // a)  What is the difference between an Abstract Class and an Interface?
            //     abstract class: 1. can have both abstarct and non-abstract methods
            //                     2. conatins fields + constructors
            //                     3. class can inherit only one
            //                     4. used when classes hvae shared code
            //     Interface: 1. defines structure
            //                2. class can implement more than 1
            //                3. unrelated classes with same behaviour

            // b)  When would you choose an Interface instead of an Abstract Class?
            //    when classes can be unrelated but share same structure
            //    or when class has multiple behaviors ( can implement multiple interfaces)

            // c)  Can a class inherit from multiple abstract classes? Can it implement multiple interfaces?
            //     class cannot inherit multiple classes but can implement multiple interfaces


            #endregion


            #endregion
            #endregion

            #region Part Two
            Console.Write("Enter center name: ");
            string centerName = Console.ReadLine();
            DeliveryCenter deliveryCenter = new DeliveryCenter(centerName);
            Console.WriteLine("Delivery center created: " + deliveryCenter.CenterName);

            Driver driver = new Driver("Ahmed");
            deliveryCenter.Driver = driver;

            #region Standard Shipment

            Console.WriteLine("\n Standard Shipment");

            Console.Write("Tracking Code: ");
            string trackingCode = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Weight: ");
            decimal weight = decimal.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            decimal deliveryFee = decimal.Parse(Console.ReadLine());

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
            weight = decimal.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            deliveryFee = decimal.Parse(Console.ReadLine());

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
            weight = decimal.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            deliveryFee = decimal.Parse(Console.ReadLine());

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
            Console.WriteLine("\n--- Tracking Statuses ---");
            deliveryCenter.PrintTrackingStatuses();

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
                DeliveryHelper.PrintShipmentDetails(standard);
                DeliveryHelper.PrintShipmentDetails(express);
                DeliveryHelper.PrintShipmentDetails(international);
            }
            else{
                Console.WriteLine("not found.");
            }

            Console.WriteLine("--- Tracking Statuses ---");

            DeliveryReport.PrintShipment(standard);
            DeliveryReport.PrintShipment(express);
            DeliveryReport.PrintShipment(international);

            Console.WriteLine("--- Insurance ---");

            DeliveryReport.PrintInsurance(standard);
            DeliveryReport.PrintInsurance(express);
            DeliveryReport.PrintInsurance(international);

            #region h & j

            // h) Store shipments in an ITrackable[] array
            Console.WriteLine("\n--- ITrackable Array ---");

            ITrackable[] trackableShipments = {standard,express,international};

            foreach (ITrackable shipment in trackableShipments)
            {
                Console.WriteLine(shipment.GetTrackingStatus());
            }


            // i) Store shipments in an IInsurable[] array
            Console.WriteLine("\n--- IInsurable Array ---");

            IInsurable[] insurableShipments ={standard,express,international};

            foreach (IInsurable shipment in insurableShipments)
            {
                Console.WriteLine("Insurance Cost: " + shipment.CalculateInsurance());
            }

            #endregion


            #endregion

            // Sealed class demonstration:
            // CompletedShipment is sealed so another class cannot inherit from it.
            //
            // class MyShipment : CompletedShipment
            // {
            // }
            // compilation error.

            Console.ReadLine();
            #endregion
        }
    }
}
