public class CompletedShipment : Shipment
{
    #region Question 10 - CompletedShipment

    public CompletedShipment(
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

    public override void PrintShipment()
    {
        Console.WriteLine( "----------------------------------------");

        Console.WriteLine( "Completed Shipment");

        base.PrintShipment();
    }

    #endregion
}