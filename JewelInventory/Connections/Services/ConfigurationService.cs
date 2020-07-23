using System;
using System.Collections.Generic;
using System.Linq;

namespace Connections
{
    public class ConfigurationService : ServiceBase, IConfigurationService
    {
        public ConfigurationMasterResponse SaveConfiguration(ConfigMasterRequest request)
        {
            var response = new ConfigurationMasterResponse();

            var configurationMaster = request.ConfigurationMaster;

            var isProductCategoryExists = DbContext.ConfigurationMasters.Any(cm => cm.ProductCategory_Enum == configurationMaster.ProductCategory_Enum);
            var isConfigurationValueExists = DbContext.ConfigurationMasters.Any(cm => cm.ConfigurationValue == configurationMaster.ConfigurationValue);
            var isParticaularExists = DbContext.ConfigurationMasters.Any(cm => cm.Particulars == configurationMaster.Particulars);

            if (configurationMaster.ConfigurationId == 0)
            {
                if (isProductCategoryExists)
                    response.AddValidationError("ProductCategory", "Product category already exists!");

                if (isConfigurationValueExists)
                    response.AddValidationError("ConfigurationValue", "Configuration value already exists!");

                if (isParticaularExists)
                    response.AddValidationError("Particulars", "Particulars already exists!");
            }
            else
            {
                var originalValue = GetOriginalRecord(configurationMaster);

                if (configurationMaster.ProductCategory_Enum != (short)originalValue["ProductCategory_Enum"] && isProductCategoryExists)
                    response.AddValidationError("ProductCategory", "Product category already exists!");

                if (configurationMaster.ConfigurationValue != (string)originalValue["ConfigurationValue"] && isConfigurationValueExists)
                    response.AddValidationError("ConfigurationValue", "Configuration value already exists!");

                if (configurationMaster.Particulars != (string)originalValue["Particulars"] && isParticaularExists)
                    response.AddValidationError("Particulars", "Particulars already exists!");
            }

            if (response.IsValid == false)
                return response;

            configurationMaster.AccessedBy = LocalStore.CurrentUser.UserId;
            configurationMaster.AccessedDate = DateTime.Now;

            if (configurationMaster.ConfigurationId == 0)
                DbContext.ConfigurationMasters.AddObject(configurationMaster);

            //Save Configurations
            DbContext.SaveChanges();
            return response;
        }

        public IQueryable<ConfigurationMaster> GetAllConfigurations(bool ReturnActiveOnly = true)
        {
            return DbContext.ConfigurationMasters.Where(x => x.Active == ReturnActiveOnly || x.Active);
        }

        public List<ConfigurationMaster> GetAllConfigurations(JewelItemCategory type)
        {
            return DbContext.ConfigurationMasters.Where(x => x.JewelItemCategory_Enum == (short)type && x.Active).ToList();
        }

        public FinancialYearResponse CreateFinancialYear(FinancialYearRequest request)
        {
            var financialYearResponse = new FinancialYearResponse();
            var finYear = request.FinancialYearMaster;

            finYear.AccessedBy = LocalStore.CurrentUser.UserId;
            finYear.AccessedDate = DateTime.Now;

            if (finYear.FinancialYearMasterId == 0)
            {
                if ((finYear.DateFrom.AddYears(1).AddDays(-1) == finYear.DateTo) == false)
                    financialYearResponse.AddValidationError("InvalidFinancialYearRange", "Invalid Financial Year Selection");

                if (finYear.FinancialYearMasterId == 0)
                    if (GetAllFinancialYears().Any(x => String.Compare(x.YearCode, finYear.YearCode, StringComparison.OrdinalIgnoreCase) == 0))
                        financialYearResponse.AddValidationError("YearCodeDuplication", "Financial year is already defined in the system !");

                var isExists = GetAllFinancialYears().Any(x => (finYear.DateFrom > x.DateFrom && finYear.DateFrom < x.DateTo) || (finYear.DateTo > x.DateFrom && finYear.DateTo <= x.DateTo) || x.YearCode == finYear.YearCode);

                if (isExists)
                    financialYearResponse.AddValidationError("FinancialYearConflict", "Financial year definition is conflicting with other Financial year !");

                if (financialYearResponse.IsValid == false)
                    return financialYearResponse;

                DbContext.FinancialYearMasters.AddObject(finYear);
            }

            //Save Configurations
            DbContext.SaveChanges();
            return financialYearResponse;
        }

        public IQueryable<FinancialYearMaster> GetAllFinancialYears()
        {
            return DbContext.FinancialYearMasters.Where(x => x.IsCancelled == false);
        }

        public String GetFinancialYearCode(DateTime date)
        {
            var finCode = GetAllFinancialYears().SingleOrDefault(x => x.IsActive && (x.DateFrom <= date && x.DateTo >= date));
            return finCode == null ? String.Empty : finCode.YearCode;
        }

        public String GetCurrentFinancialYearCode
        {
            get
            {
                var finCode = GetAllFinancialYears().SingleOrDefault(x => x.IsActive && (x.DateFrom <= DateTime.Today && x.DateTo >= DateTime.Today));
                return finCode == null ? String.Empty : finCode.YearCode;
            }
        }

        public List<String> LooseDiamondType()
        {
            return DbContext.ConfigurationMasters.Where(x => x.ProductCategory_Enum == (short)ProductCategory.Stone)
                    .Distinct().Select(x => x.Particulars).ToList();
        }
    }
}
