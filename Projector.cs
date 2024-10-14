using System;
using System.Collections.Generic;
using System.Linq;

namespace AssetTracking
{
    public class Projector : Assets
    {
        // Projector-specific properties
        public string Resolution { get; set; }
        public int Brightness { get; set; } // Brightness in lumens
        public string Type { get; set; } // For example, DLP, LCD, etc.

        // List to store all Projector assets
        private static List<Projector> projectors = new List<Projector>();

        // Method to record new projector asset details
        public override void recordNewAsset()
        {
            Console.WriteLine("Please provide the following information about the Projector:");

            Console.Write("Enter Projector's name: ");
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

            // Information specifically for Projector
            Console.WriteLine("Enter resolution:");
            Resolution = Console.ReadLine();

            Console.WriteLine("Enter brightness (in lumens):");
            int brightnessValue;
            while (!int.TryParse(Console.ReadLine(), out brightnessValue))
            {
                Console.WriteLine("Invalid input. Please enter a valid brightness value (in lumens):");
            }
            Brightness = brightnessValue;

            Console.WriteLine("Enter type (e.g., DLP, LCD):");
            Type = Console.ReadLine();

            Console.WriteLine($"New Projector Asset Recorded: {assetName}, Serial Number: {serialNumber}, Purchase Date: {purchaseDate.ToShortDateString()}, Condition: {assetCondition}, Assigned To: {assignToWho}, Price: {priceValue:C}, Location: {location}, Resolution: {Resolution}, Brightness: {Brightness} lumens, Type: {Type}");
        }

        // Method to add a new projector to the list
        public static void AddProjector()
        {
            Projector newProjector = new Projector();
            newProjector.recordNewAsset();
            projectors.Add(newProjector);
            Console.WriteLine("Projector added to the list.");
        }

        // Method to print all projectors
        public static void PrintProjectors()
        {
            Console.WriteLine("List of Projectors (sorted by purchase date):");

            // Sort the list by the purchase date before printing
            var sortedProjectors = projectors.OrderBy(projector => projector.purchaseDate).ToList();

            foreach (var projector in sortedProjectors)
            {
                Console.WriteLine($"Name: {projector.assetName}, Serial Number: {projector.serialNumber}, Purchase Date: {projector.purchaseDate.ToShortDateString()}, Condition: {projector.assetCondition}, Assigned To: {projector.assignToWho}, Price: {projector.priceValue:C}, Location: {projector.location}, Resolution: {projector.Resolution}, Brightness: {projector.Brightness} lumens, Type: {projector.Type}");
            }
        }

        // Method to remove a projector by serial number
        public static void RemoveProjector(int serialNumber)
        {
            var projectorToRemove = projectors.FirstOrDefault(p => p.serialNumber == serialNumber);
            if (projectorToRemove != null)
            {
                projectors.Remove(projectorToRemove);
                Console.WriteLine($"Projector with serial number {serialNumber} has been removed.");
            }
            else
            {
                Console.WriteLine($"No projector found with serial number {serialNumber}.");
            }
        }

        // Method to search for a projector by serial number
        public static void SearchProjector(int serialNumber)
        {
            var projector = projectors.FirstOrDefault(p => p.serialNumber == serialNumber);
            if (projector != null)
            {
                Console.WriteLine($"Projector found: Name: {projector.assetName}, Serial Number: {projector.serialNumber}, Purchase Date: {projector.purchaseDate.ToShortDateString()}, Condition: {projector.assetCondition}, Assigned To: {projector.assignToWho}, Price: {projector.priceValue:C}, Location: {projector.location}, Resolution: {projector.Resolution}, Brightness: {projector.Brightness} lumens, Type: {projector.Type}");
            }
            else
            {
                Console.WriteLine($"No projector found with serial number {serialNumber}.");
            }
        }

        // A method to get all projectors
        public static List<Projector> GetAllProjectors()
        {
            return projectors;
        }
    }
}
