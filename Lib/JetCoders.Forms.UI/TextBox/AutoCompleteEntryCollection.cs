using System;
using System.Collections;
using System.ComponentModel.Design;

namespace JetCoders.Forms.UI.Input
{
	/// <summary>
	/// Summary description for AutoCompleteDictionary.
	/// </summary>
	[Serializable]
	public class AutoCompleteEntryCollection : CollectionBase
	{
		public class AutoCompleteEntryCollectionEditor : CollectionEditor
		{
			public AutoCompleteEntryCollectionEditor(Type type) : base(type)
			{
			}

			protected override bool CanSelectMultipleInstances()
			{
				return false;
			}

			protected override Type CreateCollectionItemType()
			{
				return typeof(AutoCompleteEntry);
			}
		}

		public IAutoCompleteEntry this[int index]
		{
			get
			{
				return InnerList[index] as AutoCompleteEntry;
			}
		}

		public void Add(IAutoCompleteEntry entry)
		{
			InnerList.Add(entry);
		}

		public void AddRange(ICollection col)
		{
			InnerList.AddRange(col);
		}

		public void Add(AutoCompleteEntry entry)
		{
			InnerList.Add(entry);
		}

		public object[] ToObjectArray()
		{
			return InnerList.ToArray();
		}
		
	}
}
