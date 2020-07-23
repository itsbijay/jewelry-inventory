using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace JetCoders.Forms.UI.Input
{
	/// <summary>
	/// Summary description for AutoCompleteTriggerCollection.
	/// </summary>
	[Serializable]
	public class AutoCompleteTriggerCollection : CollectionBase
	{

		public class AutoCompleteTriggerCollectionEditor : CollectionEditor
		{
			public AutoCompleteTriggerCollectionEditor(Type type) : base(type)
			{
			}

			protected override bool CanSelectMultipleInstances()
			{
				return false;
			}

			protected override Type[] CreateNewItemTypes()
			{
				return new[] {typeof(ShortCutTrigger), typeof(TextLengthTrigger)};
			}

			protected override Type CreateCollectionItemType()
			{
				return typeof(ShortCutTrigger);
			}
		}

		public AutoCompleteTrigger this[int index]
		{
			get
			{
				return InnerList[index] as AutoCompleteTrigger;
			}
		}

		public void Add(AutoCompleteTrigger item)
		{
			InnerList.Add(item);
		}

		public void Remove(AutoCompleteTrigger item)
		{
			InnerList.Remove(item);
		}

		public virtual TriggerState OnTextChanged(string text)
		{
		    return (from AutoCompleteTrigger trigger in InnerList select trigger.OnTextChanged(text)).FirstOrDefault(state => state != TriggerState.None);
		}

	    public virtual TriggerState OnCommandKey(Keys keyData)
	    {
	        return (from AutoCompleteTrigger trigger in InnerList select trigger.OnCommandKey(keyData)).FirstOrDefault(state => state != TriggerState.None);
	    }
	}
}
