// -----------------------------------------------------------------------
// <copyright file="TaxInvoiceDetails.cs" company="JetCoders Solutions">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Connections
{
    using System.Collections.Generic;
	using System.Runtime.Serialization;

	/// <summary>
	/// Tax	Invoice	Details.
	/// </summary>
	[DataContract]
	public class TaxInvoiceDetails
	{
		public TaxInvoiceDetails()
		{
			Items = new List<ItemDetail>();

		}

		[DataMember]
		public List<ItemDetail> Items { get; set; }
	}
}
