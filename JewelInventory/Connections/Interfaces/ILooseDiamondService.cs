using System.Linq;

namespace Connections
{
    public interface ILooseDiamondService
    {
        IQueryable<LooseDiamondTransaction> GetLooseDiamonds();
        LooseDiamondResponse CreateLooseDiamond(LooseDiamondRequest addLooseDiamondRequest);
        LooseDiamondTransaction GetDiamondByDiamondCode(int diamondId);
    }
}