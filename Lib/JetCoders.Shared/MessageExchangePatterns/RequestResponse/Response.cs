using System;
using System.Runtime.Serialization;


namespace JetCoders.Shared
{
	/// <summary>
	/// Represents an abstracted Response class.
	/// </summary>
	[DataContract]
	public abstract class Response 
	{
	    /// <summary>
		/// Gets or sets the unique ID of the message being replied to.
		/// </summary>
		[DataMember(IsRequired = false)]
		public Guid RequestId { get; set; }

	}
}
