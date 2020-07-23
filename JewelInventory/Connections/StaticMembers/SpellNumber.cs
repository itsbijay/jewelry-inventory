using Spell;
using System;

namespace Connections
{
    public static class SpellNumber
    {
        public static string SpellInWord(this Decimal amount)
        {
            return amount > 0.0M ? SpellAmount.InWrods(amount).Replace("Taka", string.Empty) : string.Empty;
        }
    }
}
