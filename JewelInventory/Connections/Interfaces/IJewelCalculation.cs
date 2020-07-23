using System.Collections.Generic;
using Connections.Services;

namespace Connections
{
    public interface IJewelCalculation
    {
        CalculateResponse Calculate(CostingRates costingRates, IList<JewelTransaction> jewelTrans);
    }
}