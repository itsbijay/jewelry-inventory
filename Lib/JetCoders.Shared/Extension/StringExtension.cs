using System;

namespace JetCoders.Shared
{
    public static class StringExtension
    {
        public static String ToLowerCaseColumnName(this String name)
        {
            return name.ToLowerInvariant().Replace(" ", String.Empty).Replace(".", String.Empty).Replace("_", String.Empty);
        }
    }
}
