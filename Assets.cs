using System;

namespace AssetTracking;

public abstract class Assets  //  Parent Class of asset classes like Laptop, Phone, Monitor and Printer
{
    public string assetName {get; set;}
    public int   serialNumber{get; set;}
    public  DateTime purchaseDate{get; set;}
    public   string assetCondition{get; set;}
    public string assignToWho{get; set;}
    public decimal priceValue{ get; set;}
    public string  location{get; set;}
    public abstract void recordNewAsset(); // an Abstract method for collecting information from user for each class of assets
    
}
