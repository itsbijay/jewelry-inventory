using System;
using System.Linq;

namespace Connections
{
    /// <summary>
    /// Loose Diamonds Service
    /// </summary>
    public class LooseDiamondService : ServiceBase, ILooseDiamondService
    {
        public IQueryable<LooseDiamondTransaction> GetLooseDiamonds()
        {
            return DbContext.LooseDiamondTransactions;
        }

        public LooseDiamondResponse CreateLooseDiamond(LooseDiamondRequest addLooseDiamondRequest)
        {
            var addLooseDiamondResponse = new LooseDiamondResponse();
            var looseDiamond = addLooseDiamondRequest.LooseDiamond;
            var next = 0;

            if (looseDiamond.LooseDiamondTransactionId == 0)
            {
                if (DbContext.LooseDiamondTransactions.Count() != 0)
                {
                    next = DbContext.LooseDiamondTransactions.Max(ld => ld.LooseDiamondTransactionId);
                }

                ++next;
            }

            if (addLooseDiamondResponse.IsValid == false)
                return addLooseDiamondResponse;

            looseDiamond.AccessedBy = LocalStore.CurrentUser.UserId;
            looseDiamond.AccessedDate = DateTime.Now;

            if (looseDiamond.LooseDiamondTransactionId == 0)
                DbContext.LooseDiamondTransactions.AddObject(looseDiamond);

            // Save Diamond
            DbContext.SaveChanges();

            return addLooseDiamondResponse;
        }

        public LooseDiamondTransaction GetDiamondByDiamondCode(int diamondId)
        {
            return DbContext.LooseDiamondTransactions.FirstOrDefault(ld => ld.LooseDiamondTransactionId == diamondId);
        }
    }
}
