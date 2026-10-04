namespace Assignment_03_OOP_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1st Question Theoretical

            // Question 1:
            // a) What is the difference between Method Overloading and Method Overriding?
            //
            // Answer:
            //
            // Method Overloading:
            // It means having more than one method with the same name
            // but with different parameters.
            //
            // Example:
            // UpdateWeight(double newWeight)
            // UpdateWeight(double newWeight, double packingWeight)
            //
            // Method Overriding:
            // It means that a derived class provides its own implementation
            // of a method inherited from the base class.
            //
            // The base method must be virtual and the derived method uses override.
            //
            // Example:
            // Base class:
            // public virtual void PrintShipment()
            //
            // Derived class:
            // public override void PrintShipment()


            // b) What is the difference between Static Binding and Dynamic Binding?
            //
            // Answer:
            //
            // Static Binding:
            // The method call is decided at compile time.
            // Method overloading is an example of static binding.
            //
            // Dynamic Binding:
            // The method call is decided at runtime based on the actual object type.
            // Method overriding with virtual and override is an example of dynamic binding.
            //
            // Example:
            //
            // Shipment shipment = new ExpressShipment(...);
            //
            // shipment.PrintShipment();
            //
            // Although the variable type is Shipment,
            // the actual object is ExpressShipment.
            // Therefore, ExpressShipment.PrintShipment() is executed.

            #endregion
            #region Driver and Delivery Center

            string driverName = ReadRequiredString("Enter Driver Name: ");
            Driver driver = new Driver(driverName);

            string centerName = ReadRequiredString("Enter Delivery Center Name: ");
            DeliveryCenter center = new DeliveryCenter(centerName);

            center.Driver = driver;

            #endregion


            #region Question 12 - Main Demonstration

            Console.WriteLine();
            Console.WriteLine("===== Standard Shipment =====");

            StandardShipment standardShipment = CreateStandardShipment();

            Console.WriteLine();
            Console.WriteLine("===== Express Shipment =====");

            ExpressShipment expressShipment = CreateExpressShipment();

            Console.WriteLine();
            Console.WriteLine("===== International Shipment =====");

            InternationalShipment internationalShipment = CreateInternationalShipment();

            center.AddShipment(standardShipment);
            center.AddShipment(expressShipment);
            center.AddShipment(internationalShipment);


            Console.WriteLine();
            Console.WriteLine("===== All Shipments =====");

            center.PrintAllShipments();


            Console.WriteLine();
            Console.WriteLine("===== Delivery Helper =====");

            DeliveryHelper.PrintShipmentDetails(standardShipment);
            DeliveryHelper.PrintShipmentDetails(expressShipment);
            DeliveryHelper.PrintShipmentDetails(internationalShipment);


            Console.WriteLine();
            Console.WriteLine("===== Update Weight =====");

            Console.WriteLine($"Original Weight: {standardShipment.Weight} KG");

            standardShipment.UpdateWeight(5);

            Console.WriteLine($"Updated Weight: {standardShipment.Weight} KG");

            standardShipment.UpdateWeight(5, 0.5);

            Console.WriteLine($"Updated Weight After Packing: {standardShipment.Weight} KG");


            Console.WriteLine();
            Console.WriteLine("===== Mixed Shipment Array =====");

            Shipment[] shipments =
            {
            standardShipment,
            expressShipment,
            internationalShipment
        };

            for (int i = 0; i < shipments.Length; i++)
            {
                shipments[i].PrintShipment();
            }


            #region Search Shipment

            Console.WriteLine();
            Console.WriteLine("===== Search Shipment =====");

            string searchCode = ReadRequiredString("Enter Tracking Code to search: ");

            Shipment? searchedShipment = center[searchCode];

            if (searchedShipment != null)
            {
                Console.WriteLine();
                Console.WriteLine("Shipment Found:");

                searchedShipment.PrintShipment();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Shipment Not Found.");
            }

            #endregion


            #region Remove Shipment

            Console.WriteLine();
            Console.WriteLine("===== Remove Shipment =====");

            string removeCode = ReadRequiredString("Enter Tracking Code to remove: ");

            bool removed = center.RemoveShipment(removeCode);

            if (removed)
            {
                Console.WriteLine();
                Console.WriteLine("Shipment removed successfully.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Shipment Not Found.");
            }

            #endregion


            #region Remaining Shipments

            Console.WriteLine();
            Console.WriteLine("===== Remaining Shipments =====");

            center.PrintAllShipments();

            #endregion

            #endregion
        }


        #region Protective Code

        static string ReadRequiredString(string message)
        {
            while (true)
            {
                Console.Write(message);

                string input = Console.ReadLine() ?? string.Empty;

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }

                Console.WriteLine("Invalid input. Please try again.");
            }
        }


        static double ReadPositiveDouble(string message)
        {
            while (true)
            {
                Console.Write(message);

                string input = Console.ReadLine() ?? string.Empty;

                if (double.TryParse(input, out double value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine("Please enter a number greater than 0.");
            }
        }


        static decimal ReadPositiveDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);

                string input = Console.ReadLine() ?? string.Empty;

                if (decimal.TryParse(input, out decimal value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine("Please enter a value greater than 0.");
            }
        }


        static decimal ReadNonNegativeDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);

                string input = Console.ReadLine() ?? string.Empty;

                if (decimal.TryParse(input, out decimal value) && value >= 0)
                {
                    return value;
                }

                Console.WriteLine("Please enter a value of 0 or greater.");
            }
        }


        static int ReadPositiveInt(string message)
        {
            while (true)
            {
                Console.Write(message);

                string input = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(input, out int value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine("Please enter an integer greater than 0.");
            }
        }

        #endregion


        #region Create Standard Shipment

        static StandardShipment CreateStandardShipment()
        {
            string trackingCode = ReadRequiredString("Tracking Code: ");
            string description = ReadRequiredString("Description: ");
            double weight = ReadPositiveDouble("Weight: ");
            decimal deliveryFee = ReadPositiveDecimal("Delivery Fee: ");

            DeliveryAddress address = ReadAddress();

            return new StandardShipment(
                trackingCode,
                description,
                weight,
                deliveryFee,
                address);
        }

        #endregion


        #region Create Express Shipment

        static ExpressShipment CreateExpressShipment()
        {
            string trackingCode = ReadRequiredString("Tracking Code: ");
            string description = ReadRequiredString("Description: ");
            double weight = ReadPositiveDouble("Weight: ");
            decimal deliveryFee = ReadPositiveDecimal("Delivery Fee: ");

            DeliveryAddress address = ReadAddress();

            decimal extraFee = ReadNonNegativeDecimal("Extra Fee: ");

            return new ExpressShipment(
                trackingCode,
                description,
                weight,
                deliveryFee,
                address,
                extraFee);
        }

        #endregion


        #region Create International Shipment

        static InternationalShipment CreateInternationalShipment()
        {
            string trackingCode = ReadRequiredString("Tracking Code: ");
            string description = ReadRequiredString("Description: ");
            double weight = ReadPositiveDouble("Weight: ");
            decimal deliveryFee = ReadPositiveDecimal("Delivery Fee: ");

            DeliveryAddress address = ReadAddress();

            string destinationCountry = ReadRequiredString("Destination Country: ");
            decimal customsFee = ReadNonNegativeDecimal("Customs Fee: ");

            return new InternationalShipment(
                trackingCode,
                description,
                weight,
                deliveryFee,
                address,
                destinationCountry,
                customsFee);
        }

        #endregion


        #region Read Address

        static DeliveryAddress ReadAddress()
        {
            string city = ReadRequiredString("City: ");
            string street = ReadRequiredString("Street: ");
            int buildingNumber = ReadPositiveInt("Building Number: ");

            return new DeliveryAddress(city, street, buildingNumber);
        }

        #endregion
    }
}


