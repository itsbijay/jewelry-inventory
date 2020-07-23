namespace Connections
{
    public partial class Customer
    {
        public override string ToString()
        {
            return CompanyName + " - " + CustomersCode;
        }
    }
}