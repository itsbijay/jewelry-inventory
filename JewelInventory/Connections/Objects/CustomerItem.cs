// -----------------------------------------------------------------------
// <copyright file="CustomerItems.cs" company="JetCoders Solutions">
// </copyright>
// -----------------------------------------------------------------------

namespace Connections
{
	/// <summary>
	/// Retrives Customers in Code/Name pair.
	/// </summary>
	public class CustomerItem
	{
	    public string CustomerCode;
		public string ContactName;

		public override string ToString()
		{
			return ContactName;
		}
	}
}
