// Author: Dawson Pitcher
// Date: January 17th, 2026
// Description: This is a simple food bank inventory system to run in the terminal. It allows users to add food items,
// delete food items, see the list of current food items, and store information about each individual food item.

using Mission3Assignment;

// Opening message
Console.WriteLine("Welcome to the simple food bank inventory system!");
Console.WriteLine();

// Loop through process untill loop != true
bool loop = true;

Inventory inventory = new Inventory();

// Pause to let the user read the most recent action before re-printing the menu
void PauseBeforeMenu()
{
    Console.WriteLine("Press any key to return to the menu...");
    Console.ReadKey(true);
    Console.WriteLine();
}

do
{
    // Collect user input
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. Add food item");
    Console.WriteLine("2. Delete food item");
    Console.WriteLine("3. View inventory");
    Console.WriteLine("4. Exit program");
    Console.WriteLine();
    Console.Write("Your choice: ");
    ConsoleKeyInfo choice = Console.ReadKey();
    Console.WriteLine();

    // Add food item
    if (choice.KeyChar == '1')
    {
        Console.WriteLine();
        Console.WriteLine("You chose to add a food item");
        Console.WriteLine();
        
        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.WriteLine();
        Console.Write("Enter category: ");
        string category = Console.ReadLine();

        Console.WriteLine();
        Console.Write("Enter quantity: ");
        string quantity = Console.ReadLine();

        Console.WriteLine();
        Console.Write("Enter expiration (mm/dd/yyyy): ");
        string expirationInput = Console.ReadLine();

        // Program only talks to Inventory, not FoodItem
        inventory.AddFoodItem(name, category, quantity, expirationInput);
        Console.WriteLine();
        PauseBeforeMenu();

    }
    // Delete food item
    else if (choice.KeyChar == '2')
    {
        Console.WriteLine();
        Console.WriteLine("You chose to delete a food item");
        Console.WriteLine();
        
        Console.Write("Enter name: ");
        string? nameToDelete = Console.ReadLine();
        inventory.DeleteFoodItem(nameToDelete ?? string.Empty);
        PauseBeforeMenu();

    }
    // Print list of food items in inventory
    else if (choice.KeyChar == '3')
    {
        Console.WriteLine();
        Console.WriteLine("You chose to view the current inventory");
        Console.WriteLine();
        inventory.PrintInventory();
        PauseBeforeMenu();
    }

    // Terminate program
    else {
        Console.WriteLine();
        Console.WriteLine("You chose to exit the program");
        Console.WriteLine();
        Console.WriteLine("Goodbye!");
        Console.WriteLine();

        loop = false;
    }
    
} while (loop == true);
    

