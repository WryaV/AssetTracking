using System;
using System.Collections.Generic;
using System.Linq;

namespace AssetTracking
{
    public class Router : Assets
    {
        // Router-specific properties
        public string Bandwidth { get; set; } // Maximum bandwidth supported
        public string Frequency { get; set; } // Frequency bands (e.g., 2.4GHz, 5GHz)
        public string Type { get; set; } // For example, wired or wireless

        // List to store all Router assets
        private static List<Router> routers = new List<Router>();

        // Method to record new router asset details
        public override void recordNewAsset()
        {
            Console.WriteLine("Please provide the following information about the Router");

            Console.WriteLine("Enter Router's name: ");
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

            // Information specifically for Router
            Console.WriteLine("Enter maximum bandwidth supported:");
            Bandwidth = Console.ReadLine();

            Console.WriteLine("Enter frequency bands (e.g., '2.4GHz, 5GHz'):");
            Frequency = Console.ReadLine();

            Console.WriteLine("Enter type (e.g., wired, wireless):");
            Type = Console.ReadLine();

            Console.WriteLine($"New Router Asset Recorded: {assetName}, Serial Number: {serialNumber}, Purchase Date: {purchaseDate.ToShortDateString()}, Condition: {assetCondition}, Assigned To: {assignToWho}, Price: {priceValue:C}, Location: {location}, Bandwidth: {Bandwidth}, Frequency: {Frequency}, Type: {Type}");
        }

        // Method to add a new router to the list
        public static void AddRouter()
        {
            Router newRouter = new Router();
            newRouter.recordNewAsset();
            routers.Add(newRouter);
            Console.WriteLine("Router added to the list.");
        }

        // Method to print all routers
        public static void PrintRouters()
        {
            Console.WriteLine("List of Routers (sorted by purchase date):");

            // Sort the list by the purchase date before printing
            var sortedRouters = routers.OrderBy(router => router.purchaseDate).ToList();

            foreach (var router in sortedRouters)
            {
                Console.WriteLine($"Name: {router.assetName}, Serial Number: {router.serialNumber}, Purchase Date: {router.purchaseDate.ToShortDateString()}, Condition: {router.assetCondition}, Assigned To: {router.assignToWho}, Price: {router.priceValue:C}, Location: {router.location}, Bandwidth: {router.Bandwidth}, Frequency: {router.Frequency}, Type: {router.Type}");
            }
        }

        // Method to remove a router by serial number
        public static void RemoveRouter(int serialNumber)
        {
            var routerToRemove = routers.FirstOrDefault(r => r.serialNumber == serialNumber);
            if (routerToRemove != null)
            {
                routers.Remove(routerToRemove);
                Console.WriteLine($"Router with serial number {serialNumber} has been removed.");
            }
            else
            {
                Console.WriteLine($"No router found with serial number {serialNumber}.");
            }
        }

        // Method to search for a router by serial number
        public static void SearchRouter(int serialNumber)
        {
            var router = routers.FirstOrDefault(r => r.serialNumber == serialNumber);
            if (router != null)
            {
                Console.WriteLine($"Router found: Name: {router.assetName}, Serial Number: {router.serialNumber}, Purchase Date: {router.purchaseDate.ToShortDateString()}, Condition: {router.assetCondition}, Assigned To: {router.assignToWho}, Price: {router.priceValue:C}, Location: {router.location}, Bandwidth: {router.Bandwidth}, Frequency: {router.Frequency}, Type: {router.Type}");
            }
            else
            {
                Console.WriteLine($"No router found with serial number {serialNumber}.");
            }
        }

        // New method to get all routers
        public static List<Router> GetAllRouters()
        {
            return routers;
        }
    }
}
