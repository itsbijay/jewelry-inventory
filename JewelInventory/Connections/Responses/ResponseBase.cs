namespace Connections
{
	using System;
	using System.Collections.Generic;

    public class ResponseBase : IValidator
	{
		private Dictionary<String, String> _errors { get; set; }


		public ResponseBase()
		{
			_errors = new Dictionary<String, String>();
		}

		#region IValidator

		public int ErrorCount { get { return _errors.Count; } }

		public virtual Dictionary<String, String> AllErrors { get { return _errors; } }

		public virtual void AddValidationError(String key, String value)
		{
			_errors.Add(key, value);
		}

		public virtual bool IsValid
		{
			get
			{
				return (_errors.Count == 0);
			}
		}
		#endregion
	}
}
