using System;

namespace Connections
{
    public interface IWinSettingProvider
    {
        int UpdateAppSettings(string sectionName, string keyName, string keyValue);
        bool StockUploadManulMode { get; }
        String SqlConnectionString { get; }
        String ExcelDirectory { get; }
        String ImageDirectory { get; }
    }
}