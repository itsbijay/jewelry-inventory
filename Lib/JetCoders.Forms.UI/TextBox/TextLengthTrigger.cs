using System;

namespace JetCoders.Forms.UI.Input
{
	/// <summary>
	/// Summary description for TextLengthTrigger.
	/// </summary>
	[Serializable]
	public class TextLengthTrigger : AutoCompleteTrigger
	{
		private int textLength = 2;
		public int TextLength
		{
			get
			{
				return textLength;
			}
			set
			{
				textLength = value;
			}
		}

		public TextLengthTrigger()
		{
		}

		public TextLengthTrigger(int length)
		{
			textLength = length;
		}

		public override TriggerState OnTextChanged(string text)
		{
		    return text.Length >= TextLength
		        ? TriggerState.Show
		        : (text.Length < TextLength ? TriggerState.Hide : TriggerState.None);
		}
	}
}
