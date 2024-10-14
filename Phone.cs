using System;
using System.Collections.Generic;
using System.Linq;

namespace AssetTracking
{
    public class Phone : Assets
    {
        // Phone-specific properties
        public string PhoneModel { get; set; }
        public string OperatingSystem { get; set; }
        public int StorageCapacity { get; set; } // Storage capacity in GB

        // List to store all Phone assets
        private static List<Phone> phones = new List<Phone>();

        // Method to record new phone asset details
        public override void recordNewAsset()
        {
            Console.WriteLine("Please provide the following information about the Phone");

            Console.WriteLine("Enter Phone's name: ");
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

            
            Console.WriteLine("Enter phone model:");
            PhoneModel = Console.ReadLine();

            Console.WriteLine("Enter operating system:");
            OperatingSystem = Console.ReadLine();

            Console.WriteLine("Enter storage capacity (in GB):");
            int storageCap;
            while (!int.TryParse(Console.ReadLine(), out storageCap))
            {
                Console.WriteLine("Invalid input. Please enter a valid storage capacity (in GB):");
            }
            StorageCapacity = storageCap;

            Console.WriteLine($"New Phone Asset Recorded: {assetName}, Serial Number: {serialNumber}, Purchase Date: {purchaseDate.ToShortDateString()}, Condition: {assetCondition}, Assigned To: {assignToWho}, Price: {priceValue:C}, Location: {location}, Phone Model: {PhoneModel}, Operating System: {OperatingSystem}, Storage Capacity: {StorageCapacity} GB");
        }

        //a Method to add a new phone to the list
        public static void AddPhone()
        {
            Phone newPhone = new Phone();
            newPhone.recordNewAsset();
            phones.Add(newPhone);
            Console.WriteLine("Phone added to the list.");
        }

        //a Method to print all phones
        public static void PrintPhones()
        {
            Console.WriteLine("List of Phones (sorted by purchase date):");

            // Sort the list by the purchase date before printing
            var sortedPhones = phones.OrderBy(phone => phone.purchaseDate).ToList();

            foreach (var phone in sortedPhones)
            {
                Console.WriteLine($"Name: {phone.assetName}, Serial Number: {phone.serialNumber}, Purchase Date: {phone.purchaseDate.ToShortDateString()}, Condition: {phone.assetCondition}, Assigned To: {phone.assignToWho}, Price: {phone.priceValue:C}, Location: {phone.location}, Phone Model: {phone.PhoneModel}, Operating System: {phone.OperatingSystem}, Storage Capacity: {phone.StorageCapacity} GB");
            }
        }

        //a Method to remove a phone by serial number
        public static void RemovePhone(int serialNumber)
        {
            var phoneToRemove = phones.FirstOrDefault(p => p.serialNumber == serialNumber);
            if (phoneToRemove != null)
            {
                phones.Remove(phoneToRemove);
                Console.WriteLine($"Phone with serial number {serialNumber} has been removed.");
            }
            else
            {
                Console.WriteLine($"No phone found with serial number {serialNumber}.");
            }
        }

        // Method to search for a phone by serial number
        public static void SearchPhone(int serialNumber)
        {
            var phone = phones.FirstOrDefault(p => p.serialNumber == serialNumber);
            if (phone != null)
            {
                Console.WriteLine($"Phone found: Name: {phone.assetName}, Serial Number: {phone.serialNumber}, Purchase Date: {phone.purchaseDate.ToShortDateString()}, Condition: {phone.assetCondition}, Assigned To: {phone.assignToWho}, Price: {phone.priceValue:C}, Location: {phone.location}, Phone Model: {phone.PhoneModel}, Operating System: {phone.OperatingSystem}, Storage Capacity: {phone.StorageCapacity} GB");
            }
            else
            {
                Console.WriteLine($"No phone found with serial number {serialNumber}.");
            }
        }

        // A method to get all phones
        public static List<Phone> GetAllPhones()
        {
            return phones;
        }
    }
}
