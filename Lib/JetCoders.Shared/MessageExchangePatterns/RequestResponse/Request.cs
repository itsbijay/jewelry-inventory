using System;
using System.Runtime.Serialization;

namespace JetCoders.Shared
{
	/// <summary>
	/// Represents an abstracted Response class.
	/// </summary>
	[DataContract]
	public abstract class Request
	{
		/// <summary>
		/// Constructs a new Request object.
		/// </summary>
		protected Request()
		{
			RequestId = Guid.NewGuid();
		}

		/// <summary>
		/// Unique ID for the message.
		/// </summary>
		[DataMember(IsRequired = false)]
		public Guid RequestId { get; set; }
	}
}
