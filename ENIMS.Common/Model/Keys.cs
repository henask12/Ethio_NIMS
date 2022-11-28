using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common
{
    public static class Keys
    {

        //public static string EMAIL_CONFIRMATION_URL { get { return @"http://localhost:4200/company-setup"; } }
        //public static string INVITE_EMAIL_CONFIRMATION_URL { get { return @"http://localhost:4200/company-setup"; } }
        public static string Approval_URL { get { return @"http://svsfclust01:6811"; } }
        public static string RECOVER_PASSWORD_URL { get { return @"http://localhost:4200/reset-forgot-password"; } }
        public static int ACCESS_TOKEN_EXPIRY_HOUR { get { return 12; } }
        public static int ACCESS_CLIENT_TOKEN_EXPIRY_HOUR { get { return 12; } }
        public static int ACCESS_USER_TOKEN_EXPIRY_HOUR { get { return 12; } }
        public static int REFRESH_TOKEN_EXPIRY_HOUR { get { return 240; } }
        public static string CURRENT_TENANT { get { return "CURRENT_TENANT"; } }
        public static string EMAIL_SUBJECT { get { return "ETGPMS Notification"; } }
        public static string JWT_ACCOUNT_SUBSCRIPTION_CLAIM { get { return "JWT_ACCOUNT_SUBSCRIPTION_CLAIM"; } }
        public static string JWT_CLIENT_CURRENT_USER_CLAIM { get { return "JWT_CLIENT_CURRENT_USER"; } }
        public static string JWT_CURRENT_USER_CLAIM { get { return "JWT_INDIVIDUAL_CURRENT_USER"; } }
        public static string JWT_EMAIL_CONFIRMATION_CLAIM { get { return "JWT_EMAIL_CONFIRMATION_CLAIM"; } }
        public static string JWT_EMAIL_CONFIRMATION_COUNTRY_ID_CLAIM { get { return "JWT_EMAIL_CONFIRMATION_COUNTRY_ID_CLAIM"; } }
        public static string JWT_EMAIL_CONFIRMATION_COMPANY_NAME_CLAIM { get { return "JWT_EMAIL_CONFIRMATION_COMPANY_NAME_CLAIM"; } }
        public static string JWT_EMAIL_CONFIRMATION_PHONE_NUMBER_CLAIM { get { return "JWT_EMAIL_CONFIRMATION_PHONE_NUMBER_CLAIM"; } }
        public static string JWT_INVITE_USER_CONFIRMATION_CLAIM { get { return "JWT_INVITE_USER_CONFIRMATION_CLAIM"; } }
    }


    public static class CacheKeys
    {
        public const int COUNTRY_CACHED_TIME = 6000;
        public const string COUNTRY_GET_ALL_KEY = "/Masterdata/api/V1.0/Country/GetAll" + "," + ALL_COMMON_DATA_KEY; 
        
        public const int PRIVILAGE_CACHED_TIME = 6000;
        public const string PRIVILAGE_GETALL_KEY = "/User/api/V1.0/Privilege/GetAll";

        public const int PRIVILAGE_GETALL_MODULES_CACHED_TIME = 6000;
        public const string PRIVILAGE_GETALL_MODULES_KEY = "/User/api/V1.0/Privilege/GetAllByModule";

        public const int ROLE_CACHED_TIME = 6000;
        public const string ROLE_GET_ALL_KEY = "/User/api/V1.0/Role/GetAll";
        
        public const int ORGANIZATION_CACHED_TIME = 6000;
        public const string ORGANIZATION_GET_ALL_KEY = "/Inventory/api/V1.0/Organization/GetAll";
        
        public const int ALL_ORGANIZATION_DATA_CACHED_TIME = 6000;
        public const string ORGANIZATION_ALL_ORGANIZATION_DATA_KEY = "/MasterData/api/V1.0/BulkData/GetAllOrganizationData";//globalTime,industries,unitOfMeasurements,dateFormats
       
        public const int ALL_COMMON_DATA_CACHED_TIME = 6000;
        public const string ALL_COMMON_DATA_KEY = "/MasterData/api/V1.0/BulkData/GetAllCommonData"; //currencies,counties,languguies,titles
       
        public const int CURRENCY_CACHED_TIME = 6000;
        public const string CURRENCY_GET_ALL_KEY = "/Masterdata/api/V1.0/Currency/GetAll" + ","+ ALL_COMMON_DATA_KEY;
        
        public const int CURRENCY_FORMAT_CACHED_TIME = 6000;
        public const string CURRENCY_FORMAT_ALL_KEY = "/Masterdata/api/V1.0/CurrencyFormat/GetAll";
        
        public const int DATE_FORMAT_CACHED_TIME = 6000;
        public const string DATE_FORMAT_GET_ALL_KEY = "/Masterdata/api/V1.0/DateFormat/GetAll" + "," + ORGANIZATION_ALL_ORGANIZATION_DATA_KEY;
        
        public const int EXCHANGE_RATE_CACHED_TIME = 6000;
        public const string EXCHANGE_RATE_GET_ALL_KEY = "/Masterdata/api/V1.0/ExchangeRate/GetAll";
        
        public const int GLOBAL_TIMEZONE_CACHED_TIME = 6000;
        public const string GLOBAL_TIMEZONE_GET_ALL_KEY = "/Masterdata/api/V1.0/GlobalTimeZone/GetAll" + "," + ORGANIZATION_ALL_ORGANIZATION_DATA_KEY;
        
        public const int INDUSTRY_CACHED_TIME = 6000;
        public const string INDUSTRY_GET_ALL_KEY = "/Masterdata/api/V1.0/Industry/GetAll" + "," + ORGANIZATION_ALL_ORGANIZATION_DATA_KEY;
        
        public const int LANGUAGE_CACHED_TIME = 6000;
        public const string LANGUAGE_GET_ALL_KEY = "/Masterdata/api/V1.0/Language/GetAll" + "," + ALL_COMMON_DATA_KEY;
        
        public const int TITLE_CACHED_TIME = 6000;
        public const string TITLE_GET_ALL_KEY = "/Masterdata/api/V1.0/Title/GetAll" + "," + ALL_COMMON_DATA_KEY;
        
        public const int UNIT_OF_MEASUREMENT_CACHED_TIME = 6000;
        public const string UNIT_OF_MEASUREMENT_GET_ALL_KEY = "/Masterdata/api/V1.0/UnitOfMeasurement/GetAll" + "," + ORGANIZATION_ALL_ORGANIZATION_DATA_KEY;

        //
        public const int WAREHOUSE_CACHED_TIME = 6000; 
        public const string WAREHOUSE_GET_ALL_KEY = "/Inventory/api/V1.0/Warehouse/ *";

        //public const int WAREHOUSE_GET_BY_ORGANIZATION_CACHED_TIME = 6000;
        //public const string WAREHOUSE_GET_BY_ORGANIZATION_KEY = "/Inventory/api/V1.0/Organization/GetAll";


    }
}
