namespace IdeaGen.Configurations
{
    class Config
    {
        public static int Storeid = 0;
        public static int PrintSoFar = 60;
        public static int Branchid;

        public static string ApplicationName = "IdeaGen";
        public static bool isZeroQty = false;
        public static bool isRetailSale = true;
        public static bool isSalesAmountChange = true;
        public static bool isItemDiscountPercentage = false;
        public static bool isSalesReturn = false;

        public static bool isPrinter80mm = true
            ;
        public static bool isSizeWiseGroup = false;
        public static bool isSubTotal = false;
        public static bool isStaffWiseSaleCom = false;
        public static bool isInvoiceWiseSaleCom = false;

        public static bool isAskPrintMessage = true;
        public static bool isLoyaltyActivated = false;
        public static bool isShowPrevesDue = true;
        public static bool isShowPrevesDueIntoSaleForm = true;

        public static bool isInvoiceDiscountActivated = true;
        public static bool isMinPriceBarcode = false;
        public static bool isReorderLevelCheck = false;

        public static bool isPreveItemSaleAmount = true;

        public static bool isOnOff = true;
        public static bool isFullPaper = true;
        public static bool isPrivewOpen = true;
        public static bool isBrcodeDisplay = true;
        public static bool onlyItemSearch = false;

        public static bool isMultifilBranch = false;
        public static bool LineDiscountShow = true;
        public static string invoiceBranchDumyCode = "I";
        public static bool isMainBarnch = false;
        public static string invoiceBranchCode;

        public static bool FirstItemFistShow = false;


        public static bool isShowGrossAmount = false;
        public static bool isPaymentFormOpenWhenAddButtonClick = false;
        public static bool isTotalLineDiscountPrint = true;

        // public static string ConnectionString = @"server=145.14.152.51;user id=u913025093_mul;database=u913025093_mul;password='Mul@1107';default command timeout=1000";
        //central_point //mul_system_online_check
        public static string ConnectionString = @"server=127.0.0.1;user id=root;database=ideagen;default command timeout=1000";
    }
}
