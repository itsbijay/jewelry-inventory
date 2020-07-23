using System;

namespace JetCoders.Forms.UI.Input
{
	/// <summary>
	/// Summary description for AutoCompleteDictionaryEntry.
	/// </summary>
	[Serializable]
	public class AutoCompleteEntry : IAutoCompleteEntry
	{

		private string[] matchStrings;
		public string[] MatchStrings
		{
			get { return matchStrings ?? (matchStrings = new[] {DisplayName}); }
		}

		private string displayName = string.Empty;
		public string DisplayName
		{
			get
			{
				return displayName;
			}
			set
			{
				displayName = value;
			}
		}

		public AutoCompleteEntry()
		{
		}

		public AutoCompleteEntry(string name, params string[] matchList)
		{
			displayName = name;
			matchStrings = matchList;
		}

		public override string ToString()
		{
			return DisplayName;
		}

	}
}
