using System.ComponentModel;

namespace Connections
{
    public enum TransactionType 
    {   
        [Description("ALL")]
        NotSet = 0,
        [Description("Purchase Transaction")]
        PurchaseTransaction = 855,
        [Description("Approval Transaction")]
        ApprovalTransaction = 856,
        [Description("Marketing Transaction")]
        MarketingTransaction = 857,
        [Description("Marketing Return Transaction")]
        MarketingInReturnTransaction = 858,
        [Description("Cancelled Transaction")]
        CancelledTransaction = 859,
        [Description("Approval Return Transaction")]
        ApprovalInReturnTransaction = 860,
        [Description("Sales Transaction")]
        SalesInTransaction = 861,
        [Description("Sales Return Transaction")]
        SalesInReturnTransaction = 862 
    }
}