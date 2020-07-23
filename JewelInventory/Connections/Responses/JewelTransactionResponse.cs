namespace Connections
{
    public class JewelTransactionResponse : ResponseBase
    {
        public JewelTransactionResponse()
        {
            TransactionLookup = new TransactionLookup();
        }
        public TransactionLookup TransactionLookup { get; set; }
    }
}
