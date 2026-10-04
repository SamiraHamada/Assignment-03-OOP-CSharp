public class Driver
{
    #region Question 11 - Driver

    public string Name { get; set; }

    public Driver(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            Name = "Unknown";
        else
            Name = name.Trim();
    }

    #endregion
}
