using System;
using System.Collections.Generic;
using System.Linq;

namespace AssetTracking
{
    public class Monitor : Assets
    {
        // Monitor-specific properties
        public string Resolution { get; set; }
        public int Size { get; set; } // Size in inches
        public string PanelType { get; set; }

        // List to store all Monitor assets
        private static List<Monitor> monitors = new List<Monitor>();

        // Method to record new monitor asset details
        public override void recordNewAsset()
        {
            Console.WriteLine("Please provide the following information about the Monitor:");

            Console.Write("Monitor's name: ");
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

            // Information specifically for Monitor
            Console.WriteLine("Enter resolution:");
            Resolution = Console.ReadLine();

            Console.WriteLine("Enter size (in inches):");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("Invalid input. Please enter a valid size (in inches):");
            }
            Size = size;

            Console.WriteLine("Enter panel type:");
            PanelType = Console.ReadLine();

            Console.WriteLine($"New Monitor Asset Recorded: {assetName}, Serial Number: {serialNumber}, Purchase Date: {purchaseDate.ToShortDateString()}, Condition: {assetCondition}, Assigned To: {assignToWho}, Price: {priceValue:C}, Location: {location}, Resolution: {Resolution}, Size: {Size} inches, Panel Type: {PanelType}");
        }

        // Method to add a new monitor to the list
        public static void AddMonitor()
        {
            Monitor newMonitor = new Monitor();
            newMonitor.recordNewAsset();
            monitors.Add(newMonitor);
            Console.WriteLine("Monitor added to the list.");
        }

        // Method to print all monitors
        public static void PrintMonitors()
        {
            Console.WriteLine("List of Monitors (sorted by purchase date):");

            // Sort the list by the purchase date before printing
            var sortedMonitors = monitors.OrderBy(monitor => monitor.purchaseDate).ToList();

            foreach (var monitor in sortedMonitors)
            {
                Console.WriteLine($"Name: {monitor.assetName}, Serial Number: {monitor.serialNumber}, Purchase Date: {monitor.purchaseDate.ToShortDateString()}, Condition: {monitor.assetCondition}, Assigned To: {monitor.assignToWho}, Price: {monitor.priceValue:C}, Location: {monitor.location}, Resolution: {monitor.Resolution}, Size: {monitor.Size} inches, Panel Type: {monitor.PanelType}");
            }
        }

        // Method to remove a monitor by serial number
        public static void RemoveMonitor(int serialNumber)
        {
            var monitorToRemove = monitors.FirstOrDefault(m => m.serialNumber == serialNumber);
            if (monitorToRemove != null)
            {
                monitors.Remove(monitorToRemove);
                Console.WriteLine($"Monitor with Serial Number {serialNumber} has been removed.");
            }
            else
            {
                Console.WriteLine($"Monitor with Serial Number {serialNumber} not found.");
            }
        }

        // Method to search for a monitor by serial number
        public static void SearchMonitor(int serialNumber)
        {
            var monitorToSearch = monitors.FirstOrDefault(m => m.serialNumber == serialNumber);
            if (monitorToSearch != null)
            {
                Console.WriteLine($"Monitor Found: Name: {monitorToSearch.assetName}, Serial Number: {monitorToSearch.serialNumber}, Purchase Date: {monitorToSearch.purchaseDate.ToShortDateString()}, Condition: {monitorToSearch.assetCondition}, Assigned To: {monitorToSearch.assignToWho}, Price: {monitorToSearch.priceValue:C}, Location: {monitorToSearch.location}, Resolution: {monitorToSearch.Resolution}, Size: {monitorToSearch.Size} inches, Panel Type: {monitorToSearch.PanelType}");
            }
            else
            {
                Console.WriteLine($"Monitor with Serial Number {serialNumber} not found.");
            }
        }

        // New method to get all monitors
        public static List<Monitor> GetAllMonitors()
        {
            return monitors;
        }
    }
}
