
using System.IO;

namespace JetCoders.Forms.UI
{
	using System;
	using System.Reflection;

    public static class JewelHelper
	{
		#region Assembly Attribute Accessors

		public static string AssemblyTitle
		{
			get
			{
				object[] attributes = Assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					var titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "")
					{
						return titleAttribute.Title;
					}
				}
				return Path.GetFileNameWithoutExtension(Assembly.CodeBase);
			}
		}

		public static string AssemblyVersion
		{
			get
			{
				return Assembly.GetName().Version.ToString();
			}
		}

		public static string AssemblyDescription
		{
			get
			{
				object[] attributes = Assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				if (attributes.Length == 0)
				{
					return String.Empty;
				}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public static string AssemblyProduct
		{
			get
			{
				object[] attributes = Assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if (attributes.Length == 0)
				{
					return String.Empty;
				}
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public static string AssemblyCopyright
		{
			get
			{
				object[] attributes = Assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (attributes.Length == 0)
				{
					return String.Empty;
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public static string AssemblyCompany
		{
			get
			{
				object[] attributes = Assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				if (attributes.Length == 0)
				{
					return String.Empty;
				}
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}

		public static Assembly Assembly
		{
			get 
			{
				return Assembly.GetExecutingAssembly();
			}
		}
		#endregion
    }
}
