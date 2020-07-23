using System;
using System.Collections.Generic;
using System.Linq;

namespace Connections
{
    public interface IJewelService
    {
        IQueryable<JewelMaster> GetJewelMaster();
        JewelResponse CreateJewelMaster(JewelMasterRequest addJewelRequest);
        JewelMaster GetJewelsByJewelNo(string JewelNo);
        JewelMaster GetJewelsByStyleNo(string StyleNo);
        IList<string> GetJewelDescription();
        IList<JewelMaster> GetAllCatalogueJewels();
        IList<JewelMaster> GetCatalogueJewels(double FromJewel, double ToJewel, string JewelDesc, string SelectedWeight);
        IList<JewelMaster> GetCatalogueJewels(List<Tuple<decimal, decimal, string>> filter);
    }
}