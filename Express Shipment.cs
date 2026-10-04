public class ExpressShipment : Shipment
{
    private decimal extraFee;

    public decimal ExtraFee
    {
        get { return extraFee; }

        set
        {
            if (value >= 0)
                extraFee = value;
        }
    }


    #region Question 4 - Constructor Chaining

    public ExpressShipment(
        string trackingCode,
        string description,
        double weight,
        decimal deliveryFee,
        DeliveryAddress destination,
        decimal extraFee)
        : base(
            trackingCode,
            description,
            weight,
            deliveryFee,
            destination)
    {
        this.extraFee = 0;

        ExtraFee = extraFee;
    }

    #endregion


    #region Question 5 - Override EstimatedCost

    public override decimal EstimatedCost
    {
        get
        {
            return DeliveryFee
                   + ((decimal)Weight * 5)
                   + ExtraFee;
        }
    }

    #endregion 



    #region Question 6 - Override PrintShipment

    public override void PrintShipment()
    {
        Console.WriteLine(
            "----------------------------------------");

        Console.WriteLine(
            "Express Shipment");

        Console.WriteLine(
            $"Tracking Code : {TrackingCode}");

        Console.WriteLine(
            $"Description : {Description}");

        Console.WriteLine(
            $"Weight : {Weight} KG");

        Console.WriteLine(
            $"Delivery Fee : {DeliveryFee} EGP");

        Console.WriteLine(
            $"Extra Fee : {ExtraFee} EGP");

        Console.WriteLine(
            $"Estimated Cost : {EstimatedCost} EGP");
    }

    #endregion
}
