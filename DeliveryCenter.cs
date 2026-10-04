public class DeliveryCenter
{
    private Shipment?[] shipments;

    public string CenterName { get; set; }

    public Driver? Driver { get; set; }


    public DeliveryCenter(string centerName)
    {
        if (string.IsNullOrWhiteSpace(centerName))
            CenterName = "Unknown";
        else
            CenterName = centerName.Trim();

        shipments = new Shipment?[20];
    }


    public Shipment? this[int index]
    {
        get
        {
            if (index >= 0 &&
                index < shipments.Length)
            {
                return shipments[index];
            }

            return null;
        }

        set
        {
            if (index >= 0 &&
                index < shipments.Length)
            {
                shipments[index] = value;
            }
        }
    }


    public Shipment? this[string trackingCode]
    {
        get
        {
            if (string.IsNullOrWhiteSpace(trackingCode))
                return null;

            for (int i = 0;
                 i < shipments.Length;
                 i++)
            {
                if (shipments[i] != null &&
                    shipments[i]!.TrackingCode ==
                    trackingCode)
                {
                    return shipments[i];
                }
            }

            return null;
        }
    }


    public bool AddShipment(Shipment shipment)
    {
        if (shipment == null)
            return false;

        for (int i = 0;
             i < shipments.Length;
             i++)
        {
            if (shipments[i] == null)
            {
                shipments[i] = shipment;
                return true;
            }
        }

        return false;
    }


    public bool RemoveShipment(string trackingCode)
    {
        if (string.IsNullOrWhiteSpace(trackingCode))
            return false;

        for (int i = 0;
             i < shipments.Length;
             i++)
        {
            if (shipments[i] != null &&
                shipments[i]!.TrackingCode == trackingCode)
            {
                shipments[i] = null;

                Console.WriteLine();
                Console.WriteLine(
                    "Shipment removed successfully.");

                return true;
            }
        }

        Console.WriteLine();
        Console.WriteLine(
            "Shipment Not Found.");

        return false;
    }

    #region Question 7 - DeliveryCenter

    public void PrintAllShipments()
    {
        Console.WriteLine();
        Console.WriteLine(
            "========================================");

        Console.WriteLine(
            "Delivery Center");

        Console.WriteLine(
            "========================================");

        Console.WriteLine(
            $"Center Name : {CenterName}");

        if (Driver != null)
        {
            Console.WriteLine(
                $"Driver : {Driver.Name}");
        }

        bool found = false;

        for (int i = 0;
             i < shipments.Length;
             i++)
        {
            if (shipments[i] != null)
            {
                found = true;

                shipments[i]!.PrintShipment();
            }
        }

        if (!found)
        {
            Console.WriteLine(
                "No shipments found.");
        }
    }

    #endregion

}

