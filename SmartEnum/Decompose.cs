using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartEnum
{
    public static partial class EnumExtensions
    {
        public static IEnumerable<TEnum> Decompose<TEnum>(this TEnum e)
            where TEnum : struct
        {
            var type = typeof(TEnum);
            if (!type.IsEnum) throw new ArgumentException("T must be an Enum");

            var val = e as Enum;

            return EnumToDictionary(type)
                  .Where(x => val.HasFlag(x.Key))
                  .Select(x => (TEnum)Convert.ChangeType(x.Key, type));
        }
    }
}
