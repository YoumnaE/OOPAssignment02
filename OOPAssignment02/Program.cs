using System.ComponentModel;
using System.Reflection.Metadata;
using System.Threading.Channels;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OOPAssignment02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part One

            #region Q1 Object Coping

            //a) What happens when you assign one object variable to another object variable?
            //    reference is copied, both variables point to the same object in memory

            //b) Does assigning one object to another create a new object? Explain.
            //    no,it copies the reference to the existing object

            //c) What is the difference between copying an object and copying its reference?
            // copying a reference: Both variables refer to the same object, so changes are visible to eachother
            // copying an object: a new object is created with copied data, changes do not affect the other 

            #endregion

            #region Q2 Shallow and Deep Coping

            //a) What is a Shallow Copy?
            // shallow copy creates a new object but copies the references of its reference

            //b) What is a Deep Copy?
            //deep copy creates a new object and independent copy, so changes to one object do not affect the other

            //c) What happens to reference-type members when a Shallow Copy is created?
            // references are copied, so the original object and the copied object share the same address

            //d) What happens to reference-type members when a Deep Copy is created?
            //new copies objects are created, so the original and copied objects have independent objects

            //e) Give one situation where Deep Copy would be safer than Shallow Copy.
            //when copying a record that contains a mutable address object, deep copy is safer because changing the copied address will not affect the original

            #endregion

            #region Q3 Static Objects

            //a) What is a static field, and how is it different from an instance field?
            // static field: belongs to the class and shared by all objects
            // instance field: belongs to each object and every object has its own copy


            //b) What is a static method? Can a static method directly access instance members?
            //static method belongs to the class and can be called without creating an object
            //No

            //c) What is a static constructor, and when is it executed ?
            //tatic constructor initializes static members, executes automatically once before the class is used

            //d) What is a static class? Can you create an object from a static class?
            //static class contains only static members
            //No


            #endregion

            #region Q4 Extenstion Methods

            //a) What is an Extension Method?
            // allows adding a new method to an existing type without modifying its original code

            //b) What keyword must be used in the first parameter of an extension method? this.

            //c) Where must an extension method be declared?
            //inside a static class and the method  must also be static.

            //d) Can an extension method access private members of the class it extends? no

            #endregion

            #region Q5 Partial

            //a) What is a Partial Class?
            // one class can be split into multiple parts across different files

            //b) Why would a developer split one class into multiple files?
            //organization, maintainance , teamwork

            //c) What is a Partial Method?
            //method declared in a partial class and implemented in another part of the same class.

            //d) What happens if a declared partial method has no implementation?
            //compiler removes its declaration,no error occurs.

            #endregion


            #endregion

        #region Past Assignment
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

            
            #endregion

            #region Part two

            #region obj coping

            StandardShipment shipment1 = new StandardShipment("SH001","Books",5,50,new DeliveryAddress("Alexandria", "Egypt", 12345));

            Shipment shipment2 = shipment1;

            //creates a separate shipment object
            Shipment shipment3 = shipment1.CopyShipment();

            shipment2.UpdateWeight(10);

            Console.WriteLine(shipment1.Weight); // 10
            Console.WriteLine(shipment3.Weight); // 5

            #endregion

            #region shallow coping

            Shipment shipment4 = shipment1.ShallowCopy();

            // The address objects are the same
            Console.WriteLine(ReferenceEquals(shipment1.Destination, shipment4.Destination));
            // True

            #endregion

            #endregion
            Console.ReadLine();
        }
    }
}
