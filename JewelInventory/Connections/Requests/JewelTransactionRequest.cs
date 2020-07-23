namespace Connections
{
	public class JewelTransactionRequest : RequestBase
	{
		public JewelTransactionRequest()
		{
			TransactionLookup = new TransactionLookup();
		}

        public TransactionLookup TransactionLookup { get; set; }
	}
}
