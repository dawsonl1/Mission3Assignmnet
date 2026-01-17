namespace Mission3Assignment;


public class Inventory
{
    
    private List<FoodItem> _items = new List<FoodItem>();
    
    // Add food item to inventory
    public void AddFoodItem(string name, string category, string quantityInput, string expirationInput)
    {
        DateTime expirationDate; // declaration
        int quantity; // declaration
        
        // Validate quantity input before continuing
        while (!FoodItem.ValidateQuantity(quantityInput, out quantity))
        {
            Console.WriteLine();
            Console.Write("Please enter a valid quantity: ");
            quantityInput = Console.ReadLine();
        }
        
        // Validate expiration date (must be a valid future date)
        while (true)
        {
            if (!FoodItem.ValidateExperiationDate(expirationInput, out expirationDate))
            {
                Console.WriteLine();
                Console.Write("Please enter a valid expiration date (mm/dd/yyyy): ");
            }
            else if (expirationDate.Date <= DateTime.Today)
            {
                Console.WriteLine();
                Console.Write("Expiration date must be in the future. Enter expiration (mm/dd/yyyy): ");
            }
            else
            {
                break;
            }
            
            expirationInput = Console.ReadLine();
        }
        
        // Check if this exact item already exists (same name/category/expiration)
        FoodItem? existingItem = _items.Find(item => (
            item.Name.ToUpper() == name.ToUpper()
            &&
            item.Category.ToUpper() == category.ToUpper()
            &&
            item.ExpirationDate == expirationDate
            ));
        if (existingItem != null)  // If a match is found, just increase the quantity
        {
            Console.WriteLine();
            Console.WriteLine($"There are already {existingItem.Quantity} {existingItem.Name}(s) in inventory.");
            existingItem.Quantity += quantity;
            Console.WriteLine($"The quantity of {existingItem.Name}(s) has been updated to {existingItem.Quantity}.");
        }
        else
        {
            FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
            _items.Add(newItem);
            Console.WriteLine();
            Console.WriteLine($"The item {newItem.Name} has been added to inventory.");
        }
    }
    
    // Delete a food item by prompting the user to choose among matching names
    public void DeleteFoodItem(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine();
            Console.WriteLine("You must enter a valid name to delete a food item.");
            Console.WriteLine();
            return;
        }
        
        string normalized = name.Trim();
        string compareName = normalized.ToUpper();
        List<FoodItem> matches = new List<FoodItem>();
        foreach (FoodItem item in _items)
        {
            if (item.Name.ToUpper() == compareName)
            {
                matches.Add(item);
            }
        }
        
        if (matches.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine($"No food items found with the name \"{normalized}\".");
            Console.WriteLine();
            return;
        }
        
        // Show each matching item so the user can pick the correct one
        Console.WriteLine();
        Console.WriteLine($"Found {matches.Count} item(s) named \"{normalized}\":");
        for (int i = 0; i < matches.Count; i++)
        {
            FoodItem match = matches[i];
            Console.WriteLine($"{i + 1}. Category: {match.Category}, Quantity: {match.Quantity}, Expiration: {match.ExpirationDate:MM/dd/yyyy}");
        }
        
        int selection = 0;
        while (selection < 1 || selection > matches.Count)
        {
            Console.WriteLine();
            Console.Write("Enter the number of the item you would like to delete: ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out selection) || selection < 1 || selection > matches.Count)
            {
                Console.WriteLine("Please enter a valid option corresponding to one of the items above.");
                selection = 0;
            }
        }
        
        FoodItem itemToRemove = matches[selection - 1];
        _items.Remove(itemToRemove);
        Console.WriteLine();
        Console.WriteLine($"{itemToRemove.Name} ({itemToRemove.Category}, exp {itemToRemove.ExpirationDate:MM/dd/yyyy}) has been removed from the inventory.");
        Console.WriteLine();
    }
    
    // Print all food items currently in inventory
    public void PrintInventory()
    {
        if (_items.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("The inventory is currently empty.");
            Console.WriteLine();
            return;
        }
        
        // Display each stored item with key details
        Console.WriteLine();
        Console.WriteLine("Current food items in inventory:");
        for (int i = 0; i < _items.Count; i++)
        {
            FoodItem item = _items[i];
            Console.WriteLine($"{i + 1}. Name: {item.Name}");
            Console.WriteLine($"   Category: {item.Category}");
            Console.WriteLine($"   Quantity: {item.Quantity}");
            Console.WriteLine($"   Expiration: {item.ExpirationDate:MM/dd/yyyy}");
            Console.WriteLine();
        }
    }
}