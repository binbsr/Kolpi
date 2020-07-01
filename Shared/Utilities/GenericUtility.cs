using System.Collections.Generic;

namespace Kolpi.Shared.Utilities
{
    public class GenericUtility
    {
        public static bool Compare<T>(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }
    }
}
