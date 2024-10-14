using System;
using System.Collections.Generic;
using System.Linq;

namespace AssetTracking
{
    public class Tablet : Assets
    {
        // Tablet-specific properties
        public string ScreenSize { get; set; } // Screen size (e.g., 10.1 inches)
        public string OperatingSystem { get; set; } // Operating system (e.g., Android, iOS)
        public int BatteryLife { get; set; } // Battery life in hours

        // List to store all Tablet assets
        private static List<Tablet> tablets = new List<Tablet>();

        // Method to record new tablet asset details
        public override void recordNewAsset()
        {
            Console.WriteLine("Please provide the following information about the Tablet");

            Console.Write("Tablet's name: ");
            assetName = Console.ReadLine();

            Console.WriteLine("Enter serial number:");
            int serialNum;
            while (!int.TryParse(Console.ReadLine(), out serialNum))
            {
                Console.WriteLine("Invalid input. Please enter a valid serial number:");
            }
            serialNumber = serialNum; // Assign to the property

            Console.WriteLine("Enter purchase date (yyyy-mm-dd):");
            DateTime purchaseDt;
            while (!DateTime.TryParse(Console.ReadLine(), out purchaseDt))
            {
                Console.WriteLine("Invalid date format. Please enter a valid purchase date (yyyy-mm-dd):");
            }
            purchaseDate = purchaseDt;

            Console.WriteLine("Enter asset condition:");
            assetCondition = Console.ReadLine();

            Console.WriteLine("Enter assigned to whom:");
            assignToWho = Console.ReadLine();

            Console.WriteLine("Enter price value:");
            decimal priceVal;
            while (!decimal.TryParse(Console.ReadLine(), out priceVal))
            {
                Console.WriteLine("Invalid input. Please enter a valid price value:");
            }
            priceValue = priceVal;

            Console.WriteLine("Enter location:");
            location = Console.ReadLine();

            // Information specifically for Tablet
            Console.WriteLine("Enter screen size (e.g., '10.1 inches'):");
            ScreenSize = Console.ReadLine();

            Console.WriteLine("Enter operating system (e.g., 'Android, iOS'):");
            OperatingSystem = Console.ReadLine();

            Console.WriteLine("Enter battery life (in hours):");
            int batteryLife;
            while (!int.TryParse(Console.ReadLine(), out batteryLife))
            {
                Console.WriteLine("Invalid input. Please enter a valid battery life (in hours):");
            }
            BatteryLife = batteryLife;

            Console.WriteLine($"New Tablet Asset Recorded: {assetName}, Serial Number: {serialNumber}, Purchase Date: {purchaseDate.ToShortDateString()}, Condition: {assetCondition}, Assigned To: {assignToWho}, Price: {priceValue:C}, Location: {location}, Screen Size: {ScreenSize}, Operating System: {OperatingSystem}, Battery Life: {BatteryLife} hours");
        }

        // Method to add a new tablet to the list
        public static void AddTablet()
        {
            Tablet newTablet = new Tablet();
            newTablet.recordNewAsset();
            tablets.Add(newTablet);
            Console.WriteLine("Tablet added to the list.");
        }

        // Method to print all tablets
        public static void PrintTablets()
        {
            Console.WriteLine("List of Tablets (sorted by purchase date):");

            // Sort the list by the purchase date before printing
            var sortedTablets = tablets.OrderBy(tablet => tablet.purchaseDate).ToList();

            foreach (var tablet in sortedTablets)
            {
                Console.WriteLine($"Name: {tablet.assetName}, Serial Number: {tablet.serialNumber}, Purchase Date: {tablet.purchaseDate.ToShortDateString()}, Condition: {tablet.assetCondition}, Assigned To: {tablet.assignToWho}, Price: {tablet.priceValue:C}, Location: {tablet.location}, Screen Size: {tablet.ScreenSize}, Operating System: {tablet.OperatingSystem}, Battery Life: {tablet.BatteryLife} hours");
            }
        }

        // Method to remove a tablet by serial number
        public static void RemoveTablet(int serialNumber)
        {
            var tabletToRemove = tablets.FirstOrDefault(t => t.serialNumber == serialNumber);
            if (tabletToRemove != null)
            {
                tablets.Remove(tabletToRemove);
                Console.WriteLine($"Tablet with Serial Number {serialNumber} has been removed.");
            }
            else
            {
                Console.WriteLine($"Tablet with Serial Number {serialNumber} not found.");
            }
        }

        // Method to search for a tablet by serial number
        public static void SearchTablet(int serialNumber)
        {
            var tabletToSearch = tablets.FirstOrDefault(t => t.serialNumber == serialNumber);
            if (tabletToSearch != null)
            {
                Console.WriteLine($"Tablet Found: Name: {tabletToSearch.assetName}, Serial Number: {tabletToSearch.serialNumber}, Purchase Date: {tabletToSearch.purchaseDate.ToShortDateString()}, Condition: {tabletToSearch.assetCondition}, Assigned To: {tabletToSearch.assignToWho}, Price: {tabletToSearch.priceValue:C}, Location: {tabletToSearch.location}, Screen Size: {tabletToSearch.ScreenSize}, Operating System: {tabletToSearch.OperatingSystem}, Battery Life: {tabletToSearch.BatteryLife} hours");
            }
            else
            {
                Console.WriteLine($"Tablet with Serial Number {serialNumber} not found.");
            }
        }

        // A method to get all tablets
        public static List<Tablet> GetAllTablets()
        {
            return tablets;
        }
    }
}
