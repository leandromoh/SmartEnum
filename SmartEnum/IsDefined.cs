using System;
using System.Linq;

namespace SmartEnum
{
    public static partial class EnumExtensions
    {
        public static bool IsDefined(this Enum e)
        {
            return Enum.IsDefined(e.GetType(), e);
        }
    }
}
