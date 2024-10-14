using System.Collections;
using System.Runtime.CompilerServices;

namespace AssetTracking;
public class Program
{
    public static void Main(string[] args)
    {
        System.Console.OutputEncoding = System.Text.Encoding.Unicode;
        string message = "⚠ Please Always Follow the Instructions ⚠"; 
        Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.CursorTop);
        Console.WriteLine(message);

        AssetManager Menu = new AssetManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Add a new product");
            Console.WriteLine("2. View the current product list");
            Console.WriteLine("3. Remove a product");
            Console.WriteLine("4. Search for a product");
            Console.WriteLine("5. Exit and show the final List ");
            Console.WriteLine("Type 'exit' to quit the program at any time.");

            string userInput = Console.ReadLine()?.Trim().ToLower(); // Handle user input as a string

            if (userInput == "exit") // If the user types 'exit'
            {
                exit = true;
                Console.WriteLine("Exiting...");
                break; // Terminate the program
            }

            int userResponse;
            if (!int.TryParse(userInput, out userResponse)) // Try to parse the input to an integer
            {
                Console.WriteLine("Please insert a number between 1 to 5 or type 'exit' to quit.");
                continue; // Ask for valid input again
            }

            switch (userResponse)
            {
                case 1:
                    int userResponse2;
                    Console.WriteLine("Which Kinds of Electronic Asset You Want to Add: ");
                    Console.WriteLine("1. Laptop");
                    Console.WriteLine("2. Monitor");
                    Console.WriteLine("3. Phone");
                    Console.WriteLine("4. Printer");
                    Console.WriteLine("5. Projector");
                    Console.WriteLine("6. Router");
                    Console.WriteLine("7. Tablet");

                    string assetInput = Console.ReadLine()?.Trim().ToLower();
                    if (assetInput == "exit")
                    {
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    }
                    if (!int.TryParse(assetInput, out userResponse2))
                    {
                        Console.WriteLine("Please insert a number between 1 to 7 or type 'exit' to quit.");
                        continue;
                    }

                    Menu.assetListing(userResponse2);
                    continue;

                case 2:
                    Menu.ViewCurrentList();
                    continue;

                case 3:
                    Menu.RemoveProduct();
                    continue;

                case 4:
                    Menu.SearchProduct();
                    continue;

                case 5:
                    Console.WriteLine("Exiting and showing the final list...");
                    Menu.ViewCurrentList();
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option, please choose between 1 to 5.");
                    continue;
            }
        }
    }
}
