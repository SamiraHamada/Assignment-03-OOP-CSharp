public static class DeliveryHelper
{
    #region Question 8 - DeliveryHelper

    public static void PrintShipmentDetails(
        Shipment shipment)
    {
        if (shipment == null)
            return;

        shipment.PrintShipment();
    }

    #endregion
}