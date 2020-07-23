using System;
using System.Xml.Linq;

namespace JetCoders.Shared
{
	/// <summary>
	/// Represents extensions to the XElement type.
	/// </summary>
	public static class XElementExtensions
	{
		/// <summary>
		/// Deserializes an xElement to the known type of T.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="xElement"></param>
		/// <returns></returns>
		public static T Deserialize<T>(this XElement xElement) where T : class
		{
			return DataContractHelper.Deserialize<T>(xElement);
		}

	    /// <summary>
	    /// Serializes xml to an XElement.
	    /// </summary>
	    /// <typeparam name="T"></typeparam>
	    /// <returns></returns>
	    public static XElement Serialize<T>(this T objectToSerialize) where T : class
		{
			return DataContractHelper.Serialize(objectToSerialize);
		}

		public static XElement Serialize(this Object objectToSerialize, Type type)
		{
			return DataContractHelper.Serialize(objectToSerialize, type);
		}
	}
}
