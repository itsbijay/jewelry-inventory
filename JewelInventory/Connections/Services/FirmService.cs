// -----------------------------------------------------------------------
// <copyright file="FirmService.cs" company="JetCoders Solutions">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Connections
{
    using System;
    using System.Linq;

    /// <summary>
    /// Firm master service.
    /// </summary>
    public class FirmService : ServiceBase, IFirmService
    {
        public FirmMaster GetFrimMaster()
        {
            return DbContext.FirmMasters.Any() ? DbContext.FirmMasters.Single() : new FirmMaster();
        }

        public FirmResponse SaveFirm(FirmMasterRequest addFirmRequest)
        {
            var addFirmResponse = new FirmResponse();
            var firmMaster = addFirmRequest.FirmMaster;

            if (firmMaster.FirmMasterId == 0)
            {
                if (DbContext.FirmMasters.Any(fm => fm.FirmName == firmMaster.FirmName))
                    addFirmResponse.AddValidationError("FirmName", "Firm name already exists!");

                if (DbContext.FirmMasters.Any(fm => fm.FirmEmail == firmMaster.FirmEmail))
                    addFirmResponse.AddValidationError("FirmEmail", "Firm email already exists!");
            }

            if (addFirmResponse.IsValid == false)
                return addFirmResponse;

            firmMaster.AccessedBy = LocalStore.CurrentUser.UserId;
            firmMaster.AccessedDate = DateTime.Now;

            if (firmMaster.FirmMasterId == 0)
                DbContext.FirmMasters.AddObject(firmMaster);
            else
            {
                var firm = DbContext.FirmMasters.First();

                firm.FirmAdditionalInfo = firmMaster.FirmAdditionalInfo;
                firm.FirmAddress = firmMaster.FirmAddress;
                firm.FirmEmail = firmMaster.FirmEmail;
                firm.FirmTopHeader = firmMaster.FirmTopHeader;
                firm.FirmHeader = firmMaster.FirmHeader;
                firm.FirmLogo = firmMaster.FirmLogo;
                firm.FirmMasterId = firmMaster.FirmMasterId;
                firm.FirmName = firmMaster.FirmName;
                firm.FirmWebsite = firmMaster.FirmWebsite;
                firm.FirmTINNumber = firmMaster.FirmTINNumber;
                firm.FirmVATNumber = firmMaster.FirmVATNumber;
                firm.Tax = firmMaster.Tax;
                firm.OtherTax = firmMaster.OtherTax;
                DbContext.SaveChanges();
                return addFirmResponse;
            }

            // Save firm
            DbContext.SaveChanges();

            return addFirmResponse;
        }
    }
}
