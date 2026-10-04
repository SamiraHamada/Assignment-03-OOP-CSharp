public class InternationalShipment : Shipment
{
    private string destinationCountry;
    private decimal customsFee;

    public string DestinationCountry
    {
        get { return destinationCountry; }

        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                destinationCountry = value;
        }
    }

    public decimal CustomsFee
    {
        get { return customsFee; }

        set
        {
            if (value >= 0)
                customsFee = value;
        }
    }


    #region Question 4 - Constructor Chaining

    public InternationalShipment(
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
            destination)
    {
        this.destinationCountry = "Unknown";
        this.customsFee = 0;

        DestinationCountry = destinationCountry;
        CustomsFee = customsFee;
    }

    #endregion


    #region Question 5 - Override EstimatedCost

    public override decimal EstimatedCost
    {
        get
        {
            return DeliveryFee
                   + ((decimal)Weight * 5)
                   + CustomsFee;
        }
    }

    #endregion



    #region Question 6 - Override PrintShipment

    public override void PrintShipment()
    {
        Console.WriteLine(
            "----------------------------------------");

        Console.WriteLine(
            "International Shipment");

        Console.WriteLine(
            $"Tracking Code : {TrackingCode}");

        Console.WriteLine(
            $"Description : {Description}");

        Console.WriteLine(
            $"Weight : {Weight} KG");

        Console.WriteLine(
            $"Delivery Fee : {DeliveryFee} EGP");

        Console.WriteLine(
            $"Destination Country : " +
            $"{DestinationCountry}");

        Console.WriteLine(
            $"Customs Fee : {CustomsFee} EGP");

        Console.WriteLine(
            $"Estimated Cost : " +
            $"{EstimatedCost} EGP");
    }

    #endregion



    #region Question 9 - Generate Customs Report

    public virtual void GenerateCustomsReport()
    {
        Console.WriteLine(
            $"Customs Report: {TrackingCode} - " +
            $"{DestinationCountry} - " +
            $"Customs Fee: {CustomsFee} EGP");
    }

    #endregion 

}

