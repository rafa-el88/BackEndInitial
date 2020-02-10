using System;

namespace PositivoCore.Shared.Helper
{
    public static class HelperGuid
    {
        public static bool IsGuid(string value)
        {
            return Guid.TryParse(value, out Guid x);
        }
    }
}
