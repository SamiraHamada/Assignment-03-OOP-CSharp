public class StandardShipment : Shipment
{
    #region Question 4 - Constructor Chaining

    public StandardShipment(
        string trackingCode,
        string description,
        double weight,
        decimal deliveryFee,
        DeliveryAddress destination)
        : base(
            trackingCode,
            description,
            weight,
            deliveryFee,
            destination)
    {
    }

    #endregion



    #region Question 6 - Override PrintShipment

    public override void PrintShipment()
    {
        Console.WriteLine(
            "----------------------------------------");

        Console.WriteLine(
            "Standard Shipment");

        base.PrintShipment();
    }

    #endregion

}

