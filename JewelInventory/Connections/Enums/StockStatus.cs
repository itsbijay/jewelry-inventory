using System.ComponentModel;

namespace Connections
{
    public enum StockStatus { NotSet = 0, [Description("In Stock")] ItemIsInStock = 366, [Description("In Memo")] ItemLockedInStock = 367, [Description("Out Of Stock")] ItemOutOfStock = 368, [Description("Cancelled Stock")] CancelledStock = 369 }
}