namespace Assignment_03_OOP_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1st Question Theoritical

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

        }
    }
}
