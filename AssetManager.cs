using System;
using System.Collections.Generic;
using System.IO;

namespace AssetTracking
{
    public class AssetManager // This is the class the moves between classes and provide the Main functionality
    {
        Laptop myLaptop;
        Monitor myMonitor;
        Phone myPhone;
        Printer myPrinter;
        Projector myProjector;
        Router myRouter;
        Tablet myTablet;

        public AssetManager() // Object of asset classes
        {
            myLaptop = new Laptop();
            myMonitor = new Monitor();
            myPhone = new Phone();
            myPrinter = new Printer();
            myProjector = new Projector();
            myRouter = new Router();
            myTablet = new Tablet();
        }

        public void assetListing(int NUM)// A function that call the asset classes based on the user Choice
        {
            switch (NUM)
            {
                case 1:
                    Laptop.AddLaptop();
                    break;
                case 2:
                    Monitor.AddMonitor();
                    break;
                case 3:
                    Phone.AddPhone();
                    break;
                case 4:
                    Printer.AddPrinter();
                    break;
                case 5:
                    Projector.AddProjector();
                    break;
                case 6:
                    Router.AddRouter();
                    break;
                case 7:
                    Tablet.AddTablet();
                    break;
                default:
                    Console.WriteLine("Invalid category selection.");
                    break;
            }
        }

        public void ViewCurrentList() // if User choose 2, this function gives them the current class for all assets
        {
            Console.WriteLine("Viewing the current Asset list:\n");

            Console.WriteLine("---- Laptops ----");
            Laptop.PrintLaptops();

            Console.WriteLine("\n---- Monitors ----");
            Monitor.PrintMonitors();

            Console.WriteLine("\n---- Phones ----");
            Phone.PrintPhones();

            Console.WriteLine("\n---- Printers ----");
            Printer.PrintPrinters();

            Console.WriteLine("\n---- Projectors ----");
            Projector.PrintProjectors();

            Console.WriteLine("\n---- Routers ----");
            Router.PrintRouters();

            Console.WriteLine("\n---- Tablets ----");
            Tablet.PrintTablets();
        }

        public void RemoveProduct() // to Remove an asset from a specific category, like Phone or Laptop
        {
            Console.WriteLine("Which category of Asset do you want to remove?");
            Console.WriteLine("1. Laptop");
            Console.WriteLine("2. Monitor");
            Console.WriteLine("3. Phone");
            Console.WriteLine("4. Printer");
            Console.WriteLine("5. Projector");
            Console.WriteLine("6. Router");
            Console.WriteLine("7. Tablet");

            int userResponse;
            while (!int.TryParse(Console.ReadLine(), out userResponse) || userResponse < 1 || userResponse > 7)
            {
                Console.WriteLine("Please insert a number between 1 to 7.");
            }

            Console.WriteLine("Enter the serial number of the Asset you want to remove:");
            int serialNumber;
            while (!int.TryParse(Console.ReadLine(), out serialNumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid serial number:");
            }

            switch (userResponse)
            {
                case 1:
                    Laptop.RemoveLaptop(serialNumber);
                    break;
                case 2:
                    Monitor.RemoveMonitor(serialNumber);
                    break;
                case 3:
                    Phone.RemovePhone(serialNumber);
                    break;
                case 4:
                    Printer.RemovePrinter(serialNumber);
                    break;
                case 5:
                    Projector.RemoveProjector(serialNumber);
                    break;
                case 6:
                    Router.RemoveRouter(serialNumber);
                    break;
                case 7:
                    Tablet.RemoveTablet(serialNumber);
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }
        }

        public void SearchProduct() // Search between classes based on the serial number provided
        {
            Console.WriteLine("Which category of Asset do you want to search?");
            Console.WriteLine("1. Laptop");
            Console.WriteLine("2. Monitor");
            Console.WriteLine("3. Phone");
            Console.WriteLine("4. Printer");
            Console.WriteLine("5. Projector");
            Console.WriteLine("6. Router");
            Console.WriteLine("7. Tablet");

            int userResponse;
            while (!int.TryParse(Console.ReadLine(), out userResponse) || userResponse < 1 || userResponse > 7)
            {
                Console.WriteLine("Please insert a number between 1 to 7.");
            }

            Console.WriteLine("Enter the serial number of the Asset you want to search:");
            int serialNumber;
            while (!int.TryParse(Console.ReadLine(), out serialNumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid serial number:");
            }

            switch (userResponse)
            {
                case 1:
                    Laptop.SearchLaptop(serialNumber);
                    break;
                case 2:
                    Monitor.SearchMonitor(serialNumber);
                    break;
                case 3:
                    Phone.SearchPhone(serialNumber);
                    break;
                case 4:
                    Printer.SearchPrinter(serialNumber);
                    break;
                case 5:
                    Projector.SearchProjector(serialNumber);
                    break;
                case 6:
                    Router.SearchRouter(serialNumber);
                    break;
                case 7:
                    Tablet.SearchTablet(serialNumber);
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }
        }

        // A method to export all assets to a CSV file
        public void ExportAllAssets(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                
                writer.WriteLine("Asset Type,Asset Name,Serial Number,Purchase Date,Condition,Assigned To,Price,Location,Processor,RAM,Storage");

                
                foreach (var laptop in Laptop.GetAllLaptops())
                {
                    writer.WriteLine($"Laptop,{laptop.assetName},{laptop.serialNumber},{laptop.purchaseDate:yyyy-MM-dd},{laptop.assetCondition},{laptop.assignToWho},{laptop.priceValue},{laptop.location},{laptop.Processor},{laptop.RAM},{laptop.Storage}");
                }

                
                foreach (var monitor in Monitor.GetAllMonitors())
                {
                    writer.WriteLine($"Monitor,{monitor.assetName},{monitor.serialNumber},{monitor.purchaseDate:yyyy-MM-dd},{monitor.assetCondition},{monitor.assignToWho},{monitor.priceValue},{monitor.location},{monitor.PanelType},{monitor.Size},{monitor.PanelType}");
                }

                
                foreach (var phone in Phone.GetAllPhones())
                {
                    writer.WriteLine($"Phone,{phone.assetName},{phone.serialNumber},{phone.purchaseDate:yyyy-MM-dd},{phone.assetCondition},{phone.assignToWho},{phone.priceValue},{phone.location},{phone.PhoneModel},{phone.StorageCapacity},{phone.OperatingSystem} ");
                }

                
                foreach (var printer in Printer.GetAllPrinters())
                {
                    writer.WriteLine($"Printer,{printer.assetName},{printer.serialNumber},{printer.purchaseDate:yyyy-MM-dd},{printer.assetCondition},{printer.assignToWho},{printer.priceValue},{printer.location},{printer.PrinterType},{printer.Connectivity}, {printer.PrintSpeed}");
                }

                
                foreach (var projector in Projector.GetAllProjectors())
                {
                    writer.WriteLine($"Projector,{projector.assetName},{projector.serialNumber},{projector.purchaseDate:yyyy-MM-dd},{projector.assetCondition},{projector.assignToWho},{projector.priceValue},{projector.location},{projector.Resolution},{projector.Brightness},{projector.Type}");
                }

                
                foreach (var router in Router.GetAllRouters())
                {
                    writer.WriteLine($"Router,{router.assetName},{router.serialNumber},{router.purchaseDate:yyyy-MM-dd},{router.assetCondition},{router.assignToWho},{router.priceValue},{router.location},{router.Bandwidth},{router.Frequency},{router.Type}");
                }

                
                foreach (var tablet in Tablet.GetAllTablets())
                {
                    writer.WriteLine($"Tablet,{tablet.assetName},{tablet.serialNumber},{tablet.purchaseDate:yyyy-MM-dd},{tablet.assetCondition},{tablet.assignToWho},{tablet.priceValue},{tablet.location},{tablet.ScreenSize},{tablet.OperatingSystem}, {tablet.BatteryLife}");
                }
            }
            Console.WriteLine("All assets exported to CSV file: " + filePath);
        }
    }
}
