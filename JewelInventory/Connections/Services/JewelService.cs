using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;

namespace Connections
{
    public class JewelService : ServiceBase, IJewelService
    {
        public IQueryable<JewelMaster> GetJewelMaster()
        {
            return DbContext.JewelMasters;
        }

        public JewelResponse CreateJewelMaster(JewelMasterRequest addJewelRequest)
        {
            var addJewelResponse = new JewelResponse();
            var jewelMaster = addJewelRequest.JewelMaster;
            var next = 0;

            if (jewelMaster.JewelId == 0)
            {
                if (DbContext.JewelMasters.Any(jm => jm.JewelNo == jewelMaster.JewelNo))
                    addJewelResponse.AddValidationError("JewelNo", "Jewel No. already exists!");

                if (DbContext.JewelMasters.Any(jm => jm.StyleNo == jewelMaster.StyleNo))
                    addJewelResponse.AddValidationError("JewelNo", "Style No. already exists!");

                if (DbContext.JewelMasters.Count() != 0)
                {
                    next = DbContext.JewelMasters.Max(x => x.JewelId);
                }

                ++next;

                jewelMaster.JewelNo = String.Concat(Constants.JEWELMASTERPREFIX, next);
            }

            if (addJewelResponse.IsValid == false)
                return addJewelResponse;

            jewelMaster.AccessedBy = LocalStore.CurrentUser.UserId;
            jewelMaster.AccessedDate = DateTime.Now;

            if (jewelMaster.JewelId == 0)
                DbContext.JewelMasters.AddObject(jewelMaster);

            // Save Jewel
            DbContext.SaveChanges();

            return addJewelResponse;
        }

        public JewelMaster GetJewelsByJewelNo(string JewelNo)
        {
            return DbContext.JewelMasters.SingleOrDefault(jn => jn.JewelNo == JewelNo);
        }

        public JewelMaster GetJewelsByStyleNo(string StyleNo)
        {
            return DbContext.JewelMasters.SingleOrDefault(jn => jn.StyleNo == StyleNo);
        }

        public IList<string> GetJewelDescription()
        {
            return DbContext.JewelMasters.Select(x => x.JewelDescription).Distinct().ToList();
        }

        public IList<JewelMaster> GetAllCatalogueJewels()
        {
            var list = DbContext.JewelMasters.ToList();
            return list;
        }

        public IList<JewelMaster> GetCatalogueJewels(double FromJewel, double ToJewel, string JewelDesc, string SelectedWeight)
        {
            List<JewelMaster> list;

            switch (SelectedWeight)
            {
                case "DiamondPcs":

                    list = (from metal in DbContext.JewelMasters
                            where metal.DiamondPcs >= (decimal)FromJewel && metal.DiamondPcs <= (decimal)ToJewel && metal.JewelDescription == JewelDesc
                            select metal).ToList<JewelMaster>();
                    break;
                case "DiamondWt":
                    list = (from metal in DbContext.JewelMasters
                            where metal.DiamondWt >= (decimal)FromJewel && metal.DiamondWt <= (decimal)ToJewel && metal.JewelDescription == JewelDesc
                            select metal).ToList<JewelMaster>();
                    break;
                case "GrsWt":
                    list = (from metal in DbContext.JewelMasters
                            where metal.GrsWt >= (decimal)FromJewel && metal.GrsWt <= (decimal)ToJewel && metal.JewelDescription == JewelDesc
                            select metal).ToList<JewelMaster>();
                    break;
                case "NetWt":
                    list = (from metal in DbContext.JewelMasters
                            where metal.NetWt >= (decimal)FromJewel && metal.NetWt <= (decimal)ToJewel && metal.JewelDescription == JewelDesc
                            select metal).ToList<JewelMaster>();

                    break;
                default:
                    list = (from metal in DbContext.JewelMasters
                            where metal.DiamondPcs >= (decimal)FromJewel && metal.DiamondPcs <= (decimal)ToJewel && metal.JewelDescription == JewelDesc
                            select metal).ToList<JewelMaster>();
                    break;
            }

            return list;
        }

        public IList<JewelMaster> GetCatalogueJewels(List<Tuple<decimal, decimal, string>> filter)
        {
            Func<List<Tuple<Decimal, Decimal, String>>, String> ExtractFilteredQuery = x =>
            {
                var yeppyList = x.Select(yeppy => String.Concat(yeppy.Item3, " BETWEEN ", yeppy.Item1, " AND ", yeppy.Item2));
                var dynamicString = String.Join(" AND ", yeppyList);

                return dynamicString;
            };

            var list = ((ObjectContext)DbContext).ExecuteStoreQuery<JewelMaster>("SELECT * FROM JewelMasters WHERE " + ExtractFilteredQuery(filter));

            return list.ToList();
        }
    }
}
