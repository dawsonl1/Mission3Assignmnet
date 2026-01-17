namespace Mission3Assignment;

public class FoodItem
{
    // Attach instance attributes for later read/write access
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpirationDate { get; set; }
    
    // Constructor
    public FoodItem(string name, string category, int quantity, DateTime expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }

    // Verify instance attributes
    public static bool ValidateExperiationDate(string input, out DateTime expirationDate)
    {
        return DateTime.TryParse(input, out expirationDate);
    }
    
    public static bool ValidateQuantity(string input, out int quantity)
    {
        return int.TryParse(input, out quantity) && quantity >= 1;
    }
}