using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENIMS.Common
{
    public enum ApprovalType
    {
        Series=0,
        Parallel =1
    }
    public enum NotificationType
    {
        TenderInvitation=1,
        ProposalFlotation,
        Clarification,
        Negotiation,
        TechnicalResult,
        FinalResult,
    }
    public enum ProjectTask
    {
        Unknown = 0,
        TeamFormation = 1,
        PurchaseMethodSelection = 2,
        DocumentPreparation = 3,
        TechnicalCriteria = 4,
        FinancialCriteria = 5,
        DefineBidTime = 6,
        TenderInvitation = 7, // for OPEN & Others
        ShortListing = 8, //Supplier Interest Response
        DocumentFlotation = 9, //Short listed suppliers (Send RFQ/RFP Document)
        PropsalCollection = 10, //NO Action - Optional
        TechnicalEvaluation = 11,
        FinancialEvaluation = 12,
        EvaluationReport = 13, //Create Report
        EvaluationResult = 14, //Submit to Negotiation
        NegotiationTeamFormation = 15,
        NegotiationCommunication = 16,
        NegotiationEvaluation = 17,
        NegotiationResult = 18, //NO Action
        NegotiationReport = 19, //Create Report after negotiation
        ResultNotification = 20 //Send Result
    }
    public enum ResultType
    {
        Award = 0,
        Regreat = 1,
        Canceled = 2,
    }
    public enum FinancialResult
    {
        NotEvaluated = 0,
        Evaluated = 1,
    }
    public enum TechnicalResult
    {
        NotEvaluated = 0,
        Evaluated = 1,
        Qualified = 2,
        UnQualified = 3,
    }
    public enum ApprovalDocumentType
    {
        PR = 1,
        HA = 2,
        PT = 3,
        SS = 4,
        ES = 5,
        NT = 6,
        NES = 7,
        BT = 8,
        DR = 9,
        PC=10
    }
    public enum AttachementType
    {
        Technical = 1,
        Financial = 2,
    }
    public enum BidInterest
    {
        Pending = 1,
        Interested = 2
    }
    public enum BidStatus
    {
        Open = 1,
        Closed = 2,
    }
    public enum AwardFactor
    {
        TechnicalOnly = 1,
        FinancialOnly = 2,
        CombinedSuM = 3
    }
    public enum Necessity
    {
        Mandatory = 1,
        Optional = 2,
    }
    public enum MeasurmentTypes
    {
        Yes_No = 1,
        Pass_Fail = 2,
        Qualified_NotQualified = 3,
        Good_Poor = 4,
        Comply_NotComply = 5,
        Percentage = 6
    }
    public enum RequestDocumentType
    {
        RFP = 1,
        RFQ = 2,
        RFI = 3
    }
    public enum ProjectProcessType
    {
        RestrictedBid = 1,
        OpenBid = 2,
        TwoStageBidding = 3,
        SourcingProcess = 4,
        RFQ = 5,
        DirectPurchase = 6
    }
    public enum MemberRole
    {
        ChairPerson = 1,
        Member = 2,
        Secretary = 3,
        Observer = 4
    }
    public enum RequestType
    {
        PurchaseRequest = 1,
        HotelAccommodationRequest = 2
    }
    public enum DataType
    {
        Word = 1,
        Pdf = 2,
        Excel = 3,

    }
    public enum PurchaseType
    {
        Goods = 1,
        Services = 2
    }
    public enum PRStatus
    {
        Assigned = 1,
        UnAssigned = 2,
        ReAssigned = 3,
        Rejected = 4,
        Projectized = 5,
        Canceled = 6

    }
    public enum ApprovalStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3,
        Canceled = 4,
        NotSent=5,
    }

    public enum HotelServiceType
    {
        CrewHotel = 1,
        PassengerHotel = 2
    }
    public enum OriginatingSection
    {
        RegionOffice = 1,
        FlightOperation = 2,
        Crewscheduling = 3,
        ContractManagement = 4,
        StrategicSourcing = 5,
        Areaoffice = 6
    }




    public enum InventoryAdjustmentType
    {
        Quantity, Value
    }
    public enum ActionTable
    {
        Brand = 1,
        Country = 2,
        Currency = 3,
        CurrencyFormat = 4,
        DateFormat = 5,
        DeliveryMethod = 6,
        ExchangeRate = 7,
        GlobalTimeZone = 8,
        Industry = 9,
        ItemAdjustmentReason = 10,
        Language = 11,
        Manufacturer = 12,
        MasterCurrency = 13,
        PaymentTerm = 14,
        SalesPerson = 15,
        Title = 16,
        UnitOfMeasurement = 17
    }
    public enum RecordStatus
    {
        [Description("InActive")]
        Inactive = 1,
        [Description("Active")]
        Active = 2,
        [Description("Deleted")]
        Deleted = 3
    }

    public enum StatusSearch
    {
        [Description("All")]
        All = 0,
        [Description("Active")]
        Active = 2,
        [Description("InActive")]
        Inactive = 3
    }

    public enum StatusAction
    {
        [Description("Mark As Active")]
        MarkAsActive = 1,
        [Description("Mark As In Active")]
        MarkAsInActive = 2
    }

    public enum ActionType
    {
        Add = 1,
        Edit = 2,
        Delete = 3,
        MarkAsActive = 4,
        MarkAsInActive = 5
    }
    public enum SalesUplift
    {
        Sales = 1,
        Uplift
    }
    public enum AWBIssueBy
    {
        BOTH = 1,
        OAL,
        OWN
    }
    public enum MOP
    {
        PP = 1,
        CC,
        Both
    }
    public enum WeghitForFreight
    {
        Chargeable = 1,
        Gross,
        Volumetric
    }
    public enum GlobalIndicator
    {
        AT = 1,
        EH,
        PA,
        TS,
        WH,
    }
    public enum AreaType
    {
        Country = 1,
        City,
        IATAArea,
        STDArea,
        UserDefindArea
    }
    public enum OppsSystemSource
    {
        Manual = 1,
        Electronic,
        Both
    }
    public enum StandardAreaType
    {
        Country = 1,
        City,
        IATAArea,
    }
    public enum TariffConferenceArea
    {
        //[Description("Tariff Conference Area 1")]
        TCA1 = 1,
        //[Description(" Tariff Conference Area 2")]
        TCA2,
        //[Description("Tariff Conference Area 3")]
        TCA3
    }
    public enum ApplicableWeight
    {
        Gross = 1,
        Chargable,
    }
    public enum IATAorOWN
    {
        IATA = 1,
        OWN,
    }
    public enum AdhocRate_Charge
    {
        [Display(Name = "Charge Per AWB")]
        ChargePerAWB = 1,
        Rate,
        [Display(Name = "Consolidated Charge")]
        ConsCharge,
        [Display(Name = "Free of Cost")]
        FreeOfcost,
    }
    public enum Rate_Charge
    {
        Rate = 1,
        Charge,
    }
    public enum TACTorIRIS
    {
        TACT = 1,
        IRIS,
    }
    public enum ProvisoorRequirment
    {
        Proviso = 1,
        Requirment,
        //Nil,
    }
    public enum ICHACHFlagOptions
    {
        [Display(Name = "ICH Member")]
        I = 1,
        [Display(Name = "ACH Member")]
        A,
        [Display(Name = "Neither ACH nor ICH Member")]
        N,
    }
    public enum IDECMemberFlag
    {
        [Description("Airline is not IDEC Member")]
        N = 1,
        [Description("Non IDEC member, HOT Tap")]
        X,
        [Description("Airline is IDEC member")]
        Y,
    }
    public enum ICHGroup
    {
        [Display(Name = "A Zone")]
        A = 1,
        [Display(Name = "B Zone")]
        B,
        [Display(Name = "C Zone")]
        C,
        [Display(Name = "Not Applicable")]
        N
    }
    public enum DirectSettlement
    {
        [Description("Airline is not in direct settlement with us")]
        N = 1,
        [Description("Airline settles the bill directly and not via ICH or ACH")]
        Y
    }
    public enum MPAStatus
    {
        [Display(Name = "Non-signatory to MPA")]
        N = 1,
        [Display(Name = "Signatory with Proviso")]
        P,
        [Display(Name = "Non-signatory with requirement")]
        R,
        [Display(Name = "Signatory to MPA")]
        S
    }
    public enum UATPMember
    {
        [Description("AIRLINE IS NOT AN UATP MERCHANT/MEMBER")]
        N = 1,
        [Description("AIRLINE IS NOT AN UATP MERCHANT/MEMBER")]
        Y
    }
    public enum IATAMemberFlag
    {
        [Description("Airline is an IATA member")]
        Y = 1,
        [Description("Airline is not  IATA member")]
        N,
    }
    public enum UDAApplicabilityModule
    {
        [Display(Name = "PAX Fare Audit")]
        FAP = 1,
        [Display(Name = "Flown Code Share Commission")]
        FLP,
        [Display(Name = "Cargo Incentive")]
        INC,
        [Display(Name = "Cargo Rates")]
        RAT,
        [Display(Name = "Trucking")]
        TRK,
    }
    public enum ProvisioAreaType
    {
        Within = 1,
        Between,
        [Display(Name = "From/To")]
        From_To,
        [Display(Name = "All Sec.")]
        All_Sec
    }

    public enum RatePCTOption
    {
        [Display(Name = "Applicable Rate")]
        Applicable_Rate = 1,
        [Display(Name = "Applicable Percentage")]
        ApplicablePercentage,
    }
    public enum CargoRateClassRateCharge
    {
        [Display(Name = "Rate")]
        Rate = 1,
        [Display(Name = "Charge")]
        Charge,
    }
    public enum UDAAreaType
    {
        Country = 1,
        City,
        Airport,
        IATAArea,
        STDArea,
        State,
        Zone
    }
    public enum RateType
    {
        [Display(Name = "BKR-Book keeping rate used for accounting")]
        BKR = 1,
        [Display(Name = "FDR-IATA Five Day Rate")]
        FDR,
        [Display(Name = "BSR-Bankers Selling Rate")]
        BSR,
        [Display(Name = "CDR-IATA Call Day Rate")]
        CDR,
        [Display(Name = "Credit Card Selling Rate")]
        CSR,
        [Display(Name = "CSR-Import CC rate")]
        IMC,
        [Display(Name = "LHS-Lufthansas rate for Credit Card billing")]
        LHS,
        [Display(Name = "MMR-IATA Monthly Mean Rate")]
        MMR,
        [Display(Name = "CCR-Currency for Cargo Rates Construction")]
        CCR
    }
    public enum ProvisoMinMax
    {
        Max = 1,
        Min,
    }
    public enum ProvisoApplWeight
    {
        Gross = 1,
        Volume,
    }
    public enum RoutingAreaType
    {
        Within = 1,
        Between,
        [Display(Name = "From/To")]
        From_To,
    }
    public enum SPARevenueAreaType
    {
        [Display(Name = "A-All")]
        All = 1,
        [Display(Name = "B-Between")]
        Between,
        [Display(Name = "F-From/To")]
        From_To,
        [Display(Name = "W-Within")]
        Within
    }
    public enum CarrierType
    {
        Both = 1,
        Pax,
        Cargo,
    }
    public enum SPARevShareAreaType
    {
        Airport = 1,
        City,
        Country,
        IATAArea,
        STDArea,
        UserDefindArea,
    }
    public enum SPARoutingAreaType
    {
        City,
        Country,
        IATAArea,
        STDArea,
        UserDefindArea,
    }
    public enum SPAFlag
    {
        [Display(Name = "A-Rate/kg with or without a min. chrg")]
        A = 1,
        [Display(Name = "B–Fixed amount per shipment")]
        B,
        [Display(Name = "C-% of Normal MPA prorate value")]
        C,
        [Display(Name = "D- % of Factor based prorate value")]
        D,
        [Display(Name = "E % of applicable TACT sector rate")]
        E,
        [Display(Name = "F–Charge based on ULD")]
        F,
        [Display(Name = "G-% of AWB gross freight charge")]
        G,
        [Display(Name = "N-% of AWB net freight charge")]
        N,
    }
    public enum Flag
    {
        [Display(Name = "Rate per Kgs")]
        A = 1,
        [Display(Name = "Flat Charge")]
        B,
        [Display(Name = "% of Charge Code Value on the AWB (For same change code)")]
        C,
        [Display(Name = "% of new prorated freight charge")]
        D
    }
    public enum LastProratedSource
    {
        CTM,
        Flown,
        ImportCC,
        InwardBilling,
        Sale
    }
    public enum ProrationStatus
    {
        Prorated,
        Not_Yet_Prorated
    }
    public enum ExchangeRateType
    {
        FDR,
        MMR
    }
    public enum AWBSource
    {
        Manual,
        Electronic,
        Both
    }
    public enum Applied
    {
        [Display(Name = "Proviso")]
        P,
        [Display(Name = "Requirment")]
        R,
        [Display(Name = "Adhoc SPA")]
        A,
        [Display(Name = "Minimum")]
        M,
        [Display(Name = "FBP")]
        F,
        [Display(Name = "SPA")]
        S,
        [Display(Name = "Not Prorated")]
        N,
        [Display(Name = "Equal")]
        E
    }
    public enum ApplWeight
    {
        [Display(Name = "Gross")]
        Gross,
        [Display(Name = "Chargeable Weight")]
        ChargeableWeight,
    }

    public enum EmailTemplateType
    {
        SignUp,
        RecoverPassword,
        InviteUser
    }

    public enum AccountType
    {
        [Description("BackOffice")]
        BackOffice = 1,
        [Description("Client")]
        Client = 2
    }

    public enum MessageStatus

    {
        [Description("FromBackOffice")]
        FromBackOffice = 1,
        [Description("FromClient")]
        FromClient = 2,

    }
}
