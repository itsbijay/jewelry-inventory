using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace JetCoders.Shared
{
	public static class DataContractHelper
	{

		public static T Deserialize<T>(String xml) where T : class
		{
			if (false == xml.IsEmpty())
			{
				var xElement = XElement.Parse(xml);
				return Deserialize<T>(xElement);
			}
			return Activator.CreateInstance<T>();
		}

		public static T Deserialize<T>(XElement xElement) where T : class
		{
			if (xElement != null)
			{
				using (var reader = xElement.CreateReader())
				{
					var serializer = new DataContractSerializer(typeof(T));
					return serializer.ReadObject(reader, true) as T;
				}
			}
			return Activator.CreateInstance<T>();
		}

		public static XElement Serialize<T>(T item) where T : class
		{
			return Serialize(item, typeof(T));
		}

		public static XElement Serialize(object item, Type type)
		{
			object objectToSerialize = Activator.CreateInstance(type);
			if (item != null)
				objectToSerialize = item;

			using (var stream = new MemoryStream())
			{
				var serializer = new DataContractSerializer(type);
				serializer.WriteObject(stream, objectToSerialize);
				var xml = Encoding.UTF8.GetString(stream.GetBuffer());
				return XElement.Parse(xml.TrimEnd('\0'));
			}
		}

		public static string SerializeToXml<T>(T item) where T : class
		{
			var serializer = new DataContractSerializer(item.GetType());

			using (var backing = new StringWriter())
			using (var writer = new XmlTextWriter(backing))
			{
				serializer.WriteObject(writer, item);
				return backing.ToString();
			}
		}
	}

    public static class ObjectCopier
    {
        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(source, null))
            {
                return default(T);
            }

           
            using (var stream = new MemoryStream())
            {
                using (stream)
                { 
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, source);
                    stream.Seek(0, SeekOrigin.Begin);
                    return (T)formatter.Deserialize(stream);
                }
            }
        }
    }
}
