using System;
using System.Collections.Generic;
using System.Linq;

namespace Connections
{
    public interface IConfigurationService
    {
        ConfigurationMasterResponse SaveConfiguration(ConfigMasterRequest request);
        IQueryable<ConfigurationMaster> GetAllConfigurations(bool ReturnActiveOnly = true);
        List<ConfigurationMaster> GetAllConfigurations(JewelItemCategory type);
        String GetCurrentFinancialYearCode { get; }
        FinancialYearResponse CreateFinancialYear(FinancialYearRequest request);
        IQueryable<FinancialYearMaster> GetAllFinancialYears();
        String GetFinancialYearCode(DateTime date);
        List<String> LooseDiamondType();
    }
}