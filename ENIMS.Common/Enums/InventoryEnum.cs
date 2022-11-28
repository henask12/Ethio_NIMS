using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ENIMS.Common
{
    public enum ExemptionType
    {
        Item, Customer
    }
    public enum PriceListType
    {
        Sales, Purchase
    }
    public enum PriceListRateType
    {
        MarkUp, MarkDown, IndividualRate
    }


    public enum DecimalPlaces
    {
        [Description("0")]
        Zero = 0,
        [Description("1")]
        One = 1,
        [Description("2")]
        Two = 2,
        [Description("3")]
        Three = 3,
        [Description("4")]
        Four = 4
    }

    #region Filter
    public enum FilterContact
    {
        [Description("All Contact")]
        AllContact = 1,
        [Description("Active Contact")]
        ActiveContact = 2,
        [Description("Inactive Contact")]
        InactiveContact = 3,
        [Description("All Customer")]
        AllCustomer = 4,
        [Description("Active Customer")]
        ActiveCustomer = 5,
        [Description("Inactive Customer")]
        InactiveCustomer = 6,
        [Description("All Vendor")]
        AllVendor = 7,
        [Description("Active Vendor")]
        ActiveVendor = 8,
        [Description("Inactive Vendor")]
        InactiveVendor = 9
    }
    public enum FilterItem
    {
        [Description("All Items")]
        AllItems = 1,
        [Description("Active Items")]
        ActiveItems = 2,
        [Description("Inactive Items")]
        InactiveItems = 3,
        [Description("Sales Items")]
        SalesItems = 4,
        [Description("Purchase Items")]
        PurchaseItems = 5,
        [Description("Inventory Items")]
        InventoryItems = 6,
        [Description("Non-Inventory Items")]
        NonInventoryItems = 7,
        [Description("Servive Items")]
        ServiveItems = 8,
        [Description("Returnable Items")]
        ReturnableItems = 9,
        [Description("Non Returnable Items")]
        NonReturnableItems = 10,
        [Description("Low Stock Items")]
        LowStockItems = 11,
        [Description("Ungrouped Items")]
        UngroupedItems = 12
    }

    public enum FilterItemGroup
    {
        [Description("All Item Groups")]
        AllItemGroups = 1,
        [Description("Active Item Groups")]
        ActiveItemGroups = 2,
        [Description("Inactive Item Groups")]
        InactiveItemGroups = 3
    } 
    #endregion
    public enum ItemType
    {
        [Description("Good")]
        Good = 1,
        [Description("Service")]
        Service=2
    }

    public enum PriceRoundOfDigit
    {
        [Description("NeverMind")]
        NeverMind = 0,
        [Description("NearestWholeNumber")]
        NearestWholeNumber = 1,
        [Description("0.99")]
        NiNi = 2,
        [Description("0.50")]
        Fifty = 3,
        [Description("0.49")]
        FortyNine = 4
    }



    public enum ProductType
    {
        Inventory, NonInventory
    }

    public enum AllowedTransactionsForItem
    {
        PurchaseAndSales, Sales, Purchase
    }

    public enum ItemTransactionType
    {
        StockIn, StockOut
    }

    public enum ItemTransactionSource
    {
        InitialStock, Sales, Purchase, Transfer, Adjustment, Bundling
    }

    public enum ItemTrackingType
    {   
        
        Default=0, 
        None=1, 
        
        //SerialNumber=2, 
        //Batch=3
    }
    public enum ItemCategory
    {
        Item, 
        Composit
    }

    public enum ContactType
    {
        [Description("Customer")]
        Customer = 1,
        [Description("Vendor")]
        Vendor = 2
    }
    public enum CustomterType
    {
        [Description("N/A")]
        NA = 0,
        [Description("Business")]
        Business = 1,
        [Description("Individual")]
        Individual = 2
    }


}
