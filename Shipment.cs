#region 1st Question Update Shipment Class

public class Shipment
{
    private string trackingCode;
    private string description;
    private double weight;
    private decimal deliveryFee;

    public string TrackingCode
    {
        get
        {
            return trackingCode;
        }

        private set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                trackingCode = value;
            }
        }
    }

    public string Description
    {
        get
        {
            return description;
        }

        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                description = value;
            }
        }
    }

    public double Weight
    {
        get
        {
            return weight;
        }

        set
        {
            if (value > 0)
            {
                weight = value;
            }
        }
    }

    public decimal DeliveryFee
    {
        get
        {
            return deliveryFee;
        }

        private set
        {
            if (value >= 0)
            {
                deliveryFee = value;
            }
        }
    }

    public DeliveryAddress Destination { get; set; }

   
    public virtual decimal EstimatedCost
    {
        get
        {
            return DeliveryFee + ((decimal)Weight * 5);
        }
    }

    public Shipment(
        string trackingCode,
        string description,
        double weight,
        decimal deliveryFee,
        DeliveryAddress destination)
    {
        this.trackingCode = "Unknown";
        this.description = "Unknown";
        this.weight = 1;
        this.deliveryFee = 0;

        Destination = destination;

        TrackingCode = trackingCode;
        Description = description;
        Weight = weight;
        DeliveryFee = deliveryFee;
    }

    public void UpdateDeliveryFee(decimal newFee)
    {
        if (newFee >= 0)
        {
            DeliveryFee = newFee;
        }
    }

    public void UpdateWeight(double newWeight)
    {
        if (newWeight > 0)
        {
            Weight = newWeight;
        }
    }

    public void UpdateWeight(
        double newWeight,
        double packingWeight)
    {
        if (newWeight > 0 && packingWeight >= 0)
        {
            Weight = newWeight + packingWeight;
        }
    }

    public virtual void PrintShipment()
    {
        Console.WriteLine(
            $"Tracking Code : {TrackingCode}");

        Console.WriteLine(
            $"Description : {Description}");

        Console.WriteLine(
            $"Weight : {Weight} KG");

        Console.WriteLine(
            $"Delivery Fee : {DeliveryFee} EGP");

        Console.WriteLine(
            $"Estimated Cost : {EstimatedCost} EGP");

    }
}

#endregion
