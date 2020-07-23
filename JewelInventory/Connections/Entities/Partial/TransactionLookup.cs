using System;

namespace Connections
{
    public partial class TransactionLookup
    {
        public override string ToString()
        {
            var memo = MemoNumber ??
                       String.Format(String.Format(Constants.TRANFORMAT, TransactionDate), TransactionLookupId);

            return memo;
        }

        public string ReferenceMemoNumber { get; set; }
    }
}