namespace Connections
{
    public interface IFirmService
    {
        FirmMaster GetFrimMaster();
        FirmResponse SaveFirm(FirmMasterRequest addFirmRequest);
    }
}