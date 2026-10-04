public class PriorityInternationalShipment
    : InternationalShipment
{
    public PriorityInternationalShipment(
        string trackingCode,
        string description,
        double weight,
        decimal deliveryFee,
        DeliveryAddress destination,
        string destinationCountry,
        decimal customsFee)
        : base(
            trackingCode,
            description,
            weight,
            deliveryFee,
            destination,
            destinationCountry,
            customsFee)
    {
    }


    #region Question 9 - Generate Customs Report

    public override void GenerateCustomsReport()
    {
        Console.WriteLine(
            $"Priority Customs Report: " +
            $"{TrackingCode} - " +
            $"{DestinationCountry} - " +
            $"Customs Fee: {CustomsFee} EGP");
    }

    #endregion

}