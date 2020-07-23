using System;
using System.Configuration;
using System.Xml;

namespace Connections
{
	public class WinSettingProvider : IWinSettingProvider
	{
	    private static String GetConfigValue(String key)
		{
			var value = ConfigurationManager.AppSettings[key] ?? String.Empty;
	        return value;
		}

		public String SqlConnectionString
		{
			get { return GetConfigValue(Constants.SQLCONNECTIONSTRING); }
		}

        public String ExcelDirectory
        {
            get { return GetConfigValue(Constants.EXCELDIRECTORY); }
        }

		public String ImageDirectory
		{
			get { return GetConfigValue(Constants.IMAGEDIRECTORY); }
		}

        public bool StockUploadManulMode
        {
            get { return Convert.ToBoolean(GetConfigValue(Constants.STOCKUPLOADMANULMODE)); }
        }

		public int UpdateAppSettings(string sectionName, string keyName, string keyValue)
		{
			var xmlDoc = new XmlDocument();
			xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
			var hasNode = false;
		    if (xmlDoc.DocumentElement != null)
		        foreach (XmlElement xElement in xmlDoc.DocumentElement)
		        {
		            if (xElement.Name != sectionName) continue;
		            foreach (XmlNode xNode in xElement.ChildNodes)
		            {
		                if (xNode.Attributes[0].Value == keyName)
		                {
		                    xNode.Attributes[1].Value = keyValue;
		                    hasNode = true;
		                }
		            }
		        }

		    if (hasNode == false)
			{
				var serverConnection = xmlDoc.SelectSingleNode(@"/configuration/" + sectionName);
				var node = xmlDoc.CreateNode(XmlNodeType.Element, "add", null);
				var key = xmlDoc.CreateAttribute("key");
				key.Value = keyName;
				var value = xmlDoc.CreateAttribute("value");
				value.Value = keyValue;
			    if (node.Attributes != null)
			    {
			        node.Attributes.Append(key);
			        node.Attributes.Append(value);
			    }
			    if (serverConnection != null) serverConnection.AppendChild(node);
			}

			xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
			return 1;
		}
	}
}
