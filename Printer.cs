using System;
using System.Collections.Generic;
using System.Linq;

namespace AssetTracking
{
    public class Printer : Assets
    {
        // Printer-specific properties
        public string PrinterType { get; set; } // e.g., Inkjet, Laser
        public string Connectivity { get; set; } // e.g., USB, Wireless
        public int PrintSpeed { get; set; } // Print speed in pages per minute

        // List to store all Printer assets
        private static List<Printer> printers = new List<Printer>();

        // Method to record new printer asset details
        public override void recordNewAsset()
        {
            Console.WriteLine("Please provide the following information about the Printer");

            Console.Write("Printer's name: ");
            assetName = Console.ReadLine();

            Console.WriteLine("Enter serial number:");
            int serialNum;
            while (!int.TryParse(Console.ReadLine(), out serialNum))
            {
                Console.WriteLine("Invalid input. Please enter a valid serial number:");
            }
            serialNumber = serialNum;

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

            // Information specifically for Printer
            Console.WriteLine("Enter printer type:");
            PrinterType = Console.ReadLine();

            Console.WriteLine("Enter connectivity type:");
            Connectivity = Console.ReadLine();

            Console.WriteLine("Enter print speed (pages per minute):");
            int printSpeed;
            while (!int.TryParse(Console.ReadLine(), out printSpeed))
            {
                Console.WriteLine("Invalid input. Please enter a valid print speed (pages per minute):");
            }
            PrintSpeed = printSpeed;

            Console.WriteLine($"New Printer Asset Recorded: {assetName}, Serial Number: {serialNumber}, Purchase Date: {purchaseDate.ToShortDateString()}, Condition: {assetCondition}, Assigned To: {assignToWho}, Price: {priceValue:C}, Location: {location}, Printer Type: {PrinterType}, Connectivity: {Connectivity}, Print Speed: {PrintSpeed} pages/minute");
        }

        // Method to add a new printer to the list
        public static void AddPrinter()
        {
            Printer newPrinter = new Printer();
            newPrinter.recordNewAsset();
            printers.Add(newPrinter);
            Console.WriteLine("Printer added to the list.");
        }

        // Method to print all printers
        public static void PrintPrinters()
        {
            Console.WriteLine("List of Printers (sorted by purchase date):");

            // Sort the list by the purchase date before printing
            var sortedPrinters = printers.OrderBy(printer => printer.purchaseDate).ToList();

            foreach (var printer in sortedPrinters)
            {
                Console.WriteLine($"Name: {printer.assetName}, Serial Number: {printer.serialNumber}, Purchase Date: {printer.purchaseDate.ToShortDateString()}, Condition: {printer.assetCondition}, Assigned To: {printer.assignToWho}, Price: {printer.priceValue:C}, Location: {printer.location}, Printer Type: {printer.PrinterType}, Connectivity: {printer.Connectivity}, Print Speed: {printer.PrintSpeed} pages/minute");
            }
        }

        // Method to remove a printer by serial number
        public static void RemovePrinter(int serialNumber)
        {
            var printerToRemove = printers.FirstOrDefault(p => p.serialNumber == serialNumber);
            if (printerToRemove != null)
            {
                printers.Remove(printerToRemove);
                Console.WriteLine($"Printer with Serial Number {serialNumber} has been removed.");
            }
            else
            {
                Console.WriteLine($"No printer found with Serial Number {serialNumber}.");
            }
        }

        // Method to search for a printer by serial number
        public static void SearchPrinter(int serialNumber)
        {
            var printer = printers.FirstOrDefault(p => p.serialNumber == serialNumber);
            if (printer != null)
            {
                Console.WriteLine($"Printer found: Name: {printer.assetName}, Serial Number: {printer.serialNumber}, Purchase Date: {printer.purchaseDate.ToShortDateString()}, Condition: {printer.assetCondition}, Assigned To: {printer.assignToWho}, Price: {printer.priceValue:C}, Location: {printer.location}, Printer Type: {printer.PrinterType}, Connectivity: {printer.Connectivity}, Print Speed: {printer.PrintSpeed} pages/minute");
            }
            else
            {
                Console.WriteLine($"No printer found with Serial Number {serialNumber}.");
            }
        }

        // New method to get all printers
        public static List<Printer> GetAllPrinters()
        {
            return printers;
        }
    }
}
