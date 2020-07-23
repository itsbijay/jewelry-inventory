// -----------------------------------------------------------------------
// <copyright file="DataSetContainer.cs" company="JetCoders Solutions">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Connections
{
	using System.Data;

	/// <summary>
	/// Dataset for Report.
	/// </summary>
	public class DataSetContainer
	{
		/// <summary>
		/// Report Dataset.
		/// </summary>
		public DataSet ReportDataSet { get; set; }

		/// <summary>
		/// Report file path.
		/// </summary>
		public string ReportPath { get; set; }

	    //public ParameterFields ParameterFields { get; set; }
	}
}
