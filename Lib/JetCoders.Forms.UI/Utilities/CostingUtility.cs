using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Connections;
using JetCoders.Shared;

namespace JetCoders.Forms.UI
{
	public static class CostingUtility
	{
		public static void CreateCostingRates(this DataGridView grid, out List<CostingDetails> configCollection)
		{
			configCollection = new List<CostingDetails>();

			foreach (var row in grid.Rows)
			{
				var item = (row as DataGridViewRow);

				if (item == null) return;

				if (item.Cells[3].Value != null && item.Cells[3].Value.ToString().IsEmpty() == false)
				{
					var config = new CostingDetails
						{
							Particulars = item.Cells[1].Value.ToString(),
							ConfigurationValue = item.Cells[2].Value.ToString(),
							Amount = Decimal.Parse(item.Cells[3].Value.ToString())
						};

					if (grid.Name == "dgGoldCostingRates")
						config.ProductCategory = ProductCategory.Metal;

					if (grid.Name == "dgDiamondCostingRates")
					{
						var cell = item.Cells[1].Value;
                        if ((string)cell == ColorStones.CSReal || (string)cell == ColorStones.CSSemiPrecious || (string)cell == ColorStones.CubicZirconia)
						{
							config.ProductCategory = ProductCategory.ColorStone;
						}
						else
						{
							config.ProductCategory = ProductCategory.Stone;
						}
					}

					if (grid.Name == "dgLabourCostingRates")
					{
                        if (item.Cells[4].Value == null)
                            item.Cells[4].Value = "0.00";

						if (item.Cells[4].Value.ToString().IsEmpty())
							continue;

						config.ProductCategory = ProductCategory.Labour;
						config.MinimumAmount = Decimal.Parse(item.Cells[4].Value.ToString());
					}

					configCollection.Add(config);
				}
			}
		}

		public static void CreateSupplierCostingRates(this DataGridView grid, out List<CostingDetails> configCollection)
		{
			configCollection = new List<CostingDetails>();

			foreach (var row in grid.Rows)
			{
				var item = (row as DataGridViewRow);

				if (item == null) return;

				if (item.Cells[3].Value != null && item.Cells[3].Value.ToString().IsEmpty() == false)
				{
					var config = new CostingDetails
						{
							Particulars = item.Cells[1].Value.ToString(),
							ConfigurationValue = item.Cells[2].Value.ToString(),
							Amount = Decimal.Parse(item.Cells[3].Value.ToString())
						};

					if (grid.Name == "dgGoldCostingRates")
						config.ProductCategory = ProductCategory.Metal;

					if (grid.Name == "dgDiamondCostingRates")
						config.ProductCategory = ProductCategory.Stone;

					if (grid.Name == "dgLabourCostingRates")
					{
						if (item.Cells[4].Value == null)
							continue;

						if (item.Cells[4].Value.ToString().IsEmpty())
							continue;

						config.ProductCategory = ProductCategory.Labour;
						config.MinimumAmount = Decimal.Parse(item.Cells[4].Value.ToString());
					}

					configCollection.Add(config);
				}
			}
		}

		public static void CreateCertificateRate(this DataGridView grid, out CertificateRates certRatesCollection)
		{
			certRatesCollection = new CertificateRates();

			foreach (var row in grid.Rows)
			{
				var item = (row as DataGridViewRow);
				if (item == null) return;

                if (item.Cells[3].Value != null && item.Cells[3].Value.ToString().IsEmpty() == false && Decimal.Parse(item.Cells[3].Value.ToString()) > 0.0M)
                {
                    decimal fromValue, toValue;
                    Decimal.TryParse(item.Cells[1].Value.ToString(), out fromValue);
                    Decimal.TryParse(item.Cells[2].Value.ToString(), out toValue);

                    if (fromValue >= toValue)
                        break;

                    var config = new CertificateRates.CertificateRatesItems();
                    {
                        config.RangeMinValue = fromValue;
                        config.RangeMaxValue = toValue;
                        config.Amount = Decimal.Parse(item.Cells[3].Value.ToString());
                    }

                    certRatesCollection.Items.Add(config);
                }
                else
                    break;
			}
		}

		public static bool ValidateDependentProperties(this DataGridViewRow row, params String[] dependantColoumHeaderNames)
		{
			bool IsValid = true;
			var list = dependantColoumHeaderNames.ToList();

			if (list.Count <= 0)
				return false;

			foreach (var item in list)
			{
				if (row.Cells[item.ToLowerCaseColumnName()].Value == null)
				{
					IsValid = false;
					break;
				}

				if (row.Cells[item.ToLowerCaseColumnName()].Value != null && row.Cells[item.ToLowerCaseColumnName()].Value.ToString().IsEmpty())
				{
					IsValid = false;
					break;
				}

				if (row.Cells[item.ToLowerCaseColumnName()].ReadOnly)
				{
					if (row.Cells[item.ToLowerCaseColumnName()].Value.ToString() == "0")
					{
						IsValid = false;
						break;
					}
				}
			}

			return IsValid;
		}

		public static String GetCellValue(this DataGridViewRow row, String ColoumHeaderNames, bool AllowDefault = false)
		{
			String returnVal = String.Empty;

			if (row.ValidateDependentProperties(ColoumHeaderNames.ToLowerCaseColumnName()))
				returnVal = row.Cells[ColoumHeaderNames.ToLowerCaseColumnName()].Value.ToString();

			if (AllowDefault)
				returnVal = row.Cells[ColoumHeaderNames.ToLowerCaseColumnName()].Value.ToString();

			return returnVal;
		}

        public static T GetParsedCellValue<T>(this DataGridViewRow row, String ColoumHeaderNames, T defaultValue = default(T))
        {
            var returnVal = row.ValidateDependentProperties(ColoumHeaderNames.ToLowerCaseColumnName()) ? row.Cells[ColoumHeaderNames.ToLowerCaseColumnName()].Value : defaultValue;

            return (T)Convert.ChangeType(returnVal, typeof(T));
        }

	    public static Int32 GetColumnIndex(this DataGridView grid, String ColoumHeaderNames)
		{
		    var dataGridViewColumn = grid.Columns[ColoumHeaderNames.ToLowerCaseColumnName()];
		    return dataGridViewColumn != null ? dataGridViewColumn.Index : 0;
		}
	}
}
