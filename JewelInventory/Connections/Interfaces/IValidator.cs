using System;
using System.Collections.Generic;

namespace Connections
{
	public interface IValidator
	{
		void AddValidationError(String key, String value);
		
        Dictionary<String, String> AllErrors { get; }
		int ErrorCount { get; }
		bool IsValid { get; }
	}
}
