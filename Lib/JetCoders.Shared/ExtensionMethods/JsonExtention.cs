using System;

namespace JetCoders.Shared
{
	public static class JsonExtensions
	{
		//var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

		public static void Serialize(Object source)
		{
		    source.Serialize();
		}
	}
}