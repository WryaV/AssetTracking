using System;
using System.Collections.Generic;
using System.Linq;

namespace AssetTracking
{
    public class Laptop : Assets
    {
        // Laptop-specific properties
        public string Processor { get; set; }
        public int RAM { get; set; } // RAM in GB
        public string Storage { get; set; } // Storage type and size, e.g., SSD, HDD

        // List to store all Laptop assets
        private static List<Laptop> laptops = new List<Laptop>();

        // Method to record new laptop asset details
        public override void recordNewAsset()
        {
            Console.WriteLine("Please provide the following information about the Laptop");

            Console.WriteLine("Enter Laptop's name: ");
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

            // Information specifically for Laptop
            Console.WriteLine("Enter processor:");
            Processor = Console.ReadLine();

            Console.WriteLine("Enter RAM size (in GB):");
            int ramSize;
            while (!int.TryParse(Console.ReadLine(), out ramSize))
            {
                Console.WriteLine("Invalid input. Please enter a valid RAM size (in GB):");
            }
            RAM = ramSize;

            Console.WriteLine("Enter storage (e.g., '512GB SSD'):");
            Storage = Console.ReadLine();

            Console.WriteLine($"New Laptop Asset Recorded: {assetName}, Serial Number: {serialNumber}, Purchase Date: {purchaseDate.ToShortDateString()}, Condition: {assetCondition}, Assigned To: {assignToWho}, Price: {priceValue:C}, Location: {location}, Processor: {Processor}, RAM: {RAM} GB, Storage: {Storage}");
        }

        // Method to add a new laptop to the list
        public static void AddLaptop()
        {
            Laptop newLaptop = new Laptop();
            newLaptop.recordNewAsset();
            laptops.Add(newLaptop);
            Console.WriteLine("Laptop added to the list.");
        }

        // Method to print all laptops
        public static void PrintLaptops()
        {
            Console.WriteLine("List of Laptops (sorted by purchase date):");

            // Sort the list by the purchase date before printing
            var sortedLaptops = laptops.OrderBy(laptop => laptop.purchaseDate).ToList();

            foreach (var laptop in sortedLaptops)
            {
                Console.WriteLine($"Name: {laptop.assetName}, Serial Number: {laptop.serialNumber}, Purchase Date: {laptop.purchaseDate.ToShortDateString()}, Condition: {laptop.assetCondition}, Assigned To: {laptop.assignToWho}, Price: {laptop.priceValue:C}, Location: {laptop.location}, Processor: {laptop.Processor}, RAM: {laptop.RAM} GB, Storage: {laptop.Storage}");
            }
        }

        // Method to remove a laptop by serial number
        public static void RemoveLaptop(int serialNumber)
        {
            var laptopToRemove = laptops.FirstOrDefault(l => l.serialNumber == serialNumber);
            if (laptopToRemove != null)
            {
                laptops.Remove(laptopToRemove);
                Console.WriteLine($"Laptop with serial number {serialNumber} has been removed.");
            }
            else
            {
                Console.WriteLine($"No laptop found with serial number {serialNumber}.");
            }
        }

        // Method to search for a laptop by serial number
        public static void SearchLaptop(int serialNumber)
        {
            var laptop = laptops.FirstOrDefault(l => l.serialNumber == serialNumber);
            if (laptop != null)
            {
                Console.WriteLine($"Laptop found: Name: {laptop.assetName}, Serial Number: {laptop.serialNumber}, Purchase Date: {laptop.purchaseDate.ToShortDateString()}, Condition: {laptop.assetCondition}, Assigned To: {laptop.assignToWho}, Price: {laptop.priceValue:C}, Location: {laptop.location}, Processor: {laptop.Processor}, RAM: {laptop.RAM} GB, Storage: {laptop.Storage}");
            }
            else
            {
                Console.WriteLine($"No laptop found with serial number {serialNumber}.");
            }
        }

        // New method to get all laptops
        public static List<Laptop> GetAllLaptops()
        {
            return laptops;
        }
    }
}
