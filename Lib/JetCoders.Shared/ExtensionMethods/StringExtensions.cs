using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace JetCoders.Shared
{
	/// <summary>
	/// Represents extensions to String types.
	/// </summary>
	public static class StringExtensions
	{

		/// <summary>
		/// Returns true if the entity is empty. Can be used safely on null values of String.
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static bool IsEmpty(this String text)
		{
			return string.IsNullOrEmpty(text) || text.Trim().Length == 0;
		}

        public static bool IsDecimal(this String text)
        {
            decimal d;
            return Decimal.TryParse(text, out d);
        }

        public static bool IsNumber(this String text)
        {
            int d;
            return int.TryParse(text, out d);
        }

		/// <summary>
		/// Returns the string's value, or String.Empty if the value is null (guarantees a non-null result).
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static String ToStringOrNull(this String text)
		{
		    if (String.IsNullOrEmpty(text))
				return String.Empty;
		    return text;
		}

	    /// <summary>
		/// Overwritten method that combines the string array into a single string.
		/// </summary>
		/// <param name="array"></param>
		/// <param name="delimiter"></param>
		/// <returns></returns>
		public static String ToString(this String[] array, String delimiter)
		{
			if (array != null && array.Length > 0)
			{
				return String.Join(delimiter, array);
			}

			return String.Empty;
		}

		/// <summary>
		/// Takes a concatenated string and split is via Pascal case into a string with spaces.  For example with enums,
		/// it would split "UserAcceptedMessage" and return a string with "User Accepted Message".
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static String SplitToProperName(this String value)
		{
			var sb = new StringBuilder();
			sb.Append(value.Substring(0, 1));
			foreach (var c in value.Substring(1))
			{
				if (c == c.ToString(CultureInfo.InvariantCulture).ToUpper()[0])
					sb.Append(" ");

				sb.Append(c);
			}

			return sb.ToString();
		}

		#region html related

		private static readonly Regex HtmlRegex = new Regex("<[^>]+>|\\&nbsp\\;", RegexOptions.IgnoreCase | RegexOptions.Compiled);
		private static readonly Regex Spacer = new Regex(@"\s{2,}", RegexOptions.Compiled);
		private static readonly Regex IsWhitespace = new Regex("[^\\w&;#]", RegexOptions.Singleline | RegexOptions.Compiled);

		/// <summary>
		/// Scrubs a string to a safe and clean url.
		/// </summary>
		/// <param name="stringToParse"></param>
		/// <returns></returns>
		public static String ToSafeUrl(this String stringToParse)
		{
			String safeUrl = String.Empty;

			if (false == String.IsNullOrEmpty(stringToParse))
			{
				var regex = new Regex("[^a-zA-Z0-9 ]");

				safeUrl = regex.Replace(stringToParse, "");
				safeUrl = safeUrl.Trim();
				safeUrl = safeUrl.Replace(" ", "-");

				while (safeUrl.IndexOf("--", StringComparison.Ordinal) != -1) //remove double -
				{
					safeUrl = safeUrl.Replace("--", "-");
				}
			}
			return safeUrl.ToLowerInvariant();
		}

		public static string RemoveHtml(this String html)
		{
			return RemoveHtml(html, 0);
		}


		public static string RemoveHtml(this String html, int charLimit)
		{
			if (string.IsNullOrEmpty(html))
				return html;

			string nonhtml = Spacer.Replace(HtmlRegex.Replace(html, " ").Trim(), " ");
			if (charLimit <= 0 || charLimit >= nonhtml.Length)
				return nonhtml;
		    return nonhtml.TrimLength(charLimit);
		}

		/// <summary>
		/// Limits the lenght of a string and accounts for white spaces
		/// </summary>
		public static String TrimLength(this String text, int charLimit)
		{
			if (String.IsNullOrEmpty(text))
				return string.Empty;

			if (charLimit >= text.Length)
				return text;

			Match match = IsWhitespace.Match(text, charLimit);
			if (false == match.Success)
			{
				return text;
			}
		    return text.Substring(0, match.Index);
		}

		#region Strip Tags

	    /// <summary>
	    /// Extension used to strip all Html and Xml tags from a string.
	    /// </summary>
	    /// <returns></returns>
	    public static string StripHtmlXmlTags(this string content)
		{
			return content.StripHtmlXmlTags(false);
		}

	    /// <summary>
	    /// Extension used to strip all Html and Xml tags from a string. Will also replace p and br for newlines.
	    /// </summary>
	    /// <returns></returns>
	    public static string StripHtmlXmlTags(this string content, bool insertNewLine)
		{
	        if (insertNewLine)
			{
				content = Regex.Replace(content, "</p(?:\\s*)>(?:\\s*)<p(?:\\s*)>", "\n\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
				content = Regex.Replace(content, "<br(?:\\s*)/>", "\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
				content = Regex.Replace(content, "\"", "''", RegexOptions.IgnoreCase | RegexOptions.Compiled);
				return Regex.Replace(content, "<[^>]+>", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
			}
		    return Regex.Replace(content, "<[^>]+>", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
		}

	    /// <summary>
	    /// Extension used to ensure we don't inject script into the db.
	    /// </summary>
	    /// <returns>Clean text with no script tags.</returns>
	    public static string StripScriptTags(this string content)
		{
		    // Perform RegEx
			content = Regex.Replace(content, "<script((.|\n)*?)</script>", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			string cleanText = Regex.Replace(content, "\"javascript:", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);

			return cleanText;
		}
		#endregion

		#endregion
	}

	public static class ObjectExtensions
	{
		public static String ToStringOrNull(this Object o)
		{
			if (o == null) return null;

			return o.ToString();
		}
	}
}
