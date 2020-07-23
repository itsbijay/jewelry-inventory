namespace Connections
{
    public partial class Address
    {
        public override string ToString()
        {
            return AddressLine1 + ", " + AddressLine2 + " " + City + ", " + State + ", " + PostalCode;
        }
    }
}